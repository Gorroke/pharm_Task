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
    /// Correction.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class Correction : Window
    {
        public string CorrectionName { get; set; }
        public string CorrectionSex { get; set; }
        public string CorrectionBirth {  get; set; }
        public bool OK_Cancel { get; set; }
        public Correction()
        {
            InitializeComponent();
            OK_Cancel = false;
        }

        private void OKButton_Click(object sender, RoutedEventArgs e)
        {
            if(CorrectionNameBox.Text != null && CorrectionSexBox.Text != null && CorrectionBirthBox.Text != null)
            {
                CorrectionName = CorrectionNameBox.Text;
                CorrectionSex = CorrectionSexBox.Text;
                CorrectionBirth = CorrectionBirthBox.Text;
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

        private void Window_Activated(object sender, EventArgs e)
        {
            CorrectionNameBox.Text = CorrectionName;
            CorrectionSexBox.Text = CorrectionSex;
            CorrectionBirthBox.Text = CorrectionBirth;
        }
    }
}
