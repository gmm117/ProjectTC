using Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework
{
    public class UserMenuItemADO 
    {
        public UserMenuItemADO()
	    {

	    }

        #region Property

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
            }
        }

        /// <summary>
        /// 상태("P":Pass, "F": Fail, "B":Block)
        /// </summary>
        private string status = "B";
        public string Status
        {
            get { return status; }
            set
            {
                status = value;
            }
        }

        /// <summary>
        /// 우선순위(High:상, middle:중, bottom:하)
        /// </summary>
        private string priority = "B";
        public string Priority
        {
            get { return priority; }
            set
            {
                priority = value;
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
            }
        }

        #endregion
    }
}
