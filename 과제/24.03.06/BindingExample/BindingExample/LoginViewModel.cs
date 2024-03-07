using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace BindingExample
{
    internal class LoginViewModel : INotifyPropertyChanged
    {
        private string id;
        public string ID
        {
            get { return id; }
            set
            {
                id = value;
                OnPropertyChanged(nameof(ID));
            }
        }

        private string pw;
        public string PW
        {
            get { return pw; }
            set
            {
                pw = value;
                OnPropertyChanged(nameof(PW));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }


        public ICommand CMD_Login { get; set; }

        public LoginViewModel()
        {
            CMD_Login = new RelayCommand(Login);
        }

        private void Login(object sender)
        {
        }

    }
}
