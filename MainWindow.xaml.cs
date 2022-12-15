using System;
using System.Collections.Generic;
using System.ComponentModel;
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
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;
using WpfTest.ViewModel;

namespace WpfTest
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
       
        //public MainWindowViewModel mvvm { get; set; } = new MainWindowViewModel();//实例化一个MainWindowViewModel的变量ShowTime
        public MainWindow()
        {
            InitializeComponent();//初始化MainWindow
            //this.DataContext = mvvm; //将实例化好的mvvm变量传给DataContext进行属性Binding 将mvvm中时间和文本传给前端
            this.DataContext=new MainWindowViewModel();//另一种表现形式，无需创建新变量直接实例化对象传个DataContext
        }    

        

        }   
}
