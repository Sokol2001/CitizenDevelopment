using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CitizenDevelopment.Model
{
    public static class DataWorker
    {
        public static List<DataModel> GetAllDataModels()
        {
            using (SQLiteConnection connection = new SQLiteConnection(App.databasePath))
            {
                connection.Open();

                using var command = new SQLiteCommand("SELECT * FROM DataModel", connection);

                var result = command.ExecuteScalar();

                connection.Close();

                return new List<DataModel>();
            }
        }
    }
}
