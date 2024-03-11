using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace wpf_binding.Model
{
    /// <summary>
    /// INotifyPropertyChanged 인터페이스
    /// 객체에서 속성 값이 변경될 때 UI에 알리는데 사용
    /// ViewModel에서 속성 값이 변경될 떄 UI가 자동으로 업데이트
    /// </summary>
    internal class MainModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        //protected void OnPropertyChanged(string propertyName)
        //{
        //    if (PropertyChanged != null)
        //    {
        //        PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
        //    }
        //}

        protected void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler propertyChangedEventHandler = this.PropertyChanged;
            if (propertyChangedEventHandler != null)
            {
                propertyChangedEventHandler(this, new PropertyChangedEventArgs(name));
            }
        }
        private int num = 1;

        public int Num
        {
            set 
            {
                num = value;
                Num2 = value - 2;
                OnPropertyChanged("Num");
            }
            get 
            {
                return num; 
            }
        }

        private int num2 = 2;
        public int Num2
        {
            set
            {
                num2 = value;
                OnPropertyChanged("Num2");
            }
            get
            {
                return num2;
            }
        }
    }
}
