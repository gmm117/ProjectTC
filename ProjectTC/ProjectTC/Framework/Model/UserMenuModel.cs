using Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework
{
    public class UserMenuModel : BindableBase
    {
        /// <summary>
        /// 메뉴ID
        /// </summary>
        private string menuId = string.Empty;
        public string MenuId
        {
            get { return menuId; }
            set
            {
                menuId = value;
                OnPropertyChanged("MenuId");
            }
        }

        /// <summary>
        /// 메뉴명
        /// </summary>
        private string menuName = string.Empty;
        public string MenuName
        {
            get
            {
                return menuName;
            }
            set
            {
                menuName = value;
                OnPropertyChanged("MenuName");
            }
        }

        /// <summary>
        /// 부모MenuID
        /// </summary>
        private string parendMenuID = string.Empty;
        public string ParendMenuID
        {
            get
            {
                return parendMenuID;
            }
            set
            {
                parendMenuID = value;
                OnPropertyChanged("ParendMenuID");
            }

        }

        /// <summary>
        /// 선택된 메뉴프로젝트명
        /// </summary>
        private string projectName = string.Empty;
        public string ProjectName
        {
            get
            {
                return projectName;
            }
            set
            {
                projectName = value;
                OnPropertyChanged("ProjectName");
            }
        }

        /// <summary>
        /// 테스트명
        /// </summary>
        private string testName = string.Empty;
        public string TestName
        {
            get
            {
                return testName;
            }
            set
            {
                testName = value;
                OnPropertyChanged("TestName");
            }
        }

        /// <summary>
        /// 테스트총합
        /// </summary>
        private int testTotCnt = 0;
        public int TestTotCnt
        {
            get
            {
                return testTotCnt;
            }
            set
            {
                testTotCnt = value;
                OnPropertyChanged("TestTotCnt");
            }
        }

        /// <summary>
        /// 테스트 총완료건수
        /// </summary>
        private int testYesCnt = 0;
        public int TestYesCnt
        {
            get
            {
                return testYesCnt;
            }
            set
            {
                testYesCnt = value;
                OnPropertyChanged("TestYesCnt");
            }
        }

        /// <summary>
        /// 테스트 총 미완료건수
        /// </summary>
        private int testNoCnt = 0;
        public int TestNoCnt
        {
            get
            {
                return testNoCnt;
            }
            set
            {
                testNoCnt = value;
                OnPropertyChanged("TestNoCnt");
            }
        }

        /// <summary>
        /// 결과 총 성공건수
        /// </summary>
        private int resultYesCnt = 0;
        public int ResultYesCnt
        {
            get
            {
                return resultYesCnt;
            }
            set
            {
                resultYesCnt = value;
                OnPropertyChanged("ResultYesCnt");
            }
        }

        /// <summary>
        /// 결과 총 실패건수
        /// </summary>
        private int resultNoCnt = 0;
        public int ResultNoCnt
        {
            get
            {
                return resultNoCnt;
            }
            set
            {
                resultNoCnt = value;
                OnPropertyChanged("ResultNoCnt");
            }
        }

        /// <summary>
        /// 결과 총 Block건수
        /// </summary>
        private int resultBlockCnt = 0;
        public int ResultBlockCnt
        {
            get
            {
                return resultBlockCnt;
            }
            set
            {
                resultBlockCnt = value;
                OnPropertyChanged("ResultBlockCnt");
            }
        }
    }
}
