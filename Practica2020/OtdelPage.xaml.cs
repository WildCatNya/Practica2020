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
    /// Логика взаимодействия для OtdelPage.xaml
    /// </summary>
    public partial class OtdelPage : Page
    {
        public OtdelPage()
        {
            InitializeComponent();
            //DGridOtdelPage.ItemsSource = MagazineSetEntities.GetContext().Отдел.ToList();
        }

        private void Button_AddPage(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new AddPageOtdel(null));
        }

        private void Button_DeletePage(object sender, RoutedEventArgs e)
        {
            var OtdelForRemoving = DGridOtdelPage.SelectedItems.Cast<Отдел>().ToList();
            if (MessageBox.Show($"Вы точно хотите удалить следующие {OtdelForRemoving.Count()} элементов?",
                "Внимание", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    MagazineSetEntities.GetContext().Отдел.RemoveRange(OtdelForRemoving);
                    MagazineSetEntities.GetContext().SaveChanges();
                    MessageBox.Show("Данные удалены!");
                    DGridOtdelPage.ItemsSource = MagazineSetEntities.GetContext().Отдел.ToList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }

        private void Button_Edit(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new AddPageOtdel((sender as Button).DataContext as Отдел));
        }

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
            {
                MagazineSetEntities.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
                DGridOtdelPage.ItemsSource = MagazineSetEntities.GetContext().Отдел.ToList();
            }
        }
    }
}
