using CitizenDevelopment.Model;
using System.Collections.Generic;
using System.Data;
using System.Data.SQLite;

namespace CitizenDevelopment.DataAccess
{
    public class DataAccess
    {
        private readonly string connectionString;

        public DataAccess(string connectionString)
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
                    cmd.CommandText = "INSERT INTO Data (ApplicationName, UserName, Comment) VALUES (@ApplicationName, @UserName, @Comment)";
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
                    cmd.CommandText = "DELETE FROM Data WHERE Id=@Id";
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
                    cmd.CommandText = "UPDATE Data SET ApplicationName=@ApplicationName, UserName=@UserName, Comment=@Comment WHERE Id=@Id";
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

            using (SQLiteConnection conn = new SQLiteConnection(connectionString))
            {
                conn.Open();

                using (SQLiteCommand cmd = new SQLiteCommand(conn))
                {
                    cmd.CommandText = "SELECT * FROM Data";
                    SQLiteDataAdapter adapter = new SQLiteDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    foreach (DataRow row in dt.Rows)
                    {
                        data.Add(new DataModel()
                        {
                            Id = (int)row["Id"],
                            ApplicationName = (string)row["ApplicationName"],
                            UserName = (string)row["UserName"],
                            Comment = (string)row["Comment"]
                        });
                    }
                }
            }

            return data;
        }
    }
}
