using System;
using System.Collections.Generic;
using System.Linq;
using System.ComponentModel;
using System.Text;
using System.Threading.Tasks;

namespace BindingProject
{
    internal class TestViewModel : INotifyPropertyChanged
    {
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
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
