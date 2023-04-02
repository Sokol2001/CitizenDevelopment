using CitizenDevelopment.Model;
using CitizenDevelopment.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;

namespace CitizenDevelopment.View
{
    public partial class InsertData : Window
    {
        private readonly InsertDataViewModel viewModel;

        public InsertData()
        {
            InitializeComponent();
            viewModel = new InsertDataViewModel();

            WindowStartupLocation = WindowStartupLocation.CenterScreen;
        }

        private void Button_Cancel_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            Close();
        }

        private void Button_Save_Click(object sender, RoutedEventArgs e)
        {
            viewModel.DataModel = new DataModel
            {
                ApplicationName = txtAppName.Text,
                Comment = txtComment.Text,
                UserName = txtUserName.Text
            };

            viewModel.InsertData();

            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            Close();
        }
    }
}
