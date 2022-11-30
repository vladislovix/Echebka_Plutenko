using MaterialDesignThemes.Wpf;
using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Remoting.Contexts;
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
    /// Логика взаимодействия для Uslugi.xaml
    /// </summary>
    public partial class Uslugi : Window
    {
        baza1Entities context;
        
        public Uslugi()
        {
            InitializeComponent();
            context = new baza1Entities();
            TableServices.ItemsSource = context.Services_.ToList();
            //bazaEntities database = new bazaEntities();
            //InitializeComponent();
            //TableServices.ItemsSource = database.Services_.ToList();
            //TableServices.ItemsSource = database.ServicesImages.ToList(); ломает таблицу

        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            context = new baza1Entities();
            Services_ item = TableServices.SelectedItem as Services_;
            try
            {
                Services_ service = context.Services_.Where(c => c.Id == item.Id).Single();
                context.Services_.Remove(service);
                context.SaveChanges();

                MessageBox.Show("Клиент успешно удалён!");
                //Метод обновления таблицы после удаления
                refreshdatagrid();
            }

            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
        }

        private void refreshdatagrid()
        {
            TableServices.ItemsSource = context.Services_.ToList();
            TableServices.Items.Refresh();
        }

        

        private void Button_add_t(object sender, RoutedEventArgs e)
        {
            this.Visibility = Visibility.Collapsed;
            MainWindow window = new MainWindow();
            window.Show();
        }

        private void Button_add_u(object sender, RoutedEventArgs e)
        {
            var NewDob = new Services_();
            context.Services_.Add(NewDob);
            OpenFileDialog das = new OpenFileDialog();
            das.Title = "Выберите изображение";
            das.Filter = "All supported graphics|*.jpeg;*.jpg;*.png|" + " JPEG(*.jpeg;*.jpg)|*.jpeg;*.jpg|" +
            "Portable Network Graphic (*.png)|*.png";
            if (das.ShowDialog() == true)
            {
                NewDob.ServicesImages = new ServicesImages { ImagePath = das.FileName };
            }
            WindowAd newClientWindow = new WindowAd(context, NewDob);
            newClientWindow.ShowDialog();

            refreshdatagrid();
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            Button reda = sender as Button;
            var reda1 = reda.DataContext as Services_;
            OpenFileDialog das = new OpenFileDialog();
            das.Title = "Выберите изображение";
            das.Filter = "All supported graphics|*.jpeg;*.jpg;*.png|" + " JPEG(*.jpeg;*.jpg)|*.jpeg;*.jpg|" +
            "Portable Network Graphic (*.png)|*.png";
            if (das.ShowDialog() == true)
            {
                reda1.ServicesImages = new ServicesImages { ImagePath = das.FileName };
            }
            WindowAd newClientWindow = new WindowAd(context, reda1);
            newClientWindow.ShowDialog();
        }
    }
}
