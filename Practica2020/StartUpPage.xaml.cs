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

namespace Practica2020
{
    /// <summary>
    /// Логика взаимодействия для StartUpPage.xaml
    /// </summary>
    public partial class StartUpPage : Page
    {
        public StartUpPage()
        {
            InitializeComponent();
        }

        private void Button_ClickMagazine(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new MagazinePage());
        }

        private void Button_ClickOtdel(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new OtdelPage());
        }

        private void Button_ClickTovar(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new TovarPage());
        }

        private void Button_ClickOtdelTovar(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new OtdelTovarPage());
        }

        private void Button_ClickStreet(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new StreetPage());
        }

        private void Button_ClickProdavec(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new ProdavecPage());
        }

        private void Button_ClickGain(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new GainPage());
        }
    }
}
