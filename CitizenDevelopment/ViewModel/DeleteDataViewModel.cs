using CitizenDevelopment.DataAccess;
using CitizenDevelopment.Model;
using System;
using System.ComponentModel;
using System.Configuration;
using System.Windows;
using MessageBox = CitizenDevelopment.View.MessageBox;

namespace CitizenDevelopment.ViewModel
{
    public class DeleteDataViewModel : INotifyPropertyChanged
    {
        private readonly DbAccess _dbAccess;
        private DataModel _dataModel;
        private int _id;

        public DeleteDataViewModel(int id)
        {
            string connectionString = ConfigurationManager.ConnectionStrings["ConnectionString"].ConnectionString;

            _dbAccess = new DbAccess(connectionString);
            _dataModel = _dbAccess.GetDataById(id);
            _id = id;
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

        public bool GetData()
        {
            var ownerWindow = Application.Current.MainWindow;

            try
            {
                DataModel = _dbAccess.GetDataById(_id);

                if (DataModel != null)
                {
                    MessageBox.Show("Data geted successfully!", ownerWindow);
                    return true;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error retrieving data: {ex.Message}", ownerWindow);
                return false;
            }

            MessageBox.Show($"Unable to find item for this Id", ownerWindow);
            return false;
        }

        public void DeleteData()
        {
            var ownerWindow = Application.Current.MainWindow;
           
            try
            {
                _dbAccess.DeleteData(_id);
                MessageBox.Show("Data updated successfully!", ownerWindow);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating data: {ex.Message}", ownerWindow);
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

}
