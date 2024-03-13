using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Controls;
using System.Windows.Input;

namespace PictuerDrawing
{
    internal class SubViewModel : INotifyPropertyChanged
    {
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
        public SubViewModel(int value)
        {
            SwitchView = value;
        }
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
