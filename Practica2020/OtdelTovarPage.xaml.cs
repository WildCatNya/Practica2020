﻿using System;
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
    /// Логика взаимодействия для OtdelTovarPage.xaml
    /// </summary>
    public partial class OtdelTovarPage : Page
    {
        public OtdelTovarPage()
        {
            InitializeComponent();
            DGridOtdelTovarPage.ItemsSource = MagazineSetEntities.GetContext().Отдел_товар.ToList();
        }

        private void Button_Edit(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new AddPageOtdelTovar((sender as Button).DataContext as Отдел_товар));
        }

        private void Button_AddPage(object sender, RoutedEventArgs e)
        {
            Manager.MainFrame.Navigate(new AddPageOtdelTovar(null));
        }

        private void Button_DeletePage(object sender, RoutedEventArgs e)
        {
            var OtdelTovarForRemoving = DGridOtdelTovarPage.SelectedItems.Cast<Отдел_товар>().ToList();
            if (MessageBox.Show($"Вы точно хотите удалить следующие {OtdelTovarForRemoving.Count()} элементов?",
                "Внимание", MessageBoxButton.YesNo, MessageBoxImage.Question) == MessageBoxResult.Yes)
            {
                try
                {
                    MagazineSetEntities.GetContext().Отдел_товар.RemoveRange(OtdelTovarForRemoving);
                    MagazineSetEntities.GetContext().SaveChanges();
                    MessageBox.Show("Данные удалены!");
                    DGridOtdelTovarPage.ItemsSource = MagazineSetEntities.GetContext().Отдел_товар.ToList();
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
                DGridOtdelTovarPage.ItemsSource = MagazineSetEntities.GetContext().Отдел_товар.ToList();
            }
        }
    }
}
