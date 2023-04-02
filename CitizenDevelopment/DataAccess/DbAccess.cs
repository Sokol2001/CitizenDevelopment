using CitizenDevelopment.Model;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;
using System.Windows.Controls;

namespace CitizenDevelopment.DataAccess
{
    public class DbAccess
    {
        private readonly string connectionString;

        public DbAccess(string connectionString)
        {
            this.connectionString = connectionString;
        }

        public void InsertData(DataModel data)
        {
            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                conn.Open();

                using (SQLiteCommand cmd = new SQLiteCommand(conn))
                {
                    cmd.CommandText = "INSERT INTO DataModel (ApplicationName, UserName, Comment) VALUES (@ApplicationName, @UserName, @Comment)";
                    cmd.Parameters.AddWithValue("@ApplicationName", data.ApplicationName);
                    cmd.Parameters.AddWithValue("@UserName", data.UserName);
                    cmd.Parameters.AddWithValue("@Comment", data.Comment);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void DeleteData(int id)
        {
            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                conn.Open();

                using (SQLiteCommand cmd = new SQLiteCommand(conn))
                {
                    cmd.CommandText = "DELETE FROM DataModel WHERE Id=@Id";
                    cmd.Parameters.AddWithValue("@Id", id);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void UpdateData(DataModel data)
        {
            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                conn.Open();

                using (SQLiteCommand cmd = new SQLiteCommand(conn))
                {
                    cmd.CommandText = "UPDATE DataModel SET ApplicationName=@ApplicationName, UserName=@UserName, Comment=@Comment WHERE Id=@Id";
                    cmd.Parameters.AddWithValue("@Id", data.Id);
                    cmd.Parameters.AddWithValue("@ApplicationName", data.ApplicationName);
                    cmd.Parameters.AddWithValue("@UserName", data.UserName);
                    cmd.Parameters.AddWithValue("@Comment", data.Comment);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public List<DataModel> GetData()
        {
            List<DataModel> data = new List<DataModel>();

            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                SQLiteDataAdapter adapter = new SQLiteDataAdapter("SELECT * FROM DataModel", connection);

                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                foreach (DataRow row in dataTable.Rows)
                {
                    data.Add(new DataModel()
                    {
                        Id = Convert.ToInt32(row["Id"]),
                        ApplicationName = (string)row["ApplicationName"],
                        UserName = (string)row["UserName"],
                        Comment = (string)row["Comment"]
                    });
                }

            }


            return data;
        }

        public DataModel GetDataById(int id)
        {
            DataModel data = null;

            using (SQLiteConnection connection = new SQLiteConnection(connectionString))
            {
                SQLiteDataAdapter adapter = new SQLiteDataAdapter($"SELECT * FROM DataModel WHERE Id = {id}", connection);

                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                if (dataTable.Rows.Count > 0)
                {
                    DataRow row = dataTable.Rows[0];
                    data = new DataModel()
                    {
                        Id = Convert.ToInt32(row["Id"]),
                        ApplicationName = (string)row["ApplicationName"],
                        UserName = (string)row["UserName"],
                        Comment = (string)row["Comment"]
                    };
                }
            }

            return data;
        }

    }
}
