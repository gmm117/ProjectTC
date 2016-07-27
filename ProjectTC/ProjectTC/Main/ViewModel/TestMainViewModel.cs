using Framework;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
            var items = MemPreference.Get<ADOConnection>().InitMenuList();

            foreach(var item in items)
            {
                MenuList.Add(item.Key);
            }

            TabTestList.Add(new TestListModel("건강보험", new TestListView()));
            TabTestList.Add(new TestListModel("의료보험", new TestListView()));
        }

        public override void Subscribe(object source)
        {
             
        }
        #endregion

        #region Preperty


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

        private ObservableCollection<TestListModel> tabTestList;
        public ObservableCollection<TestListModel> TabTestList
        {
            get
            {
                if (tabTestList == null)
                {
                    tabTestList = new ObservableCollection<TestListModel>();
                }
                return tabTestList;
            }
            set
            {
                tabTestList = value;
                OnPropertyChanged("TabTestList");
            }
        }

        #endregion

    }
}
