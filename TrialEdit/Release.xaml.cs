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
    /// Interaction logic for Release.xaml
    /// </summary>
    public partial class Release : Window
    {
        public string WSC;
        public string WSR;
        public delegate void SendMessage(string value1, string value2);
        public SendMessage sendMessage;
        Data.Station Station = new Data.Station();
        public Release(Data.Station station)
        {
            InitializeComponent();
            Station = station;
        }
        public void WorkStationCChanged(object sender, SelectionChangedEventArgs e)
        {
            WSC = WorkStationC.SelectedIndex.ToString();
        }
        public void WorkStationRChanged(object sender, SelectionChangedEventArgs e)
        {
            WSR = WorkStationR.SelectedIndex.ToString();
        }
        private void CloseCommandHandler(object sender, ExecutedRoutedEventArgs e)
        {
            bool canrealse=false;
            for (var i = 0; i < Station.CUM.Count; i++)
            {
                if ((int.Parse(WSC) - 1) == Station.CUM[i].x)
                {
                    if ((int.Parse(WSR) - 1) == Station.CUM[i].y)
                    {
                        canrealse = true;
                        break;
                    }
                }
            }
            /*for (var i = 0; i < Station.RGT.Count; i++)
            {
                if ((int.Parse(WSC) - 1) == Station.RGT[i].x)
                {
                    if ((int.Parse(WSR) - 1) == Station.RGT[i].y)
                    {
                        canrealse = true;
                        break;
                    }
                }
            }*/
            if (canrealse)
            {
                if (MessageBox.Show("您将要丢弃耗材的区域为：[" + WSC + ',' + WSR + "]\n确认退出设置？", "确认", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    sendMessage(WSC, WSR);
                    this.Close();
                }
            }
            else
            {
                MessageBox.Show("该区域无可丢弃的耗材！", "Info", MessageBoxButton.YesNo, MessageBoxImage.Warning);
                this.Close();
            }
        }

    }
}
