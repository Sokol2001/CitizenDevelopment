using System.Data;
using System.Data.SQLite;
using System.Windows;

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

            string connectionString = "Data Source=C:\\Users\\Oleksii\\source\\repos\\CitizenDevelopment\\database.db";

            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                SQLiteDataAdapter adapter = new SQLiteDataAdapter("SELECT * FROM DataModel", connection);

                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                myDataGrid.ItemsSource = dataTable.DefaultView;
            }
        }
    }
}
