using BridgeBaseComponents;
using System;
using System.Collections.Generic;
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
    /// Interaction logic for 一条基础记录.xaml
    /// </summary>
    public partial class 一条基础记录 : UserControl, INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public void Notify(string propName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
            }
        }
        private 基础记录项目 _基础记录项目参数 = new 基础记录项目();
        public 基础记录项目 基础记录项目参数
        {
            get { return _基础记录项目参数; }
            set { _基础记录项目参数 = value; Notify("基础记录项目参数"); }
        }

        public 一条基础记录()
        {
            InitializeComponent();
            this.DataContext = 基础记录项目参数;
            AddNewItem.MouseLeftButtonUp += AddNewItem_MouseLeftButtonUp;
            InsertNewItem.MouseLeftButtonUp += InsertNewItem_MouseLeftButtonUp;
        }
        public 一条基础记录(bool falseForInsert)
        {
            //true for added items like 一条基础记录()
            //false for inserted items
            InitializeComponent();
            this.DataContext = 基础记录项目参数;
            if (!falseForInsert)
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

            一条基础记录 ListViewItem = new 一条基础记录();
            if (ListView == ((MainWindow)Application.Current.MainWindow).基本信息记录项目ListView)
            {
                ((MainWindow)Application.Current.MainWindow).基本信息记录项目集合.Add(ListViewItem);
            }
            if (ListView == ((MainWindow)Application.Current.MainWindow).基本参数记录项目ListView)
            {
                ((MainWindow)Application.Current.MainWindow).基本参数记录项目集合.Add(ListViewItem);
            }
            if (ListView == ((MainWindow)Application.Current.MainWindow).结构简图记录项目ListView)
            {
                ((MainWindow)Application.Current.MainWindow).结构简图记录项目集合.Add(ListViewItem);
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
            while (!(dListViewItem is 一条基础记录))
            {
                dListViewItem = VisualTreeHelper.GetParent(dListViewItem);
            }
            ListView ListView = dListView as ListView;

            一条基础记录 ListViewItem = dListViewItem as 一条基础记录;
            ListViewItem.Height = ListViewItem.ActualHeight;
            TimeSpan du = TimeSpan.FromMilliseconds(300);
            DoubleAnimation anim = new DoubleAnimation(0, du);
            //anim.EasingFunction = new ExponentialEase();
            ListViewItem.BeginAnimation(一条基础记录.OpacityProperty, anim);
            ListViewItem.BeginAnimation(一条基础记录.HeightProperty, anim);
            //DoubleAnimation transAnim = new DoubleAnimation(40, du);
            //TranslateTransform translateTransform = new TranslateTransform();
            //ListViewItem.RenderTransform = translateTransform;
            //translateTransform.BeginAnimation(TranslateTransform.XProperty, transAnim);

            await Task.Delay(du);
            if (ListView == ((MainWindow)Application.Current.MainWindow).基本信息记录项目ListView)
            {
                ((MainWindow)Application.Current.MainWindow).基本信息记录项目集合.Remove(ListViewItem);
            }
            if (ListView == ((MainWindow)Application.Current.MainWindow).基本参数记录项目ListView)
            {
                ((MainWindow)Application.Current.MainWindow).基本参数记录项目集合.Remove(ListViewItem);
            }
            if (ListView == ((MainWindow)Application.Current.MainWindow).结构简图记录项目ListView)
            {
                ((MainWindow)Application.Current.MainWindow).结构简图记录项目集合.Remove(ListViewItem);
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
            while (!(dListViewItem is 一条基础记录))
            {
                dListViewItem = VisualTreeHelper.GetParent(dListViewItem);
            }
            ListView ListView = dListView as ListView;
            一条基础记录 ListViewItem = dListViewItem as 一条基础记录;

            一条基础记录 toAddListViewItem = new 一条基础记录(false);

            if (ListView == ((MainWindow)Application.Current.MainWindow).基本信息记录项目ListView)
            {
                int index = ((MainWindow)Application.Current.MainWindow).基本信息记录项目集合.IndexOf(ListViewItem);
                ((MainWindow)Application.Current.MainWindow).基本信息记录项目集合.Insert(index, toAddListViewItem);
            }
            if (ListView == ((MainWindow)Application.Current.MainWindow).基本参数记录项目ListView)
            {
                int index = ((MainWindow)Application.Current.MainWindow).基本参数记录项目集合.IndexOf(ListViewItem);
                ((MainWindow)Application.Current.MainWindow).基本参数记录项目集合.Insert(index, toAddListViewItem);
            }
            if (ListView == ((MainWindow)Application.Current.MainWindow).结构简图记录项目ListView)
            {
                int index = ((MainWindow)Application.Current.MainWindow).结构简图记录项目集合.IndexOf(ListViewItem);
                ((MainWindow)Application.Current.MainWindow).结构简图记录项目集合.Insert(index, toAddListViewItem);
            }

            DoubleAnimation scaleAnim = new DoubleAnimation(0, 1, du);
            ScaleTransform scaleTrans = new ScaleTransform();
            toAddListViewItem.RenderTransform = scaleTrans;
            scaleTrans.BeginAnimation(ScaleTransform.ScaleYProperty, scaleAnim);

            //RotateTransform rotateTrans = new RotateTransform();
            //toAddListViewItem.AddNewItem.RenderTransform = rotateTrans;
            //DoubleAnimation rotateAnim = new DoubleAnimation(45, du);
            //rotateTrans.BeginAnimation(RotateTransform.AngleProperty, rotateAnim);

            //double tWidth = tb.ActualWidth;
            //toAddListViewItem.InsertNewItem.Width = 0;
            //toAddListViewItem.InsertNewItem.BeginAnimation(AddOrDeleteButton.WidthProperty, new DoubleAnimation(0, tWidth, TimeSpan.FromMilliseconds(300)));
            //toAddListViewItem.InsertNewItem.Visibility = Visibility.Visible;
        }
    }
}
