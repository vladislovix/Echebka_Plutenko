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

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        baza1Entities database = new baza1Entities();
        public MainWindow()
        {
            InitializeComponent();
        }

        private void Button_auto_Click(object sender, RoutedEventArgs e)
        {
            string login = txtboxLogin.Text;
            string pass = txtboxPass.Password;

            if (database.Clients.Any(u => u.FirstName == login && u.LastName == pass))

            {
                foreach (var client in database.Clients)
                {
                    if (client.FirstName == login && client.LastName == pass)

                    {
                        

                        this.Visibility = Visibility.Collapsed;
                        Uslugi window = new Uslugi();
                        window.Show();

                    }
                }

            }
            
        }
    }
    
}

