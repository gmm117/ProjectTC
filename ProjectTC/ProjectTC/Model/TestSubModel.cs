using Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectTC
{
    public class TestSubModel : BindableBase
    {
        public TestSubModel(string _tabHeader, TestSubView _view)
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
        public TestSubView tabContentView;
        public TestSubView TabContentView 
        { 
            get
            {
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
