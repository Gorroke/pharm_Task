using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows;
using System.Windows.Controls;

namespace BindingProject
{
    internal class TestViewModel : INotifyPropertyChanged
    {
        public ICommand ButtonICommand { get; set; }
        public TestViewModel() 
        { 
            ButtonICommand = new RelayCommand(TestMessageBox);
            
        }
        private void TestMessageBox(object sender)
        {
            MessageBox.Show(can.GetType().ToString());
        }

        Button can;
        public Button Can
        {
            get { return can; }
            set { can = value; }
        }

        string buttonText;
        public string ButtonText
        {
            get { return buttonText; }
            set { buttonText = value; }
        }


        string testtext;
        public string TestText
        {
            get { return testtext; }
            set
            {
                testtext = value;
                OnPropertyChanged("TestText"); // TestText 속성 명 값을 매개변수로 입력
            }
        }

        public event PropertyChangedEventHandler PropertyChanged; // 속성 값이 변경될 때 이벤트가 발생한다.
        protected void OnPropertyChanged(string propertyName)
        {
            if(PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName)); // label의 속성 값 변경
            }
            //if문을 생략하고 한줄로 요약 가능
            //PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName)); << 위 if문과 같은 문장 -> null이 아니면 invoke한다.
        }
        
    }
}
