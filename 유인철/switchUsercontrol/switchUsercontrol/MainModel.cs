using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace switchUsercontrol
{
    internal class MainModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private int switchView;
        public int SwitchView
        {
            get { return switchView; }
            set
            {
                switchView = value;
                OnPropertyChanged("SwitchView");
            }
        }
        public ICommand SwitchViewCommand { get; }
        public MainModel()
        {
            SwitchView = 0;
            SwitchViewCommand = new RelayCommand<object>(p => OnSwitchView(p));
        }

        private void OnSwitchView(object index)
        {
            SwitchView = int.Parse(index.ToString());
        }


    }
}
