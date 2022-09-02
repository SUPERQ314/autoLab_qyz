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
    /// Interaction logic for Aspiration.xaml
    /// </summary>
    public partial class Aspiration : Window
    {
        public string UseRawItem { get; set; }
        public delegate void SendMessage(int value1,int value2);
        public SendMessage sendMessage;
        public int Num = 0;
        bool canAspiration = false;
        Data.Station Station = new Data.Station();
        int X, Y, Col, TipNum;
        public Aspiration(Data.Station station,int x,int y,int col, int tipnum)
        {
            InitializeComponent();
            Station = station;
            X = x;
            Y = y;
            Col = col;
            TipNum = tipnum;
        }
        private void CloseCommandHandler(object sender, ExecutedRoutedEventArgs e)
        {
            if (Num == 0)
            {
                this.Close();
            }
            else if (MessageBox.Show("您要吸取的总容量为：" + Num*TipNum + "µL\n确认退出设置？", "确认", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                sendMessage(Num,index);
                this.Close();
            }
        }
        public void limitnumber(object sender, TextCompositionEventArgs e)
        {
            Regex re = new Regex("[^0^1^2^3^4^5^6^7^8^9]");
            e.Handled = re.IsMatch(e.Text);
        }
        public int index = 0;
        public void Input(object sender, TextChangedEventArgs e)
        {
            var content = this.num.Text;
            if (content != "")
            {
                Num = Int32.Parse(content);
                if (Num > 1000)
                {
                    System.Windows.MessageBox.Show("不得超过1mL！", "Info", MessageBoxButton.OK, MessageBoxImage.Warning);
                    this.num.Text = "1000";
                    Num = 1000;
                }
            }
            for (var i = 0; i < Station.RGT.Count; i++)
            {
                if ((X-1) == Station.RGT[i].x)
                {
                    if ((Y-1) == Station.RGT[i].y)
                    {
                        var l=(float)Num/1000*TipNum;
                        if (Station.RGT[i].volume[Col - 1]-l >=0 )
                        {
                            canAspiration = true;
                            index = i;
                            break;
                        }
                        else
                        {
                            canAspiration = false;
                            break;
                        }
                    }
                }
            }
            if (!canAspiration)
            {
                MessageBox.Show("无足够的溶液，请重新配置！", "Info", MessageBoxButton.OK, MessageBoxImage.Warning);
                this.Close();
            }
        }
    }
}
