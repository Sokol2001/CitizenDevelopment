using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace CitizenDevelopment
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        static string databaseName = "database.db";
        //static string folderPath = Environment.CurrentDirectory;
        static string folderPath = @"C:\Users\Oleksii\source\repos\CitizenDevelopment\Hotel\bin\Debug\";

        static string x = "Data Source=C:\\Users\\Oleksii\\source\\repos\\CitizenDevelopment\\Hotel\\bin\\Debug\\database.db;Pooling=true;FailIfMissing=false;Version=3";

        public static string databasePath = System.IO.Path.Combine("Data Source= ",folderPath, databaseName, "; Version=3;");

    }
}
