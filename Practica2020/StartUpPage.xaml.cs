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
    }
}
