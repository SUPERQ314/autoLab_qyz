using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Diagnostics;
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
using System.Windows.Threading;
using System.Text.RegularExpressions;
using Newtonsoft.Json;
using Microsoft.Win32;
using System.IO;

namespace TrialEdit
{
    public static class util
    {
        public static void SaveWindows(Window window, int dpi, string filename)
        {
            var rtb = new RenderTargetBitmap(
                (int)window.Width,//width
                (int)window.Height,//height
                dpi,//dpi x
                dpi,//dpi y
                PixelFormats.Pbgra32 //pixelformat
            );
            rtb.Render(window);
            saveRTBAsPNG(rtb, filename);
        }
        public static void SaveCanvas(Window window, Canvas canvas, int dpi, string filename)
        {
            System.Windows.Size size = new System.Windows.Size(window.Width, window.Height);
            canvas.Measure(size);
            var rtb = new RenderTargetBitmap(
                (int)window.Width,//width
                (int)window.Height,//height
                dpi,//dpi x
                dpi,//dpi y
                PixelFormats.Pbgra32 //pixelformat
            );
            rtb.Render(canvas);
            saveRTBAsPNG(rtb, filename);
        }
        public static void saveRTBAsPNG(RenderTargetBitmap bmp, string filename)
        {
            var enc = new System.Windows.Media.Imaging.PngBitmapEncoder();
            enc.Frames.Add(System.Windows.Media.Imaging.BitmapFrame.Create(bmp));
            using (var stm = System.IO.File.Create(filename))
            {
                enc.Save(stm);
            }
        }
    }
    /// <summary>
    /// Interaction logic for StationEdit.xaml
    /// </summary>
    public partial class StationEdit : Window
    {
        public int Num1, Num2, Num3;
        public char[] Type;
        public float[] Volumes;
        public char[] ClearT;
        public float[] ClearV;
        public Data.Station station = new Data.Station();
        public delegate void SendMessage(Data.Station value1);
        public SendMessage sendMessage;
        public delegate void test(int a);
        public test Test;
        public delegate void preset(string path);
        public preset Preset;
        private BitmapImage BitmapToBitmapImage(System.Drawing.Bitmap bitmap)
        {
            BitmapImage bitmapImage = new BitmapImage();
            using (System.IO.MemoryStream ms = new System.IO.MemoryStream())
            {
                bitmap.Save(ms, bitmap.RawFormat);
                bitmapImage.BeginInit();
                bitmapImage.StreamSource = ms;
                bitmapImage.CacheOption = BitmapCacheOption.OnLoad;
                bitmapImage.EndInit();
                bitmapImage.Freeze();
            }
            return bitmapImage;
        }

        public StationEdit()
        {
            InitializeComponent();
            BitmapImage bmpBlank = BitmapToBitmapImage(Filestore.Resource.blank);
            img1.Source = bmpBlank;
            img2.Source = bmpBlank;
            img3.Source = bmpBlank;
            img4.Source = bmpBlank;
            img5.Source = bmpBlank;
            img6.Source = bmpBlank;
            img7.Source = bmpBlank;
            img8.Source = bmpBlank;
            img9.Source = bmpBlank;
            img10.Source = bmpBlank;
            img11.Source = bmpBlank;
            img12.Source = bmpBlank;
            this.Closing += Window_Closing;
        }
        public void Receive(char[] value1, float[] value2)
        {
            Type = value1;
            Volumes = value2;
        }
        public string filename = System.IO.Directory.GetCurrentDirectory()+"preset.png";
        ///<summary>
        ///在窗口关闭时触发事件
        /// </summary>
        /// 
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            if (System.Windows.MessageBox.Show("Exit preprocessing mode？", "Info", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
            {
                var hasTip = false;
                for (var i = 0; i < station.CUM.Count;i++ )
                {
                    if (station.CUM[i].type == "Tip") hasTip = true;
                }
                for (var i = 0; i < station.RGT.Count;i++ )
                {
                    Console.WriteLine(station.RGT[i].type);
                }
                Console.WriteLine(station.Stack.Tip);
                if (station.Stack.Tip > 0) hasTip = true;
                Console.WriteLine(station.Stack.S96);
                Console.WriteLine(station.Stack.D96);
                if (!hasTip)
                {
                    e.Cancel = true;
                    MessageBox.Show("Please add at least one pipette tip!","Info",MessageBoxButton.YesNo,MessageBoxImage.Warning);
                }
                //保证耗材中至少有一个96孔深孔板或一个96孔浅孔板
                var has96 = false;
                for (var i = 0; i < station.CUM.Count; i++)
                {
                    if (station.CUM[i].type == "96D" || station.CUM[i].type == "96F")
                    {
                        has96 = true;
                    }
                }
                if (station.Stack.D96 > 0 || station.Stack.S96 > 0)
                {
                    has96 = true;
                }
                if (!has96)
                {
                    e.Cancel = true;
                    MessageBox.Show("Please add at least one 96-well plate!", "Info", MessageBoxButton.YesNo, MessageBoxImage.Warning);
                }
                bool hasREG = false;
                if (station.RGT.Count != 0)
                {
                    hasREG = true;
                }
                if (!hasREG)
                {
                    e.Cancel = true;
                    MessageBox.Show("Please add at least one reagent groove of 12 columns!", "Info", MessageBoxButton.YesNo, MessageBoxImage.Warning);
                }
                if (has96 & hasTip & hasREG)
                {
                    e.Cancel = false;
                    string file = JsonConvert.SerializeObject(station, Formatting.Indented);
                    SaveFileDialog saveFileDialog = new SaveFileDialog();
                    saveFileDialog.Filter = "Station Presettle File (*.spf)|*.spf";
                    if (saveFileDialog.ShowDialog() == true)
                    {
                        File.WriteAllText(saveFileDialog.FileName, file);
                    }
                    util.SaveWindows(this, 96, filename);
                }
                //Test(1);
                //Data.Station station1 = new Data.Station();
                //sendMessage(station1);
            }
            else
            {
                e.Cancel = true;
            }
            Preset(filename);
        }
        public void limitnumber(object sender, TextCompositionEventArgs e)
        {
            Regex re = new Regex("[^0^1^2^3^4^5^6^7^8^9^.]");
            e.Handled = re.IsMatch(e.Text);
        }
        public void Input1(object sender, TextChangedEventArgs e)
        {
            var content = this.num1.Text;
            if (content != "")
            {
                Num1 = Int32.Parse(content);
                if (Num1 > 10)
                {
                    System.Windows.MessageBox.Show("Maxmium is 10!", "Info", MessageBoxButton.YesNo, MessageBoxImage.Warning);
                    this.num1.Text = "10";
                    Num1 = 10;
                }
                station.Stack.Tip = Num1;
            }
        }
        public void Input2(object sender, TextChangedEventArgs e)
        {
            var content = this.num2.Text;
            if (content != "")
            {
                Num2 = Int32.Parse(content);
                if (Num2 > 10)
                {
                    System.Windows.MessageBox.Show("Maxmium is 10!", "Info", MessageBoxButton.YesNo, MessageBoxImage.Warning);
                    this.num2.Text = "10";
                    Num2 = 10;
                }
                station.Stack.S96 = Num2;
            }
        }
        public void Input3(object sender, TextChangedEventArgs e)
        {
            var content = this.num3.Text;
            if (content != "")
            {
                Num3 = Int32.Parse(content);
                if (Num3 > 10)
                {
                    System.Windows.MessageBox.Show("Maxmium is 10!", "Info", MessageBoxButton.YesNo, MessageBoxImage.Warning);
                    this.num3.Text = "10";
                    Num3 = 10;
                }
                station.Stack.D96 = Num3;
            }
        }
        
        private void None1(object sender, RoutedEventArgs e)
        {
            BitmapImage bmpBlank = BitmapToBitmapImage(Filestore.Resource.blank);
            img1.Source = bmpBlank;
            station.delete(0, 0);
        }
        private void plate_D1(object sender, RoutedEventArgs e)
        {
            station.delete(0, 0);
            station.record1(0, 0, "96D");
            BitmapImage bmpD_96 = BitmapToBitmapImage(Filestore.Resource.D_96);
            img1.Source = bmpD_96;
        }
        private void None2(object sender, RoutedEventArgs e)
        {
            BitmapImage bmpBlank = BitmapToBitmapImage(Filestore.Resource.blank);
            img2.Source = bmpBlank;
            station.delete(1, 0);
        }
        private void plate_D2(object sender, RoutedEventArgs e)
        {
            station.delete(1, 0);
            station.record1(1, 0, "96D");
            BitmapImage bmpD_96 = BitmapToBitmapImage(Filestore.Resource.D_96);
            img2.Source = bmpD_96;
        }
        private void None3(object sender, RoutedEventArgs e)
        {
            BitmapImage bmpBlank = BitmapToBitmapImage(Filestore.Resource.blank);
            img3.Source = bmpBlank;
            station.delete(2, 0);
        }
        private void plate_D3(object sender, RoutedEventArgs e)
        {
            station.delete(2, 0);
            station.record1(2, 0, "96D");
            BitmapImage bmpD_96 = BitmapToBitmapImage(Filestore.Resource.D_96);
            img3.Source = bmpD_96;
        }
        private void None4(object sender, RoutedEventArgs e)
        {
            BitmapImage bmpBlank = BitmapToBitmapImage(Filestore.Resource.blank);
            img4.Source = bmpBlank;
            station.delete(3, 0);
        }
        private void plate_D4(object sender, RoutedEventArgs e)
        {
            station.delete(3, 0);
            station.record1(3, 0, "96D");
            BitmapImage bmpD_96 = BitmapToBitmapImage(Filestore.Resource.D_96);
            img4.Source = bmpD_96;
        }
        private void None5(object sender, RoutedEventArgs e)
        {
            BitmapImage bmpBlank = BitmapToBitmapImage(Filestore.Resource.blank);
            img5.Source = bmpBlank;
            station.delete(0, 1);
        }
        private void plate_D5(object sender, RoutedEventArgs e)
        {
            station.delete(0, 1);
            station.record1(0, 1, "96D");
            BitmapImage D_96 = BitmapToBitmapImage(Filestore.Resource.D_96);
            img5.Source = D_96;
        }
        private void None6(object sender, RoutedEventArgs e)
        {
            BitmapImage bmpBlank = BitmapToBitmapImage(Filestore.Resource.blank);
            img6.Source = bmpBlank;
            station.delete(1, 1);
        }
        private void plate_D6(object sender, RoutedEventArgs e)
        {
            station.delete(1,1);
            station.record1(1, 1, "96D");
            BitmapImage D_96 = BitmapToBitmapImage(Filestore.Resource.D_96);
            img6.Source = D_96;
        }
        private void None7(object sender, RoutedEventArgs e)
        {
            BitmapImage bmpBlank = BitmapToBitmapImage(Filestore.Resource.blank);
            img7.Source = bmpBlank;
            station.delete(2, 1);
        }
        private void plate_D7(object sender, RoutedEventArgs e)
        {
            station.delete(2, 1);
            station.record1(2, 1, "96D");
            BitmapImage bmpD_96 = BitmapToBitmapImage(Filestore.Resource.D_96);
            img7.Source = bmpD_96;
        }
        private void None8(object sender, RoutedEventArgs e)
        {
            BitmapImage bmpBlank = BitmapToBitmapImage(Filestore.Resource.blank);
            img8.Source = bmpBlank;
            station.delete(3, 1);
        }
        private void plate_D8(object sender, RoutedEventArgs e)
        {
            station.delete(3, 1);
            station.record1(3, 1, "96D");
            BitmapImage bmpD_96 = BitmapToBitmapImage(Filestore.Resource.D_96);
            img8.Source = bmpD_96;
        }
        private void None9(object sender, RoutedEventArgs e)
        {
            BitmapImage bmpBlank = BitmapToBitmapImage(Filestore.Resource.blank);
            img9.Source = bmpBlank;
            station.delete(0, 2);
        }
        private void plate_D9(object sender, RoutedEventArgs e)
        {
            station.delete(0, 2);
            station.record1(0, 2, "96D");
            BitmapImage bmpD_96 = BitmapToBitmapImage(Filestore.Resource.D_96);
            img9.Source = bmpD_96;
        }
        private void None10(object sender, RoutedEventArgs e)
        {
            BitmapImage bmpBlank = BitmapToBitmapImage(Filestore.Resource.blank);
            img10.Source = bmpBlank;
            station.delete(1, 2);
        }
        private void plate_D10(object sender, RoutedEventArgs e)
        {
            station.delete(1, 2);
            station.record1(1, 2, "96D");
            BitmapImage bmpD_96 = BitmapToBitmapImage(Filestore.Resource.D_96);
            img10.Source = bmpD_96;
        }
        private void None11(object sender, RoutedEventArgs e)
        {
            BitmapImage bmpBlank = BitmapToBitmapImage(Filestore.Resource.blank);
            img11.Source = bmpBlank;
            station.delete(2, 2);
        }
        private void plate_D11(object sender, RoutedEventArgs e)
        {
            station.delete(2, 2);
            station.record1(2, 2, "96D");
            BitmapImage bmpD_96 = BitmapToBitmapImage(Filestore.Resource.D_96);
            img11.Source = bmpD_96;
        }
        private void None12(object sender, RoutedEventArgs e)
        {
            BitmapImage bmpBlank = BitmapToBitmapImage(Filestore.Resource.blank);
            img12.Source = bmpBlank;
            station.delete(3, 2);
        }
        private void plate_D12(object sender, RoutedEventArgs e)
        {
            station.delete(3, 2);
            station.record1(3, 2, "96D");
            BitmapImage bmpD_96 = BitmapToBitmapImage(Filestore.Resource.D_96);
            img12.Source = bmpD_96;
        }
        private void plate_F1(object sender, RoutedEventArgs e)
        {
            station.delete(0, 0);
            station.record1(0, 0, "96F");
            BitmapImage bmpF_96 = BitmapToBitmapImage(Filestore.Resource.F_96);
            img1.Source = bmpF_96;
        }
        private void plate_F2(object sender, RoutedEventArgs e)
        {
            station.delete(1, 0);
            station.record1(1, 0, "96F");
            BitmapImage bmpF_96 = BitmapToBitmapImage(Filestore.Resource.F_96);
            img2.Source = bmpF_96;
        }
        private void plate_F3(object sender, RoutedEventArgs e)
        {
            station.delete(2, 0);
            station.record1(2, 0, "96F");
            BitmapImage bmpF_96 = BitmapToBitmapImage(Filestore.Resource.F_96);
            img3.Source = bmpF_96;
        }
        private void plate_F4(object sender, RoutedEventArgs e)
        {
            station.delete(3, 0);
            station.record1(3, 0, "96F");
            BitmapImage bmpF_96 = BitmapToBitmapImage(Filestore.Resource.F_96);
            img4.Source = bmpF_96;
        }
        private void plate_F5(object sender, RoutedEventArgs e)
        {
            station.delete(0, 1);
            station.record1(0, 1, "96F");
            BitmapImage bmpF_96 = BitmapToBitmapImage(Filestore.Resource.F_96);
            img5.Source = bmpF_96;
        }
        private void plate_F6(object sender, RoutedEventArgs e)
        {
            station.delete(1, 1);
            station.record1(1, 1, "96F");
            BitmapImage bmpF_96 = BitmapToBitmapImage(Filestore.Resource.F_96);
            img6.Source = bmpF_96;
        }
        private void plate_F7(object sender, RoutedEventArgs e)
        {
            station.delete(2, 1);
            station.record1(2, 1, "96F");
            BitmapImage bmpF_96 = BitmapToBitmapImage(Filestore.Resource.F_96);
            img7.Source = bmpF_96;
        }
        private void plate_F8(object sender, RoutedEventArgs e)
        {
            station.delete(3, 1);
            station.record1(3, 1, "96F");
            BitmapImage bmpF_96 = BitmapToBitmapImage(Filestore.Resource.F_96);
            img8.Source = bmpF_96;
        }
        private void plate_F9(object sender, RoutedEventArgs e)
        {
            station.delete(0, 2);
            station.record1(0, 2, "96F");
            BitmapImage bmpF_96 = BitmapToBitmapImage(Filestore.Resource.F_96);
            img9.Source = bmpF_96;
        }
        private void plate_F10(object sender, RoutedEventArgs e)
        {
            station.delete(1, 2);
            station.record1(1, 2, "96F");
            BitmapImage bmpF_96 = BitmapToBitmapImage(Filestore.Resource.F_96);
            img10.Source = bmpF_96;
        }
        private void plate_F11(object sender, RoutedEventArgs e)
        {
            station.delete(2, 2);
            station.record1(2, 2, "96F");
            BitmapImage bmpF_96 = BitmapToBitmapImage(Filestore.Resource.F_96);
            img11.Source = bmpF_96;
        }
        private void plate_F12(object sender, RoutedEventArgs e)
        {
            station.delete(3, 2);
            station.record1(3, 2, "96F");
            BitmapImage bmpF_96 = BitmapToBitmapImage(Filestore.Resource.F_96);
            img12.Source = bmpF_96;
        }
        private void slot12_1(object sender, RoutedEventArgs e)
        {
            station.delete(0, 0);
            TrialEdit.Slot12 form = new TrialEdit.Slot12();
            form.sendMessage = Receive;
            bool? result = form.ShowDialog();
            BitmapImage bmpSlot_12 = BitmapToBitmapImage(Filestore.Resource.Slot_12);
            img1.Source = bmpSlot_12;
            station.record2(0,0,Type, Volumes);
        }
        private void slot12_2(object sender, RoutedEventArgs e)
        {
            station.delete(1, 0);
            TrialEdit.Slot12 form = new TrialEdit.Slot12();
            form.sendMessage = Receive;
            bool? result = form.ShowDialog();
            BitmapImage bmpSlot_12 = BitmapToBitmapImage(Filestore.Resource.Slot_12);
            img2.Source = bmpSlot_12;
            Console.WriteLine(Type);
            station.record2(1,0,Type, Volumes);
        }
        private void slot12_3(object sender, RoutedEventArgs e)
        {
            station.delete(2, 0);
            TrialEdit.Slot12 form = new TrialEdit.Slot12();
            form.sendMessage = Receive;
            bool? result = form.ShowDialog();
            BitmapImage bmpSlot_12 = BitmapToBitmapImage(Filestore.Resource.Slot_12);
            img3.Source = bmpSlot_12;
            station.record2(2, 0, Type, Volumes);
        }
        private void slot12_4(object sender, RoutedEventArgs e)
        {
            station.delete(3, 0);
            TrialEdit.Slot12 form = new TrialEdit.Slot12();
            form.sendMessage = Receive;
            bool? result = form.ShowDialog();
            BitmapImage bmpSlot_12 = BitmapToBitmapImage(Filestore.Resource.Slot_12);
            img4.Source = bmpSlot_12;
            station.record2(3, 0, Type, Volumes);
        }
        private void slot12_5(object sender, RoutedEventArgs e)
        {
            station.delete(0, 1);
            TrialEdit.Slot12 form = new TrialEdit.Slot12();
            form.sendMessage = Receive;
            bool? result = form.ShowDialog();
            BitmapImage bmpSlot_12 = BitmapToBitmapImage(Filestore.Resource.Slot_12);
            img5.Source = bmpSlot_12;
            station.record2(0, 1, Type, Volumes);
        }
        private void slot12_6(object sender, RoutedEventArgs e)
        {
            station.delete(1, 1);
            TrialEdit.Slot12 form = new TrialEdit.Slot12();
            form.sendMessage = Receive;
            bool? result = form.ShowDialog();
            BitmapImage bmpSlot_12 = BitmapToBitmapImage(Filestore.Resource.Slot_12);
            img6.Source = bmpSlot_12;
            station.record2(1,1,Type, Volumes);
        }
        private void slot12_7(object sender, RoutedEventArgs e)
        {
            station.delete(2, 1);
            TrialEdit.Slot12 form = new TrialEdit.Slot12();
            form.sendMessage = Receive;
            bool? result = form.ShowDialog();
            BitmapImage bmpSlot_12 = BitmapToBitmapImage(Filestore.Resource.Slot_12);
            img7.Source = bmpSlot_12;
            station.record2(2,1, Type, Volumes);
        }
        private void slot12_8(object sender, RoutedEventArgs e)
        {
            station.delete(3, 1);
            TrialEdit.Slot12 form = new TrialEdit.Slot12();
            form.sendMessage = Receive;
            bool? result = form.ShowDialog();
            BitmapImage bmpSlot_12 = BitmapToBitmapImage(Filestore.Resource.Slot_12);
            img8.Source = bmpSlot_12;
            station.record2(3, 1, Type, Volumes);
        }
        private void slot12_9(object sender, RoutedEventArgs e)
        {
            station.delete(0, 2);
            TrialEdit.Slot12 form = new TrialEdit.Slot12();
            form.sendMessage = Receive;
            bool? result = form.ShowDialog();
            BitmapImage bmpSlot_12 = BitmapToBitmapImage(Filestore.Resource.Slot_12);
            img9.Source = bmpSlot_12;
            station.record2(0, 2,Type, Volumes);
        }
        private void slot12_10(object sender, RoutedEventArgs e)
        {
            station.delete(1, 2);
            TrialEdit.Slot12 form = new TrialEdit.Slot12();
            form.sendMessage = Receive;
            bool? result = form.ShowDialog();
            BitmapImage bmpSlot_12 = BitmapToBitmapImage(Filestore.Resource.Slot_12);
            img10.Source = bmpSlot_12;
            station.record2(1, 2, Type, Volumes);
        }
        private void slot12_11(object sender, RoutedEventArgs e)
        {
            station.delete(2, 2);
            TrialEdit.Slot12 form = new TrialEdit.Slot12();
            form.sendMessage = Receive;
            bool? result = form.ShowDialog();
            BitmapImage bmpSlot_12 = BitmapToBitmapImage(Filestore.Resource.Slot_12);
            img11.Source = bmpSlot_12;
            station.record2(2, 2, Type, Volumes);
        }
        private void slot12_12(object sender, RoutedEventArgs e)
        {
            station.delete(3, 2);
            TrialEdit.Slot12 form = new TrialEdit.Slot12();
            form.sendMessage = Receive;
            bool? result = form.ShowDialog();
            BitmapImage bmpSlot_12 = BitmapToBitmapImage(Filestore.Resource.Slot_12);
            img12.Source = bmpSlot_12;
            station.record2(3, 2, Type, Volumes);
        }
        private void tip1(object sender, RoutedEventArgs e)
        {
            station.delete(0, 0);
            station.record1(0, 0, "Tip");
            BitmapImage bmpTip = BitmapToBitmapImage(Filestore.Resource.Tip);
            img1.Source = bmpTip;
        }
        private void tip2(object sender, RoutedEventArgs e)
        {
            station.delete(1, 0);
            station.record1(1, 0, "Tip");
            BitmapImage bmpTip = BitmapToBitmapImage(Filestore.Resource.Tip);
            img2.Source = bmpTip;
        }
        private void tip3(object sender, RoutedEventArgs e)
        {
            station.delete(2, 0);
            station.record1(2, 0, "Tip");
            BitmapImage bmpTip = BitmapToBitmapImage(Filestore.Resource.Tip);
            img3.Source = bmpTip;
        }
        private void tip4(object sender, RoutedEventArgs e)
        {
            station.delete(3, 0);
            station.record1(3, 0, "Tip");
            BitmapImage bmpTip = BitmapToBitmapImage(Filestore.Resource.Tip);
            img4.Source = bmpTip;
        }
        private void tip5(object sender, RoutedEventArgs e)
        {
            station.delete(0, 1);
            station.record1(0, 1, "Tip");
            BitmapImage bmpTip = BitmapToBitmapImage(Filestore.Resource.Tip);
            img5.Source = bmpTip;
        }
        private void tip6(object sender, RoutedEventArgs e)
        {
            station.delete(1, 1);
            station.record1(1, 1, "Tip");
            BitmapImage bmpTip = BitmapToBitmapImage(Filestore.Resource.Tip);
            img6.Source = bmpTip;
        }
        private void tip7(object sender, RoutedEventArgs e)
        {
            station.delete(2, 1);
            station.record1(2, 1, "Tip");
            BitmapImage bmpTip = BitmapToBitmapImage(Filestore.Resource.Tip);
            img7.Source = bmpTip;
        }
        private void tip8(object sender, RoutedEventArgs e)
        {
            station.delete(3, 1);
            station.record1(3, 1, "Tip");
            BitmapImage bmpTip = BitmapToBitmapImage(Filestore.Resource.Tip);
            img8.Source = bmpTip;
        }
        private void tip9(object sender, RoutedEventArgs e)
        {
            station.delete(0, 2);
            station.record1(0, 2, "Tip");
            BitmapImage bmpTip = BitmapToBitmapImage(Filestore.Resource.Tip);
            img9.Source = bmpTip;
        }
        private void tip10(object sender, RoutedEventArgs e)
        {
            station.delete(1, 2);
            station.record1(1, 2, "Tip");
            BitmapImage bmpTip = BitmapToBitmapImage(Filestore.Resource.Tip);
            img10.Source = bmpTip;
        }
        private void tip11(object sender, RoutedEventArgs e)
        {
            station.delete(2, 2);
            station.record1(2, 2, "Tip");
            BitmapImage bmpTip = BitmapToBitmapImage(Filestore.Resource.Tip);
            img11.Source = bmpTip;
        }
        private void tip12(object sender, RoutedEventArgs e)
        {
            station.delete(3, 2);
            station.record1(3, 2, "Tip");
            BitmapImage bmpTip = BitmapToBitmapImage(Filestore.Resource.Tip);
            img12.Source = bmpTip;
        }
        private void slot1_1(object sender, RoutedEventArgs e)
        {
            station.delete(0, 0);
            station.record1(0, 0, "slot");
            BitmapImage bmpSlot = BitmapToBitmapImage(Filestore.Resource.Slot_1);
            img1.Source = bmpSlot;
        }
        private void slot1_2(object sender, RoutedEventArgs e)
        {
            station.delete(1, 0);
            station.record1(1, 0, "slot");
            BitmapImage bmpSlot = BitmapToBitmapImage(Filestore.Resource.Slot_1);
            img2.Source = bmpSlot;
        }
        private void slot1_3(object sender, RoutedEventArgs e)
        {
            station.delete(2, 0);
            station.record1(2, 0, "slot");
            BitmapImage bmpSlot = BitmapToBitmapImage(Filestore.Resource.Slot_1);
            img3.Source = bmpSlot;
        }
        private void slot1_4(object sender, RoutedEventArgs e)
        {
            station.delete(3, 0);
            station.record1(3, 0, "slot");
            BitmapImage bmpSlot = BitmapToBitmapImage(Filestore.Resource.Slot_1);
            img4.Source = bmpSlot;
        }
        private void slot1_5(object sender, RoutedEventArgs e)
        {
            station.delete(0, 1);
            station.record1(0, 1, "slot");
            BitmapImage bmpSlot = BitmapToBitmapImage(Filestore.Resource.Slot_1);
            img5.Source = bmpSlot;
        }
        private void slot1_6(object sender, RoutedEventArgs e)
        {
            station.delete(1, 1);
            station.record1(1, 1, "slot");
            BitmapImage bmpSlot = BitmapToBitmapImage(Filestore.Resource.Slot_1);
            img6.Source = bmpSlot;
        }
        private void slot1_7(object sender, RoutedEventArgs e)
        {
            station.delete(2, 1);
            station.record1(2, 1, "slot");
            BitmapImage bmpSlot = BitmapToBitmapImage(Filestore.Resource.Slot_1);
            img7.Source = bmpSlot;
        }
        private void slot1_8(object sender, RoutedEventArgs e)
        {
            station.delete(3, 1);
            station.record1(3, 1, "slot");
            BitmapImage bmpSlot = BitmapToBitmapImage(Filestore.Resource.Slot_1);
            img8.Source = bmpSlot;
        }
        private void slot1_9(object sender, RoutedEventArgs e)
        {
            station.delete(0, 2);
            station.record1(0, 2, "slot");
            BitmapImage bmpSlot = BitmapToBitmapImage(Filestore.Resource.Slot_1);
            img9.Source = bmpSlot;
        }
        private void slot1_10(object sender, RoutedEventArgs e)
        {
            station.delete(1, 2);
            station.record1(1, 2, "slot");
            BitmapImage bmpSlot = BitmapToBitmapImage(Filestore.Resource.Slot_1);
            img10.Source = bmpSlot;
        }
        private void slot1_11(object sender, RoutedEventArgs e)
        {
            station.delete(2, 2);
            station.record1(2, 2, "slot");
            BitmapImage bmpSlot = BitmapToBitmapImage(Filestore.Resource.Slot_1);
            img11.Source = bmpSlot;
        }
        private void slot1_12(object sender, RoutedEventArgs e)
        {
            station.delete(3, 2);
            station.record1(3, 2, "slot");
            BitmapImage bmpSlot = BitmapToBitmapImage(Filestore.Resource.Slot_1);
            img12.Source = bmpSlot;
        }
    }
}
