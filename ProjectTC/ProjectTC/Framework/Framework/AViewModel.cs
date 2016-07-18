using Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;

namespace Framework
{
    public class AViewModel : BindableBase, IDisposable
    {
        public AViewModel()
        {
            Initialize();
        }

        #region variable

        /// <summary>
        /// 토큰
        /// </summary>
        public Guid Token = Guid.Empty;

        #endregion

        #region property

        /// <summary>
        /// 소속 뷰
        /// </summary>
        public string ViewId { get; set; }

        /// <summary>
        /// 표출 뷰 명
        /// </summary>
        public string ViewDisplayName { get; set; }

        #endregion


        #region command

        /// <summary>
        /// 윈도우 닫기
        /// </summary>
        public DelegateCommand<UserControl> CloseWindowCommand
        {
            get
            {
                if (m_closeWindowCommand == null)
                {
                    m_closeWindowCommand = new DelegateCommand<UserControl>(ExecuteCloseWindow);
                }
                return m_closeWindowCommand;
            }
        }
        private DelegateCommand<UserControl> m_closeWindowCommand;
        private void ExecuteCloseWindow(UserControl control)
        {
            Window.GetWindow(control).Close();
        }


        /// <summary>
        /// 컨텍스트 등록 커맨드
        /// </summary>
        public DelegateCommand<object> RegistrationCommand
        {
            get
            {
                if (m_registrationCommand == null)
                {
                    m_registrationCommand = new DelegateCommand<object>(Registration);
                }
                return m_registrationCommand;
            }
        }
        private DelegateCommand<object> m_registrationCommand;
        private void Registration(object instance)
        {
            // 토큰이 없을 경우 컨텍스트 관리 시작
            if (this.Token == Guid.Empty)
            {
                SetViewInfo();

                var item = ContextManager.Instance.ViewModelMap.Where(p => p.Value.ViewId == this.ViewId).FirstOrDefault();

                if (item.Key == Guid.Empty)
                {
                    ContextManager.Instance.RegistPubSub(this);
                }
                else
                {
                    this.Token = item.Key;
                    ContextManager.Instance.ViewModelMap[item.Key] = this;
                }

                Initialized();

                Console.Out.WriteLine(string.Format("ViewModel Registration -> [{0}] {1}:{2}", this.Token, this.ViewId, this.ViewDisplayName));

            }
        }

        #endregion

        #region method

        /// <summary>
        /// 컨텍스트 해제
        /// </summary>
        public void Unregistration()
        {
            if (this.Token != Guid.Empty)
            {
                ContextManager.Instance.UnregistPubSub(this);

                Released();

                Console.Out.WriteLineAsync(string.Format("Unregistration [{0}] {1}:{2}  --- Count:{3}", this.Token, this.ViewId, this.ViewDisplayName, ContextManager.Instance.Count()));
            }
        }

        /// <summary>
        /// 뷰 모델 컨텍스트 해제
        /// </summary>
        /// <param name="view"></param>
        public void Released(UserControl view)
        {
            if (view != null && view.DataContext != null)
            {
                var viewmodel = view.DataContext as AViewModel;
                if (viewmodel != null)
                {
                    viewmodel.Unregistration();
                }
            }
        }

        #endregion


       

        #region interface

        /// <summary>
        /// 뷰 모델 생성자에서 실행할 작업을 기술한다.
        /// </summary>
        public virtual void Initialize() { }

        /// <summary>
        /// Set view's identifier
        /// </summary>
        public virtual void SetViewInfo() { }

        /// <summary>
        /// 뷰 모델과 엮인 뷰가 로딩될 때 호출된다.
        /// </summary>
        public virtual void Initialized() { }

        /// <summary>
        /// 구독
        /// </summary>
        /// <param name="source"></param>
        public virtual void Subscribe(object source) { }

        /// <summary>
        /// 종료 시 실행됨
        /// </summary>
        public virtual void Released() { }

        #endregion


        #region IDisposable 관련 추가

        private bool isDisposed;

        public void Dispose()
        {
            this.Dispose(true);
            GC.SuppressFinalize(this);
        }

        private void Dispose(bool disposing)
        {
            if (!isDisposed)
            {
                if (disposing)
                {
                    //Managed
                    this.DisposeManaged();
                }

                //Unmanaged
                this.DisposeUnmanaged();

                isDisposed = true;
            }
        }

        /// <summary>
        /// 관리되는 자원을 해제한다. 
        /// ViewModelBase 클래스를 상속받는 ViewModel 클래스에서는 이 메소드를 상속 받아 사용한다.
        /// </summary>
        protected virtual void DisposeManaged()
        {

        }

        /// <summary>
        /// 비관리되는 자원을 해제한다.
        /// ViewModelBase 클래스를 상속받는 ViewModel 클래스에서는 이 메소드를 상속 받아 사용한다.
        /// </summary>
        protected virtual void DisposeUnmanaged()
        {

        }

        /// <summary>
        /// 소멸자
        /// </summary>
        ~AViewModel()
        {
            string msg = string.Format("{0} ({1}) Finalized", this.GetType().Name, this.GetHashCode());
            System.Diagnostics.Debug.WriteLine(msg);

            this.Dispose(false);

            Unregistration();
        }

        #endregion
    }
}
