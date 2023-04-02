using CitizenDevelopment.DataAccess;
using CitizenDevelopment.Model;
using CitizenDevelopment.View;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Windows;
using MessageBox = CitizenDevelopment.View.MessageBox;

namespace CitizenDevelopment.ViewModel
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        private List<DataModel> dataModels;
        private readonly DbAccess _dbAccess;

        public MainWindowViewModel()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

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
            var ownerWindow = Application.Current.MainWindow;

            try
            {
                dataModels = _dbAccess.GetData();
                MessageBox.Show("Data loaded successfully!", ownerWindow);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error retrieving data: {ex.Message}", ownerWindow);
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
