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

namespace WpfApp1
{
    /// <summary>
    /// Логика взаимодействия для MainWin.xaml
    /// </summary>
    public partial class MainWin : Window
    {
        public MainWin()
        {
            InitializeComponent();
        }

    
       

        private void Button_Serv(object sender, RoutedEventArgs e)
        {
            this.Visibility = Visibility.Collapsed;
            Uslugi window = new Uslugi();
            window.Show();
        }

        private void Button_Client(object sender, RoutedEventArgs e)
        {
            this.Visibility = Visibility.Collapsed;
            Clients window = new Clients();
            //window.Show();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
        }
    }
}
