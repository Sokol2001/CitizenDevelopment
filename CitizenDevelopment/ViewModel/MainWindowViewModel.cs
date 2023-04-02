using CitizenDevelopment.DataAccess;
using CitizenDevelopment.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows;

namespace CitizenDevelopment.ViewModel
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        private List<DataModel> dataModels;
        private readonly DbAccess _dbAccess;

        public MainWindowViewModel()
        {
            string connectionString = @"Data Source=C:\Users\Oleksii\source\repos\CitizenDevelopment\database.db";

            _dbAccess = new DbAccess(connectionString);
        }

        public List<DataModel> DataModels
        {
            get { return dataModels; }
            set
            {
                dataModels = value;
                OnPropertyChanged(nameof(DataModels));
            }
        }

        public void GetData()
        {
            try
            {
                dataModels = _dbAccess.GetData();
                MessageBox.Show("Data loaded successfully!");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error retrieving data: {ex.Message}");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
