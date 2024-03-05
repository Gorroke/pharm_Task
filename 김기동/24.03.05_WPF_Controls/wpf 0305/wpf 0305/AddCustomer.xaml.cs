//using System.Windows;

//namespace wpf_0305
//{
//    public partial class AddCustomerWindow : Window
//    {
//        public AddCustomerWindow()
//        {
//            InitializeComponent();
//        }

//        private void Add_Click(object sender, RoutedEventArgs e)
//        {
//            string name = NameTextBox.Text;
//            string gender = GenderComboBox.Text;
//            string birth = BirthDatePicker.SelectedDate?.ToString("yyMMdd");

//            if (!string.IsNullOrEmpty(name) && !string.IsNullOrEmpty(gender) && birth != null)
//            {
//                Customer newCustomer = new Customer(name, gender, birth);
//                // MainWindow의 AddCustomer 메서드 호출하여 새 고객 추가
//                MainWindow mainWindow = Application.Current.MainWindow as MainWindow;
//                if (mainWindow != null)
//                {
//                    mainWindow.AddCustomer(newCustomer);
//                    Close();
//                }
//            }
//            else
//            {
//                MessageBox.Show("입력값을 확인하세요.");
//            }
//        }

//    }
//}
