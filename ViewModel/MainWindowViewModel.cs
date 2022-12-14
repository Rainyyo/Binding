using DXH.ViewModel;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Threading;


namespace WpfTest.ViewModel
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        private DispatcherTimer ShowTimer;//创建一个定时器ShowTimer的变量

        public MainWindowViewModel()
        {
            MyText = "Hello";//初始化MyText的值
            ShowTimer = new DispatcherTimer();//实例化
            ShowTimer.Interval = TimeSpan.FromSeconds(1);//每隔一秒触发一次
            ShowTimer.Tick += ShowTimer_Tick;//创建事件触发器
            ShowTimer.Start();//启动计时器
        }

        #region 接口的实现
        public event PropertyChangedEventHandler PropertyChanged;//实现接口
        #endregion

        private void ShowTimer_Tick(object sender, EventArgs e)
        {
            NowTime = System.DateTime.Now.ToString();
            //NowTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");//另一种显示的文本格式
        }

        /// <summary> 
        /// 前端 Binding 只能绑定属性名  NowTime
        /// </summary>
        private string  nowTime;//创建一个来实现前端的Binding
        
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
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("MyText"));//自带的方法
            }
        }



        #region OnPropertyChanged  
        
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

         //public bool CanExecute(object parameter)
         //{
         //    throw new NotImplementedException();
         //}

         //public void Execute(object parameter)
         //{
         //    throw new NotImplementedException();
         //}
         #endregion
    }

}
