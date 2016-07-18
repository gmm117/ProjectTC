using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Framework
{
    public abstract class APreference
    {
        #region variable

        private Dictionary<Type, object> m_container = new Dictionary<Type, object>();

        #endregion

        #region interface

        /// <summary>
        /// 초기화
        /// </summary>
        public abstract void Initialize();

        #endregion


        #region method

        public T GetValue<T>() where T : class
        {
            object value;
            if (m_container.TryGetValue(typeof(T), out value))
            {
                return (T)value;
            }
            else
            {
                return null;
            }
        }

        public void SetValue<T>(T value) where T : class
        {
            T item = GetValue<T>();
            if (item != null)
            {
                m_container.Remove(typeof(T));
            }
            m_container.Add(typeof(T), value);
        }

        #endregion
    }
}
