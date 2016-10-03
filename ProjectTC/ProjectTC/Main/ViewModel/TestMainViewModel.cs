using Framework;
using Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ProjectTC
{
    public class TestMainViewModel : AViewModel
    {
        #region interface

        public override void SetViewInfo()
        {
            this.ViewId = "TestMain";
        }

        public override void Initialized()
        {
            DicItems = MemPreference.Get<ADOConnection>().InitMenuList();
            MenuList = new ObservableCollection<UserMenuModel>(DicItems.Keys);

            if(MenuList.Count > 0)
                SelectedMenu = MenuList.FirstOrDefault();
        }

        public override void Subscribe(object source)
        {
             
        }
        #endregion

        #region Preperty

        /// <summary>
        /// 메뉴Item
        /// </summary>
        private IDictionary<UserMenuModel, IList<UserMenuModel>> dicItems;
        public IDictionary<UserMenuModel, IList<UserMenuModel>> DicItems
        {
            get
            {
                if (dicItems == null)
                {
                    dicItems = new Dictionary<UserMenuModel, IList<UserMenuModel>>();
                }
                return dicItems;
            }
            set
            {
                dicItems = value;
            }
        }

        #region Menu Control

        private ObservableCollection<UserMenuModel> menuList;
        public ObservableCollection<UserMenuModel> MenuList
        {
            get
            {
                if (menuList == null)
                {
                    menuList = new ObservableCollection<UserMenuModel>();
                }
                return menuList;
            }
            set
            {
                menuList = value;
                OnPropertyChanged("MenuList");
            }
        }

        private UserMenuModel selectedMenu;
        public UserMenuModel SelectedMenu
        {
            get
            {
                return selectedMenu;
            }
            set
            {
                selectedMenu = value;

                Refresh();

                OnPropertyChanged("SelectedMenu");
            }
        }

        private int selectedMenuIndex = 0;
        public int SelectedMenuIndex
        {
            get
            {

                return selectedMenuIndex;
            }
            set
            {
                selectedMenuIndex = value;
                OnPropertyChanged("SelectedMenuIndex");
            }
        }

        

        #endregion

        #region Tab Control

        private ObservableCollection<TestSubModel> tabTestList;
        public ObservableCollection<TestSubModel> TabTestList
        {
            get
            {
                if (tabTestList == null)
                {
                    tabTestList = new ObservableCollection<TestSubModel>();
                }
                return tabTestList;
            }
            set
            {
                tabTestList = value;
                OnPropertyChanged("TabTestList");
            }
        }

        private TestSubModel selectedTabTest;
        public TestSubModel SelectedTabTest
        {
            get
            {
                return selectedTabTest;
            }
            set
            {
                selectedTabTest = value;
                OnPropertyChanged("SelectedTabTest");
            }
        }

        private int selectedTabIndex = 0;
        public int SelectedTabIndex
        {
            get
            {
                return selectedTabIndex;
            }
            set
            {
                selectedTabIndex = value;
                OnPropertyChanged("SelectedTabIndex");
            }
        }

        #endregion

        #endregion

        #region Command

       

        #endregion

        #region Method

        private void Refresh()
        {
            TabTestList.Clear();

            if (DicItems.ContainsKey(selectedMenu) == true)
            {
                var items = DicItems.Where(p => p.Key == selectedMenu).FirstOrDefault();
                if (items.Value != null)
                {
                    foreach (var item in items.Value)
                    {
                        TabTestList.Add(new TestSubModel(item.TestName, new TestSubView()));
                    }

                    if (TabTestList.Count > 0)
                        SelectedTabTest = TabTestList.FirstOrDefault();
                }
            }
        }

        #endregion
    }
}
