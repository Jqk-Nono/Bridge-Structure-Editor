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
using System.Windows.Navigation;
using System.Windows.Shapes;
//using BridgeManagement.cs;
using System.Windows.Media.Animation;
using System.ComponentModel;
using System.Collections.ObjectModel;
using Microsoft.Win32;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using System.Threading;
using BridgeBaseComponents;

namespace 新建桥类
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public void Notify(string propName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
            }
        }
        public Bridge newBridgeType { get; set; }

        public string _桥梁类型名称;
        public string 桥梁类型名称
        {
            get { return _桥梁类型名称; }
            set { _桥梁类型名称 = value; Notify("桥梁类型名称"); }
        }

        #region 基本信息数据Controls
        ObservableCollection<一条基础记录> _基本信息记录项目集合 = new ObservableCollection<一条基础记录>() { new 一条基础记录() };
        public ObservableCollection<一条基础记录> 基本信息记录项目集合
        {
            get
            {
                return _基本信息记录项目集合;
            }
            set
            {
                _基本信息记录项目集合 = value;
            }
        }

        ObservableCollection<一条基础记录> _基本参数记录项目集合 = new ObservableCollection<一条基础记录>() { new 一条基础记录() };
        public ObservableCollection<一条基础记录> 基本参数记录项目集合
        {
            get
            {
                return _基本参数记录项目集合;
            }
            set
            {
                _基本参数记录项目集合 = value;
            }
        }

        ObservableCollection<一条基础记录> _结构简图记录项目集合 = new ObservableCollection<一条基础记录>() { new 一条基础记录() };
        public ObservableCollection<一条基础记录> 结构简图记录项目集合
        {
            get
            {
                return _结构简图记录项目集合;
            }
            set
            {
                _结构简图记录项目集合 = value;
            }
        }
        #endregion

        #region 养护管理数据Controls
        ObservableCollection<一个一级部件> _桥面系一级部件集合 = new ObservableCollection<一个一级部件>() { new 一个一级部件() };
        public ObservableCollection<一个一级部件> 桥面系一级部件集合
        {
            get
            {
                return _桥面系一级部件集合;
            }
            set
            {
                _桥面系一级部件集合 = value;
            }
        }

        ObservableCollection<一个一级部件> _上部结构一级部件集合 = new ObservableCollection<一个一级部件>() { new 一个一级部件() };
        public ObservableCollection<一个一级部件> 上部结构一级部件集合
        {
            get
            {
                return _上部结构一级部件集合;
            }
            set
            {
                _上部结构一级部件集合 = value;
            }
        }

        ObservableCollection<一个一级部件> _下部结构一级部件集合 = new ObservableCollection<一个一级部件>() { new 一个一级部件() };
        public ObservableCollection<一个一级部件> 下部结构一级部件集合
        {
            get
            {
                return _下部结构一级部件集合;
            }
            set
            {
                _下部结构一级部件集合 = value;
            }
        }

        string _桥面系一级部件名称集合;
        public string 桥面系一级部件名称集合
        {
            get { return _桥面系一级部件名称集合; }
            set { _桥面系一级部件名称集合 = value; Notify("桥面系一级部件名称集合"); }
        }

        string _上部结构一级部件名称集合;
        public string 上部结构一级部件名称集合
        {
            get { return _上部结构一级部件名称集合; }
            set { _上部结构一级部件名称集合 = value; Notify("上部结构一级部件名称集合"); }
        }

        string _下部结构一级部件名称集合;
        public string 下部结构一级部件名称集合
        {
            get { return _下部结构一级部件名称集合; }
            set { _下部结构一级部件名称集合 = value; Notify("下部结构一级部件名称集合"); }
        }

        double _桥面系权重;
        public double 桥面系权重
        {
            get { return _桥面系权重; }
            set { _桥面系权重 = value; Notify("桥面系权重"); }
        }
        double _上部结构权重;
        public double 上部结构权重
        {
            get { return _上部结构权重; }
            set { _上部结构权重 = value; Notify("上部结构权重"); }
        }
        double _下部结构权重;
        public double 下部结构权重
        {
            get { return _下部结构权重; }
            set { _下部结构权重 = value; Notify("下部结构权重"); }
        }

        #endregion

        #region 基本信息数据参数
        private 基本信息数据 _基本信息数据参数 = new 基本信息数据();
        public 基本信息数据 基本信息数据参数
        {
            get { return _基本信息数据参数; }
            set { _基本信息数据参数 = value; Notify("基本信息数据参数"); }
        }

        private 基本信息数据组成结构 _基本信息记录项目集合参数 = new 基本信息数据组成结构("基本信息");
        public 基本信息数据组成结构 基本信息记录项目集合参数
        {
            get { return _基本信息记录项目集合参数; }
            set { _基本信息记录项目集合参数 = value; Notify("基本信息记录项目集合参数"); }
        }

        private 基本信息数据组成结构 _基本参数记录项目集合参数 = new 基本信息数据组成结构("基本参数");
        public 基本信息数据组成结构 基本参数记录项目集合参数
        {
            get { return _基本参数记录项目集合参数; }
            set { _基本参数记录项目集合参数 = value; Notify("基本参数记录项目集合参数"); }
        }

        private 基本信息数据组成结构 _结构简图记录项目集合参数 = new 基本信息数据组成结构("结构简图");
        public 基本信息数据组成结构 结构简图记录项目集合参数
        {
            get { return _结构简图记录项目集合参数; }
            set { _结构简图记录项目集合参数 = value; Notify("结构简图记录项目集合参数"); }
        }
        #endregion

        #region 养护管理数据参数
        private 养护管理数据 _养护管理数据参数 = new 养护管理数据();
        public 养护管理数据 养护管理数据参数
        {
            get { return _养护管理数据参数; }
            set { _养护管理数据参数 = value; Notify("养护管理数据参数"); }
        }

        private 桥梁组成结构 _桥面系组成结构 = new 桥梁组成结构("桥面系", 0.2);
        public 桥梁组成结构 桥面系组成结构
        {
            get { return _桥面系组成结构; }
            set { _桥面系组成结构 = value; Notify("桥面系组成结构"); }
        }

        private 桥梁组成结构 _上部结构组成结构 = new 桥梁组成结构("上部结构", 0.4);
        public 桥梁组成结构 上部结构组成结构
        {
            get { return _上部结构组成结构; }
            set { _上部结构组成结构 = value; Notify("上部结构组成结构"); }
        }

        private 桥梁组成结构 _下部结构组成结构 = new 桥梁组成结构("下部结构", 0.4);
        public 桥梁组成结构 下部结构组成结构
        {
            get { return _下部结构组成结构; }
            set { _下部结构组成结构 = value; Notify("下部结构组成结构"); }
        }
        #endregion

        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = this;
            var cancellationTokenSource = new CancellationTokenSource();
            var task = Repeat.Interval(TimeSpan.FromSeconds(3), () => SavingWork(), cancellationTokenSource.Token);
        }
        private void SavingWork()
        {
            //MessageBox.Show(DateTime.Now.ToShortTimeString());
            //testText.Text = "a";
            ObtainDataContent();

            FileStream newfile = File.Create(@"C:\Users\lee\Desktop\1.txt");
            byte[] contentString = Encoding.UTF8.GetBytes(DateTime.Now.ToLongTimeString());
            newfile.Write(contentString, 0, contentString.Length);
            newfile.Flush();
            newfile.Close();
        }

        protected override void OnClosing(CancelEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("是否保存当前窗口内的内容？", "确认关闭窗口", MessageBoxButton.YesNoCancel, MessageBoxImage.Warning);
            if (result == MessageBoxResult.Yes)
            {
                e.Cancel = true;
                导出button.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
            }
            if (result == MessageBoxResult.Cancel)
            {
                e.Cancel = true;
            }
            if (result == MessageBoxResult.No)
            {
                base.OnClosing(e);
            }
        }
        private void Expander_Expanded(object sender, RoutedEventArgs e)
        {
            Expander expander = sender as Expander;
            if (expander == expander1)
            {
                GridLengthConverter gridLengthConverter = new GridLengthConverter();
                g1.Height = (GridLength)gridLengthConverter.ConvertFrom("*");
                g2.Height = GridLength.Auto;
                g3.Height = GridLength.Auto;
                expander1.IsExpanded = true;
                expander2.IsExpanded = false;
                expander3.IsExpanded = false;
            }
            if (expander == expander2)
            {
                GridLengthConverter gridLengthConverter = new GridLengthConverter();
                g1.Height = GridLength.Auto;
                g2.Height = (GridLength)gridLengthConverter.ConvertFrom("*");
                g3.Height = GridLength.Auto;
                expander1.IsExpanded = false;
                expander2.IsExpanded = true;
                expander3.IsExpanded = false;
            }
            if (expander == expander3)
            {
                GridLengthConverter gridLengthConverter = new GridLengthConverter();
                g1.Height = GridLength.Auto;
                g2.Height = GridLength.Auto;
                g3.Height = (GridLength)gridLengthConverter.ConvertFrom("*");
                expander1.IsExpanded = false;
                expander2.IsExpanded = false;
                expander3.IsExpanded = true;
            }
        }

        private void expander4_Expanded(object sender, RoutedEventArgs e)
        {
            Expander expander = sender as Expander;
            if (expander == expander4)
            {
                GridLengthConverter gridLengthConverter = new GridLengthConverter();
                g4.Height = (GridLength)gridLengthConverter.ConvertFrom("*");
                g5.Height = GridLength.Auto;
                g6.Height = GridLength.Auto;
                expander4.IsExpanded = true;
                expander5.IsExpanded = false;
                expander6.IsExpanded = false;
            }
            if (expander == expander5)
            {
                GridLengthConverter gridLengthConverter = new GridLengthConverter();
                g4.Height = GridLength.Auto;
                g5.Height = (GridLength)gridLengthConverter.ConvertFrom("*");
                g6.Height = GridLength.Auto;
                expander4.IsExpanded = false;
                expander5.IsExpanded = true;
                expander6.IsExpanded = false;
            }
            if (expander == expander6)
            {
                GridLengthConverter gridLengthConverter = new GridLengthConverter();
                g4.Height = GridLength.Auto;
                g5.Height = GridLength.Auto;
                g6.Height = (GridLength)gridLengthConverter.ConvertFrom("*");
                expander4.IsExpanded = false;
                expander5.IsExpanded = false;
                expander6.IsExpanded = true;
            }
        }

        private void ObtainDataContent()
        {
            基本信息记录项目集合参数.基础记录项目集合.Clear();
            foreach (一条基础记录 s in 基本信息记录项目集合)
            {
                基本信息记录项目集合参数.基础记录项目集合.Add(s.基础记录项目参数);
            }
            this.基本信息数据参数.基本信息记录项目结构 = 基本信息记录项目集合参数;

            基本参数记录项目集合参数.基础记录项目集合.Clear();
            foreach (一条基础记录 s in 基本参数记录项目集合)
            {
                基本参数记录项目集合参数.基础记录项目集合.Add(s.基础记录项目参数);
            }
            this.基本信息数据参数.基本参数记录项目结构 = 基本参数记录项目集合参数;

            结构简图记录项目集合参数.基础记录项目集合.Clear();
            foreach (一条基础记录 s in 结构简图记录项目集合)
            {
                结构简图记录项目集合参数.基础记录项目集合.Add(s.基础记录项目参数);
            }
            this.基本信息数据参数.结构简图记录项目结构 = 结构简图记录项目集合参数;

            桥面系组成结构.桥梁组成一级部件集合.Clear();
            foreach (一个一级部件 s in 桥面系一级部件集合)
            {
                s.桥梁组成一级部件参数.桥梁组成二级部件集合.Clear();
                foreach (一个二级部件 ss in s.二级部件集合)
                {
                    ss.桥梁组成二级部件参数.检查指标集合.Clear();
                    foreach (一条指标 sss in ss.指标集合)
                    {
                        sss.检查指标.标度及其说明集合.Clear();
                        foreach (一条标度及说明 ssss in sss.标度及其说明集合)
                        {
                            sss.检查指标.标度及其说明集合.Add(ssss.标度及其说明);
                        }
                        ss.桥梁组成二级部件参数.检查指标集合.Add(sss.检查指标);
                    }
                    s.桥梁组成一级部件参数.桥梁组成二级部件集合.Add(ss.桥梁组成二级部件参数);
                }
                桥面系组成结构.桥梁组成一级部件集合.Add(s.桥梁组成一级部件参数);
            }

            上部结构组成结构.桥梁组成一级部件集合.Clear();
            foreach (一个一级部件 s in 上部结构一级部件集合)
            {
                s.桥梁组成一级部件参数.桥梁组成二级部件集合.Clear();
                foreach (一个二级部件 ss in s.二级部件集合)
                {
                    ss.桥梁组成二级部件参数.检查指标集合.Clear();
                    foreach (一条指标 sss in ss.指标集合)
                    {
                        sss.检查指标.标度及其说明集合.Clear();
                        foreach (一条标度及说明 ssss in sss.标度及其说明集合)
                        {
                            sss.检查指标.标度及其说明集合.Add(ssss.标度及其说明);
                        }
                        ss.桥梁组成二级部件参数.检查指标集合.Add(sss.检查指标);
                    }
                    s.桥梁组成一级部件参数.桥梁组成二级部件集合.Add(ss.桥梁组成二级部件参数);
                }
                上部结构组成结构.桥梁组成一级部件集合.Add(s.桥梁组成一级部件参数);
            }

            下部结构组成结构.桥梁组成一级部件集合.Clear();
            foreach (一个一级部件 s in 下部结构一级部件集合)
            {
                s.桥梁组成一级部件参数.桥梁组成二级部件集合.Clear();
                foreach (一个二级部件 ss in s.二级部件集合)
                {
                    ss.桥梁组成二级部件参数.检查指标集合.Clear();
                    foreach (一条指标 sss in ss.指标集合)
                    {
                        sss.检查指标.标度及其说明集合.Clear();
                        foreach (一条标度及说明 ssss in sss.标度及其说明集合)
                        {
                            sss.检查指标.标度及其说明集合.Add(ssss.标度及其说明);
                        }
                        ss.桥梁组成二级部件参数.检查指标集合.Add(sss.检查指标);
                    }
                    s.桥梁组成一级部件参数.桥梁组成二级部件集合.Add(ss.桥梁组成二级部件参数);
                }
                下部结构组成结构.桥梁组成一级部件集合.Add(s.桥梁组成一级部件参数);
            }
            this.养护管理数据参数.桥面系 = 桥面系组成结构;
            this.养护管理数据参数.上部结构 = 上部结构组成结构;
            this.养护管理数据参数.下部结构 = 下部结构组成结构;

            newBridgeType = new Bridge();
            newBridgeType.桥梁类型名称 = 桥梁类型名称;
            newBridgeType.基本信息数据 = 基本信息数据参数;
            newBridgeType.养护管理数据 = 养护管理数据参数;

        }

        private void 导入_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.DefaultExt = ".xml";
            ofd.Filter = "xml|*.xml";
            ofd.ShowDialog();
            if (!String.IsNullOrEmpty(ofd.FileName) && ofd.CheckFileExists && ofd.CheckPathExists)
            {
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(ofd.FileName);

                XmlNode BRIDGENode = xmlDoc.DocumentElement.SelectSingleNode("/BRIDGE");
                this.桥梁类型名称 = BRIDGENode.Attributes["桥梁类型名称"].Value;

                #region 基本信息数据
                XmlNode 基本信息数据 = xmlDoc.DocumentElement.SelectSingleNode("/BRIDGE/基本信息数据");
                foreach (XmlNode 基本信息数据组成结构 in 基本信息数据)
                {
                    if (基本信息数据组成结构.Attributes["结构名称"].Value == "基本信息")
                    {
                        导入基本信息数据组成结构(基本信息数据组成结构, 基本信息记录项目集合);
                        #region MyRegion
                        //基本信息记录项目集合.Clear();
                        //foreach (XmlNode 基础记录项目 in 基本信息数据组成结构)
                        //{
                        //    一条基础记录 s = new 一条基础记录(false);
                        //    s.基础记录项目参数.描述名称 = 基础记录项目.Attributes["描述名称"].Value;
                        //    int result;
                        //    s.基础记录项目参数.最大长度 = int.TryParse(基础记录项目.Attributes["最大长度"].Value, out result) ? result : 300;
                        //    基本信息记录项目集合.Add(s);
                        //}
                        ////基本信息记录项目集合.Add(new 一条基础记录());
                        //一条基础记录 temp = new 一条基础记录();
                        //temp.基础记录项目参数.描述名称 = 基本信息记录项目集合.Last().基础记录项目参数.描述名称;
                        //temp.基础记录项目参数.最大长度 = 基本信息记录项目集合.Last().基础记录项目参数.最大长度;
                        ////temp.基础记录项目参数 = 基本信息记录项目集合.Last().基础记录项目参数;
                        //基本信息记录项目集合[基本信息记录项目集合.Count - 1] = temp;
                        #endregion
                    }
                    if (基本信息数据组成结构.Attributes["结构名称"].Value == "基本参数")
                    {
                        导入基本信息数据组成结构(基本信息数据组成结构, 基本参数记录项目集合);
                    }
                    if (基本信息数据组成结构.Attributes["结构名称"].Value == "结构简图")
                    {
                        导入基本信息数据组成结构(基本信息数据组成结构, 结构简图记录项目集合);
                    }
                }
                #endregion

                #region 养护管理数据
                XmlNode 养护管理数据 = xmlDoc.DocumentElement.SelectSingleNode("/BRIDGE/养护管理数据");
                foreach (XmlNode 桥梁组成结构 in 养护管理数据)
                {
                    if (桥梁组成结构.Attributes["名称"].Value == "桥面系")
                    {
                        导入桥梁组成结构(桥梁组成结构, 桥面系一级部件集合);
                        double result;
                        double.TryParse(桥梁组成结构.Attributes["权重"].Value, out result);
                        桥面系权重 = result;
                        #region MyRegion
                        //桥面系一级部件集合.Clear();
                        //foreach (XmlNode 桥梁组成一级部件 in 桥梁组成结构)
                        //{
                        //    一个一级部件 s = new 一个一级部件(false);
                        //    s.二级部件集合.Clear();
                        //    s.桥梁组成一级部件参数.部件名称 = 桥梁组成一级部件.Attributes["部件名称"].Value;
                        //    bool sbResult;
                        //    s.桥梁组成一级部件参数.是否主要部件 = bool.TryParse(桥梁组成一级部件.Attributes["是否主要部件"].Value, out sbResult) ? sbResult : false;
                        //    double sdResult;
                        //    s.桥梁组成一级部件参数.部件权重 = double.TryParse(桥梁组成一级部件.Attributes["部件权重"].Value, out sdResult) ? sdResult : 0;
                        //    foreach (XmlNode 桥梁组成二级部件 in 桥梁组成一级部件)
                        //    {
                        //        一个二级部件 ss = new 一个二级部件(false);
                        //        ss.指标集合.Clear();
                        //        bool ssbResult;
                        //        ss.桥梁组成二级部件参数.是否主要部件 = bool.TryParse(桥梁组成二级部件.Attributes["是否主要部件"].Value, out ssbResult) ? ssbResult : false;
                        //        int ssiResult;
                        //        ss.桥梁组成二级部件参数.构件数 = int.TryParse(桥梁组成二级部件.Attributes["构件数"].Value, out ssiResult) ? ssiResult : 1;
                        //        ss.桥梁组成二级部件参数.部件名称 = 桥梁组成二级部件.Attributes["部件名称"].Value;
                        //        double ssdResult;
                        //        ss.桥梁组成二级部件参数.部件权重 = double.TryParse(桥梁组成二级部件.Attributes["部件权重"].Value, out ssdResult) ? ssdResult : 0;
                        //        foreach (XmlNode 检查指标 in 桥梁组成二级部件)
                        //        {
                        //            一条指标 sss = new 一条指标(false);
                        //            sss.标度及其说明集合.Clear();
                        //            sss.检查指标.指标名称 = 检查指标.Attributes["指标名称"].Value;
                        //            foreach (XmlNode 标度及其说明 in 检查指标)
                        //            {
                        //                一条标度及说明 ssss = new 一条标度及说明();
                        //                int iResult;
                        //                ssss.标度及其说明.标度 = int.TryParse(标度及其说明.Attributes["标度"].Value, out iResult) ? iResult : 0;
                        //                bool ssssbResult;
                        //                ssss.标度及其说明.是否存在 = bool.TryParse(标度及其说明.Attributes["是否存在"].Value, out ssssbResult) ? ssssbResult : false;
                        //                ssss.标度及其说明.定性说明 = 标度及其说明.Attributes["定性说明"].Value;
                        //                ssss.标度及其说明.定量说明 = 标度及其说明.Attributes["定量说明"].Value;
                        //                sss.标度及其说明集合.Add(ssss);
                        //            }
                        //            ss.指标集合.Add(sss);
                        //        }
                        //        //ss.指标集合.Add(new 一条指标());
                        //        一条指标 temp0 = new 一条指标();
                        //        temp0.检查指标.指标名称 = ss.指标集合.Last().检查指标.指标名称;
                        //        temp0.检查指标.标度及其说明集合 = ss.指标集合.Last().检查指标.标度及其说明集合;
                        //        ss.指标集合[ss.指标集合.Count - 1] = temp0;

                        //        s.二级部件集合.Add(ss);
                        //    }
                        //    //s.二级部件集合.Add(new 一个二级部件());
                        //    一个二级部件 temp1 = new 一个二级部件();
                        //    temp1.桥梁组成二级部件参数.IsExist = s.二级部件集合.Last().桥梁组成二级部件参数.IsExist;
                        //    temp1.桥梁组成二级部件参数.是否主要部件 = s.二级部件集合.Last().桥梁组成二级部件参数.是否主要部件;
                        //    temp1.桥梁组成二级部件参数.构件数 = s.二级部件集合.Last().桥梁组成二级部件参数.构件数;
                        //    temp1.桥梁组成二级部件参数.检查指标集合 = s.二级部件集合.Last().桥梁组成二级部件参数.检查指标集合;
                        //    temp1.桥梁组成二级部件参数.部件名称 = s.二级部件集合.Last().桥梁组成二级部件参数.部件名称;
                        //    temp1.桥梁组成二级部件参数.部件权重 = s.二级部件集合.Last().桥梁组成二级部件参数.部件权重;
                        //    s.二级部件集合[s.二级部件集合.Count - 1] = temp1;

                        //    桥面系一级部件集合.Add(s);
                        //}
                        ////桥面系一级部件集合.Add(new 一个一级部件());
                        //一个一级部件 temp2 = new 一个一级部件();
                        //temp2.桥梁组成一级部件参数.是否主要部件 = 桥面系一级部件集合.Last().桥梁组成一级部件参数.是否主要部件;
                        //temp2.桥梁组成一级部件参数.桥梁组成二级部件集合 = 桥面系一级部件集合.Last().桥梁组成一级部件参数.桥梁组成二级部件集合;
                        //temp2.桥梁组成一级部件参数.部件名称 = 桥面系一级部件集合.Last().桥梁组成一级部件参数.部件名称;
                        //temp2.桥梁组成一级部件参数.部件权重 = 桥面系一级部件集合.Last().桥梁组成一级部件参数.部件权重;

                        //桥面系一级部件集合[桥面系一级部件集合.Count - 1] = temp2;
                        #endregion
                    }

                    if (桥梁组成结构.Attributes["名称"].Value == "上部结构")
                    {
                        导入桥梁组成结构(桥梁组成结构, 上部结构一级部件集合);
                        double result;
                        double.TryParse(桥梁组成结构.Attributes["权重"].Value, out result);
                        上部结构权重 = result;
                    }

                    if (桥梁组成结构.Attributes["名称"].Value == "下部结构")
                    {
                        导入桥梁组成结构(桥梁组成结构, 下部结构一级部件集合);
                        double result;
                        double.TryParse(桥梁组成结构.Attributes["权重"].Value, out result);
                        下部结构权重 = result;
                    }
                }
                #endregion
            }
        }

        private void 导入基本信息数据组成结构(XmlNode 基本信息数据组成结构, ObservableCollection<一条基础记录> 记录项目集合)
        {
            记录项目集合.Clear();
            foreach (XmlNode 基础记录项目 in 基本信息数据组成结构)
            {
                一条基础记录 s = new 一条基础记录(false);
                s.基础记录项目参数.描述名称 = 基础记录项目.Attributes["描述名称"].Value;
                int result;
                s.基础记录项目参数.最大长度 = int.TryParse(基础记录项目.Attributes["最大长度"].Value, out result) ? result : 300;
                记录项目集合.Add(s);
            }
            一条基础记录 temp = new 一条基础记录();
            temp.基础记录项目参数.描述名称 = 记录项目集合.Last().基础记录项目参数.描述名称;
            temp.基础记录项目参数.最大长度 = 记录项目集合.Last().基础记录项目参数.最大长度;
            记录项目集合[记录项目集合.Count - 1] = temp;
        }

        private void 导入桥梁组成结构(XmlNode 桥梁组成结构, ObservableCollection<一个一级部件> 一级部件集合)
        {
            一级部件集合.Clear();
            foreach (XmlNode 桥梁组成一级部件 in 桥梁组成结构)
            {
                一个一级部件 s = new 一个一级部件(false);
                s.二级部件集合.Clear();
                s.桥梁组成一级部件参数.部件名称 = 桥梁组成一级部件.Attributes["部件名称"].Value;
                bool sbResult;
                s.桥梁组成一级部件参数.是否主要部件 = bool.TryParse(桥梁组成一级部件.Attributes["是否主要部件"].Value, out sbResult) ? sbResult : false;
                double sdResult;
                s.桥梁组成一级部件参数.部件权重 = double.TryParse(桥梁组成一级部件.Attributes["部件权重"].Value, out sdResult) ? sdResult : 0;
                bool sb2Result;
                s.桥梁组成一级部件参数.IsExist = bool.TryParse(桥梁组成一级部件.Attributes["IsExist"].Value, out sb2Result) ? sb2Result : false;
                MessageBox.Show(桥梁组成一级部件.Attributes["IsExist"].Value);
                MessageBox.Show(s.桥梁组成一级部件参数.IsExist.ToString());
                foreach (XmlNode 桥梁组成二级部件 in 桥梁组成一级部件)
                {
                    一个二级部件 ss = new 一个二级部件(false);
                    ss.指标集合.Clear();
                    bool ssbResult;
                    ss.桥梁组成二级部件参数.是否主要部件 = bool.TryParse(桥梁组成二级部件.Attributes["是否主要部件"].Value, out ssbResult) ? ssbResult : false;
                    int ssiResult;
                    ss.桥梁组成二级部件参数.构件数 = int.TryParse(桥梁组成二级部件.Attributes["构件数"].Value, out ssiResult) ? ssiResult : 1;
                    ss.桥梁组成二级部件参数.部件名称 = 桥梁组成二级部件.Attributes["部件名称"].Value;
                    double ssdResult;
                    ss.桥梁组成二级部件参数.部件权重 = double.TryParse(桥梁组成二级部件.Attributes["部件权重"].Value, out ssdResult) ? ssdResult : 0;
                    bool ssb2Result;
                    ss.桥梁组成二级部件参数.IsExist = bool.TryParse(桥梁组成二级部件.Attributes["IsExist"].Value, out ssb2Result) ? ssb2Result : false;
                    foreach (XmlNode 检查指标 in 桥梁组成二级部件)
                    {
                        一条指标 sss = new 一条指标(false);
                        sss.标度及其说明集合.Clear();
                        sss.检查指标.指标名称 = 检查指标.Attributes["指标名称"].Value;
                        foreach (XmlNode 标度及其说明 in 检查指标)
                        {
                            一条标度及说明 ssss = new 一条标度及说明();
                            int iResult;
                            ssss.标度及其说明.标度 = int.TryParse(标度及其说明.Attributes["标度"].Value, out iResult) ? iResult : 0;
                            bool ssssbResult;
                            ssss.标度及其说明.是否存在 = bool.TryParse(标度及其说明.Attributes["是否存在"].Value, out ssssbResult) ? ssssbResult : false;
                            ssss.标度及其说明.定性说明 = 标度及其说明.Attributes["定性说明"].Value;
                            ssss.标度及其说明.定量说明 = 标度及其说明.Attributes["定量说明"].Value;
                            sss.标度及其说明集合.Add(ssss);
                        }
                        ss.指标集合.Add(sss);
                    }
                    //ss.指标集合.Add(new 一条指标());
                    一条指标 temp0 = new 一条指标();
                    temp0.检查指标.指标名称 = ss.指标集合.Last().检查指标.指标名称;
                    temp0.检查指标.标度及其说明集合 = ss.指标集合.Last().检查指标.标度及其说明集合;
                    ss.指标集合[ss.指标集合.Count - 1] = temp0;
                    s.二级部件集合.Add(ss);
                }
                //s.二级部件集合.Add(new 一个二级部件());
                一个二级部件 temp1 = new 一个二级部件();
                temp1.桥梁组成二级部件参数.IsExist = s.二级部件集合.Last().桥梁组成二级部件参数.IsExist;
                temp1.桥梁组成二级部件参数.是否主要部件 = s.二级部件集合.Last().桥梁组成二级部件参数.是否主要部件;
                temp1.桥梁组成二级部件参数.构件数 = s.二级部件集合.Last().桥梁组成二级部件参数.构件数;
                temp1.桥梁组成二级部件参数.检查指标集合 = s.二级部件集合.Last().桥梁组成二级部件参数.检查指标集合;
                temp1.桥梁组成二级部件参数.部件名称 = s.二级部件集合.Last().桥梁组成二级部件参数.部件名称;
                temp1.桥梁组成二级部件参数.部件权重 = s.二级部件集合.Last().桥梁组成二级部件参数.部件权重;
                s.二级部件集合[s.二级部件集合.Count - 1] = temp1;

                一级部件集合.Add(s);
            }
            //一级部件集合.Add(new 一个一级部件());
            一个一级部件 temp2 = new 一个一级部件();
            temp2.桥梁组成一级部件参数.是否主要部件 = 一级部件集合.Last().桥梁组成一级部件参数.是否主要部件;
            temp2.桥梁组成一级部件参数.桥梁组成二级部件集合 = 一级部件集合.Last().桥梁组成一级部件参数.桥梁组成二级部件集合;
            temp2.桥梁组成一级部件参数.部件名称 = 一级部件集合.Last().桥梁组成一级部件参数.部件名称;
            temp2.桥梁组成一级部件参数.部件权重 = 一级部件集合.Last().桥梁组成一级部件参数.部件权重;

            一级部件集合[一级部件集合.Count - 1] = temp2;
        }

        private void 导出_Click(object sender, RoutedEventArgs e)
        {
            ObtainDataContent();
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.DefaultExt = ".xml";
            sfd.Filter = "xml|*.xml";
            sfd.ShowDialog();
            if (!String.IsNullOrEmpty(sfd.FileName) && !sfd.CheckFileExists && sfd.CheckPathExists)
            {
                XmlWriter writer = XmlWriter.Create(sfd.FileName);
                XmlDocument xmlDoc = new XmlDocument();
                XmlElement el = (XmlElement)xmlDoc.AppendChild(xmlDoc.CreateElement("BRIDGE"));
                el.SetAttribute("桥梁类型名称", 桥梁类型名称);

                XmlNode 基本信息数据库 = el.AppendChild(xmlDoc.CreateElement("基本信息数据"));
                foreach (基本信息数据组成结构 s in 基本信息数据参数.基本信息数据组成结构集合)
                {
                    XmlNode xmlNode1 = 基本信息数据库.AppendChild(xmlDoc.CreateElement("基本信息数据组成结构"));
                    ((XmlElement)xmlNode1).SetAttribute("结构名称", s.结构名称);
                    foreach (基础记录项目 ss in s.基础记录项目集合)
                    {
                        XmlElement xmlNode2 = (XmlElement)xmlNode1.AppendChild(xmlDoc.CreateElement("基础记录项目"));
                        xmlNode2.SetAttribute("描述名称", ss.描述名称);
                        xmlNode2.SetAttribute("最大长度", ss.最大长度.ToString());
                    }
                }

                XmlNode 养护管理数据库 = el.AppendChild(xmlDoc.CreateElement("养护管理数据"));
                foreach (桥梁组成结构 s in 养护管理数据参数.桥梁组成结构集合)
                {
                    XmlNode xmlNode1 = 养护管理数据库.AppendChild(xmlDoc.CreateElement("桥梁组成结构"));
                    ((XmlElement)xmlNode1).SetAttribute("名称", s.名称);
                    switch (s.名称)
                    {
                        case "桥面系":
                            ((XmlElement)xmlNode1).SetAttribute("权重", 桥面系权重.ToString());
                            break;
                        case "上部结构":
                            ((XmlElement)xmlNode1).SetAttribute("权重", 上部结构权重.ToString());
                            break;
                        case "下部结构":
                            ((XmlElement)xmlNode1).SetAttribute("权重", 下部结构权重.ToString());
                            break;
                        default:
                            ((XmlElement)xmlNode1).SetAttribute("权重", "0");
                            break;
                    }
                    foreach (桥梁组成一级部件 ss in s.桥梁组成一级部件集合)
                    {
                        XmlElement el1 = (XmlElement)xmlNode1.AppendChild(xmlDoc.CreateElement("桥梁组成一级部件"));
                        el1.SetAttribute("部件名称", ss.部件名称);
                        el1.SetAttribute("部件权重", ss.部件权重.ToString());
                        el1.SetAttribute("是否主要部件", ss.是否主要部件.ToString());
                        el1.SetAttribute("IsExist", ss.IsExist.ToString());
                        foreach (桥梁组成二级部件 sss in ss.桥梁组成二级部件集合)
                        {
                            XmlElement el2 = (XmlElement)el1.AppendChild(xmlDoc.CreateElement("桥梁组成二级部件"));
                            el2.SetAttribute("部件名称", sss.部件名称);
                            el2.SetAttribute("部件权重", sss.部件权重.ToString());
                            el2.SetAttribute("构件数", sss.构件数.ToString());
                            el2.SetAttribute("是否主要部件", sss.是否主要部件.ToString());
                            el2.SetAttribute("IsExist", sss.IsExist.ToString());
                            foreach (检查指标 ssss in sss.检查指标集合)
                            {
                                XmlElement el3 = (XmlElement)el2.AppendChild(xmlDoc.CreateElement("检查指标"));
                                el3.SetAttribute("指标名称", ssss.指标名称);
                                foreach (标度及其说明 sssss in ssss.标度及其说明集合)
                                {
                                    XmlElement el4 = (XmlElement)el3.AppendChild(xmlDoc.CreateElement("标度及其说明"));
                                    el4.SetAttribute("标度", sssss.标度.ToString());
                                    el4.SetAttribute("定性说明", sssss.定性说明);
                                    el4.SetAttribute("定量说明", sssss.定量说明);
                                    el4.SetAttribute("是否存在", sssss.是否存在.ToString());
                                }
                            }
                        }
                    }
                }
                xmlDoc.WriteContentTo(writer);
                writer.Close();
            }
        }

        private void 新建_Click(object sender, RoutedEventArgs e)
        {
            MessageBoxResult result = MessageBox.Show("请确认当前窗口内容是否已导出保存?", "确认是否保存", MessageBoxButton.YesNoCancel, MessageBoxImage.Warning);
            if (result == MessageBoxResult.Yes)
            {
                this.基本信息记录项目集合.Clear();
                this.基本信息记录项目集合.Add(new 一条基础记录());
                this.基本参数记录项目集合.Clear();
                this.基本参数记录项目集合.Add(new 一条基础记录());
                this.结构简图记录项目集合.Clear();
                this.结构简图记录项目集合.Add(new 一条基础记录());
                this.桥面系一级部件集合.Clear();
                this.桥面系一级部件集合.Add(new 一个一级部件());
                this.上部结构一级部件集合.Clear();
                this.上部结构一级部件集合.Add(new 一个一级部件());
                this.下部结构一级部件集合.Clear();
                this.下部结构一级部件集合.Add(new 一个一级部件());
            }
            if (result == MessageBoxResult.No)
            {
                导出button.RaiseEvent(new RoutedEventArgs(Button.ClickEvent));
            }
        }
    }

    internal static class Repeat
    {
        public static Task Interval(
            TimeSpan pollInterval,
            Action action,
            CancellationToken token)
        {
            // We don't use Observable.Interval:
            // If we block, the values start bunching up behind each other.
            return Task.Factory.StartNew(
                () =>
                {
                    for (; ; )
                    {
                        if (token.WaitCancellationRequested(pollInterval))
                            break;

                        action();
                    }
                }, token, TaskCreationOptions.LongRunning, TaskScheduler.Default);
        }
    }

    static class CancellationTokenExtensions
    {
        public static bool WaitCancellationRequested(this CancellationToken token, TimeSpan timeout)
        {
            return token.WaitHandle.WaitOne(timeout);
        }
    }

}
