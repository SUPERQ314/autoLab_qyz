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
using System.Text.RegularExpressions;

namespace TrialEdit
{
    /// <summary>
    /// Interaction logic for Dispense1.xaml
    /// </summary>
    public partial class Dispense1 : Window
    {
        public string dispenseVol = "";
        public delegate void SendMessage(string value);
        public SendMessage sendMessage;
        Data.Station Station = new Data.Station();
        int positionX = 0, positionY = 0, Volume = 0;
        public Dispense1(Data.Station station, int x, int y, int volume)
        {
            InitializeComponent();
            Station = station;
            positionX = x;
            positionY = y;
            Volume = volume;
        }
        public void limitnumber(object sender, TextCompositionEventArgs e)
        {
            Regex re = new Regex("[^0^1^2^3^4^5^6^7^8^9]");
            e.Handled = re.IsMatch(e.Text);
        }
        bool canDispense = false;

        private void Button_Click(object sender, RoutedEventArgs e)
        {

        }

        public void Input(object sender, TextChangedEventArgs e)
        {
            for (var i = 0; i < Station.CUM.Count; i++)
            {
                if (Station.CUM[i].x == (positionX-1))
                {
                    if (Station.CUM[i].y == (positionY-1))
                    {
                        if (Station.CUM[i].type == "96D" || Station.CUM[i].type == "96F")
                        {
                            canDispense = true;
                        }
                    }
                }
            }
            if (!canDispense)
            {
                MessageBox.Show("液体只能释放至96孔深孔板或96孔浅孔板！", "Info", MessageBoxButton.OK, MessageBoxImage.Warning);
                this.Close();
            }
            else
            {
                int Num;
                dispenseVol = this.dispense.Text;
                if (dispenseVol != "")
                {
                    Num = Int32.Parse(dispenseVol);
                    if (Num > 1000)
                    {
                        System.Windows.MessageBox.Show("不得超过1mL！", "Info", MessageBoxButton.OK, MessageBoxImage.Warning);
                        this.dispense.Text = "1000";
                        Num = 1000;
                    }
                    if (Num > Volume)
                    {
                        this.dispense.Text = Volume.ToString();
                        System.Windows.MessageBox.Show("放液量大于吸液量，请重新设置！", "Info", MessageBoxButton.OK, MessageBoxImage.Warning);
                    }
                }
            }
        }
        private void CloseCommandHandler(object sender, ExecutedRoutedEventArgs e)
        {
            if (dispenseVol == "")
            {
                this.Close();
            }
            else if (MessageBox.Show("设置的每个枪头的放液量为：" + dispenseVol + "µL\n确认退出设置？", "确认", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                sendMessage(dispenseVol);
                this.Close();
            }
        }
    }
}
