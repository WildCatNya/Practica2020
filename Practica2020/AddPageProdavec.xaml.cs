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
    /// Логика взаимодействия для AddPageProdavec.xaml
    /// </summary>
    public partial class AddPageProdavec : Page
    {
        private Продавец _currentProdavec = new Продавец();
        public AddPageProdavec(Продавец selectedProdavec)
        {
            InitializeComponent();
            if (selectedProdavec != null)
            {
                _currentProdavec = selectedProdavec;
            }
            DataContext = _currentProdavec;
            ComboOtdel.ItemsSource = MagazineSetEntities.GetContext().Отдел.ToList();
            ComboStreet.ItemsSource = MagazineSetEntities.GetContext().Справочник__Улица.ToList();
            ComboMagazine.ItemsSource = MagazineSetEntities.GetContext().Magazine.ToList();
        }

        private void Button_Save(object sender, RoutedEventArgs e)
        {
            if (_currentProdavec.id_продавца == 0)
            {
                MagazineSetEntities.GetContext().Продавец.Add(_currentProdavec);
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
