using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace Calculator.src
{
    public class Util
    {
        public void Window_PreviewKeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key >= Key.E && e.Key <= Key.N || e.Key >= Key.F7 && e.Key <= Key.F16)
            {
                e.Handled = true;
            }
        }

        public bool CheckNum(Key key)
        {
            return key >= Key.D0 && key <= Key.D9 || key >= Key.NumPad0 && key <= Key.NumPad9;
        }

        private int max_difficulty = 15;
        private int min_difficulty = 11;
        public bool IsOutOfValue(int value)
        {
            return value > max_difficulty || value < min_difficulty;
        }
    }
}
