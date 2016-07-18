using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework
{
    public class MemPreference : APreference
    {
        public MemPreference()
        {
            Instance = this;
            Initialize();
        }

        public static MemPreference Instance { get; set; }

        /// <summary>
        /// 초기화 작업
        /// </summary>
        public override void Initialize()
        {
            SetValue<ContextManager>(new ContextManager());

            SetValue<ADOConnection>(new ADOConnection());
        }

        #region static

        /// <summary>
        /// 요소 가져오기
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <returns></returns>
        public static T Get<T>() where T : class
        {
            return Instance.GetValue<T>();
        }

        /// <summary>
        /// 요소 추가하기
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="value"></param>
        public static void Set<T>(T value) where T : class
        {
            Instance.SetValue<T>(value);
        }

        #endregion
    }
}
