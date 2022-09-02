using System;
using System.Collections.Generic;
using System.Globalization;
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
    /// Interaction logic for Slot12.xaml
    /// </summary>
    public partial class Slot12 : Window
    {
        public char[] Type = { ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ', ' ' };
        public String Volume;
        public String[] text = { "", "", "", "", "", "", "", "", "", "", "", "" };
        public float[] Volumes = new float[12] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
        public string types = "";
        public String Text;
        public float turn;
        public int i = 0;
        public delegate void SendMessage(char[] value1, float[] value2);
        public SendMessage sendMessage;
        public Slot12()
        {
            InitializeComponent();
            this.Closing += Window_Closing;
        }
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (System.Windows.MessageBox.Show("Exit？", "Info", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                bool hasREG = false;
                for (var i = 0; i < Volumes.Length; i++)
                {
                    if (Volumes[i] > 0) hasREG = true;
                }
                if (hasREG)
                {
                    e.Cancel = false;
                    sendMessage(Type, Volumes);
                }
                else
                {
                    e.Cancel = true;
                    MessageBox.Show("Please add reagent！", "Info", MessageBoxButton.YesNo, MessageBoxImage.Warning);
                }
            }
            else
            {
                e.Cancel = true;
            }
            /*var existedT = false;
            var E = 0;
            var n = 0;
            for (var i = 0; i < Type.Length; i++)
            {
                for (var j = 0; j < types.Length; j++)
                {
                    if (Type[i] == types[j])
                    {
                        existedT = true;
                        E = j;
                        break;
                    }
                }
                if (!existedT && Type[i] != ' ')
                {
                    types += Type[i];
                    //Volumes[n] = float.Parse(volume.Text, CultureInfo.InvariantCulture.NumberFormat);
                    n++;
                }
                else
                {
                    //Volumes[E] += float.Parse(volume.Text, CultureInfo.InvariantCulture.NumberFormat);
                }
                existedT = false;
            }*/
        }
        public void limitnumber(object sender, TextCompositionEventArgs e)
        {
            Regex re = new Regex("[^0^1^2^3^4^5^6^7^8^9^.]");
            e.Handled = re.IsMatch(e.Text);
        }
        public void Add_Item(object sender, RoutedEventArgs e)
        {
            if (i < 12)
            {
                if (type.Text.Equals("None"))
                {
                    text[i] = Convert.ToString(i + 1) + "   None\n";
                    Type[i] = ' ';
                    Volumes[i] = 0;
                    Settings.Content = '\n';
                    foreach (string value in text) Settings.Content += value;
                    i++;
                }
                else
                {
                    if (float.Parse(volume.Text) <0.001)
                    {
                        MessageBox.Show("请放置容量>1微升的液体!", "Info", MessageBoxButton.YesNo, MessageBoxImage.Warning);
                    }
                    else
                    {
                        text[i] = Convert.ToString(i + 1) + "   " + type.Text + "   " + volume.Text + "mL\n";
                        Type[i] = type.Text[0];
                        Volumes[i] = float.Parse(volume.Text);
                        Settings.Content = '\n';
                        foreach (string value in text) Settings.Content += value;
                        i++;
                    }
                }
            }
        }
        public void Delete_Item(object sender, RoutedEventArgs e)
        {
            if (i > 0)
            {
                i--;
                text[i] = " ";
                Type[i] = ' ';
                Volumes[i] = 0;
                Settings.Content = '\n';
                foreach (string value in text) Settings.Content += value;
            }
        }

        private void volume_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (volume.Text != "")
            {
                if (float.Parse(volume.Text) > 10)
                {
                    MessageBox.Show("Maxmium is 10mL！", "Info", MessageBoxButton.YesNo, MessageBoxImage.Warning);
                    volume.Text = "10";
                }
            }
        }
    }
}
