using BridgeBaseComponents;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace 新建桥类
{
    /// <summary>
    /// Interaction logic for 一个部件.xaml
    /// </summary>
    public partial class 一个二级部件 : UserControl, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public void Notify(string propName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
            }
        }
        private 桥梁组成二级部件 _桥梁组成二级部件参数 = new 桥梁组成二级部件();
        public 桥梁组成二级部件 桥梁组成二级部件参数
        {
            get { return _桥梁组成二级部件参数; }
            set { _桥梁组成二级部件参数 = value; Notify("桥梁组成二级部件参数"); }
        }
        //public string 部件名称 { get; set; }
        //public double 权重 { get; set; }
        //public bool 是否主要部件 { get; set; }
        private ObservableCollection<一条指标> _指标集合 = new ObservableCollection<一条指标>() { new 一条指标() };
        public ObservableCollection<一条指标> 指标集合
        {
            get { return _指标集合; }
            set { _指标集合 = value; }
        }
        public 一个二级部件()
        {
            InitializeComponent();
            桥梁组成二级部件参数 = new 桥梁组成二级部件();
            this.DataContext = 桥梁组成二级部件参数;
            指标集合ListView.DataContext = this;
            AddNewItem.MouseLeftButtonUp += AddNewItem_MouseLeftButtonUp;
            InsertNewItem.MouseLeftButtonUp += InsertNewItem_MouseLeftButtonUp;
        }
        public 一个二级部件(bool tof)
        {
            //true for added items like 一个部件()
            //false for inserted items
            InitializeComponent();
            桥梁组成二级部件参数 = new 桥梁组成二级部件();
            this.DataContext = 桥梁组成二级部件参数;
            指标集合ListView.DataContext = this;
            if (!tof)
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
            while (!(dListView is 一个一级部件))
            {
                dListView = VisualTreeHelper.GetParent(dListView);
            }
            while (!(scrollViewer is ScrollViewer))
            {
                scrollViewer = VisualTreeHelper.GetParent(scrollViewer);
            }
            一个一级部件 ListView = dListView as 一个一级部件;

            一个二级部件 ListViewItem = new 一个二级部件();
            ListView.二级部件集合.Add(ListViewItem);
            
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
            while (!(dListView is 一个一级部件))
            {
                dListView = VisualTreeHelper.GetParent(dListView);
            }
            while (!(dListViewItem is 一个二级部件))
            {
                dListViewItem = VisualTreeHelper.GetParent(dListViewItem);
            }
            一个一级部件 ListView = dListView as 一个一级部件;
            一个二级部件 ListViewItem = dListViewItem as 一个二级部件;

            ListViewItem.Height = ListViewItem.ActualHeight;
            TimeSpan du = TimeSpan.FromMilliseconds(300);
            DoubleAnimation anim = new DoubleAnimation(0, du);
            ListViewItem.BeginAnimation(一个二级部件.OpacityProperty, anim);
            ListViewItem.BeginAnimation(一个二级部件.HeightProperty, anim);

            await Task.Delay(du);
            ListView.二级部件集合.Remove(ListViewItem);
        }
        private void InsertNewItem_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            TimeSpan du = TimeSpan.FromMilliseconds(400);
            AddOrDeleteButton tb = sender as AddOrDeleteButton;

            DependencyObject dListView = tb;
            DependencyObject dListViewItem = tb;
            DependencyObject scrollViewer = tb;
            while (!(dListView is 一个一级部件))
            {
                dListView = VisualTreeHelper.GetParent(dListView);
            }
            while (!(dListViewItem is 一个二级部件))
            {
                dListViewItem = VisualTreeHelper.GetParent(dListViewItem);
            }
            一个一级部件 ListView = dListView as 一个一级部件;
            一个二级部件 ListViewItem = dListViewItem as 一个二级部件;

            一个二级部件 toAddListViewItem = new 一个二级部件(false);

            int index = ListView.二级部件集合.IndexOf(ListViewItem);
            ListView.二级部件集合.Insert(index, toAddListViewItem);

            DoubleAnimation scaleAnim = new DoubleAnimation(0, 1, du);
            ScaleTransform scaleTrans = new ScaleTransform();
            toAddListViewItem.RenderTransform = scaleTrans;
            scaleTrans.BeginAnimation(ScaleTransform.ScaleYProperty, scaleAnim);
        }
    }
}
