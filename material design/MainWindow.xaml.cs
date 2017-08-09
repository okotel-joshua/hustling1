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
using System.Data.SqlClient;
using MySql.Data.MySqlClient;
using System.Data;

namespace material_design
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }
       // MySqlConnection connection = new MySqlConnection("server=localhost; user=root; database=student_checkpage; port=3306, password='';");
        MySqlConnection connection = new MySqlConnection("server=localhost; user=root; database=student_checkpage; port=3306; password='okotel1234';");

        private void TextBox_TextChanged(object sender, TextChangedEventArgs e)
        {

        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            connection.Open();
            MySqlCommand cmd = new MySqlCommand("SELECT `student_name`, `class_pin` FROM `register` WHERE `student_name` = '" + usernametxt.Text + "' AND `class_pin` = '" + passwordtxt.Text + "'", connection);
            
            MySqlDataAdapter da = new MySqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            da.Fill(dt);
            if(dt.Rows.Count > 0)
            {

               // NavigationService nav = NavigationService.GetNavigationService(this);
               // nav.Navigate(new Uri("Window1.xaml", UriKind.RelativeOrAbsolute));
                NavigationWindow window = new NavigationWindow();
                window.Source = new Uri("Home.xaml", UriKind.Relative);
                window.Show();
                this.Close();
            }
            else
            {

            }
            connection.Close();

            
            //var newForm = new Home(); //create your new form.
            //newForm.Show(); //show the new form.
            //this.Close(); //only if you want to close the current form.
            //Home p2 = new Home();
            //this.NavigationService.Navigate(p2);
            //NavigationService nav = NavigationService.GetNavigationService(this);
            //nav.Navigate(new Uri("Home.xaml", UriKind.RelativeOrAbsolute));
        }
    }
}
