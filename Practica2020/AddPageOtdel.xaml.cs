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
    /// Логика взаимодействия для AddPageOtdel.xaml
    /// </summary>
    public partial class AddPageOtdel : Page
    {
        private Отдел _currentOtdel = new Отдел();
        public AddPageOtdel(Отдел selectedOtdel)
        {
            InitializeComponent();
            if (selectedOtdel != null)
            {
                _currentOtdel = selectedOtdel;
            }
            DataContext = _currentOtdel;
            ComboMagName.ItemsSource = MagazineSetEntities.GetContext().Magazine.ToList();
        }
        private void Button_Save(object sender, RoutedEventArgs e)
        {
            //if (_currentOtdel.id_отдела == 0)
            //{
                MagazineSetEntities.GetContext().Отдел.Add(_currentOtdel);
            //}
            //try
            //{
                MagazineSetEntities.GetContext().SaveChanges();
                MessageBox.Show("Сохранение успешно");
                Manager.MainFrame.GoBack();
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show(ex.Message.ToString());
            //}
        }
    }
}
