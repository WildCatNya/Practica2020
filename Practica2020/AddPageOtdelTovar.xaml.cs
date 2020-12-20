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
    /// Логика взаимодействия для AddPageOtdelTovar.xaml
    /// </summary>
    public partial class AddPageOtdelTovar : Page
    {
        private Отдел_товар _currentOtdelTovar = new Отдел_товар();
        public AddPageOtdelTovar(Отдел_товар selectedOtdelTovar)
        {
            InitializeComponent();
            if (selectedOtdelTovar != null)
            {
                _currentOtdelTovar = selectedOtdelTovar;
            }
            DataContext = _currentOtdelTovar;
            ComboOtdel.ItemsSource = MagazineSetEntities.GetContext().Отдел.ToList();
            ComboTovar.ItemsSource = MagazineSetEntities.GetContext().Товар.ToList();
        }

        private void Button_Save(object sender, RoutedEventArgs e)
        {
            if ((_currentOtdelTovar.id_отдела == 0) && _currentOtdelTovar.id_товара == 0)
            {
                MagazineSetEntities.GetContext().Отдел_товар.Add(_currentOtdelTovar);
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
