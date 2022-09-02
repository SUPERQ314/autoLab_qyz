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
using Newtonsoft.Json;
using Microsoft.Win32;
using System.IO;
using System.Windows.Threading;

namespace TrialEdit
{
    /// <summary>
    /// Interaction logic for EditFlow.xaml
    /// </summary>
    public partial class EditFlow : Window
    {
        public int StepIndex = 0;
        public string Tips = "";
        public string WSR, WSC, TipType, TipColumn;
        private int rowCount = 0;
        private int colCount = 0;
        public string strength, TipTM, TipCM;
        public string WSRM="", WSCM="";
        public string ItemType="", WSRG="", WSCG="";
        public string RawItemType { get; set; }
        public int Avolume;
        public bool Tipped = false;
        public int move2x, move2y, move2col;
        public Data.Station Station;
        public int TipNum = 0;
        public int DispenseVol = 0;
        bool aspirated = false;
        public bool[] tips = new bool[8];
        public double Time = 0;
        public delegate void SendMessage(double value);
        public SendMessage sendMessage;
        public double[] time=new double[1000];
        public int timecnt=0;
        bool mixed=false;
        public void Receive(int value1,string value2,bool[] value3)
        {
            TipNum = value1;
            Tips = value2;
            tips = value3;
        }
        int ColIndex = 0;
        public void ReceiveA( int value2,int index)
        {
            Avolume = value2;
            ColIndex = index;
        }
        public void RecieveD(string value)
        {
            DispenseVol = int.Parse(value);
        }
        public void RecieveM(string value)
        {
            strength = value;
        }
        public void RecieveG(string value1, string value2, string value3)
        {
            WSCG = value1;
            WSRG = value2;
            ItemType = value3;
        }
        public void RecieveR(string value1, string value2)
        {
            WSCM = value1;
            WSRM = value2;
        }
        public void ReceiveM(string value1,string value2,string value3)
        {
            move2x = int.Parse(value1);
            move2y = int.Parse(value2);
            move2col = int.Parse(value3);
        }
        int tipnum = 0;
        public EditFlow(Data.Station station,string path)
        {
            this.InitializeComponent();
            this.Closing += Window_Closing;
            preset.Source = new BitmapImage(new Uri(System.IO.Directory.GetCurrentDirectory() + "preset.png"));
            TipSteps.Source = BitmapToBitmapImage(Filestore.Resource.Pippete);
            Gripper.Source = BitmapToBitmapImage(Filestore.Resource.Gripper);
            shaker.Source = BitmapToBitmapImage(Filestore.Resource.Shake);
            Seperate.Source = BitmapToBitmapImage(Filestore.Resource.Seperate);
            Station = station;
            for (var i = 0; i < Station.CUM.Count; i++)
            {
                if (Station.CUM[i].type == "Tip")
                {
                    tipnum += 12;
                }
            }
            for (var i=0;i<10;i++)
            {
                Editflow.RowDefinitions.Add(new RowDefinition());
            }
            // Insert code required on object creation below this point.
        }
        private void Window_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            for(var i = 0; i < timecnt; i++)
            {
                Time += time[i];
            }
            sendMessage(Time);
            string file = JsonConvert.SerializeObject(steps, Formatting.Indented);
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "ExperientFlowDesign file (*.efd)|*.efd";
            if (saveFileDialog.ShowDialog() == true)
            {
                File.WriteAllText(saveFileDialog.FileName, file);
            }
        }
        
        DispatcherTimer timer = new DispatcherTimer();  // 定时器timer
        int durTime = 5;  // 视频播放时长，也就是循环周期
        Image Img = new Image();

        Image pic;
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
        private void capture(object sender,SelectionChangedEventArgs e)
        {
            var index = Tongs.SelectedIndex;
            var step = "Actions";
            switch(index)
            {
                case 1:
                    {
                        TrialEdit.Grip grip = new Grip(Station);
                        grip.sendMessage = RecieveG;
                        grip.ShowDialog();
                        if (ItemType != "")
                        {
                            switch (ItemType)
                            {
                                case "枪头盒":
                                    {
                                        Station.Stack.Tip--;
                                        tipnum += 12;
                                        Station.record1(int.Parse(WSCG) - 1, int.Parse(WSRG) - 1, "Tip");
                                        pic = new Image();
                                        pic.Source =BitmapToBitmapImage(Filestore.Resource.GripTipBox);
                                        timer.Interval = new TimeSpan(0, 0, 0, durTime); // 设置定时器重复周期
                                        timer.Tick += new EventHandler(timerEvent);
                                        timer.Start();  // 启动定时器
                                        break;
                                    }
                                case "96孔深孔板":
                                    {
                                        Station.Stack.D96--;
                                        Station.record1(int.Parse(WSCG) - 1, int.Parse(WSRG) - 1, "96D");
                                        pic = new Image();
                                        pic.Source = BitmapToBitmapImage(Filestore.Resource.Grip96);
                                        timer.Interval = new TimeSpan(0, 0, 0, durTime); // 设置定时器重复周期
                                        timer.Tick += new EventHandler(timerEvent);
                                        timer.Start();  // 启动定时器
                                        break;
                                    }
                                case "96孔浅孔板":
                                    {
                                        Station.Stack.S96--;
                                        Station.record1(int.Parse(WSCG) - 1, int.Parse(WSRG) - 1, "96F");
                                        pic = new Image();
                                        pic.Source = BitmapToBitmapImage(Filestore.Resource.Grip96);
                                        timer.Interval = new TimeSpan(0, 0, 0, durTime); // 设置定时器重复周期
                                        timer.Tick += new EventHandler(timerEvent);
                                        timer.Start();  // 启动定时器
                                        break;
                                    }
                            }
                            FlowDesign.Grip grip1 = new FlowDesign.Grip();
                            grip1.Name="Grip";
                            grip1.X = int.Parse(WSCG);
                            grip1.Y = int.Parse(WSRG);
                            grip1.Type = ItemType;
                            steps.Add(grip1);
                            step = "添加" + ItemType + "至[" + WSCG + "," + WSRG + "]";
                            time[timecnt]= (12.5 * int.Parse(WSCG) + 10 * int.Parse(WSRG));
                            timecnt++;
                            StepIndex++;
                            ItemType = "";
                            WSRG = "";
                            WSCG = "";
                            AddStep(step);
                        }
                        break;
                    }
                case 2:
                    {
                        TrialEdit.Release release = new Release(Station);
                        release.sendMessage = RecieveR;
                        release.ShowDialog();
                        if (WSRM != "" && WSCM != "")
                        {
                            FlowDesign.Release release1 = new FlowDesign.Release();
                            release1.StepName = "Release";
                            release1.X = int.Parse(WSCM)-1;
                            release1.Y = int.Parse(WSRM)-1;
                            for(var i = 0; i < Station.CUM.Count; i++)
                            {
                                if (Station.CUM[i].x == (int.Parse(WSCM) - 1))
                                {
                                    if(Station.CUM[i].y == (int.Parse(WSRM) - 1))
                                    {
                                        release1.Type=Station.CUM[i].type;
                                        break;
                                    }
                                }
                            }
                            step = "丢弃[" + WSCM + "," + WSRM + "]区域\n所用耗材";
                            steps.Add(release1);
                            time[timecnt]= (25 * (5-int.Parse(WSCM)) + 20 * int.Parse(WSRM));
                            timecnt++;
                            Station.delete(int.Parse(WSCM) - 1, int.Parse(WSRM) - 1);
                            StepIndex++;
                            pic = new Image();
                            pic.Source = BitmapToBitmapImage(Filestore.Resource.Release);
                            timer.Interval = new TimeSpan(0, 0, 0, durTime); // 设置定时器重复周期
                            timer.Tick += new EventHandler(timerEvent);
                            timer.Start();  // 启动定时器
                            AddStep(step);
                        }
                        WSRM = "";
                        WSCM = "";
                        break;
                    }
            }
        }
        public void timerEvent(object sender, EventArgs e)
        {
            // MediaElement需要先停止播放才能再开始播放，
            // 否则会停在最后一帧不动
            //pic.LoadedBehavior = MediaState.Manual;
            //pic.Stop();
            //pic.Play();
        } 
        List<FlowDesign.Dispense> CanMix = new List<FlowDesign.Dispense>();
        int PastX = 0;
        int PastY = 0;
        bool dispensed = false;
        private void AddTip(object sender, SelectionChangedEventArgs e)
        {
            var index = Tip.SelectedIndex;
            var step="Actions";
            switch(index)
            {
                case 1:
                    {
                        var addable = false;
                        if (tipnum > 0)
                        {
                            addable = true;
                        }
                        if (addable)
                        {
                            if (Tipped)
                            {
                                MessageBox.Show("已经加载过枪尖，请勿重复加载！", "Info", MessageBoxButton.OK, MessageBoxImage.Warning);
                                break;
                            }
                            else
                            {
                                    TrialEdit.GetTip mytip = new GetTip();
                                    mytip.sendMessage = Receive;
                                    mytip.ShowDialog();
                                    if (Tips != "")
                                    {
                                        for (var i = 0; i < Station.CUM.Count; i++)
                                        {
                                            if (Station.CUM[i].type == "Tip")
                                            {
                                                time[timecnt]= (12.5 * (Station.CUM[i].x + 1) + 10 * (Station.CUM[i].y + 1));
                                                timecnt++;
                                                PastX = Station.CUM[i].x + 1; PastY = Station.CUM[i].y + 1;
                                                break;
                                            }
                                        }
                                        tipnum--;
                                        step = "GetTip 获取枪头:\n" + Tips;
                                        Tips = "";
                                        Tipped = true;
                                        aspirated = false;
                                        dispensed = false;
                                        FlowDesign.GetTip gettip = new FlowDesign.GetTip();
                                        gettip.StepName = "GetTip";
                                        gettip.Tips = tips;
                                        steps.Add(gettip);
                                        StepIndex++;
                                        mixed=false;

                                        pic = new Image();
                                        pic.Source = BitmapToBitmapImage(Filestore.Resource.GetTip);
                                        timer.Interval = new TimeSpan(0, 0, 0, durTime); // 设置定时器重复周期
                                        timer.Tick += new EventHandler(timerEvent);
                                        timer.Start();  // 启动定时器
                                        AddStep(step);
                                    }
                            }
                        }
                        else
                        {
                            MessageBox.Show("无足够可用的移液枪！", "Info", MessageBoxButton.OK, MessageBoxImage.Warning);
                        }
                        break;
                    }
                case 2:
                    {
                        if (!Tipped)
                        {
                            MessageBox.Show("请先加载枪头！", "Info", MessageBoxButton.OK, MessageBoxImage.Warning);
                            break;
                        }
                        else
                        {
                            move2x = 0; move2y = 0;
                            TrialEdit.Move move = new Move();
                            move.sendMessage = ReceiveM;
                            move.ShowDialog();
                            if (move2x != 0 && move2y != 0)
                            {
                                FlowDesign.Move move1 = new FlowDesign.Move();
                                move1.StepName = "Move";
                                move1.X = move2x;
                                move1.Y = move2y;
                                move1.Column = move2col;
                                steps.Add(move1);
                                step = "Move 移动枪头至：\n" + move2x + "列" + move2y + "行\n第" + move2col + "列";
                                time[timecnt] = ((move2x - PastX) * 12.5 + (move2y - PastY) * 10);
                                timecnt++;
                                PastX = move2x; PastY = move2y;
                                StepIndex++;
                                pic = new Image();
                                pic.Source = BitmapToBitmapImage(Filestore.Resource.Move);
                                timer.Interval = new TimeSpan(0, 0, 0, durTime); // 设置定时器重复周期
                                timer.Tick += new EventHandler(timerEvent);
                                timer.Start();  // 启动定时器
                                AddStep(step);
                            }
                            else
                            {
                                move2x = PastX;
                                move2y = PastY;
                            }
                            break;
                        }
                    }
                case 3:
                    {
                        if (move2x == 0 && move2y == 0)
                        {
                            MessageBox.Show("请先将枪头移动至有效位置！", "Info", MessageBoxButton.OK, MessageBoxImage.Warning);
                            break;
                        }
                        else if (aspirated)
                        {
                            MessageBox.Show("枪头不可重复吸液！", "Info", MessageBoxButton.OK, MessageBoxImage.Warning);
                            break;
                        }
                        else
                        {
                            var rawItemType = RawItemType;
                            Avolume = 0;
                            TrialEdit.Aspiration aspiration = new Aspiration(Station, move2x, move2y, move2col, TipNum);
                            aspiration.sendMessage = ReceiveA;
                            aspiration.UseRawItem = rawItemType;
                            aspiration.ShowDialog();
                            if (Avolume != 0)
                            {
                                aspirated = true;
                                FlowDesign.Aspiration aspiration1 = new FlowDesign.Aspiration();
                                aspiration1.StepName = "Aspiration";
                                aspiration1.EachVolume = Avolume;
                                steps.Add(aspiration1);
                                step = "Aspiration 吸液:\n吸取液体的容量为:\n" + Avolume * TipNum + "µL";
                                pic = new Image();
                                pic.Source = BitmapToBitmapImage(Filestore.Resource.Aspiration);
                                timer.Interval = new TimeSpan(0, 0, 0, durTime); // 设置定时器重复周期
                                timer.Tick += new EventHandler(timerEvent);
                                timer.Start();  // 启动定时器
                                Station.RGT[ColIndex].volume[move2col - 1] -= ((float)Avolume) / 1000 * TipNum;
                                StepIndex++;
                                time[timecnt]= 40;
                                timecnt++;
                                AddStep(step);
                                break;
                            }
                            else
                            {
                                break;
                            }
                        }
                    }
                case 4:
                    {
                        TrialEdit.Dispense1 dispense = new Dispense1(Station,move2x,move2y,Avolume);
                        FlowDesign.Dispense Dispense = new FlowDesign.Dispense();
                        dispense.sendMessage = RecieveD;
                        dispense.ShowDialog();
                        if(!dispensed)
                        {
                            if (DispenseVol != 0)
                            {
                                step = "Dispense 放液:每个枪头放液：\n" + DispenseVol + "µL";
                                Dispense.StepName = "Dispense";
                                Dispense.X = move2x;
                                Dispense.Y = move2y;
                                Dispense.Col = move2col;
                                Dispense.Vol = DispenseVol;
                                steps.Add(Dispense);
                                CanMix.Add(Dispense);
                                dispensed = true;
                                Avolume -= DispenseVol;
                                time[timecnt] = 40;
                                timecnt++;
                                StepIndex++;
                                pic = new Image();
                                pic.Source = BitmapToBitmapImage(Filestore.Resource.Dispense);
                                timer.Interval = new TimeSpan(0, 0, 0, durTime); // 设置定时器重复周期
                                timer.Tick += new EventHandler(timerEvent);
                                timer.Start();  // 启动定时器
                                AddStep(step);
                                DispenseVol = 0;
                                break;
                            }
                            else
                            {
                                break;
                            }
                        }
                        else
                        {
                            MessageBox.Show("此操作将造成气溶胶污染！", "Info", MessageBoxButton.OK, MessageBoxImage.Warning);
                            break;
                        }
                    }
                case 5:
                    {
                        if (Tipped)
                        {
                            if (Avolume == 0)
                            {
                                Tipped = false;
                                FlowDesign.DiscardTip discard = new FlowDesign.DiscardTip();
                                discard.StepName = "DiscardTip";
                                discard.Num = TipNum;
                                TipNum = 0;
                                steps.Add(discard);
                                step = "DiscardTip 释放枪头";
                                move2x = 0; move2y = 0;
                                time[timecnt]= PastX * 12.5 + PastY * 10 + 5;
                                timecnt++;
                                StepIndex++;
                                pic = new Image();
                                pic.Source = BitmapToBitmapImage(Filestore.Resource.DiscardTip);
                                timer.Interval = new TimeSpan(0, 0, 0, durTime); // 设置定时器重复周期
                                timer.Tick += new EventHandler(timerEvent);
                                timer.Start();  // 启动定时器
                                AddStep(step);
                                break;
                            }
                            else
                            {
                                MessageBox.Show("枪头中仍有液体，请弃液！", "Info", MessageBoxButton.OK, MessageBoxImage.Warning);
                                break;
                            }
                        }
                        else
                        {
                            MessageBox.Show("未加载枪头！", "Info", MessageBoxButton.OK, MessageBoxImage.Warning);
                            break;
                        }
                    }
                case 6:
                    {
                        bool canMix = false;
                        for (var i = 0; i < CanMix.Count; i++)
                        {
                            if (CanMix[i].X == move2x)
                            {
                                if (CanMix[i].Y == move2y)
                                {
                                    if (CanMix[i].Col == move2col)
                                    {
                                        if (CanMix[i].Vol != 0)
                                        {
                                            for (var j = 0; j < Station.CUM.Count; j++)
                                            {
                                                if (Station.CUM[j].x == (move2x - 1))
                                                {
                                                    if (Station.CUM[j].y == (move2y - 1))
                                                    {
                                                        if (Station.CUM[j].type == "96D" || Station.CUM[j].type == "96F")
                                                            canMix = true;
                                                        break;
                                                    }
                                                }
                                            }
                                            break;
                                        }
                                    }
                                }
                            }
                        }
                        if (!Tipped)
                        {
                            MessageBox.Show("请先加载枪头！", "Info", MessageBoxButton.OK, MessageBoxImage.Warning);
                            break;
                        }
                        else if (Avolume != 0)
                        {
                            MessageBox.Show("枪头内仍有液体，请先放液！", "Info", MessageBoxButton.OK, MessageBoxImage.Warning);
                            break;
                        }
                        else if (!canMix)
                        {
                            MessageBox.Show("所选区域无有效液体！", "Info", MessageBoxButton.OK, MessageBoxImage.Warning);
                            break;
                        }
                        else if (mixed)
                        {
                            MessageBox.Show("该枪头已混匀过液体，请丢弃！", "Info", MessageBoxButton.OK, MessageBoxImage.Warning);
                            break;
                        }
                        else
                        {
                            mixed = true;
                            TrialEdit.Mix mix = new TrialEdit.Mix();
                            mix.sendMessage = RecieveM;
                            mix.ShowDialog();
                            FlowDesign.Mix mix1 = new FlowDesign.Mix();
                            mix1.StepName = "Mix";
                            mix1.Strength = strength;
                            steps.Add(mix1);
                            step = "Mix 吹打混匀,强度为：" + strength;
                            if (strength == "低")
                            {
                                time[timecnt] = 45;
                                timecnt++;
                            }
                            else if (strength == "中")
                            {
                                time[timecnt] = 50;
                                timecnt++;
                            }
                            else
                            {
                                time[timecnt] = 55;
                                timecnt--;
                            }
                            StepIndex++;
                            pic = new Image();
                            pic.Source = BitmapToBitmapImage(Filestore.Resource.Mix);
                            timer.Interval = new TimeSpan(0, 0, 0, durTime); // 设置定时器重复周期
                            timer.Tick += new EventHandler(timerEvent);
                            timer.Start();  // 启动定时器
                            AddStep(step);
                            break;
                        }
                    }
                case 7:
                    {
                        if (Avolume == 0||!Tipped)
                        {
                            MessageBox.Show("无需弃液！", "Info", MessageBoxButton.OK, MessageBoxImage.Warning);
                            break;
                        }
                        else
                        {
                            step = "Let Flow 弃液并\n丢弃当前使用的枪头\n";
                            move2x = 0; move2y = 0;
                            time[timecnt]= (12.5 * PastX + 10 * PastY + 5);
                            timecnt++;
                            Tipped = false;
                            StepIndex++;
                            FlowDesign.LetFlow letflow = new FlowDesign.LetFlow();
                            letflow.StepName = "Let Flow";
                            letflow.RestVol = Avolume;
                            steps.Add(letflow);
                            pic = new Image();
                            pic.Source = BitmapToBitmapImage(Filestore.Resource.LetFlow);
                            timer.Interval = new TimeSpan(0, 0, 0, durTime); // 设置定时器重复周期
                            timer.Tick += new EventHandler(timerEvent);
                            timer.Start();  // 启动定时器
                            AddStep(step);
                            Avolume = 0;
                            break;
                        }
                    }
            }
        }
        
        /*private void DeleteContent(object sender,EventArgs e)
        {
            Editflow.Children.Remove(Changebutton);
            var btnName = Changebutton.Name;
            var New = ((int)(btnName[btnName.Length - 1]) - 48 + 1).ToString();
            btnName = btnName.Remove(6);
            btnName = btnName.Insert(6,New);
            MessageBox.Show(btnName);
        }*/
        int hasdeleted = 0;
        private void delete(object sender,RoutedEventArgs e)
        {
            if (StepIndex > 1)
            {
                if (MessageBox.Show("确认删除当前步骤？", "确认", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    if (colCount % 3 == 1)
                    {
                        MessageBox.Show((StepIndex * 3 + hasdeleted + 1).ToString());
                        for(var i = 0; i < 4; i++)
                        {
                            //Editflow.Children.RemoveAt(StepIndex * 3 + rowCount / 2 + 1);
                            Editflow.Children.RemoveAt(StepIndex * 3 + (rowCount - 4) / 2 + hasdeleted - 1);
                        }
                        rowCount -= 2;
                        colCount = 3;
                    }
                    else
                    {
                        for (var i = 0; i < 3; i++)
                        {
                            Editflow.Children.RemoveAt(StepIndex * 3 + (rowCount-2)/2 + hasdeleted - 1);
                        }
                        colCount--;
                    }
   
                    switch (GetPropertyNameValue(steps[steps.Count - 1]).ToString())
                    {
                        case "Grip":
                            {
                                GetGripValue(steps[steps.Count - 1]);
                                break;
                            }
                        case "Release":
                            {
                                GetReleaseValue(steps[steps.Count - 1]);
                                break;
                            }
                        case "GetTip":
                            {
                                Tipped = false;
                                TipNum= 0;
                                break;
                            }
                        case "DiscardTip":
                            {
                                var i = 0;
                                foreach (var prop in steps[steps.Count-1].GetType().GetProperties())
                                {
                                    if (i == 1)
                                    {
                                        TipNum = int.Parse(prop.GetValue(steps[steps.Count-1]).ToString());
                                    }
                                    i++;
                                }
                                Tipped= true;
                                GetMoveValue();
                                break;
                            }
                        case "Move":
                            {
                                GetMoveValue();
                                break;
                            }
                        case "Aspiration":
                            {
                                GetAspirationValue(steps[steps.Count - 1]);
                                break;
                            }
                        case "Dispense":
                            {
                                GetDispenseValue(steps[steps.Count - 1]);
                                dispensed = false;
                                break;
                            }
                        case "Let Flow":
                            {
                                Tipped = true;
                                var i = 0;
                                foreach (var prop in steps[steps.Count - 1].GetType().GetProperties())
                                {
                                    if (i == 1)
                                    {
                                        Avolume = int.Parse(prop.GetValue(steps[steps.Count - 1]).ToString());
                                    }
                                    i++;
                                }
                                GetMoveValue();
                                break;
                            }
                    }
                    steps.RemoveAt(steps.Count - 1);
                    StepIndex--;
                    timecnt--;
                    time[timecnt] = 0;
                }
            }
            else if(StepIndex == 1)
            {
                if (MessageBox.Show("确认删除当前步骤？", "确认", MessageBoxButton.YesNo) == MessageBoxResult.Yes)
                {
                    switch (GetPropertyNameValue(steps[steps.Count - 1]).ToString())
                    {
                        case "Grip":
                            {
                                GetGripValue(steps[steps.Count - 1]);
                                break;
                            }
                        case "Release":
                            {
                                GetReleaseValue(steps[steps.Count - 1]);
                                break;
                            }
                        case "GetTip":
                            {
                                Tipped = false;
                                TipNum = 0;
                                break;
                            }
                        case "DiscardTip":
                            {
                                var i = 0;
                                foreach (var prop in steps[steps.Count - 1].GetType().GetProperties())
                                {
                                    if (i == 1)
                                    {
                                        TipNum = int.Parse(prop.GetValue(steps[steps.Count - 1]).ToString());
                                    }
                                    i++;
                                }
                                break;
                            }
                        case "Let Flow":
                            {
                                Tipped = true;
                                var i = 0;
                                foreach (var prop in steps[steps.Count - 1].GetType().GetProperties())
                                {
                                    if (i == 1)
                                    {
                                        Avolume = int.Parse(prop.GetValue(steps[steps.Count - 1]).ToString());
                                    }
                                    i++;
                                }
                                break;
                            }
                        case "Move":
                            {
                                GetMoveValue();
                                break;
                            }
                        case "Aspiration":
                            {
                                GetAspirationValue(steps[steps.Count - 1]);
                                break;
                            }
                        case "Dispense":
                            {
                                GetDispenseValue(steps[steps.Count - 1]);
                                dispensed = false;
                                break;
                            }
                    }
                    steps.RemoveAt(steps.Count - 1);
                    for (var i = 0; i < 2; i++)
                    {
                        Editflow.Children.RemoveAt(StepIndex * 3 + (rowCount - 2) / 2 + hasdeleted);
                    }
                    StepIndex--;
                    timecnt--;
                    time[timecnt] = 0;
                    colCount = 0;
                    rowCount = 0;
                    hasdeleted += 2;
                }
            }
        }
        public static object GetPropertyNameValue(object info)
        {
            if (info == null) return null;
            Type t=info.GetType();
            IEnumerable<System.Reflection.PropertyInfo> properties = t.GetProperties();
            return properties.First().GetValue(info, null);
        }
        public int delX, delY;
        public float avolume;
        public void GetDispenseValue(object dispense)
        {
            var i = 0;
            foreach(var prop in dispense.GetType().GetProperties())
            {
                if (i == 4)
                {
                    Avolume += int.Parse(prop.GetValue(dispense).ToString());
                }
                i++;
            }
            CanMix.Remove(CanMix[CanMix.Count - 1]);
        }
        public void GetAspirationValue(object aspiration)
        {
            var i = 0;
            foreach(var prop in aspiration.GetType().GetProperties())
            {
                if (i == 1)
                {
                    avolume = float.Parse(prop.GetValue(aspiration).ToString());
                }
                i++;
            }
            Station.RGT[ColIndex].volume[move2col - 1] += avolume / 1000 * TipNum;
            Avolume = 0;
            aspirated = false;
        }
        public void GetMoveValue()
        {
            bool hasmoved = false;
            for(var i = 2; i < steps.Count; i++)
            {
                Type t = steps[steps.Count - i].GetType();
                //IEnumerable<System.Reflection.PropertyInfo> properties = t.GetProperties();
                var j = 0;
                foreach (var prop in steps[steps.Count - i].GetType().GetProperties())
                {
                    if (j == 0)
                    {
                        if (prop.GetValue(steps[steps.Count - i]).ToString() == "Move")
                        { 
                            hasmoved = true;
                            j++;
                        }
                    }
                    if (hasmoved)
                    {
                        if (j == 2)
                        { 
                            move2x = int.Parse(prop.GetValue(steps[steps.Count - i]).ToString());
                            PastX = move2x;
                        }
                        else if (j == 3)
                        {
                            move2y = int.Parse(prop.GetValue(steps[steps.Count - i]).ToString());
                            PastY = move2y;
                        }
                        else if (j == 4)
                        {
                            move2col = int.Parse(prop.GetValue(steps[steps.Count - i]).ToString());
                        }
                        j++;
                    }
                }
                if (hasmoved)
                {
                    MessageBox.Show("上一move参数" + move2x.ToString() + "," + move2y.ToString(), "Info", MessageBoxButton.OK, MessageBoxImage.Information);
                    break;
                }
            }
            if (!hasmoved)
            {
                move2x = 0; PastX = 0; PastY = 0;
                move2y = 0;
                move2col= 0;
            }
        }
        public string GetGripValue(object grip)
        {
            int i = 0;
            
            string Type = "";
            foreach (var property in grip.GetType().GetProperties())
            {
                if(i == 0)
                {

                }
                else if(i == 1)
                {
                    delX = int.Parse(property.GetValue(grip).ToString());
                }
                else if(i == 2)
                {
                    delY = int.Parse(property.GetValue(grip).ToString());
                }
                else if (i == 3)
                {
                    Type = property.GetValue(grip).ToString();
                    if(Type == "枪头盒")
                    {
                        Station.Stack.Tip++;
                        tipnum -= 12;
                    }
                    else if(Type == "96孔深孔板"){
                        Station.Stack.D96++;
                    }
                    else if (Type == "96孔浅孔板")
                    {
                        Station.Stack.S96++;
                    }
                }
                Station.delete(delX-1,delY-1);
                //MessageBox.Show(property.GetValue(grip).ToString());
                i++;
            }
            
            return grip.ToString();
        }
        public string GetReleaseValue(object release)
        {
            int i = 0;

            string Type = "";
            foreach (var property in release.GetType().GetProperties())
            {
                if (i == 0)
                {

                }
                else if (i == 1)
                {
                    delX=int.Parse(property.GetValue(release).ToString());
                }
                else if (i == 2)
                {
                    delY = int.Parse(property.GetValue(release).ToString());
                }
                else if(i == 3)
                {
                    Type = property.GetValue(release).ToString();
                }
               // MessageBox.Show(property.GetValue(release).ToString());
                i++;
            }
            Station.record1(delX,delY,Type);
            return release.ToString();
        }
        private void AddStep(string step)
        {
            Button btn = new Button
            {
                Name = "Button" + StepIndex.ToString(),
                Content = step,
                FontSize = 15,
                Height = 70,
                Width = 200,
                Margin = new Thickness(0),
                VerticalAlignment = VerticalAlignment.Top,
                Visibility = Visibility.Visible,
            };
            //btn.MouseDoubleClick += new MouseButtonEventHandler(button_Click);
            Image img1 = new Image();
            if (colCount % 3 == 0)
            {
                if (rowCount > 7)
                {
                    Editflow.RowDefinitions.Add(new RowDefinition());
                    Editflow.RowDefinitions.Add(new RowDefinition());
                    Editflow.RowDefinitions.Add(new RowDefinition());
                }
                if (rowCount != 0)
                {
                    if ((rowCount/2) % 2 != 0)
                    {
                        img1.Source = BitmapToBitmapImage(Filestore.Resource.Right);
                        img1.SetValue(Grid.ColumnProperty, 6);
                        img1.SetValue(Grid.RowProperty, rowCount-1);
                    }
                    else
                    {
                        img1.Source = BitmapToBitmapImage(Filestore.Resource.Left);
                        img1.SetValue(Grid.ColumnProperty, 0);
                        img1.SetValue(Grid.RowProperty, rowCount-1);
                    }
                }
                Editflow.Children.Add(img1);
                colCount = 0;
                rowCount+=2;
            }
            btn.SetValue(Grid.RowProperty, rowCount);
            pic.SetValue(Grid.RowProperty, rowCount - 1);
            Image img = new Image();
            img.SetValue(Grid.RowProperty, rowCount - 1);
            //BitmapImage bmp2 = new BitmapImage(new Uri(@"\\Mac\Home\Desktop\图标\左向箭头.png"));
            if ((rowCount/2) % 2 != 0)
            {
                if (StepIndex != 1)
                {
                    img.Source = BitmapToBitmapImage(Filestore.Resource.Right);
                    img.SetValue(Grid.ColumnProperty, colCount * 2);
                }
                btn.SetValue(Grid.ColumnProperty, colCount++ * 2 + 1);
                pic.SetValue(Grid.ColumnProperty, (colCount - 1) * 2 + 1);
            }
            else
            {
                img.Source = BitmapToBitmapImage(Filestore.Resource.Left);
                img.SetValue(Grid.ColumnProperty, 6 - colCount * 2);
                btn.SetValue(Grid.ColumnProperty, 6 - (colCount++ * 2 + 1));
                pic.SetValue(Grid.ColumnProperty, 6 - ((colCount - 1) * 2 + 1));
            }
            Editflow.Children.Add(img);
            Editflow.Children.Add(pic);
            Editflow.Children.Add(btn);
            Tip.SelectedIndex = 0;
            Tongs.SelectedIndex = 0;
        }
        List<object> steps = new List<object>();
    }
}
