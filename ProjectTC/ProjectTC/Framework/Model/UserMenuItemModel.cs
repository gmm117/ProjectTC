using Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework
{
    public class UserMenuItemModel : BindableBase
    {
        public UserMenuItemModel ()
	    {

	    }

        #region Property

        /// <summary>
        /// 선택여부
        /// </summary>
        private bool isCheck = false;
        public bool IsCheck
        {
            get { return isCheck; }
            set
            {
                isCheck = value;
                OnPropertyChanged("IsCheck");
            }
        }

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
        /// 순번
        /// </summary>
        private int seq = 0;
        public int Seq
        {
            get
            {
                return seq;
            }
            set 
            {
                seq = value;
                OnPropertyChanged("Seq");
            }
        }

        /// <summary>
        /// 단계1
        /// </summary>
        private string depth1 = string.Empty;
        public string Depth1
        {
            get { return depth1; }
            set
            {
                depth1 = value;
                OnPropertyChanged("Depth1");
            }
        }

        /// <summary>
        /// 단계2
        /// </summary>
        private string depth2 = string.Empty;
        public string Depth2
        {
            get { return depth2; }
            set
            {
                depth2 = value;
                OnPropertyChanged("Depth2");
            }
        }

        /// <summary>
        /// 단계3
        /// </summary>
        private string depth3 = string.Empty;
        public string Depth3
        {
            get { return depth3; }
            set
            {
                depth3 = value;
                OnPropertyChanged("Depth3");
            }
        }

        /// <summary>
        /// 단계4
        /// </summary>
        private string depth4 = string.Empty;
        public string Depth4
        {
            get { return depth4; }
            set
            {
                depth4 = value;
                OnPropertyChanged("Depth4");
            }
        }

        /// <summary>
        /// 이름
        /// </summary>
        private string title = string.Empty;
        public string Title
        {
            get { return title; }
            set
            {
                title = value;
                OnPropertyChanged("Title");
            }
        }

        /// <summary>
        /// 테스터
        /// </summary>
        private string tester = string.Empty;
        public string Tester
        {
            get { return tester; }
            set
            {
                tester = value;
                OnPropertyChanged("Tester");
            }
        }

        /// <summary>
        /// 테스트날짜
        /// </summary>
        private DateTime testDate = DateTime.Now;
        public DateTime TestDate
        {
            get { return testDate; }
            set
            {
                testDate = value;
                OnPropertyChanged("TestDate");
            }
        }

        /// <summary>
        /// 테스트걸린시간
        /// </summary>
        private int testTime = 0;
        public int TestTime
        {
            get { return testTime; }
            set
            {
                testTime = value;
                OnPropertyChanged("TestTime");
            }
        }

        /// <summary>
        /// 상태리스트("P":Pass, "F": Fail, "B":Block)
        /// </summary>
        private ObservableCollection<ComboIntItem> comboStatusList = new ObservableCollection<ComboIntItem>();
        public ObservableCollection<ComboIntItem> ComboStatusList
        {
            get
            {
                if (comboStatusList.Count == 0)
                {
                    comboStatusList.Add(new ComboIntItem("Pass", 1));
                    comboStatusList.Add(new ComboIntItem("Fail", 2));
                    comboStatusList.Add(new ComboIntItem("Block", 3));
                }

                return comboStatusList;
            }
            set
            {
                comboStatusList = value;
                OnPropertyChanged("ComboStatusList");
            }
        }

        /// <summary>
        /// 선택된 상태리스트("P":Pass, "F": Fail, "B":Block)
        /// </summary>
        private ComboIntItem selectedStatus;
        public ComboIntItem SelectedStatus
        {
            get
            {
                return selectedStatus;
            }
            set
            {
                selectedStatus = value;

                if (selectedStatus.DisplayString != StatusToString)
                    StatusToString = SelectedStatus.DisplayString;

                OnPropertyChanged("SelectedStatus");
            }
        }

        /// <summary>
        /// 상태("P"(1):Pass, "F"(2): Fail, "B"(3):Block)
        /// </summary>
        private string statusToString = "Block";
        public string StatusToString
        {
            get 
            {
                return statusToString; 
            }
            set
            {
                statusToString = value;
                OnPropertyChanged("StatusToString");
            }
        }

        /// <summary>
        /// 우선순위(High(1):상, middle(2):중, bottom(3):하)
        /// </summary>
        private ObservableCollection<ComboIntItem> comboPriorityList = new ObservableCollection<ComboIntItem>();
        public ObservableCollection<ComboIntItem> ComboPriorityList
        {
            get
            {
                if (comboPriorityList.Count == 0)
                {
                    comboPriorityList.Add(new ComboIntItem(Resx.FrameworkresxKO.High, 1));
                    comboPriorityList.Add(new ComboIntItem(Resx.FrameworkresxKO.Middle, 2));
                    comboPriorityList.Add(new ComboIntItem(Resx.FrameworkresxKO.Bottom, 3));
                }

                return comboPriorityList;
            }
            set
            {
                comboPriorityList = value;
                OnPropertyChanged("ComboPriorityList");
            }
        }

        /// <summary>
        /// 선택된 우선순위(High(1):상, middle(2):중, bottom(3):하)
        /// </summary>
        private ComboIntItem selectedPriority;
        public ComboIntItem SelectedPriority
        {
            get
            {
                return selectedPriority;
            }
            set
            {
                selectedPriority = value;

                if (selectedPriority.DisplayString != PriorityToString)
                    PriorityToString = selectedPriority.DisplayString;

                OnPropertyChanged("SelectedPriority");
            }
        }
        
        /// <summary>
        /// 우선순위(High(1):상, middle(3):중, bottom(2):하)
        /// </summary>
        private string priorityToString = Resx.FrameworkresxKO.Bottom;
        public string PriorityToString
        {
            get { return priorityToString; }
            set
            {
                priorityToString = value;
                OnPropertyChanged("PriorityToString");
            }
        }

        /// <summary>
        /// 버전
        /// </summary>
        private string version = string.Empty;
        public string Version
        {
            get { return version; }
            set
            {
                version = value;
                OnPropertyChanged("Version");
            }
        }

        /// <summary>
        /// 재현경로
        /// </summary>
        private string testStep = string.Empty;
        public string TestStep
        {
            get { return testStep; }
            set
            {
                testStep = value;
                OnPropertyChanged("TestStep");
            }
        }

        /// <summary>
        /// 현재버그
        /// </summary>
        private string curTest = string.Empty;
        public string CurTest
        {
            get { return curTest; }
            set
            {
                curTest = value;
                OnPropertyChanged("CurTest");
            }
        }

        /// <summary>
        /// 환경세팅
        /// </summary>
        private string preCondition = string.Empty;
        public string PreCondition
        {
            get { return preCondition; }
            set
            {
                preCondition = value;
                OnPropertyChanged("PreCondition");
            }
        }

        /// <summary>
        /// 기대효과
        /// </summary>
        private string expResult = string.Empty;
        public string ExpResult
        {
            get { return expResult; }
            set
            {
                expResult = value;
                OnPropertyChanged("ExpResult");
            }
        }

        #endregion
    }
}
