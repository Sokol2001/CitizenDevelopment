using CitizenDevelopment.DataAccess;
using CitizenDevelopment.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CitizenDevelopment.ViewModel
{
    public class UpdateDataViewModel : INotifyPropertyChanged
    {
        private readonly DbAccess _dbAccess;
        private DataModel _dataModel;
        private int _id;

        public UpdateDataViewModel(int id)
        {
            string connectionString = @"Data Source=C:\Users\Oleksii\source\repos\CitizenDevelopment\database.db";
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
            try
            {
                DataModel = _dbAccess.GetDataById(_id);
                MessageBox.Show("Data geted successfully!");
                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error retrieving data: {ex.Message}");
                return false;
            }
        }

        public void UpdateData()
        {
            try
            {
                _dbAccess.UpdateData(DataModel);
                MessageBox.Show("Data updated successfully!");
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating data: {ex.Message}");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

}
