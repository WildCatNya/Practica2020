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
    /// Логика взаимодействия для AddPageTovar.xaml
    /// </summary>
    public partial class AddPageTovar : Page
    {
        private Товар _currentTovar = new Товар();
        public AddPageTovar(Товар selectedTovar)
        {
            InitializeComponent();
            if (selectedTovar != null)
            {
                _currentTovar = selectedTovar;
            }
            DataContext = _currentTovar;
        }

        private void Button_Save(object sender, RoutedEventArgs e)
        {

            if (_currentTovar.id_товара == 0)
            {
                MagazineSetEntities.GetContext().Товар.Add(_currentTovar);
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
