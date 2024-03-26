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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace _0321_wpf디자인
{
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            List<User> items = new List<User>();
            items.Add(new User() { Name = "Apple Store", TransferID = "123 455 657", Category = "Electronics", Date = "Nov 11, 2023", Amount="$ 650" 
            , ImagePath="/Resources/apple.png"});
            items.Add(new User() { Name = "Spotify", TransferID = "113 385 127", Category = "Subscribe",  Date = "Nov 15, 2023", Amount = "$ 12.5",
                ImagePath = "/Resources/spotify.png"});
            items.Add(new User() { Name = "Amazon", TransferID = "127 345 278", Category = "Home Decore", Date = "Nov 18, 2023", Amount = "$ 1560" ,
                ImagePath = "/Resources/amazon.jpeg"});
            items.Add(new User() { Name = "Binance", TransferID = "421 451 831", Category = "Subscribe", Date = "Nov 21, 2023", Amount = "$ 11320",
                ImagePath = "/Resources/binance.png"});
            Item.ItemsSource = items;
        }
        public class User
        {
            public string _ImagePath;

            private string _Name;

            private string _TransferID;

            private string _Category;

            private string _Date;

            private string _Status;

            private string _Amount;


            public string ImagePath {  get; set; }
            public string Name { get { return _Name; } set { _Name = value; } }

            public string TransferID { get { return _TransferID; } set { _TransferID = value; } }

            public string Category { get { return _Category; } set { _Category = value; } }

            public string Date { get { return _Date; } set { _Date = value; } }

            public string Status { get { return _Status; } set { _Status = value; } }
            public string Amount { get { return _Amount; } set { _Amount = value; } }

        }
        private static User ListView_GetItem(RoutedEventArgs e)
        {
            DependencyObject dep = (DependencyObject)e.OriginalSource;
            while (!(dep is System.Windows.Controls.ListViewItem))
            {
                try
                {
                    dep = VisualTreeHelper.GetParent(dep);
                }
                catch
                {
                    return null;
                }
            }
            ListViewItem item = (ListViewItem)dep;
            User content = (User)item.Content;
            return content;
        }

        private void Status_Click(object sender, RoutedEventArgs e)
        {
            User user = (User)Item.SelectedItem;

            if (user != null)
            {
                MessageBox.Show($"선택 {user.Name}");
            }
            else
            {
                MessageBox.Show("선택되지 않았습니다");
            }
        }

    }
}
