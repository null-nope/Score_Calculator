using Calculator.src;
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
using System.Windows.Shapes;

namespace Calculator.windows
{
    /// <summary>
    /// SetExPathWin.xaml 的交互逻辑
    /// </summary>
    public partial class SetExPathWin : Window
    {
        public SetExPathWin()
        {
            InitializeComponent();
        }

        private void Save_Botton_Click(object sender, RoutedEventArgs e)
        {
            DataExport.SetSavePath(Path.Text);
        }
    }
}
