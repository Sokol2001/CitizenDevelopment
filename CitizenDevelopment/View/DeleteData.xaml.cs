using CitizenDevelopment.ViewModel;
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
using System.Windows.Shapes;

namespace CitizenDevelopment.View
{
    public partial class DeleteData : Window
    {
        private DeleteDataViewModel viewModel;

        public DeleteData()
        {
            InitializeComponent();
        }

        private void Button_Cancel_Click(object sender, RoutedEventArgs e)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            Close();
        }

        private void findDataButton_Click(object sender, RoutedEventArgs e)
        {
            viewModel = new DeleteDataViewModel(Convert.ToInt32(txtId.Text));

            var isGeted = viewModel.GetData();

            if (isGeted)
            {
                txtAppName.Text = viewModel.DataModel.ApplicationName;
                txtUserName.Text = viewModel.DataModel.UserName;
                txtComment.Text = viewModel.DataModel.Comment;

                txtId.IsReadOnly = true;

                findDataButton.Visibility = Visibility.Hidden;
                saveButton.Visibility = Visibility.Visible;
            }
        }

        private void saveButton_Click(object sender, RoutedEventArgs e)
        {
            viewModel.DeleteData();

            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            Close();
        }
    }
}
