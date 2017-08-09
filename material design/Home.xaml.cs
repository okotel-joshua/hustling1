using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
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
using System.Configuration;
using MySql.Data.MySqlClient;
using System.Data;
using System.Windows.Navigation;

namespace material_design
{
    /// <summary>
    /// Interaction logic for Home.xaml
    /// </summary>
    public partial class Home : Page
    {

        public class DataObject
        {
            public int id { get; set; }
            public string names { get; set; }
            public string number { get; set; }
            public string email { get; set; }
        }
        MySqlConnection connection = new MySqlConnection("server=localhost; user=''; database=student_checkpage; port=3306; password='';");

        public Home()
        {
            InitializeComponent();
            connection.Open();

            MySqlCommand cmd = new MySqlCommand("SELECT * FROM `contacts`", connection);
            MySqlDataAdapter sda = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable("contacts");
            sda.Fill(dt);
            dataGrid1.ItemsSource = dt.DefaultView;
            connection.Close();

            //var list = new ObservableCollection<DataObject>();
            //list.Add(new DataObject() { id = 1, name = "Ben", phone = "0706820009", email = "bensek73@gmail.com" });
            // list.Add(new DataObject() { id = 2, name = "Mark", phone = "0706820009", email = "bensek73@gmail.com" });
            //list.Add(new DataObject() { id = 3, name = "Sek", phone = "0706820009", email = "bensek73@gmail.com" });
            //list.Add(new DataObject() { id = 4, name = "Mike", phone = "0706820009", email = "bensek73@gmail.com" });
            //list.Add(new DataObject() { id = 5, name = "Willy", phone = "0706820009", email = "bensek73@gmail.com" });

            //this.dataGrid1.ItemsSource = list;
        }

        private void dataGrid1_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            //NavigationWindow window = new NavigationWindow();
            //window.Source = new Uri("Window1.xaml", UriKind.Relative);
            //window.Show();
            //this.Close();

            NavigationService nav = NavigationService.GetNavigationService(this);
            nav.Navigate(new Uri("Window1.xaml", UriKind.RelativeOrAbsolute));
        }
    }
}
