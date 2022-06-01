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

namespace ShopWPF.Views
{
    /// <summary>
    /// Logika interakcji dla klasy LogInView.xaml
    /// </summary>
    public partial class LogInView : UserControl
    {
        public LogInView()
        {
            InitializeComponent();
        }

        private void Password_PasswordChanged(object sender, RoutedEventArgs e)
        {
            PassHidden.Text = Password.Password;
        }
    }
}
