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
    /// Логика взаимодействия для TovarPage.xaml
    /// </summary>
    public partial class TovarPage : Page
    {
        public TovarPage()
        {
            InitializeComponent();
            //DGridTovarPage.ItemsSource = MagazineSetEntities.GetContext().Товар.ToList();
        }

        private void Button_Edit(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new AddPageTovar((sender as Button).DataContext as Товар));
        }

        private void Button_AddPage(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new AddPageTovar(null));
        }

        private void Button_DeletePage(object sender, RoutedEventArgs e)
        {
            var TovarForRemoving = DGridTovarPage.SelectedItems.Cast<Товар>().ToList();
            if (MessageBox.Show($"Вы точно хотите удалить следующие {TovarForRemoving.Count()} элементов?",
                "Внимание", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    MagazineSetEntities.GetContext().Товар.RemoveRange(TovarForRemoving);
                    MagazineSetEntities.GetContext().SaveChanges();
                    MessageBox.Show("Данные удалены!");
                    DGridTovarPage.ItemsSource = MagazineSetEntities.GetContext().Товар.ToList();
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
                DGridTovarPage.ItemsSource = MagazineSetEntities.GetContext().Товар.ToList();
            }
        }
    }
}
