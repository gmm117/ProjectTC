using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework
{
    public class ContextManager
    {
        public static ContextManager Instance { get; private set; }

        /// <summary>
        /// 뷰 모델 맵
        /// </summary>
        public Dictionary<Guid, AViewModel> ViewModelMap;

        public ContextManager()
        {
            Instance = this;

            ViewModelMap = new Dictionary<Guid, AViewModel>();
        }

        /// <summary>
        /// 관리중인 컨텍스트 수
        /// </summary>
        /// <returns></returns>
        public int Count()
        {
            return ViewModelMap.Count;
        }

        /// <summary>
        /// 토큰을 발행한다.
        /// </summary>
        /// <param name="viewModel"></param>
        private void IssueToken(AViewModel viewModel)
        {
            while (viewModel.Token == Guid.Empty)
            {
                viewModel.Token = Guid.NewGuid();

                var a = ViewModelMap.SingleOrDefault(p => p.Key == viewModel.Token);
                if (a.Key == null || a.Key == Guid.Empty)
                {
                    break;
                }
                else
                {
                    viewModel.Token = Guid.Empty;
                }
            }
        }

        /// <summary>
        /// 뷰 모델을 PubSub 관리범위에 등록한다.
        /// </summary>
        /// <param name="viewModel"></param>
        public void RegistPubSub(AViewModel viewModel)
        {
            IssueToken(viewModel);

            if (false == ViewModelMap.ContainsKey(viewModel.Token))
            {
                ViewModelMap.Add(viewModel.Token, viewModel);
                Console.Out.WriteLineAsync(string.Format("++ Context Count : {0}", ViewModelMap.Count));
            }
        }

        /// <summary>
        /// 뷰 모델을 PubSub 관리범위에서 해제한다.
        /// </summary>
        /// <param name="viewModel"></param>
        public void UnregistPubSub(AViewModel viewModel)
        {
            ViewModelMap.Remove(viewModel.Token);
            viewModel.Token = Guid.Empty;

            Console.Out.WriteLineAsync(string.Format("-- Context Count : {0}", ViewModelMap.Count));
        }

        /// <summary>
        /// Sender는 제외하고 브로드캐스트한다.
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="source"></param>
        public void Publish(Guid token, object source)
        {
            foreach (AViewModel viewModel in ViewModelMap.Values)
            {
                if (viewModel.Token == token) continue;

                System.Windows.Application.Current.Dispatcher.BeginInvoke(System.Windows.Threading.DispatcherPriority.Normal, (Action)delegate()
                {
                    viewModel.Subscribe(source);
                });
            }
        }

        /// <summary>
        /// 특정 뷰 모델 컨텍스트만 추출한다.
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public IList<T> GetViewModels<T>() where T : AViewModel
        {
            var viewModels = new List<T>();
            var selectedViewModels = this.ViewModelMap.Values.Where(p => p is T);
            foreach (var vm in selectedViewModels)
            {
                viewModels.Add((T)vm);
            }
            return viewModels;
        }

    }
}
