using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    /// Interaction logic for RegisterForEvent.xaml
    /// </summary>
    public partial class RegisterForEvent : Page, INotifyPropertyChanged
    {
        private int amm;

        public int ammount
        {
            get
            {
                return amm;
            }
            set
            {
                int tmp = 0;
                if ((bool)km42.IsChecked) tmp += 145;
                if ((bool)km21.IsChecked) tmp += 75;
                if ((bool)km5.IsChecked) tmp += 20;

                amm = value;
                PropertyChange("ammount");
            }
        }

        public RegisterForEvent()
        {
            InitializeComponent();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void PropertyChange(string name)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(name));
        }

        private void button_back_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.GoBack();
        }

        private void CheckBox_Checked(object sender, RoutedEventArgs e)
        {
            PropertyChange("amount");
        }
    }
}
