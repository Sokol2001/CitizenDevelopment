using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace CitizenDevelopment.ViewModel
{
    public abstract class BaseViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private bool _isBusy;
        public bool IsBusy
        {
            get => _isBusy;
            set
            {
                _isBusy = value;
                OnPropertyChanged();
            }
        }

        public bool IsNotBusy => !IsBusy;

        public void DisplayMessage(string message, MessageType messageType = MessageType.Information)
        {
            //TODO: implementation of message displaying logic
        }
    }

    public enum MessageType
    {
        Information,
        Warning,
        Error
    }
}
