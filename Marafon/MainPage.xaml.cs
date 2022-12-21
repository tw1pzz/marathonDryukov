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

namespace Marafon
{
    /// <summary>
    /// Interaction logic for MainPage.xaml
    /// </summary>
    public partial class MainPage : Page
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void button_becomeSponsor_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new Uri("SponsorPage.xaml", UriKind.RelativeOrAbsolute));
        }

        private void button_about_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AboutPage());
        }

        private void button_becomeRunner_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new RegisterRunnerPage());
        }

        private void button_login_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new LoginPage());
        }
    }
}
