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
       
        public MainWindowViewModel mvvm { get; set; } = new MainWindowViewModel();//实例化一个MainWindowViewModel的变量ShowTime
        public MainWindow()
        {
            InitializeComponent();//初始化MainWindow
            this.DataContext = mvvm; //将实例化好的mvvm变量传给DataContext进行属性Binding 将mvvm中时间和文本传给前端
        }    

        #region Button_Click 
        public ShowWindow sw;//创建一个对象
                             //
        private void ShowWindow_Click(object sender, RoutedEventArgs e)
        {
            sw = new ShowWindow();//实例化Show Window
            sw.WindowStartupLocation = WindowStartupLocation.CenterScreen;//事件触发是窗体显示的位置

            //sw.Show();    //.Show()使窗口变为活动窗口，但是它不会阻塞程序的执行，即其他代码会继续执行

            sw.ShowDialog();   //.ShowDialog();将窗口设为模态窗口，并会阻塞程序的执行，直到用户关闭该窗口为止
        }
        #endregion

        }   
}
