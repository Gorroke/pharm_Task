﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Windows.Input;

namespace wpf_binding.ViewModel
{
    internal class MainViewModel:INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        protected void OnpropertyChanged(string name)
        {
            PropertyChangedEventHandler propertyChangedEventHandler = PropertyChanged;
            if(propertyChangedEventHandler != null)
            {
                propertyChangedEventHandler(this, new PropertyChangedEventArgs(name));
            }
        }

        public ICommand ClickCommand { get; }
        public MainViewModel()
        {
            model = new Model.MainModel();
            ClickCommand = new RelayCommand(OnClick);
        }

        private Model.MainModel model = null;
        public Model.MainModel Model
        {
            get { return model; }
            set { model = value; }
        }

        private void OnClick(object parameter)
        {
            Console.WriteLine("버튼 클릭되었습니다.");
        }

    }
}
