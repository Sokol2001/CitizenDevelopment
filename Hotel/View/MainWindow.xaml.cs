using CitizenDevelopment.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Windows;
using System.Windows.Controls;

namespace CitizenDevelopment.View
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            string connectionString = "Data Source=C:\\Users\\Oleksii\\source\\repos\\CitizenDevelopment\\Hotel\\bin\\Debug\\database.db";

            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                SQLiteDataAdapter adapter = new SQLiteDataAdapter("SELECT * FROM DataModel", connection);

                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                myDataGrid.ItemsSource = dataTable.DefaultView;
            }
        }


        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string connectionString = "Data Source=C:\\Users\\Oleksii\\source\\repos\\CitizenDevelopment\\Hotel\\bin\\Debug\\database.db";

            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                SQLiteDataAdapter adapter = new SQLiteDataAdapter("SELECT Id, ApplicationName, UserName, Comment FROM DataModel", connection);

                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                myDataGrid.ItemsSource = dataTable.DefaultView;
            }
        }
    }
}
