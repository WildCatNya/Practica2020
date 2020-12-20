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
    /// Логика взаимодействия для AddPageGain.xaml
    /// </summary>
    public partial class AddPageGain : Page
    {
        private Продавец_Товар__Выручка_ _currentGain = new Продавец_Товар__Выручка_();
        public AddPageGain(Продавец_Товар__Выручка_ selectedGain)
        {
            InitializeComponent();
            if (selectedGain != null)
            {
                _currentGain = selectedGain;
            }
            DataContext = _currentGain;
            ComboProdavecF.ItemsSource = MagazineSetEntities.GetContext().Продавец.ToList();
            ComboProdavecI.ItemsSource = MagazineSetEntities.GetContext().Продавец.ToList();
            ComboProdavecO.ItemsSource = MagazineSetEntities.GetContext().Продавец.ToList();
            ComboTovar.ItemsSource = MagazineSetEntities.GetContext().Товар.ToList();
        }

        private void Button_Save(object sender, RoutedEventArgs e)
        {
            if (_currentGain.id_выручки == 0)
            {
                MagazineSetEntities.GetContext().Продавец_Товар__Выручка_.Add(_currentGain);
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
