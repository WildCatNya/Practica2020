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
    /// Логика взаимодействия для AddPageStreet.xaml
    /// </summary>
    public partial class AddPageStreet : Page
    {
        private Справочник__Улица _currentStreet = new Справочник__Улица();
        public AddPageStreet(Справочник__Улица selectedStreet)
        {
            InitializeComponent();
            if (selectedStreet != null)
            {
                _currentStreet = selectedStreet;
            }
            DataContext = _currentStreet;
        }

        private void Button_Save(object sender, RoutedEventArgs e)
        {
            if (_currentStreet.id_СУ == 0)
            {
                MagazineSetEntities.GetContext().Справочник__Улица.Add(_currentStreet);
            }
            try
            {
                MagazineSetEntities.GetContext().SaveChanges();
                MessageBox.Show("Сохранение успешно");
                Manager.MainFrame.GoBack();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message.ToString());
            }
        }
    }
}
