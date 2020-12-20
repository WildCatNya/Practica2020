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
    /// Логика взаимодействия для StreetPage.xaml
    /// </summary>
    public partial class StreetPage : Page
    {
        public StreetPage()
        {
            InitializeComponent();
            //DGridStreetPage.ItemsSource = MagazineSetEntities.GetContext().Справочник__Улица.ToList();
        }

        private void Button_Edit(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new AddPageStreet((sender as Button).DataContext as Справочник__Улица));
        }

        private void Button_AddPage(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new AddPageStreet(null));
        }

        private void Button_DeletePage(object sender, RoutedEventArgs e)
        {
            var StreetForRemoving = DGridStreetPage.SelectedItems.Cast<Справочник__Улица>().ToList();
            if (MessageBox.Show($"Вы точно хотите удалить следующие {StreetForRemoving.Count()} элементов?",
                "Внимание", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    MagazineSetEntities.GetContext().Справочник__Улица.RemoveRange(StreetForRemoving);
                    MagazineSetEntities.GetContext().SaveChanges();
                    MessageBox.Show("Данные удалены!");
                    DGridStreetPage.ItemsSource = MagazineSetEntities.GetContext().Справочник__Улица.ToList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
            {
                MagazineSetEntities.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
                DGridStreetPage.ItemsSource = MagazineSetEntities.GetContext().Справочник__Улица.ToList();
            }
        }
    }
}
