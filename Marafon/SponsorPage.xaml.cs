using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO.Ports;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
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
    /// Interaction logic for SponsorPage.xaml
    /// </summary>
    public partial class SponsorPage : Page, INotifyPropertyChanged
    {
        private int donate = 50;

        public int donation
        {
            get
            {
                return donate;
            }
            set
            {
                int tmp = 0;
                int.TryParse(value.ToString(), out tmp);

                if (tmp >= 10)
                {
                    donate = value;
                    PropertyChange("donation");
                }
            }
        }


        public SponsorPage()
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

        private void Page_Loaded(object sender, RoutedEventArgs e)
        {
            List<RunnerInfo> runnerInfo = new List<RunnerInfo>();
            Util.db.Registration.ToList().ForEach(r => runnerInfo.Add(new RunnerInfo() { runner = r.Runner, reg = r }));

            comboBox_runner.ItemsSource = runnerInfo;
            comboBox_runner.DisplayMemberPath = "info";

            this.DataContext = this;

            comboBox_runner.SelectedIndex = 0;
        }

        private void button_sub_Click(object sender, RoutedEventArgs e)
        {
            if (donation >= 20)
            {
                donation -= 10;
                PropertyChange("donation");
            }
        }

        private void button_add_Click(object sender, RoutedEventArgs e)
        {
            donation += 10;
        }

        private void comboBox_runner_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            RunnerInfo runner = comboBox_runner.SelectedItem as RunnerInfo;
            Registration reg = runner.runner.Registration.LastOrDefault();

            if (reg != null)
            {
                Charity charity = reg.Charity;
                label_charity.Content = charity.CharityName;
            }
            else
                label_charity.Content = "Фонд";
        }

        private void Image_MouseDown(object sender, MouseButtonEventArgs e)
        {
            RunnerInfo runner = comboBox_runner.SelectedItem as RunnerInfo;
            Registration reg = runner.runner.Registration.LastOrDefault();

            if (reg != null)
            {
                new wndCharityInfo(reg.Charity).ShowDialog();
            }
        }

        private void button_pay_Click(object sender, RoutedEventArgs e)
        {
            if (string.IsNullOrWhiteSpace(textbox_name.Text) || textbox_name.Text.Length <= 0)
            {
                MessageBox.Show("Введите ваше имя");
                return;
            }

            if (string.IsNullOrWhiteSpace(textbox_card.Text) || textbox_card.Text.Length <= 0)
            {
                MessageBox.Show("Введите владельца карты");
                return;
            }

            if (string.IsNullOrWhiteSpace(textbox_cardnum.Text) || textbox_cardnum.Text.Length <= 0)
            {
                MessageBox.Show("Введите номер карты");
                return;
            }

            if (string.IsNullOrWhiteSpace(textbox_card_mon.Text) || textbox_card_mon.Text.Length <= 0)
            {
                MessageBox.Show("Введите месяц");
                return;
            }

            if (int.Parse(textbox_card_mon.Text) < 1 || int.Parse(textbox_card_mon.Text) > 12)
            {
                MessageBox.Show("Введите корректный месяц");
                return;
            }

            if (string.IsNullOrWhiteSpace(textbox_card_year.Text) || textbox_card_year.Text.Length <= 0)
            {
                MessageBox.Show("Введите год");
                return;
            }

            if (string.IsNullOrWhiteSpace(textbox_card_cvc.Text) || textbox_card_cvc.Text.Length <= 0)
            {
                MessageBox.Show("Введите cvc");
                return;
            }

            Sponsorship sponsor = new Sponsorship();

            sponsor.Amount = donation;
            sponsor.Registration = (comboBox_runner.SelectedItem as RunnerInfo).reg;
            sponsor.SponsorName = textbox_name.Text;

            try
            {
                Util.db.Sponsorship.Add(sponsor);
                Util.db.SaveChanges();
            }
            catch
            {
                MessageBox.Show("Произошла ошибка при добавлении");
            }
            finally
            {
                NavigationService.Navigate(new SponsorshipSuccessPage(comboBox_runner.SelectedItem as RunnerInfo, sponsor.Registration.Charity, donation));
            }
        }

        private void textbox_cardnum_KeyDown(object sender, KeyEventArgs e)
        {
            if (!new Regex("[0-9]").IsMatch(e.Key.ToString()))
                e.Handled = true;
        }
    }
}
