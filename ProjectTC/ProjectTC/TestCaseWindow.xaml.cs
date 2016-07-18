using Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace ProjectTC
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class TestCaseWindow : Window
    {
        public TestCaseWindow()
        {
            InitializeComponent();

            this.DataContext = new TestCaseWindowViewModel();

            resizer = new WindowResizer(this, this.grd_main, this.grd_draggable);
        }

        #region variable

        /// <summary>
        /// 윈도우 리사이져
        /// </summary>
        private WindowResizer resizer;

        #endregion
    }
}
