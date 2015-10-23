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
using System.Collections.ObjectModel;
using System.Windows.Media.Animation;
using System.ComponentModel;
using BridgeBaseComponents;

namespace 新建桥类
{
    /// <summary>
    /// Interaction logic for 一个一级部件.xaml
    /// </summary>
    public partial class 一个一级部件 : UserControl, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public void Notify(string propName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
            }
        }
        ObservableCollection<一个二级部件> _二级部件集合 = new ObservableCollection<一个二级部件>() { new 一个二级部件() };
        public ObservableCollection<一个二级部件> 二级部件集合
        {
            get { return _二级部件集合; }
            set { _二级部件集合 = value; }
        }
        private 桥梁组成一级部件 _桥梁组成一级部件参数 = new 桥梁组成一级部件();
        public 桥梁组成一级部件 桥梁组成一级部件参数
        {
            get { return _桥梁组成一级部件参数; }
            set { _桥梁组成一级部件参数 = value; Notify("桥梁组成一级部件参数"); }
        }
        //public string 部件名称 { get; set; }
        //public double 权重 { get; set; }
        //public bool 是否主要部件 { get; set; }
        public 一个一级部件()
        {
            //一个一级部件(true),一个按钮
            InitializeComponent();
            桥梁组成一级部件参数 = new 桥梁组成一级部件();
            this.DataContext = 桥梁组成一级部件参数;
            二级部件集合ListView.DataContext = this;
            AddNewItem.MouseLeftButtonUp += AddNewItem_MouseLeftButtonUp;
            InsertNewItem.MouseLeftButtonUp += InsertNewItem_MouseLeftButtonUp;
        }
        public 一个一级部件(bool trurForAdd_falseForAddAndInsert)
        {
            //true for added items like 一个一级部件(),一个按钮
            //false for inserted items, 两个按钮
            InitializeComponent();
            桥梁组成一级部件参数 = new 桥梁组成一级部件();
            this.DataContext = 桥梁组成一级部件参数;
            二级部件集合ListView.DataContext = this;
            if (!trurForAdd_falseForAddAndInsert)
            {
                AddNewItem.MouseLeftButtonUp += DeleteItem;
                InsertNewItem.MouseLeftButtonUp += InsertNewItem_MouseLeftButtonUp;

                InsertNewItem.Visibility = Visibility.Visible;
                RotateTransform rotateTrans = new RotateTransform();
                AddNewItem.RenderTransform = rotateTrans;
                DoubleAnimation rotateAnim = new DoubleAnimation(45, TimeSpan.FromMilliseconds(300));
                rotateTrans.BeginAnimation(RotateTransform.AngleProperty, rotateAnim);
            }
            else
            {
                AddNewItem.MouseLeftButtonUp += AddNewItem_MouseLeftButtonUp;
                InsertNewItem.MouseLeftButtonUp += InsertNewItem_MouseLeftButtonUp;
            }
        }
        private void AddNewItem_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            TimeSpan du = TimeSpan.FromMilliseconds(400);
            AddOrDeleteButton tb = sender as AddOrDeleteButton;
            RotateTransform rotateTrans = new RotateTransform();
            tb.RenderTransform = rotateTrans;
            DoubleAnimation rotateAnim = new DoubleAnimation(45, du);
            rotateTrans.BeginAnimation(RotateTransform.AngleProperty, rotateAnim);
            tb.MouseLeftButtonUp -= AddNewItem_MouseLeftButtonUp;
            tb.MouseLeftButtonUp += DeleteItem;
            DependencyObject dListView = tb;
            DependencyObject scrollViewer = tb;
            while (!(dListView is ListView))
            {
                dListView = VisualTreeHelper.GetParent(dListView);
            }
            while (!(scrollViewer is ScrollViewer))
            {
                scrollViewer = VisualTreeHelper.GetParent(scrollViewer);
            }
            ListView ListView = dListView as ListView;

            一个一级部件 ListViewItem = new 一个一级部件();
            if (ListView == ((MainWindow)Application.Current.MainWindow).桥面系ListView)
            {
                ((MainWindow)Application.Current.MainWindow).桥面系一级部件集合.Add(ListViewItem);
                ((MainWindow)Application.Current.MainWindow).桥面系一级部件名称集合 = GetCollection(((MainWindow)Application.Current.MainWindow).桥面系一级部件集合);
            }
            if (ListView == ((MainWindow)Application.Current.MainWindow).上部结构ListView)
            {
                ((MainWindow)Application.Current.MainWindow).上部结构一级部件集合.Add(ListViewItem);
                ((MainWindow)Application.Current.MainWindow).上部结构一级部件名称集合 = GetCollection(((MainWindow)Application.Current.MainWindow).上部结构一级部件集合);
            }
            if (ListView == ((MainWindow)Application.Current.MainWindow).下部结构ListView)
            {
                ((MainWindow)Application.Current.MainWindow).下部结构一级部件集合.Add(ListViewItem);
                ((MainWindow)Application.Current.MainWindow).下部结构一级部件名称集合 = GetCollection(((MainWindow)Application.Current.MainWindow).下部结构一级部件集合);
            }
            (scrollViewer as ScrollViewer).ScrollToBottom();
            ScaleTransform scaleTransform = new ScaleTransform();
            ListViewItem.RenderTransform = scaleTransform;
            DoubleAnimation scaleAnim = new DoubleAnimation(0, 1, du);
            scaleTransform.BeginAnimation(ScaleTransform.ScaleYProperty, scaleAnim);

            double tWidth = tb.ActualWidth;
            InsertNewItem.Width = 0;
            InsertNewItem.BeginAnimation(AddOrDeleteButton.WidthProperty, new DoubleAnimation(0, tWidth, TimeSpan.FromMilliseconds(300)));
            InsertNewItem.Visibility = Visibility.Visible;
        }
        private async void DeleteItem(object sender, MouseButtonEventArgs e)
        {
            AddOrDeleteButton tb = sender as AddOrDeleteButton;
            DependencyObject dListView = tb;
            DependencyObject dListViewItem = tb;
            while (!(dListView is ListView))
            {
                dListView = VisualTreeHelper.GetParent(dListView);
            }
            while (!(dListViewItem is 一个一级部件))
            {
                dListViewItem = VisualTreeHelper.GetParent(dListViewItem);
            }
            ListView ListView = dListView as ListView;

            一个一级部件 ListViewItem = dListViewItem as 一个一级部件;
            ListViewItem.Height = ListViewItem.ActualHeight;
            TimeSpan du = TimeSpan.FromMilliseconds(300);
            DoubleAnimation anim = new DoubleAnimation(0, du);
            ListViewItem.BeginAnimation(一个一级部件.OpacityProperty, anim);
            ListViewItem.BeginAnimation(一个一级部件.HeightProperty, anim);

            await Task.Delay(du);
            if (ListView == ((MainWindow)Application.Current.MainWindow).桥面系ListView)
            {
                ((MainWindow)Application.Current.MainWindow).桥面系一级部件集合.Remove(ListViewItem);
                ((MainWindow)Application.Current.MainWindow).桥面系一级部件名称集合 = GetCollection(((MainWindow)Application.Current.MainWindow).桥面系一级部件集合);
            }
            if (ListView == ((MainWindow)Application.Current.MainWindow).上部结构ListView)
            {
                ((MainWindow)Application.Current.MainWindow).上部结构一级部件集合.Remove(ListViewItem);
                ((MainWindow)Application.Current.MainWindow).上部结构一级部件名称集合 = GetCollection(((MainWindow)Application.Current.MainWindow).上部结构一级部件集合);
            }
            if (ListView == ((MainWindow)Application.Current.MainWindow).下部结构ListView)
            {
                ((MainWindow)Application.Current.MainWindow).下部结构一级部件集合.Remove(ListViewItem);
                ((MainWindow)Application.Current.MainWindow).下部结构一级部件名称集合 = GetCollection(((MainWindow)Application.Current.MainWindow).上部结构一级部件集合);
            }
        }
        private void InsertNewItem_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            TimeSpan du = TimeSpan.FromMilliseconds(400);
            AddOrDeleteButton tb = sender as AddOrDeleteButton;

            DependencyObject dListView = tb;
            DependencyObject dListViewItem = tb;
            DependencyObject scrollViewer = tb;
            while (!(dListView is ListView))
            {
                dListView = VisualTreeHelper.GetParent(dListView);
            }
            while (!(dListViewItem is 一个一级部件))
            {
                dListViewItem = VisualTreeHelper.GetParent(dListViewItem);
            }
            ListView ListView = dListView as ListView;
            一个一级部件 ListViewItem = dListViewItem as 一个一级部件;

            一个一级部件 toAddListViewItem = new 一个一级部件(false);

            if (ListView == ((MainWindow)Application.Current.MainWindow).桥面系ListView)
            {
                int index = ((MainWindow)Application.Current.MainWindow).桥面系一级部件集合.IndexOf(ListViewItem);
                ((MainWindow)Application.Current.MainWindow).桥面系一级部件集合.Insert(index, toAddListViewItem);
                ((MainWindow)Application.Current.MainWindow).桥面系一级部件名称集合 = GetCollection(((MainWindow)Application.Current.MainWindow).桥面系一级部件集合);
            }
            if (ListView == ((MainWindow)Application.Current.MainWindow).上部结构ListView)
            {
                int index = ((MainWindow)Application.Current.MainWindow).上部结构一级部件集合.IndexOf(ListViewItem);
                ((MainWindow)Application.Current.MainWindow).上部结构一级部件集合.Insert(index, toAddListViewItem);
                ((MainWindow)Application.Current.MainWindow).上部结构一级部件名称集合 = GetCollection(((MainWindow)Application.Current.MainWindow).上部结构一级部件集合);
            }
            if (ListView == ((MainWindow)Application.Current.MainWindow).下部结构ListView)
            {
                int index = ((MainWindow)Application.Current.MainWindow).下部结构一级部件集合.IndexOf(ListViewItem);
                ((MainWindow)Application.Current.MainWindow).下部结构一级部件集合.Insert(index, toAddListViewItem);
                ((MainWindow)Application.Current.MainWindow).下部结构一级部件名称集合 = GetCollection(((MainWindow)Application.Current.MainWindow).上部结构一级部件集合);
            }

            DoubleAnimation scaleAnim = new DoubleAnimation(0, 1, du);
            ScaleTransform scaleTrans = new ScaleTransform();
            toAddListViewItem.RenderTransform = scaleTrans;
            scaleTrans.BeginAnimation(ScaleTransform.ScaleYProperty, scaleAnim);
        }
        private string GetCollection(ObservableCollection<一个一级部件> 结构部件集合)
        {
            string ss = string.Empty;
            foreach (一个一级部件 ListViewItem in 结构部件集合)
            {
                ss += ListViewItem.桥梁组成一级部件参数.部件名称 + "  ";
            }
            return ss;
        }
    }

}
