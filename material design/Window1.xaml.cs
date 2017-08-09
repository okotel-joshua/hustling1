using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
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

namespace material_design
{
    /// <summary>
    /// Interaction logic for Window1.xaml
    /// </summary>
    public partial class Window1 : Page
    {
        MySqlConnection connection = new MySqlConnection("server=localhost; user=root; database=student_checkpage; port=3306; password='';");

        public Window1()
        {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            connection.Open();
            MySqlCommand comm = connection.CreateCommand();
            comm.CommandText = "INSERT INTO contacts(names,number,email) VALUES (@names, @number, @email)";
            comm.Parameters.AddWithValue("@names", nametxt.Text);
            comm.Parameters.AddWithValue("@number", phonetxt.Text);
            comm.Parameters.AddWithValue("@email", emailtxt.Text);
            comm.ExecuteNonQuery();
            connection.Close();
            NavigationService nav = NavigationService.GetNavigationService(this);
            nav.Navigate(new Uri("Home.xaml", UriKind.RelativeOrAbsolute));

        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            NavigationService nav = NavigationService.GetNavigationService(this);
            nav.Navigate(new Uri("Home.xaml", UriKind.RelativeOrAbsolute));

        }
    }
}
