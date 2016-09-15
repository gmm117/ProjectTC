using Framework;
using Mvvm;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace ProjectTC
{
    public class TestCaseWindowViewModel : AViewModel
    {
        public TestCaseWindowViewModel()
        {

        }

        #region interface

        public override void SetViewInfo()
        {
            this.ViewId = "TestCaseWindow";
        }

        public override void Initialized()
        {

        }

        public override void Subscribe(object source)
        {

        }
        #endregion

        #region Command
        private ICommand registrationCommand;
        public ICommand RegistrationCommand
        {
            get
            {
                if (registrationCommand == null)
                    registrationCommand = new DelegateCommand<object>(ExcuetRegistration);
                return registrationCommand;
            }
            set { registrationCommand = value; }
        }

        private void ExcuetRegistration(object param)
        {
            TestMainView view = new TestMainView();
            ChildrenView.Clear();
            ChildrenView.Add(view);
        }

        #endregion

        #region Property
        /// <summary>
        /// 자식 뷰
        /// </summary>
        private ObservableCollection<UIElement> childrenView;
        public ObservableCollection<UIElement> ChildrenView
        {
            get
            {
                if (childrenView == null)
                {
                    childrenView = new ObservableCollection<UIElement>();
                }
                return childrenView;
            }
            set
            {
                childrenView = value;
                OnPropertyChanged("ChildrenView");
            }
        }

        private WindowState currentWindowState = WindowState.Normal;
        public WindowState CurrentWindowState
        {
            get
            {
                return currentWindowState;
            }
            set
            {
                currentWindowState = value;
                OnPropertyChanged("CurrentWindowState");
            }
        }
        

        #endregion


        #region command

        /// <summary>
        /// 종료
        /// </summary>
        public DelegateCommand ProgramExitCommand
        {
            get
            {
                if (m_programExitCommand == null)
                {
                    m_programExitCommand = new DelegateCommand(ExecuteProgramExit);
                }
                return m_programExitCommand;
            }
        }
        private DelegateCommand m_programExitCommand;
        private void ExecuteProgramExit()
        {
            System.Windows.Application.Current.Shutdown();
        }

        /// <summary>
        /// 최소화
        /// </summary>
        public DelegateCommand MinimizeCommand
        {
            get
            {
                if (m_minimizeCommand == null)
                {
                    m_minimizeCommand = new DelegateCommand(ExecuteMinimize);
                }
                return m_minimizeCommand;
            }
        }
        private DelegateCommand m_minimizeCommand;
        private void ExecuteMinimize()
        {
            CurrentWindowState = System.Windows.WindowState.Minimized;
        }

        /// <summary>
        /// 최대화/복원 토글
        /// </summary>
        private DelegateCommand maxRestoreToggleCommand;
        public DelegateCommand MaxRestoreToggleCommand
        {
            get
            {
                if (maxRestoreToggleCommand == null)
                {
                    maxRestoreToggleCommand = new DelegateCommand(ToggleMaximize);
                }
                return maxRestoreToggleCommand;
            }
        }

        /// <summary>
        /// 최대창 - 복원 토글
        /// </summary>
        private void ToggleMaximize()
        {
            if (CurrentWindowState == System.Windows.WindowState.Maximized)
            {
                CurrentWindowState = System.Windows.WindowState.Normal;
            }
            else
            {
                CurrentWindowState = System.Windows.WindowState.Maximized;
            }
        }


        /// <summary>
        /// 최대화/복원 토글
        /// </summary>
        private DelegateCommand<MouseButtonEventArgs> doubleClickTitleCommand;
        public DelegateCommand<MouseButtonEventArgs> DoubleClickTitleCommand
        {
            get
            {
                if (doubleClickTitleCommand == null)
                {
                    doubleClickTitleCommand = new DelegateCommand<MouseButtonEventArgs>(ExecuteTitleDrag);
                }
                return doubleClickTitleCommand;
            }
        }
        
        private void ExecuteTitleDrag(MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left && e.ClickCount >= 2)
            {
                ToggleMaximize();
            }
        }

        #endregion
    }
}
