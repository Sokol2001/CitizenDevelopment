using CitizenDevelopment.ViewModel;
using System;
using System.Windows;
using System.Windows.Media.Animation;

namespace CitizenDevelopment.View
{
    public partial class MainWindow : Window
    {
        private readonly MainWindowViewModel viewModel;

        public MainWindow()
        {
            InitializeComponent();
            viewModel = new MainWindowViewModel();
            DataContext = viewModel;

            Loaded += MainWindow_Loaded;

            WindowStartupLocation = WindowStartupLocation.CenterScreen;
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            DoubleAnimation animation = new DoubleAnimation(0, 1, TimeSpan.FromSeconds(5));
            this.BeginAnimation(UIElement.OpacityProperty, animation);
        }

        private void btnGet_Click(object sender, RoutedEventArgs e)
        {
            viewModel.GetData();

            myDataGrid.ItemsSource = viewModel.DataModels;
        }

        private void btnInsert_Click(object sender, RoutedEventArgs e)
        {
            InsertData insertData = new InsertData();
            insertData.Show();
            Close();
        }

        private void btnUpdate_Click(object sender, RoutedEventArgs e)
        {
            UpdateData updateData = new UpdateData();
            updateData.Show();
            Close();
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            DeleteData deleteData = new DeleteData();
            deleteData.Show();
            Close();
        }
    }
}
