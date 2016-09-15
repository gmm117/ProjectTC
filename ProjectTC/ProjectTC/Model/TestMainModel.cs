using Framework;
using Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectTC
{
    public class TestMainModel : BindableBase
    {
        public TestMainModel()
        {

        }

        #region Property
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
                OnPropertyChanged("DicItems");
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
