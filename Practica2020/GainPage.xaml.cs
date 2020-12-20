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
    /// Логика взаимодействия для GainPage.xaml
    /// </summary>
    public partial class GainPage : Page
    {
        public GainPage()
        {
            InitializeComponent();
            //DGridGainPage.ItemsSource = MagazineSetEntities.GetContext().Продавец_Товар__Выручка_.ToList();
        }

        private void Button_Edit(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new AddPageGain((sender as Button).DataContext as Продавец_Товар__Выручка_));
        }

        private void Button_AddPage(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new AddPageGain(null));
        }

        private void Button_DeletePage(object sender, RoutedEventArgs e)
        {
            var GainForRemoving = DGridGainPage.SelectedItems.Cast<Продавец_Товар__Выручка_>().ToList();
            if (MessageBox.Show($"Вы точно хотите удалить следующие {GainForRemoving.Count()} элементов?",
                "Внимание", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    MagazineSetEntities.GetContext().Продавец_Товар__Выручка_.RemoveRange(GainForRemoving);
                    MagazineSetEntities.GetContext().SaveChanges();
                    MessageBox.Show("Данные удалены!");
                    DGridGainPage.ItemsSource = MagazineSetEntities.GetContext().Продавец_Товар__Выручка_.ToList();
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
                DGridGainPage.ItemsSource = MagazineSetEntities.GetContext().Продавец_Товар__Выручка_.ToList();
            }
        }
    }
}
