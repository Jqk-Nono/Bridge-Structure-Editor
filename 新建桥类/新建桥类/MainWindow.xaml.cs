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
using System.Diagnostics;
using System.Runtime.InteropServices;

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

        public string _filePath;
        public string filePath
        {
            get { return _filePath; }
            set { _filePath = value; Notify("filePath"); }
        }
        public string _tempFilePath;
        public string tempFilePath
        {
            get { return ("自动保存文件位置：" + _tempFilePath); }
            set { _tempFilePath = value; Notify("tempFilePath"); }
        }
        public string _上次自动保存时间;
        public string 上次自动保存时间
        {
            get { return "上次自动保存时间：" + _上次自动保存时间; }
            set { _上次自动保存时间 = value; Notify("上次自动保存时间"); }
        }

        public MainWindow()
        {
            InitializeComponent();
            this.DataContext = this;
            选择导入或新建 startWindow = new 选择导入或新建();
            startWindow.ShowDialog();
            this.filePath = startWindow.filePath;
            if (startWindow.ChosenOption == "导入")
            {
                ImportXml(this.filePath);
            }
            var cancellationTokenSource = new CancellationTokenSource();
            var task = Repeat.Interval(TimeSpan.FromSeconds(30), () => SavingWork(filePath), cancellationTokenSource.Token);
        }
        public void ChangeNameCollection()
        {
            桥面系一级部件名称集合 = string.Empty;
            上部结构一级部件名称集合 = string.Empty;
            下部结构一级部件名称集合 = string.Empty;
            foreach (一个一级部件 s in 桥面系一级部件集合)
            {
                桥面系一级部件名称集合 += s.桥梁组成一级部件参数.部件名称 + "  ";
            }
            foreach (一个一级部件 s in 上部结构一级部件集合)
            {
                上部结构一级部件名称集合 += s.桥梁组成一级部件参数.部件名称 + "  ";
            }
            foreach (一个一级部件 s in 下部结构一级部件集合)
            {
                下部结构一级部件名称集合 += s.桥梁组成一级部件参数.部件名称 + "  ";
            }
        }
        private void StartSavingWork()
        {

        }
        private void SavingWork(string tempFilePath)
        {
            tempFilePath = System.IO.Path.GetDirectoryName(filePath) + @"\" + System.IO.Path.GetFileNameWithoutExtension(filePath) + ".temp.xml";
            ExportXml(@tempFilePath);
            this.tempFilePath = tempFilePath;
            this.上次自动保存时间 = DateTime.Now.ToLongTimeString();
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

        private Bridge ObtainDataContent()
        {
            #region MyRegion1
            this.基本信息数据参数.基本信息记录项目结构 = 
                ObtainDataContentA(基本信息记录项目集合参数, 基本信息记录项目集合);

            this.基本信息数据参数.基本参数记录项目结构 =
                ObtainDataContentA(基本参数记录项目集合参数, 基本参数记录项目集合);

            this.基本信息数据参数.结构简图记录项目结构 =
                ObtainDataContentA(结构简图记录项目集合参数, 结构简图记录项目集合);
            #endregion

            #region MyRegion2
            ObtainDataContentB(桥面系组成结构, 桥面系一级部件集合);

            ObtainDataContentB(上部结构组成结构, 上部结构一级部件集合);

            ObtainDataContentB(下部结构组成结构, 下部结构一级部件集合);
            #endregion

            #region MyRegion3
            this.养护管理数据参数.桥面系 = 桥面系组成结构;
            this.养护管理数据参数.上部结构 = 上部结构组成结构;
            this.养护管理数据参数.下部结构 = 下部结构组成结构;

            this.养护管理数据参数.桥面系.权重 = this.桥面系权重;
            this.养护管理数据参数.上部结构.权重 = this.上部结构权重;
            this.养护管理数据参数.下部结构.权重 = this.下部结构权重;

            newBridgeType = new Bridge();
            newBridgeType.桥梁类型名称 = 桥梁类型名称;
            newBridgeType.基本信息数据 = 基本信息数据参数;
            newBridgeType.养护管理数据 = 养护管理数据参数;
            #endregion

            return newBridgeType;
        }

        private 基本信息数据组成结构 ObtainDataContentA(基本信息数据组成结构 p1,ObservableCollection<一条基础记录> p2)
        {
            p1.基础记录项目集合.Clear();
            foreach (一条基础记录 s in p2)
            {
                p1.基础记录项目集合.Add(s.基础记录项目参数);
            }
            return p1;
        }

        private void ObtainDataContentB(桥梁组成结构 p1,ObservableCollection<一个一级部件> p2)
        {
            p1.桥梁组成一级部件集合.Clear();
            foreach (一个一级部件 s in p2)
            {
                s.桥梁组成一级部件参数.桥梁组成二级部件集合.Clear();
                foreach (一个二级部件 ss in s.二级部件集合)
                {
                    ss.桥梁组成二级部件参数.检查指标集合.Clear();
                    foreach (一条指标 sss in ss.指标集合)
                    {
                        sss.检查指标参数.标度及其说明集合.Clear();
                        foreach (一条标度及说明 ssss in sss.标度及其说明集合)
                        {
                            sss.检查指标参数.标度及其说明集合.Add(ssss.标度及其说明);
                        }
                        ss.桥梁组成二级部件参数.检查指标集合.Add(sss.检查指标参数);
                    }
                    s.桥梁组成一级部件参数.桥梁组成二级部件集合.Add(ss.桥梁组成二级部件参数);
                }
                p1.桥梁组成一级部件集合.Add(s.桥梁组成一级部件参数);
            }
        }

        private void 导入_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.DefaultExt = ".xml";
            ofd.Filter = "xml|*.xml";
            ofd.ShowDialog();
            if (!String.IsNullOrEmpty(ofd.FileName) && ofd.CheckFileExists && ofd.CheckPathExists)
            {
                ImportXml(ofd.FileName);
            }
        }
        private void ImportXml(string FileName)
        {
            try
            {
                filePath = FileName;
                XmlDocument xmlDoc = new XmlDocument();
                xmlDoc.Load(FileName);

                XmlNode BRIDGENode = xmlDoc.DocumentElement.SelectSingleNode("/BRIDGE");
                this.桥梁类型名称 = BRIDGENode.Attributes["桥梁类型名称"].Value;

                #region 基本信息数据
                XmlNode 基本信息数据 = xmlDoc.DocumentElement.SelectSingleNode("/BRIDGE/基本信息数据");
                foreach (XmlNode 基本信息数据组成结构 in 基本信息数据)
                {
                    if (基本信息数据组成结构.Attributes["结构名称"].Value == "基本信息")
                    {
                        导入基本信息数据组成结构(基本信息数据组成结构, 基本信息记录项目集合);
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

                ChangeNameCollection();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
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
            try
            {
                一级部件集合.Clear();
                #region 桥梁组成一级部件
                foreach (XmlNode 桥梁组成一级部件 in 桥梁组成结构)
                {
                    一个一级部件 s = new 一个一级部件(false);
                    一级部件集合.Add(s);
                    s.二级部件集合.Clear();
                    s.桥梁组成一级部件参数.部件名称 = 桥梁组成一级部件.Attributes["部件名称"].Value;
                    bool sbResult;
                    s.桥梁组成一级部件参数.是否主要部件 = bool.TryParse(桥梁组成一级部件.Attributes["是否主要部件"].Value, out sbResult) ? sbResult : false;
                    double sdResult;
                    s.桥梁组成一级部件参数.部件权重 = double.TryParse(桥梁组成一级部件.Attributes["部件权重"].Value, out sdResult) ? sdResult : 0;
                    bool sb2Result;
                    s.桥梁组成一级部件参数.IsExist = bool.TryParse(桥梁组成一级部件.Attributes["IsExist"].Value, out sb2Result) ? sb2Result : false;

                    #region 桥梁组成二级部件
                    foreach (XmlNode 桥梁组成二级部件 in 桥梁组成一级部件)
                    {
                        一个二级部件 ss = new 一个二级部件(false);
                        s.二级部件集合.Add(ss);
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

                        #region 检查指标
                        foreach (XmlNode 检查指标 in 桥梁组成二级部件)
                        {
                            一条指标 sss = new 一条指标(false);
                            ss.指标集合.Add(sss);
                            sss.标度及其说明集合.Clear();
                            sss.检查指标参数.指标名称 = 检查指标.Attributes["指标名称"].Value;

                            #region 标度及其说明
                            foreach (XmlNode 标度及其说明 in 检查指标)
                            {
                                一条标度及说明 ssss = new 一条标度及说明();
                                int iResult;
                                ssss.标度及其说明.标度 = int.TryParse(标度及其说明.Attributes["标度"].Value, out iResult) ? iResult : 0;
                                if ((标度及其说明 as XmlElement).HasAttribute("是否存在"))
                                {
                                    bool ssssbResult;
                                    ssss.标度及其说明.IsExist = bool.TryParse(标度及其说明.Attributes["是否存在"].Value, out ssssbResult) ? ssssbResult : false;
                                }
                                if ((标度及其说明 as XmlElement).HasAttribute("IsExist"))
                                {
                                    bool ssssbResult;
                                    ssss.标度及其说明.IsExist = bool.TryParse(标度及其说明.Attributes["IsExist"].Value, out ssssbResult) ? ssssbResult : false;
                                }
                                ssss.标度及其说明.定性说明 = 标度及其说明.Attributes["定性说明"].Value;
                                ssss.标度及其说明.定量说明 = 标度及其说明.Attributes["定量说明"].Value;
                                sss.标度及其说明集合.Add(ssss);
                            }
                            #endregion

                            //ss.指标集合.Add(sss);
                        }
                        #endregion

                        一条指标 temp0 = new 一条指标();
                        temp0.检查指标参数.指标名称 = ss.指标集合.Last().检查指标参数.指标名称;
                        temp0.检查指标参数.标度及其说明集合 = ss.指标集合.Last().检查指标参数.标度及其说明集合;
                        temp0.标度及其说明集合 = ss.指标集合.Last().标度及其说明集合;

                        ss.指标集合[ss.指标集合.Count - 1] = temp0;

                        //s.二级部件集合.Add(ss);
                    }
                    #endregion

                    一个二级部件 temp1 = new 一个二级部件();
                    if (s.二级部件集合.Count == 0)
                    {
                        s.二级部件集合.Add(new 一个二级部件(true));
                    }
                    //temp1.桥梁组成二级部件参数 = s.二级部件集合.Last()?.桥梁组成二级部件参数;
                    temp1.桥梁组成二级部件参数.IsExist = s.二级部件集合.Last().桥梁组成二级部件参数.IsExist;
                    temp1.桥梁组成二级部件参数.是否主要部件 = s.二级部件集合.Last().桥梁组成二级部件参数.是否主要部件;
                    temp1.桥梁组成二级部件参数.构件数 = s.二级部件集合.Last().桥梁组成二级部件参数.构件数;
                    temp1.桥梁组成二级部件参数.检查指标集合 = s.二级部件集合.Last().桥梁组成二级部件参数.检查指标集合;
                    temp1.桥梁组成二级部件参数.部件名称 = s.二级部件集合.Last().桥梁组成二级部件参数.部件名称;
                    temp1.桥梁组成二级部件参数.部件权重 = s.二级部件集合.Last().桥梁组成二级部件参数.部件权重;
                    temp1.指标集合 = s.二级部件集合.Last().指标集合;

                    s.二级部件集合[s.二级部件集合.Count - 1] = temp1;

                    //一级部件集合.Add(s);
                }
                #endregion

                一个一级部件 temp2 = new 一个一级部件();
                if (一级部件集合.Count == 0)
                {
                    一级部件集合.Add(new 一个一级部件(true));
                }
                //temp2.桥梁组成一级部件参数 = 一级部件集合.Last().桥梁组成一级部件参数;
                temp2.桥梁组成一级部件参数.IsExist = 一级部件集合.Last().桥梁组成一级部件参数.IsExist;
                temp2.桥梁组成一级部件参数.是否主要部件 = 一级部件集合.Last().桥梁组成一级部件参数.是否主要部件;
                temp2.桥梁组成一级部件参数.桥梁组成二级部件集合 = 一级部件集合.Last().桥梁组成一级部件参数.桥梁组成二级部件集合;
                temp2.桥梁组成一级部件参数.部件名称 = 一级部件集合.Last().桥梁组成一级部件参数.部件名称;
                temp2.桥梁组成一级部件参数.部件权重 = 一级部件集合.Last().桥梁组成一级部件参数.部件权重;
                temp2.二级部件集合 = 一级部件集合.Last().二级部件集合;

                一级部件集合[一级部件集合.Count - 1] = temp2;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private void 导出_Click(object sender, RoutedEventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.DefaultExt = ".xml";
            sfd.Filter = "xml|*.xml";
            sfd.ShowDialog();
            if (!String.IsNullOrEmpty(sfd.FileName) && !sfd.CheckFileExists && sfd.CheckPathExists)
            {
                ExportXml(sfd.FileName);
            }
        }

        private void ExportXml(string fileName)
        {
            //有待修改回的代码见注释
            try
            {
                string sqlMessage=string.Empty;
                Bridge newBridge = ObtainDataContent();
                XmlWriter writer = XmlWriter.Create(fileName);
                XmlDocument xmlDoc = new XmlDocument();
                XmlElement el = (XmlElement)xmlDoc.AppendChild(xmlDoc.CreateElement("BRIDGE"));
                el.SetAttribute("桥梁类型名称", newBridge.桥梁类型名称);

                XmlNode 基本信息数据库 = el.AppendChild(xmlDoc.CreateElement("基本信息数据"));
                foreach (基本信息数据组成结构 s in newBridge.基本信息数据.基本信息数据组成结构集合)
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
                foreach (桥梁组成结构 s in newBridge.养护管理数据.桥梁组成结构集合)
                {
                    XmlNode xmlNode1 = 养护管理数据库.AppendChild(xmlDoc.CreateElement("桥梁组成结构"));
                    ((XmlElement)xmlNode1).SetAttribute("名称", s.名称);
                    switch (s.名称)
                    {
                        case "桥面系":
                            ((XmlElement)xmlNode1).SetAttribute("权重", newBridge.养护管理数据.桥面系.权重.ToString());
                            break;
                        case "上部结构":
                            ((XmlElement)xmlNode1).SetAttribute("权重", newBridge.养护管理数据.上部结构.权重.ToString());
                            break;
                        case "下部结构":
                            ((XmlElement)xmlNode1).SetAttribute("权重", newBridge.养护管理数据.下部结构.权重.ToString());
                            break;
                        default:
                            ((XmlElement)xmlNode1).SetAttribute("权重", "0");
                            break;
                    }
                    foreach (桥梁组成一级部件 ss in s.桥梁组成一级部件集合)
                    {
                        if (!string.IsNullOrWhiteSpace(ss.部件名称))
                        {
                            XmlElement el1 = (XmlElement)xmlNode1.AppendChild(xmlDoc.CreateElement("桥梁组成一级部件"));

                            el1.SetAttribute("部件名称", ExcludeSpecialSymbol(ss.部件名称));
                            el1.SetAttribute("部件权重", ss.部件权重.ToString());
                            el1.SetAttribute("是否主要部件", ss.是否主要部件.ToString());
                            el1.SetAttribute("IsExist", "true");
                            //el1.SetAttribute("IsExist", ss.IsExist.ToString());
                            foreach (桥梁组成二级部件 sss in ss.桥梁组成二级部件集合)
                            {
                                if (!string.IsNullOrWhiteSpace(sss.部件名称))
                                {
                                    XmlElement el2 = (XmlElement)el1.AppendChild(xmlDoc.CreateElement("桥梁组成二级部件"));

                                    el2.SetAttribute("部件名称", ExcludeSpecialSymbol(sss.部件名称));
                                    el2.SetAttribute("部件权重", ss.部件权重.ToString());
                                    //el2.SetAttribute("部件权重", sss.部件权重.ToString());
                                    el2.SetAttribute("构件数", sss.构件数.ToString());
                                    el2.SetAttribute("是否主要部件", ss.是否主要部件.ToString());
                                    //el2.SetAttribute("是否主要部件", sss.是否主要部件.ToString());
                                    el2.SetAttribute("IsExist", "true");
                                    //el2.SetAttribute("IsExist", sss.IsExist.ToString());
                                    foreach (检查指标 ssss in sss.检查指标集合)
                                    {
                                        if (!string.IsNullOrWhiteSpace(ssss.指标名称))
                                        {
                                            XmlElement el3 = (XmlElement)el2.AppendChild(xmlDoc.CreateElement("检查指标"));
                                            el3.SetAttribute("指标名称", ExcludeSpecialSymbol(ssss.指标名称));
                                            foreach (标度及其说明 sssss in ssss.标度及其说明集合)
                                            {
                                                XmlElement el4 = (XmlElement)el3.AppendChild(xmlDoc.CreateElement("标度及其说明"));
                                                el4.SetAttribute("标度", sssss.标度.ToString());
                                                el4.SetAttribute("定性说明", sssss.定性说明);
                                                el4.SetAttribute("定量说明", sssss.定量说明);

                                                //el4.SetAttribute("IsExist", sssss.IsExist.ToString());
                                                if (!string.IsNullOrWhiteSpace(sssss.定性说明) || !string.IsNullOrWhiteSpace(sssss.定量说明)) 
                                                {
                                                    el4.SetAttribute("IsExist", "true");
                                                }
                                                else
                                                {
                                                    el4.SetAttribute("IsExist", "false");
                                                }

                                                if (string.IsNullOrWhiteSpace(sssss.定性说明) && 
                                                    string.IsNullOrWhiteSpace(sssss.定量说明) &&
                                                    sssss.IsExist)
                                                {
                                                    sqlMessage += s.名称 + ss.部件名称 + sss.部件名称 + ssss.指标名称 + "标度" + sssss.标度.ToString() + "存在但没有任何说明\r\n";
                                                }
                                            }
                                        }
                                    }
                                }
                            }
                        }
                    }
                }
                //if (!string.IsNullOrWhiteSpace(sqlMessage))
                //{
                //    //MessageBox.Show(sqlMessage, "消息提示", MessageBoxButton.OK, MessageBoxImage.Warning);
                //}
                xmlDoc.WriteContentTo(writer);
                writer.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
        }

        private string ExcludeSpecialSymbol(string s)
        {
            try
            {
                for (int i = 0; i < s.Length; i++)
                {
                    if (s[i].ToString() == " ")
                    {
                        s = s.Remove(i, 1);
                    }
                }

                for (int i = 0; i < s.Length; i++)
                {
                    if (s[i].ToString() == "、")
                    {
                        s = s.Remove(i, 1);
                    }
                }

                for (int i = 0; i < s.Length; i++)
                {
                    if (s[i].ToString() == "(" || s[i].ToString() == "（")
                    {
                        for (int j = 0; j < s.Length; j++)
                        {
                            if (s[j].ToString() == ")" || s[j].ToString() == "）")
                            {
                                s = s.Remove(i, j - i + 1);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            return s;
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
            if (result == MessageBoxResult.Cancel)
            {
                
            }
            ChangeNameCollection();
        }

        private void TestButton_Click(object sender, RoutedEventArgs e)
        {
            this.桥面系一级部件集合[1].二级部件集合[1].指标集合.Add(new 一条指标());
        }

        private void OpenDirectoryToTempFile(object sender, MouseButtonEventArgs e)
        {
            OpenFolderAndSelectFile(_tempFilePath);
        }
        private void OpenDirectoryToFile(object sender, MouseButtonEventArgs e)
        {
            OpenFolderAndSelectFile(_filePath);
        }
        public static void OpenFolderAndSelectFile(string filePath)
        {
            if (filePath == null)
                throw new ArgumentNullException("filePath");

            IntPtr pidl = ILCreateFromPathW(filePath);
            SHOpenFolderAndSelectItems(pidl, 0, IntPtr.Zero, 0);
            ILFree(pidl);
        }

        [DllImport("shell32.dll", CharSet = CharSet.Unicode)]
        private static extern IntPtr ILCreateFromPathW(string pszPath);

        [DllImport("shell32.dll")]
        private static extern int SHOpenFolderAndSelectItems(IntPtr pidlFolder, int cild, IntPtr apidl, int dwFlags);

        [DllImport("shell32.dll")]
        private static extern void ILFree(IntPtr pidl);

        private void 保存_Click(object sender, RoutedEventArgs e)
        {
            ExportXml(filePath);
            MessageBox.Show("保存成功!", "操作结果", MessageBoxButton.OK, MessageBoxImage.Asterisk);
        }
    }

    internal static class Repeat
    {
        public static Task Interval(TimeSpan pollInterval, Action action, CancellationToken token)
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
