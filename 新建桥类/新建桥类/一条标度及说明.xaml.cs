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
using System.ComponentModel;
using BridgeBaseComponents;

namespace 新建桥类
{
    /// <summary>
    /// Interaction logic for 一条标度及说明.xaml
    /// </summary>
    public partial class 一条标度及说明 : UserControl,INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        public void Notify(string propName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
            }
        }
        public 标度及其说明 _标度及其说明 = new 标度及其说明();
        public 标度及其说明 标度及其说明
        {
            get { return _标度及其说明; }
            set { _标度及其说明 = value; Notify("标度及其说明"); }
        }
        public 一条标度及说明()
        {
            InitializeComponent();
            标度及其说明 = new 标度及其说明();
            this.DataContext = 标度及其说明;
        }
        public 一条标度及说明(int i)
        {
            InitializeComponent();
            标度及其说明 = new 标度及其说明();
            this.DataContext = 标度及其说明;
            this.标度及其说明.标度 = i;
        }
        public 一条标度及说明(int i,string 定性说明,string 定量说明)
        {
            InitializeComponent();
            标度及其说明 = new 标度及其说明();
            this.DataContext = 标度及其说明;
            this.标度及其说明.标度 = i;
            this.标度及其说明.定性说明 = 定性说明;
            this.标度及其说明.定量说明 = 定量说明 ;
        }
    }
}
