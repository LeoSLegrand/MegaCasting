using MegaCasting.Wpf.ViewModel;
using MegaCasting.Wpf.View;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace MegaCasting.Wpf.View
{
    public partial class LoginView : UserControl
    {

        public LoginView()
        {
            InitializeComponent();
            this.DataContext = new LoginViewViewModel();
        }

        private void PasswordBoxLogin_PasswordChanged(object sender, RoutedEventArgs e)
            => ((LoginViewViewModel)this.DataContext).Password = ((PasswordBox)sender).Password;

        private void ConnectButton_Click(object sender, RoutedEventArgs e)
            => ((LoginViewViewModel)this.DataContext).Authenticate();

    }

}
