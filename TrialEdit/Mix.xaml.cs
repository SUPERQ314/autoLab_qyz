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
    /// Interaction logic for Mix.xaml
    /// </summary>
    public partial class Mix : Window
    {
        public string strength;
        public delegate void SendMessage(string value);
        public SendMessage sendMessage;
        public Mix()
        {
            InitializeComponent();
        }
        private void CloseCommandHandler(object sender, ExecutedRoutedEventArgs e)
        {
            if (MessageBox.Show("吹打混匀的强度为："+strength+"\n确认退出设置？", "确认", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                sendMessage(strength);
                this.Close();
            }
        }
        private void RatioButtonChecked(object sender,EventArgs e)
        {
            if(High.IsChecked==true)
            {
                strength = "高";
            } else if(Middle.IsChecked==true)
            {
                strength = "中";
            }
            else
            {
                strength = "低";
            }
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }
    }
}
