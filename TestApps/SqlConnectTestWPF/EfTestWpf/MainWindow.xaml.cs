﻿using EfTestWpf.ManualMapping;
using EfTestWpf.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
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

namespace EfTestWpf
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        MobileContext db;
        public MainWindow()
        {
            InitializeComponent();

            db = new MobileContext();
            db.Phones.Load(); // загружаем данные
            phonesGrid.ItemsSource = db.Phones.Local.ToBindingList(); // устанавливаем привязку к кэшу

            this.Closing += MainWindow_Closing;
        }

        private void MainWindow_Closing(object sender, System.ComponentModel.CancelEventArgs e)
        {
            db.Dispose();
        }

        private void updateButton_Click(object sender, RoutedEventArgs e)
        {
            db.SaveChanges();
        }

        private void deleteButton_Click(object sender, RoutedEventArgs e)
        {
            if (phonesGrid.SelectedItems != null)
            {
                for (int i = 0; i < phonesGrid.SelectedItems.Count; i++)
                {
                    Phone phone = phonesGrid.SelectedItems[i] as Phone;
                    if (phone != null)
                    {
                        db.Phones.Remove(phone);
                    }
                }
            }
            db.SaveChanges();
        }

        private void TestButton_Click(object sender, RoutedEventArgs e)
        {
            TableHeaderExplorer exploreTable = new TableHeaderExplorer(ConstVarData.ConnectionStringToChips);

            var res = exploreTable.GetTabelHeader("Chips");
        }

        private void CreateMapperWindow(object sender, RoutedEventArgs e)
        {
            ManualMapping.View.ManualMappingView view = new ManualMapping.View.ManualMappingView();
            view.DataContext = new ManualMapping.ViewModel.ManualMapperViewModel();
            view.ShowDialog();
        }
    }
}
