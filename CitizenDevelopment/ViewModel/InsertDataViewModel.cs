using CitizenDevelopment.DataAccess;
using CitizenDevelopment.Model;
using System;
using System.ComponentModel;
using System.Configuration;
using System.Windows;
using MessageBox = CitizenDevelopment.View.MessageBox;

namespace CitizenDevelopment.ViewModel
{
    public class InsertDataViewModel : INotifyPropertyChanged
    {
        private readonly DbAccess _dbAccess;
        private DataModel _dataModel;

        public InsertDataViewModel()
        {
            string connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

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
            var ownerWindow = Application.Current.MainWindow;
            
            try
            {
                _dbAccess.InsertData(DataModel);
                MessageBox.Show("Data saved successfully!", ownerWindow);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving data: {ex.Message}", ownerWindow);
            }
        }


        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
