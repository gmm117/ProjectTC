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

        // 선택된 메뉴프로젝트명
        private string projectName;
        public string ProjectName
        {
            get
            {
                return projectName;
            }
            set
            {
                projectName = value;
                OnPropertyChanged("ProjectName");
            }
        }

        // 테스트명
        private string testName;
        public string TestName
        {
            get
            {
                return testName;
            }
            set
            {
                testName = value;
                OnPropertyChanged("TestName");
            }
        }

        // 테스트총합
        private int testTotCnt;
        public int TestTotCnt
        {
            get
            {
                return testTotCnt;
            }
            set
            {
                testTotCnt = value;
                OnPropertyChanged("TestTotCnt");
            }
        }

        // 테스트 총완료건수
        private int testYesCnt;
        public int TestYesCnt
        {
            get
            {
                return testYesCnt;
            }
            set
            {
                testYesCnt = value;
                OnPropertyChanged("TestYesCnt");
            }
        }

        // 테스트 총 미완료건수
        private int testNoCnt;
        public int TestNoCnt
        {
            get
            {
                return testNoCnt;
            }
            set
            {
                testNoCnt = value;
                OnPropertyChanged("TestNoCnt");
            }
        }

        // 결과 총 성공건수
        private int resultYesCnt;
        public int ResultYesCnt
        {
            get
            {
                return resultYesCnt;
            }
            set
            {
                resultYesCnt = value;
                OnPropertyChanged("ResultYesCnt");
            }
        }

        // 결과 총 실패건수
        private int resultNoCnt;
        public int ResultNoCnt
        {
            get
            {
                return resultNoCnt;
            }
            set
            {
                resultNoCnt = value;
                OnPropertyChanged("ResultNoCnt");
            }
        }

        // 결과 총 Block건수
        private int resultBlockCnt;
        public int ResultBlockCnt
        {
            get
            {
                return resultBlockCnt;
            }
            set
            {
                resultBlockCnt = value;
                OnPropertyChanged("ResultBlockCnt");
            }
        }
    }
}
