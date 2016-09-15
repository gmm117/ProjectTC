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
    /// Interaction logic for TestResultView.xaml
    /// </summary>
    public partial class TestMainView : UserControl
    {
        public TestMainViewModel VM;

        public TestMainView()
        {
            InitializeComponent();

            this.VM = new TestMainViewModel();
            this.VM.OwnerView = this;

            this.DataContext = VM;
        }


    }
}
