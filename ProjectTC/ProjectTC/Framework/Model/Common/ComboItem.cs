using Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework
{
    public class ComboStringItem : BindableBase
    {
        public ComboStringItem(string _displayString, string _valuesString)
        {
            DisplayString = _displayString;
            ValuesString = _valuesString;
        }

        private string displayString = string.Empty;
        public string DisplayString
        {
            get
            {
                return displayString;
            }
            set
            {
                displayString = value;
                OnPropertyChanged("DisplayString");
            }
        }

        private string valuesString = string.Empty;
        public string ValuesString
        {
            get
            {
                return valuesString;
            }
            set
            {
                valuesString = value;
                OnPropertyChanged("ValuesString");
            }
        }
    }


    public class ComboIntItem : BindableBase
    {
        public ComboIntItem(string _StringDisplay, int _IntValue)
        {
            DisplayString = _StringDisplay;
            IntValue = _IntValue;
        }

        private string displayString = string.Empty;
        public string DisplayString
        {
            get
            {
                return displayString;
            }
            set
            {
                displayString = value;
                OnPropertyChanged("DisplayString");
            }
        }

        private int m_IntValue = -1;
        public int IntValue
        {
            get
            {
                return m_IntValue;
            }
            set
            {
                m_IntValue = value;
                OnPropertyChanged("IntValue");
            }
        }
    }
}
