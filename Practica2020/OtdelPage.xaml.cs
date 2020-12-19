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
    /// Логика взаимодействия для OtdelPage.xaml
    /// </summary>
    public partial class OtdelPage : Page
    {
        public OtdelPage()
        {
            InitializeComponent();
            DGridOtdelPage.ItemsSource = MagazineSetEntities.GetContext().Отдел.ToList();
        }
    }
}
