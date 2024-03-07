using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace BindingProject
{
    internal class RelayCommand : ICommand
    {
        public event EventHandler CanExecuteChanged; // 실행할 수 있는 상태 확인 이벤트

        public bool CanExecute(object parameter) // 실행할 수 있는 상태 확인
        {
            return true;
        }

        public void Execute(object parameter) // 실행문
        {
            MessageBox.Show("Test 성공");
        }

    }
}
