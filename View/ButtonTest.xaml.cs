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

namespace WpfTest
{
    /// <summary>
    /// ButtonTest.xaml 的交互逻辑
    /// </summary>
    public partial class ButtonTest : UserControl
    {
        public ButtonTest()
        {
            InitializeComponent();
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
