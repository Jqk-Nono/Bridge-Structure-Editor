using Microsoft.Win32;
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

namespace 新建桥类
{
    /// <summary>
    /// Interaction logic for 选择导入或新建.xaml
    /// </summary>
    public partial class 选择导入或新建 : Window
    {
        public string filePath { get; set; }
        public string ChosenOption { get; set; }
        public 选择导入或新建()
        {
            InitializeComponent();
            filePath = System.IO.Path.GetTempFileName();
        }

        private void 新建Button_CLick(object sender, RoutedEventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.DefaultExt = ".xml";
            sfd.Filter = "XML文件|*.xml";
            sfd.ShowDialog();
            if(!String.IsNullOrEmpty(sfd.FileName))
            {
                this.filePath = sfd.FileName;
                this.ChosenOption = "新建";
                this.Close();
            }
            else
            {
                this.Close();
            }
        }

        private void 导入Button_Click(object sender, RoutedEventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.DefaultExt = ".xml";
            ofd.Filter = "XML文件|*.xml";
            ofd.ShowDialog();
            if (!String.IsNullOrEmpty(ofd.FileName))
            {
                this.filePath = ofd.FileName;
                this.ChosenOption = "导入";
                this.Close();
            }
            else
            {
                this.Close();
            }
        }
    }
}
