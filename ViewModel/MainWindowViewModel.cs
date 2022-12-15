using DXH.ViewModel;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Threading;

namespace WpfTest.ViewModel
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        private DispatcherTimer ShowTimer;//创建一个定时器ShowTimer的变量
        //public ButtonTest  buttonTest { get; set; }=new ButtonTest();
        //public TextBinding_Test TextBinding_Test { get; set; } = new TextBinding_Test();

        public MainWindowViewModel()
        {
            //MyText = "123789";//初始化mytext的值
            mytext = "Hello";
            ShowTimer = new DispatcherTimer();//实例化
            ShowTimer.Interval = TimeSpan.FromSeconds(1);//每隔一秒触发一次
            ShowTimer.Tick += ShowTimer_Tick;//创建事件触发器进行订阅  使用方法+= Tab+Tab
            ShowTimer.Start();//启动计时器
        }

        private void ShowTimer_Tick(object sender, EventArgs e)
        {
            NowTime = System.DateTime.Now.ToString();
            //NowTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");//另一种显示的文本格式
        }

        #region 接口的实现
        public event PropertyChangedEventHandler PropertyChanged;//实现数据绑定接口

        #endregion
            
        #region Binding 用到的属性
        
        /// <summary> 
        /// 前端 Binding 只能绑定属性名  NowTime        
        /// </summary>
        private string nowTime;//创建一个来实现前端的Binding

        public string NowTime//属性
        {
            get { return nowTime; }
            set
            {
                nowTime = value;

                //this.OnPropertyChanged("NowTime");//改写的方法   在#region OnPropertyChanged中

                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("NowTime"));//自带的方法
            }
        }

        /// <summary> 
        /// 前端 Binding 只能绑定属性名  MyText
        /// </summary>
        private string mytext;

        public string MyText
        {
            get
            { return mytext; }
            set
            {
                mytext = value;
                //this.OnPropertyChanged("MyText");
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("MyText"));//自带的方法
            }
        }

        /// <summary>
        /// 如果有同一类的不同变量 公用同一属性值的时候，前端Binding 应显示为{Binding 变量.属性}
        ///                                              例如Model中有一个Person类的UserName {Binding UserName.Name}
        ///</summary>
        private string userName;

        public string UserName
        {
            get { return userName; }
            set
            {
                userName = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("UserName"));
            }
        }
        #endregion

        /*  #region OnPropertyChanged  

          /// <summary>
          /// 对属性值的更改通知
          /// </summary>
          protected virtual void OnPropertyChanged(string propertyName)
          {
              VerifyPropertyName(propertyName);
              PropertyChangedEventHandler propertyChanged = this.PropertyChanged;
              if (propertyChanged != null)
              {
                  PropertyChangedEventArgs e = new PropertyChangedEventArgs(propertyName);
                  propertyChanged(this, e);
              }
          }

          protected virtual bool ThrowOnInvalidPropertyName { get; private set; }

          public void VerifyPropertyName(string propertyName)
          {
              if (TypeDescriptor.GetProperties(this)[propertyName] == null)
              {
                  string message = "Invalid property name: " + propertyName;
                  if (ThrowOnInvalidPropertyName)
                  {
                      throw new Exception(message);
                  }

                  Debug.Fail(message);
              }
          }
          #endregion
      }
  */

        #region 按钮Binding点击事件

        RelayCommand _ActionCommand;
        public ICommand ActionCommand
        {
            get
            {
                if (_ActionCommand == null)
                    _ActionCommand = new RelayCommand(param => this.Action(param as string));
                return _ActionCommand;
            }
        }

        public void Action(string param)
        {
            if (param == "Show")
            {
                Show();
            }
        }
        /// <summary>
        /// 定义一个Show方法来实现
        /// </summary>
        public void Show()
        {
            ShowWindow showWindow= new ShowWindow();
            showWindow.WindowStartupLocation=WindowStartupLocation.CenterScreen; 
            showWindow.ShowDialog();
        }
        #endregion
    }
}