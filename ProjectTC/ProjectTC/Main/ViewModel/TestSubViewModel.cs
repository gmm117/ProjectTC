using Framework;
using Microsoft.Win32;
using Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProjectTC
{
    public class TestSubViewModel : AViewModel
    {
        public TestSubViewModel()
        {

        }

        public override void SetViewInfo()
        {
            this.ViewId = "TestSubView";
        }

        #region Command


        private DelegateCommand attachFileTestCaseCommand;
        public DelegateCommand AttachFileTestCaseCommand
        {
            get
            {
                if (attachFileTestCaseCommand == null)
                    attachFileTestCaseCommand = new DelegateCommand(AttachFileTestCaseCommandInteraction);
                return attachFileTestCaseCommand;
            }
            set { attachFileTestCaseCommand = value; }
        }

        private void AttachFileTestCaseCommandInteraction()
        {
            OpenFileDialog dialog = new OpenFileDialog();
            dialog.Filter = "Image Files (*.jpg; *.jpeg; *.gif; *.bmp; *.png)|*.jpg;*.jpeg;*.gif;*.bmp;*.png";
            dialog.Multiselect = false;
            dialog.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.Desktop);
            dialog.ShowDialog();

        }

        #endregion

    }
}
