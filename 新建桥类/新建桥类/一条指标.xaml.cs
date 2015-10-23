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
using System.Windows.Media.Animation;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.ComponentModel;
using System.Collections.ObjectModel;
using BridgeBaseComponents;

namespace 新建桥类
{
    /// <summary>
    /// Interaction logic for 一条指标.xaml
    /// </summary>
    public partial class 一条指标 : UserControl,INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public void Notify(string propName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
            }
        }
        private 检查指标 _检查指标参数 = new 检查指标();
        public 检查指标 检查指标参数
        {
            get { return _检查指标参数; }
            set { _检查指标参数 = value; Notify("检查指标参数"); }
        }

        private ObservableCollection<一条标度及说明> _标度及其说明集合 = new ObservableCollection<一条标度及说明>() { new 一条标度及说明(1), new 一条标度及说明(2), new 一条标度及说明(3), new 一条标度及说明(4), new 一条标度及说明(5) };
        public ObservableCollection<一条标度及说明> 标度及其说明集合
        {
            get { return _标度及其说明集合; }
            set { _标度及其说明集合 = value; }
        }
        public 一条指标()
        {
            InitializeComponent();
            检查指标参数 = new 检查指标();
            this.DataContext = 检查指标参数;
            标度及其说明集合ListView.DataContext = this;
            AddNewItem.MouseLeftButtonUp += AddNewItem_MouseLeftButtonUp;
        }
        public 一条指标(bool b)
        {
            //true for Add
            //false for Delete
            InitializeComponent();
            检查指标参数 = new 检查指标();
            this.DataContext = 检查指标参数;
            标度及其说明集合ListView.DataContext = this;
            if (b == false)
            {
                RotateTransform rotateTrans = new RotateTransform();
                AddNewItem.RenderTransform = rotateTrans;
                DoubleAnimation rotateAnim = new DoubleAnimation(45, TimeSpan.FromMilliseconds(300));
                rotateTrans.BeginAnimation(RotateTransform.AngleProperty, rotateAnim);
                AddNewItem.MouseLeftButtonUp -= AddNewItem_MouseLeftButtonUp;
                AddNewItem.MouseLeftButtonUp += DeleteItem_MouseLeftButtonUp;
            }
            else
            {
                AddNewItem.MouseLeftButtonUp += AddNewItem_MouseLeftButtonUp;
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
            tb.MouseLeftButtonUp += DeleteItem_MouseLeftButtonUp;
            DependencyObject dListView = tb;
            DependencyObject scrollViewer = tb;
            while (!(dListView is 一个二级部件))
            {
                dListView = VisualTreeHelper.GetParent(dListView);
            }
            while (!(scrollViewer is ScrollViewer))
            {
                scrollViewer = VisualTreeHelper.GetParent(scrollViewer);
            }
            一个二级部件 ListView = dListView as 一个二级部件;

            一条指标 ListViewItem = new 一条指标();
            ListView.指标集合.Add(ListViewItem);
            (scrollViewer as ScrollViewer).ScrollToBottom();
            ScaleTransform scaleTransform = new ScaleTransform();
            ListViewItem.RenderTransform = scaleTransform;
            DoubleAnimation scaleAnim = new DoubleAnimation(0, 1, du);
            scaleTransform.BeginAnimation(ScaleTransform.ScaleYProperty, scaleAnim);
        }
        private async void DeleteItem_MouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            AddOrDeleteButton tb = sender as AddOrDeleteButton;
            DependencyObject dListView = tb;
            DependencyObject dListViewItem = tb;
            while (!(dListView is 一个二级部件))
            {
                dListView = VisualTreeHelper.GetParent(dListView);
            }
            while (!(dListViewItem is 一条指标))
            {
                dListViewItem = VisualTreeHelper.GetParent(dListViewItem);
            }
            一个二级部件 ListView = dListView as 一个二级部件;
            一条指标 ListViewItem = dListViewItem as 一条指标;

            ListViewItem.Height = ListViewItem.ActualHeight;
            TimeSpan du = TimeSpan.FromMilliseconds(300);
            DoubleAnimation anim = new DoubleAnimation(0, du);
            ListViewItem.BeginAnimation(一条指标.OpacityProperty, anim);
            ListViewItem.BeginAnimation(一条指标.HeightProperty, anim);
            await Task.Delay(du);
            ListView.指标集合.Remove(ListViewItem);
        }

    }
}
