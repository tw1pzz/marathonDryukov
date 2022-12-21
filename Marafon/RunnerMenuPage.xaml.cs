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
    /// Interaction logic for RunnerMenuPage.xaml
    /// </summary>
    public partial class RunnerMenuPage : Page
    {
        public RunnerMenuPage()
        {
            InitializeComponent();
        }

        private void button_back_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void label_cross_MouseDown(object sender, MouseButtonEventArgs e)
        {
            rich_textbox_contacts.Visibility = Visibility.Hidden;
            label_cross.Visibility = Visibility.Hidden;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            rich_textbox_contacts.Visibility = Visibility.Visible;
            label_cross.Visibility = Visibility.Visible;
        }

        private void Button_Click_1(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new RegisterForEvent());
        }
    }
}
