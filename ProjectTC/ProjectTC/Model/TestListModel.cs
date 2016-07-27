using Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectTC
{
    public class TestListModel : BindableBase
    {
        public TestListModel(string _tabHeader, TestListView _view)
        {
            TabHeader = _tabHeader;
            TabContentView = _view;
        }

        /// <summary>
        /// 탭컨트롤 헤더
        /// </summary>
        private string tabHeader = string.Empty;
        public string TabHeader
        { 
            get
            {
                return tabHeader;
            }
            set
            {
                tabHeader = value;
                OnPropertyChanged("TabHeader");
            }
        }

        /// <summary>
        /// 탭컨트롤 Content
        /// </summary>
        public TestListView tabContentView; 
        public TestListView TabContentView 
        { 
            get
            {
                if(tabContentView == null)
                    tabContentView = new TestListView();

                return tabContentView;
            }
            set
            {
                tabContentView = value;
                OnPropertyChanged("TabContentView");
            } 
        }
    }
}
