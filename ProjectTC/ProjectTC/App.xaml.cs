using Framework;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace ProjectTC
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        /// <summary>
        /// Preference 관리자
        /// </summary>
        public static MemPreference Mem { get; private set; }

        public App()
        {
            Mem = new MemPreference();
        }
    }
}
