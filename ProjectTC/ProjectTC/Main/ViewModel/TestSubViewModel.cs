using Framework;
using Microsoft.Win32;
using Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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

        #region Property

        private ObservableCollection<UserMenuItemModel> testSubList;
        public ObservableCollection<UserMenuItemModel> TestSubList
        {
            get
            {
                if (testSubList == null)
                {
                    testSubList = new ObservableCollection<UserMenuItemModel>();
                }

                return testSubList;
            }
            set
            {
                testSubList = value;
                OnPropertyChanged("TestSubList");
            }
        }

        private TestSubModel selectedTestSubItem;
        public TestSubModel SelectedTestSubItem
        {
            get
            {
                return selectedTestSubItem;
            }
            set
            {
                selectedTestSubItem = value;
                OnPropertyChanged("SelectedTestSubItem");
            }
        }

        #endregion

        #region Command

        /// <summary>
        /// 첨부파일
        /// </summary>
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

        /// <summary>
        /// ListView LeftClick
        /// </summary>
        private DelegateCommand<object> mouseLeftButtonUpCommand;
        public DelegateCommand<object> MouseLeftButtonUpCommand
        {
            get
            {
                if (mouseLeftButtonUpCommand == null)
                    mouseLeftButtonUpCommand = new DelegateCommand<object>(MouseLeftButtonUpCommandInteraction);
                return mouseLeftButtonUpCommand;
            }
            set { mouseLeftButtonUpCommand = value; }
        }

        private void MouseLeftButtonUpCommandInteraction(object obj)
        {
            if (obj == null)
                return;

            UserMenuItemModel model = obj as UserMenuItemModel;


        }

        #endregion

    }
}
