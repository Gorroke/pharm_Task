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
    /// Add.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class Add : Window
    {
        public string Addname { get; set; }
        public string Addsex { get; set; }
        public string Addbirth { get; set; }
        public bool OK_Cancel { get; set; }
        public Add()
        {
            InitializeComponent();
            OK_Cancel = false;
        }

        private void OKButton_Click(object sender, RoutedEventArgs e)
        {
            if (AddName.Text != null && AddSex.Text != null && AddBirth.Text != null)
            {
                Addname = AddName.Text;
                Addsex = AddSex.Text;
                Addbirth = AddBirth.Text;
                OK_Cancel = true;
                this.Close();
            }
            else
            {
                MessageBox.Show("잘못 입력하셨습니다.");
            }
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }
    }
}
