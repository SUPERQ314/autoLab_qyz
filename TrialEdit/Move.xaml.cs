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
    /// Interaction logic for Dispense.xaml
    /// </summary>
    public partial class Move : Window
    {
        public string WSC;
        public string WSR;
        public string TipColumn;
        public delegate void SendMessage(string value1, string value2, string value3);
        public SendMessage sendMessage;
        public Move()
        {
            InitializeComponent();
        }
        public void WorkStationCChanged(object sender, SelectionChangedEventArgs e)
        {
            WSC = WorkStationC.SelectedIndex.ToString();
        }
        public void WorkStationRChanged(object sender, SelectionChangedEventArgs e)
        {
            WSR = WorkStationR.SelectedIndex.ToString();
        }
        public void TipCChanged(object sender, SelectionChangedEventArgs e)
        {
            TipColumn = TipC.SelectedIndex.ToString();
        }
        private void CloseCommandHandler(object sender, ExecutedRoutedEventArgs e)
        {
            if (WorkStationC.SelectedIndex == 0 || WorkStationR.SelectedIndex == 0 || TipC.SelectedIndex == 0)
            {
                this.Close();
            }
            else if (MessageBox.Show("您选择的工作区为：[" + WSC + ',' + WSR + "]\n您选择的96孔板列号为：" + TipColumn + "\n确认退出设置？", "确认", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                sendMessage(WSC, WSR, TipColumn);
                this.Close();
            }
        }
    }
}

