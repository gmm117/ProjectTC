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
        // 메뉴ID
        private string menuId;
        public string MenuId
        {
            get { return menuId; }
            set
            {
                menuId = value;
                OnPropertyChanged("MenuId");
            }
        }

        // 메뉴명
        private string menuName;
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

        // 부모MenuID
        private string parendMenuID;
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
    }
}
