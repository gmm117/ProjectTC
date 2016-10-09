using AutoMapper;
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
            InitializeMapper();
            
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
                OnPropertyChanged("SelectedMenu");

                Refresh();

                
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

        private void InitializeMapper()
        {
            Mapper.CreateMap<UserMenuItemADO, UserMenuItemModel>()
                .ForMember(to => to.Priority, opt => opt.MapFrom(from => from.Priority == 1 ? Resx.ProjectTCResx.High : from.Priority == 2 ? Resx.ProjectTCResx.Middle : Resx.ProjectTCResx.Bottom))
                .ForMember(to => to.Status, opt => opt.MapFrom(from => from.Status == 1 ? Resx.ProjectTCResx.Pass : from.Priority == 2 ? Resx.ProjectTCResx.Fail : Resx.ProjectTCResx.Block));
        }

        private void Refresh()
        {
            try
            {
                TabTestList.Clear();

                if (DicItems.ContainsKey(selectedMenu) == true)
                {
                    var items = DicItems.Where(p => p.Key == selectedMenu).FirstOrDefault();
                    if (items.Value != null)
                    {
                        foreach (var item in items.Value)
                        {
                            var subItem = MemPreference.Get<ADOConnection>().GetMenuItemList(item.MenuId);
                            if (subItem.Count <= 0)
                                continue;

                            var subModel = new TestSubModel(item.TestName, new TestSubView());
                            subModel.TabContentView.VM.TestSubList = new ObservableCollection<UserMenuItemModel>(subItem.Select(Mapper.Map<UserMenuItemADO, UserMenuItemModel>).ToList());
                            foreach (var subItem1 in subModel.TabContentView.VM.TestSubList)
                            {
                                subItem1.SelectedStatus = subItem1.ComboStatusList.Where(p => p.DisplayString == subItem1.Status).FirstOrDefault();
                                subItem1.SelectedPriority = subItem1.ComboPriorityList.Where(p => p.DisplayString == subItem1.Priority).FirstOrDefault();
                            }

                            TabTestList.Add(subModel);
                        }

                        if (TabTestList.Count > 0)
                            SelectedTabTest = TabTestList.FirstOrDefault();
                    }
                }
            }
            catch(Exception ex)
            {
                throw ex;
            }
            
        }

        #endregion
    }
}
