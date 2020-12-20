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
    /// Логика взаимодействия для ProdavecPage.xaml
    /// </summary>
    public partial class ProdavecPage : Page
    {
        public ProdavecPage()
        {
            InitializeComponent();
            //DGridProdavecPage.ItemsSource = MagazineSetEntities.GetContext().Продавец.ToList();
        }

        private void Button_AddPage(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new AddPageProdavec(null));
        }

        private void Page_IsVisibleChanged(object sender, DependencyPropertyChangedEventArgs e)
        {
            if (Visibility == Visibility.Visible)
            {
                MagazineSetEntities.GetContext().ChangeTracker.Entries().ToList().ForEach(p => p.Reload());
                DGridProdavecPage.ItemsSource = MagazineSetEntities.GetContext().Продавец.ToList();
            }
        }

        private void Button_Edit(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new AddPageProdavec((sender as Button).DataContext as Продавец));
        }

        private void Button_DeletePage(object sender, RoutedEventArgs e)
        {
            var ProdavecForRemoving = DGridProdavecPage.SelectedItems.Cast<Продавец>().ToList();
            if (MessageBox.Show($"Вы точно хотите удалить следующие {ProdavecForRemoving.Count()} элементов?",
                "Внимание", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    MagazineSetEntities.GetContext().Продавец.RemoveRange(ProdavecForRemoving);
                    MagazineSetEntities.GetContext().SaveChanges();
                    MessageBox.Show("Данные удалены!");
                    DGridProdavecPage.ItemsSource = MagazineSetEntities.GetContext().Продавец.ToList();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message.ToString());
                }
            }
        }
    }
}
