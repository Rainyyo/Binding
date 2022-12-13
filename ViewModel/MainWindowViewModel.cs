using DXH.ViewModel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Threading;

namespace WpfTest.ViewModel
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        private DispatcherTimer ShowTimer;
        public MainWindowViewModel()
        {
            ShowTimer = new DispatcherTimer();//实例化
            ShowTimer.Interval = TimeSpan.FromSeconds(1);//每隔一秒触发一次
            ShowTimer.Tick += ShowTimer_Tick;//创建事件触发器
            ShowTimer.Start();//启动计时器   
        }

        private void ShowTimer_Tick(object sender, EventArgs e)
        {
            //NowTime = System.DateTime.Now.ToString();
            NowTime = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");//另一种显示的文本格式  
        }


        private string  nowTime;//创建一个实现来实现前端的Binding

       

        /// <summary>
        /// 前端 Binding  NowTime
        /// </summary>
        public string NowTime
        {
			get { return nowTime; }
			set
			{ 
				nowTime = value;
                this.OnPropertyChanged("NowTime");//改写的方法

                //PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("NowTime"));//自带的方法
            }
		}


        #region   
        public event PropertyChangedEventHandler PropertyChanged;//实现接口
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
}
