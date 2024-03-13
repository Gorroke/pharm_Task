using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace PictuerDrawing
{
    internal class NamingViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public Action CloseAction { get; set; }

        private string _namingPicture;
        public string NamingName
        {
            get { return _namingPicture; }
            set { _namingPicture = value; }
        }
        public ICommand NamingButton { get; set; }
        public NamingViewModel() 
        {
            NamingButton = new RelayCommand(SaveNaming);
        }
        private void SaveNaming(object sender)
        {
            NameingPicture np = NameingPicture.GetInstance();
            np.PictureName = NamingName;
            MessageBox.Show("저장 완료");
            CloseAction();
        }
    }
}
