using System.Windows;
using System.Windows.Input;

namespace CitizenDevelopment.View
{
    public partial class MessageBox : Window
    {
        public MessageBox()
        {
            InitializeComponent();
        }

        private void okButton_Click(object sender, RoutedEventArgs e)
        {
            this.Close();
        }

        public static void Show(string message, Window owner)
        {
            var messageBox = new MessageBox
            {
                messageText = { Text = message }
            };
            messageBox.Owner = owner;
            messageBox.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            messageBox.ShowDialog();
        }

        private void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            this.DragMove();
        }
    }
}
