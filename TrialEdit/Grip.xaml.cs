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
    /// Interaction logic for Grip.xaml
    /// </summary>
    public partial class Grip : Window
    {
        public string WSC;
        public string WSR;
        public string ItemType;
        public delegate void SendMessage(string value1, string value2, string value3);
        public SendMessage sendMessage;
        Data.Station Station;
        public Grip(Data.Station station)
        {
            InitializeComponent();
            Station = station;
        }
        public void NewItem(object sender, SelectionChangedEventArgs e)
        {
            var Type = GripNew.SelectedIndex;
            switch (Type)
            {
                case 1:
                    {
                        ItemType = "枪头盒";
                        var tip = Station.Stack.Tip-1;
                        if (tip < 0)
                        {
                            MessageBox.Show("耗材栈中无足够的枪尖盒", "Info", MessageBoxButton.YesNo, MessageBoxImage.Warning);
                            this.Close();
                            break;
                        }
                        else
                        {
                            MessageBox.Show("添置后枪头盒余量为：" + tip, "Info", MessageBoxButton.YesNo, MessageBoxImage.Warning);
                            break;
                        }
                    }
                case 2:
                    {
                        ItemType = "96孔深孔板";
                        var D96 = Station.Stack.D96 - 1;
                        if (D96 < 0)
                        {
                            MessageBox.Show("耗材中无足够的96孔深孔板", "Info", MessageBoxButton.YesNo, MessageBoxImage.Warning);
                            this.Close();
                            break;
                        }
                        else
                        {
                            MessageBox.Show("添置后96孔深孔板余量为：" + D96 , "Info", MessageBoxButton.YesNo, MessageBoxImage.Warning);
                            break;
                        }
                    }
                case 3:
                    {
                        ItemType = "96孔浅孔板";
                        var S96 = Station.Stack.S96 - 1;
                        if (S96 < 0)
                        {
                            MessageBox.Show("耗材中无足够的96孔浅孔板", "Info", MessageBoxButton.YesNo, MessageBoxImage.Warning);
                            this.Close();
                            break;
                        }
                        else
                        {
                            MessageBox.Show("添置后96孔浅孔板余量为：" + S96, "Info", MessageBoxButton.YesNo, MessageBoxImage.Warning);
                            break;
                        }
                    }
            }
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
            bool correct = true;
            if (WorkStationC.SelectedIndex == 0 || WorkStationR.SelectedIndex == 0|| GripNew.SelectedIndex==0)
            {
                this.Close();
                correct = false;
            }
            else{
                for (var i = 0; i < Station.CUM.Count; i++)
                {
                    if ((int.Parse(WSC)-1) == Station.CUM[i].x)
                    {
                        if ((int.Parse(WSR)-1) == Station.CUM[i].y)
                        {
                            MessageBox.Show("[" + WSC + "," + WSR + "]处已放置耗材，不可重复添加！", "Info", MessageBoxButton.YesNo, MessageBoxImage.Warning);
                            correct = false;
                            this.Close();
                            break;
                        }
                    }
                }
                for (var i = 0; i < Station.RGT.Count; i++)
                {
                    if ((int.Parse(WSC) - 1) == Station.RGT[i].x)
                    {
                        if((int.Parse(WSR)-1) == Station.RGT[i].y)
                        {
                            MessageBox.Show("[" + WSC + "," + WSR + "]处已放置耗材，不可重复添加！", "Info", MessageBoxButton.YesNo, MessageBoxImage.Warning);
                            correct = false;
                            this.Close();
                            break;
                        }
                    }
                }
            }
            if (correct)
            {
                if (MessageBox.Show("您将要放置的新耗材为：" + ItemType + "\n新耗材的区域为：[" + WSC + ',' + WSR + "]\n确认退出设置？", "确认", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    sendMessage(WSC, WSR, ItemType);
                    this.Close();
                }
            }
        }
    }
}
