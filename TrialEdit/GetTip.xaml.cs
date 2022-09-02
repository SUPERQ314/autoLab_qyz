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

namespace TrialEdit
{
    /// <summary>
    /// Interaction logic for GetTip.xaml
    /// </summary>
    public partial class GetTip : Window
    {
        public string Tips = "";
        public int TipNum = 0;
        public bool[] tips = { false, false, false, false, false, false, false, false };
        public delegate void SendMessage(int value1,string value2,bool[] tips);
        public SendMessage sendMessage;
        public GetTip()
        {
            InitializeComponent();
        }
        private void CloseCommandHandler(object sender, ExecutedRoutedEventArgs e)
        {
            if (T1.IsChecked == true)
            {
                Tips += "A ";
                TipNum++;
                tips[0] = true;
            }
            else{
                tips[0] = false;
            }
            if (T2.IsChecked == true)
            {
                Tips += "B ";
                TipNum++;
                tips[1] = true;
            }
            else
            {
                tips[1] = false;
            }
            if (T3.IsChecked == true)
            {
                Tips += "C ";
                TipNum++;
                tips[2] = true;
            }
            else
            {
                tips[2] = false;
            }
            if (T4.IsChecked == true)
            {
                Tips += "D ";
                TipNum++;
                tips[3] = true;
            }
            else
            {
                tips[3] = false;
            }
            if (T5.IsChecked == true)
            {
                Tips += "E ";
                TipNum++;
                tips[4] = true;
            }
            else
            {
                tips[4] = false;
            }
            if (T6.IsChecked == true)
            {
                Tips += "F ";
                TipNum++;
                tips[5] = true;
            }
            else
            {
                tips[5] = false;
            }
            if (T7.IsChecked == true)
            {
                Tips += "G ";
                TipNum++;
                tips[6] = true;
            }
            else
            {
                tips[6] = false;
            }
            if (T8.IsChecked == true)
            {
                Tips += "H ";
                TipNum++;
                tips[7] = true;
            }
            else
            {
                tips[7] = false;
            }
            if (Tips == "")
            {
                this.Close();
            }
            else
            {
                if (MessageBox.Show("您选择的枪头为：" + Tips + "\n确认退出设置？", "确认", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    sendMessage(TipNum,Tips,tips);
                    this.Close();
                }
                else
                {
                    Tips = "";
                }
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
