using System;
using System.Windows;
using System.Windows.Media.Imaging;
using Path = System.IO.Path;

namespace Marafon
{
    /// <summary>
    /// Interaction logic for wndCharityInfo.xaml
    /// </summary>
    public partial class wndCharityInfo : Window
    {
        public wndCharityInfo(Charity charity)
        {
            InitializeComponent();

            label_charityName.Content = charity.CharityName;
            textBlock.Text = charity.CharityDescription;

            image_charity.Source = new BitmapImage(new Uri(Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "charities", charity.CharityLogo)));
        }
    }
}
