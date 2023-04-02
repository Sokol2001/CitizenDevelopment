using CitizenDevelopment.DataAccess;
using CitizenDevelopment.Model;
using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Input;

namespace CitizenDevelopment.ViewModel
{
    public class InsertDataViewModel : INotifyPropertyChanged
    {
        private readonly DbAccess _dbAccess;
        private DataModel _dataModel;

        public InsertDataViewModel()
        {
            string connectionString = @"Data Source=C:\Users\Oleksii\source\repos\CitizenDevelopment\database.db";
            _dbAccess = new DbAccess(connectionString);
            _dataModel = new DataModel();
        }

        public DataModel DataModel
        {
            get { return _dataModel; }
            set
            {
                _dataModel = value;
                OnPropertyChanged(nameof(DataModel));
            }
        }

        public void InsertData()
        {
            try
            {
                _dbAccess.InsertData(DataModel);
                MessageBox.Show("Data saved successfully!");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving data: {ex.Message}");
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
