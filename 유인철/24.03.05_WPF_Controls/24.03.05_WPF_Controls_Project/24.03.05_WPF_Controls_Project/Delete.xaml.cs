using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace _24._03._05_WPF_Controls_Project
{
    /// <summary>
    /// Delete.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class Delete : Window
    {
        public string DeleteName { get; set; }
        public bool OK_Cancel { get; set; }
        public Delete()
        {
            InitializeComponent();
            OK_Cancel = false;
        }

        private void OKbutton_Click(object sender, RoutedEventArgs e)
        {
            if(NameBox.Text != null)
            {
                DeleteName = NameBox.Text;
                OK_Cancel = true;
                this.Close();
            }
            else
            {
                MessageBox.Show("잘못 입력 하셨습니다.");
            }
        }

        private void Cancelbutton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
