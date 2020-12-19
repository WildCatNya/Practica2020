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
    /// Логика взаимодействия для MagazinePage.xaml
    /// </summary>
    public partial class MagazinePage : Page
    {
        public MagazinePage()
        {
            InitializeComponent();
            //DGridMagPage.ItemsSource = MagazineSetEntities.GetContext().Magazine.ToList();
        }

        private void Button_AddPage(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new AddPage(null));
        }

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
            {
                MagazineSetEntities.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
                DGridMagPage.ItemsSource = MagazineSetEntities.GetContext().Magazine.ToList();
            }
        }

        private void Button_Edit(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new AddPage((sender as Button).DataContext as Magazine));
        }

        private void Button_DeletePage(object sender, RoutedEventArgs e)
        {
            var MagazineForRemoving = DGridMagPage.SelectedItems.Cast<Magazine>().ToList();
            if (MessageBox.Show($"Вы точно хотите удалить следующие {MagazineForRemoving.Count()} элементов?", 
                "Внимание", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    MagazineSetEntities.GetContext().Magazine.RemoveRange(MagazineForRemoving);
                    MagazineSetEntities.GetContext().SaveChanges();
                    MessageBox.Show("Данные удалены!");
                    DGridMagPage.ItemsSource = MagazineSetEntities.GetContext().Magazine.ToList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }
    }
}
