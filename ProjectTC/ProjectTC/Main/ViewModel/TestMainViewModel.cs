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

            TabTestList.Add(new TestSubModel("건강보험", new TestSubView()));
            TabTestList.Add(new TestSubModel("의료보험", new TestSubView()));
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

        #endregion

    }
}
