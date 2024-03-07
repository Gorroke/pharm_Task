using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace BindingProject
{
    internal class TestViewModel : INotifyPropertyChanged
    {
        private ICommand buttonICommand;
        public ICommand ButtonICommand
        {
            get
            {
                buttonICommand = new RelayCommand();
                return buttonICommand;
            }
        }
        string testtext;
        public string TestText
        {
            get { return testtext; }
            set
            {
                testtext = value;
                OnPropertyChanged("TestText");
            }
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnPropertyChanged(string propertyName)
        {
            if(PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName)); // label의 값 변경
            }
            //if문을 생략하고 한줄로 요약 가능
            //PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName)); << 위 if문과 같은 문장 null이 아니면 invoke한다.
        }
        
    }
}
