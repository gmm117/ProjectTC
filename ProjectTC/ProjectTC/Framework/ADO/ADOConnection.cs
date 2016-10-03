using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace Framework
{
    public class ADOConnection
    {
        public static ADOConnection Instance { get; private set; }

        public ADOConnection()
        {
            Initialize();
        }


        #region Propery

        // SQL Connection 
        private SqlConnection connection;
        private SqlConnection Connection
        {
            get
            {
                return connection;
            }
            set
            {
                connection = value;
            }
        }


        #endregion

        #region Inialize 

        public void Initialize()
        {
            CreateTestCaseDataBase();

            CreateTestCaseTable();

            InsertTestCaseData();
        }

        #region ADO Connection 연결

        // ADO Connection 연결
        private bool ConnetionDataBase(string DBOwner)
        {
            foreach(string p in PreDefine.ADOPass)
            {
                string ConnectionStr = string.Format(PreDefine.ConnectionStatement, DBOwner, WindowsIdentity.GetCurrent().Name.Split('\\')[0], "sa", p);

                try
                {
                    Connection = new SqlConnection(ConnectionStr);

                    Connection.Open();
                }
                catch(Exception ex)
                {
                   // MessageBox.Show(ex.ToString());
                    continue;
                }
                
                if (Connection.State == ConnectionState.Open)
                     return true;
            }


            if (Connection == null)
            {
                MessageBox.Show(Resx.FrameworkresxKO.NotADOConnection);
                return false;
            }

            return true;
        }

        #endregion

        #region DB 생성

        // 물리적 DB Path 여부
        private bool CheckDBPhyFile()
        {
            DirectoryInfo di = new DirectoryInfo(PreDefine.PhysicalPath);
            if (di.Exists == false)
                di.Create();

            return File.Exists(PreDefine.PhysicalMDFPath);
        }

        // 현재 TestCase DB가 없는경우 생성하는 함수
        private void CreateTestCaseDataBase()
        {
            try
            {
                if (!ConnetionDataBase("MASTER"))
                    return;

                bool IsExists = CheckDBPhyFile();
                string Query = string.Empty;

                if (IsExists == true)
                {
                    Query = string.Format(@"IF NOT EXISTS ( SELECT * FROM SYSDATABASES WHERE NAME = 'TestCase' ) 
                                            BEGIN 
                                            EXEC SP_ATTACH_DB 'StreetZip', '{0}', '{1}' 
                                            END ", PreDefine.PhysicalMDFPath, PreDefine.PhysicalLDFPath);
                }
                else
                {
                    Query = string.Format(@"IF NOT EXISTS ( SELECT * FROM SYSDATABASES WHERE NAME = 'TestCase' ) 
                                            BEGIN 
                                            CREATE DATABASE [TestCase] ON ( NAME =  N'TestCase_Data', FILENAME =  N'{0}', SIZE = 3 ) 
                                            LOG ON (NAME =  N'TestCase_Log', FILENAME =  N'{1}', SIZE = 1 ) 
                                            END ", PreDefine.PhysicalMDFPath, PreDefine.PhysicalLDFPath);
                }

                ExcuteSqlCommand(Query);
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        #endregion

        #region Table 생성

        private void InsertTestCaseData()
        {
            try
            {
                string[] UserMenuList = { "인적사항", "데스크", "예약", "수납", "전자차트", "보험차트", "보험청구", "EDI" };

                foreach(string item in UserMenuList)
                {
                    string Query = string.Empty;

                    Query = string.Format(@"IF NOT EXISTS (SELECT * FROM DBO.TC_USERMENU WHERE MenuName = '{0}')
                                           BEGIN 
                                            INSERT INTO DBO.TC_USERMENU VALUES (NEWID(), '{1}', 'Empty', '{2}', '', 0, 0, 0, 0, 0, 0) 
                                           END", item, item, item);
                    ExcuteSqlCommand(Query);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void CreateTestCaseTable()
        {
            try
            {
                string Query = string.Empty;

                if (!ConnetionDataBase("TestCase"))
                    return;

                Query = @"IF NOT EXISTS (SELECT * FROM DBO.SYSOBJECTS  WHERE  ID = OBJECT_ID(N'[DBO].[TC_USERMENU]') AND OBJECTPROPERTY(ID, N'ISUSERTABLE') = 1) 
                        BEGIN 
                        CREATE TABLE [dbo].[TC_USERMENU](
                            [MenuID] [varchar](36) NOT NULL,
	                        [MenuName] [varchar](100) NOT NULL,
	                        [ParentMenuID] [varchar](36) NOT NULL,
                            [ProjectName] [varchar](100) NULL,
	                        [TestName] [varchar](100) NULL,
	                        [TestTotCnt] int NULL,
	                        [TestYesCnt] int NULL,
	                        [TestNoCnt] int NULL,
	                        [ResultYesCnt] int NULL,
	                        [ResultNoCnt] int NULL,
	                        [ResultBlockedCnt] int NULL,
                        CONSTRAINT [PK_TC_USERMENU] PRIMARY KEY CLUSTERED
                        (
	                        [MenuID] ASC
                        ) ON [PRIMARY]
                        ) ON [PRIMARY]
                        END ";

                ExcuteSqlCommand(Query);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        #endregion

        #region 데이터로딩

        // SQL Command 실행
        public IDictionary<UserMenuModel, IList<UserMenuModel>> InitMenuList()
        {
            IDictionary<UserMenuModel, IList<UserMenuModel>> dic = new Dictionary<UserMenuModel, IList<UserMenuModel>>();
            IList<UserMenuModel> list = new List<UserMenuModel>();

            string Query = string.Empty;
            Query = @"SELECT * FROM [DBO].[TC_USERMENU]";

            Connection.Open();
            using (SqlCommand cmd = new SqlCommand(Query, Connection))
            {
                SqlDataReader read = cmd.ExecuteReader();

                while (read.Read())
                {
                    var item = new UserMenuModel();

                    PropertyInfo[] properties = item.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance);
                    int nIdx = 0;
                    foreach (PropertyInfo prop in properties)
                    {
                        PropertyInfo propertyInfo = item.GetType().GetProperty(prop.Name);
                        propertyInfo.SetValue(item, Convert.ChangeType(read[nIdx++].ToString(), propertyInfo.PropertyType), null);
                    }


                    list.Add(item);
                }

                var items = list.Where(p => p.ParendMenuID == "Empty");

                foreach(var p in items)
                {
                    dic.Add(p, new List<UserMenuModel>());

                    var items1 = list.Where(p1 => p1.ParendMenuID == p.MenuId);

                    foreach(var p2 in items1)
                    {
                        dic[p].Add(p2);
                    }
                }
            }

            return dic;
        }

        // SQL Command 실행
        public IList<UserMenuItemModel> GetMenuItemList(string MenuID)
        {
            IList<UserMenuItemModel> list = new List<UserMenuItemModel>();

            string Query = string.Empty;
            Query = string.Format(@"SELECT * FROM [DBO].[TC_USERMENU_ITEM] values = '{0}' ", MenuID);

            Connection.Open();
            using (SqlCommand cmd = new SqlCommand(Query, Connection))
            {
                SqlDataReader read = cmd.ExecuteReader();

                while (read.Read())
                {
                    var item = new UserMenuModel();

                    PropertyInfo[] properties = item.GetType().GetProperties(BindingFlags.Public | BindingFlags.Instance);
                    int nIdx = 0;
                    foreach (PropertyInfo prop in properties)
                    {
                        PropertyInfo propertyInfo = item.GetType().GetProperty(prop.Name);
                        propertyInfo.SetValue(item, Convert.ChangeType(read[nIdx++].ToString(), propertyInfo.PropertyType), null);
                    }


                    
                }
            }

            return list;
        }

        #endregion

        #endregion

        #region 공통사항

        // SQL Command 실행
        private void ExcuteSqlCommand(string Query)
        {
            if(Connection.State != ConnectionState.Open)
                Connection.Open();

            using (SqlCommand cmd = new SqlCommand(Query, Connection))
            {
                cmd.ExecuteNonQuery();
                Connection.Close();
            }
        }

        #endregion
    }
}

