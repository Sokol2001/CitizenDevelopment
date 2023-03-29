using CitizenDevelopment.Model;
using System.Collections.Generic;
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

            
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            using (SQLiteConnection connection = new SQLiteConnection(App.databasePath))
            {
                var DB = new SQLiteConnection("Data Source=C:\\Users\\Oleksii\\source\\repos\\CitizenDevelopment\\Hotel\\bin\\Debug\\database.db; Pooling=true; FailIfMissing=false; Version=3");

                DB.Open();

                using var command = new SQLiteCommand("SELECT * FROM DataModel", connection);

                command.Connection.Open();

                var result = command.ExecuteScalar();

                connection.Close();

                
            }

        }
    }
}
