using Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectTC
{
    public class TestResultViewModel : AViewModel
    {
        #region interface

        public override void SetViewInfo()
        {
            this.ViewId = "TestResult";
        }

        public override void Initialized()
        {

        }

        public override void Subscribe(object source)
        {

        }
        #endregion



    }
}
