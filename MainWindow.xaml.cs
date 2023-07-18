using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Numerics;
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

namespace HDCC_wpf
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private void h_TextChanged(object sender, TextChangedEventArgs e)
        {
            culcu();

        }

        private void l_TextChanged(object sender, TextChangedEventArgs e)
        {
            culcu();
        }

        private void culcu()
        {

            result.Text = "计算中";
            int.TryParse(l.Text, out int lowd);
            int.TryParse(h.Text, out int highd);

            try
            {
                int delta = highd - lowd;
                if (delta >= 0)
                {
                    result.Text = ((int)Math.Pow(2,delta) * CalculateCombination(highd, delta)).ToString();
                    Debug.WriteLine(lowd+"/"+highd+ "/" + delta+ "/" + CalculateCombination(highd, delta));
                }
                else result.Text = "计算失败";
            }
            catch(Exception e) {
                MessageBox.Show("Err" + e.Message);
            }
        }

        static BigInteger CalculateCombination(int n, int r)
        {
            BigInteger numerator = 1;
            BigInteger denominator = 1;

            for (int i = 1; i <= r; i++)
            {
                numerator *= n;
                denominator *= i;
                n--;
            }

            BigInteger result = numerator / denominator;
            return result;
        }
    }
}
