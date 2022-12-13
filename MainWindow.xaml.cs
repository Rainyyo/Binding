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
using WpfTest.View;
using WpfTest.ViewModel;

namespace WpfTest
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MyClass Mc { get; set; }=new MyClass();
        public MainWindow()
        {   
            InitializeComponent();//加载MainWindow

            Mc.MyText = "Hello";
            //this.DataContext= mv;   
        }       

        public ShowWindow sw;//创建一个对象   

        #region Button_Click 
        private void ShowWindow_Click(object sender, RoutedEventArgs e)
        {
            sw = new ShowWindow();//实例化Show Window
            sw.WindowStartupLocation = WindowStartupLocation.CenterScreen;//事件触发是窗体显示的位置

            //sw.Show();    //.Show()使窗口变为活动窗口，但是它不会阻塞程序的执行，即其他代码会继续执行

            sw.ShowDialog();   //.ShowDialog();将窗口设为模态窗口，并会阻塞程序的执行，直到用户关闭该窗口为止
        }
        #endregion

        public MainWindowViewModel mv { get; set; } = new MainWindowViewModel();

        private void Binding_Show_Loaded(object sender, RoutedEventArgs e)
        {
            this.DataContext = mv;

        }

        /// <summary>
        /// Binding_Test
        /// </summary>
        public class MyClass : INotifyPropertyChanged
        {
            public event PropertyChangedEventHandler PropertyChanged;

            private string mytext;
            public string MyText
            {
                get
                { return mytext; }
                set
                {
                    mytext = value;
                    PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("MyText"));
                }
            }
        }
    }
}
