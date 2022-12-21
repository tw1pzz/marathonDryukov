using System;
using System.ComponentModel;
using System.Windows;
using Timer = System.Timers.Timer;

namespace Marafon
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window, INotifyPropertyChanged
    {
        public string Time
        {
            get
            {
                DateTime dt1 = DateTime.Now;
                DateTime dt2 = DateTime.Parse("2022-12-28 6:00");

                TimeSpan ts = dt2 - dt1;

                return string.Format("{0} дн {1} ч {2} мин {3} сек до старта марафона!", ts.Days, ts.Hours, ts.Minutes, ts.Seconds);
            }
        }
        public MainWindow()
        {
            InitializeComponent();

            this.DataContext = this;
        }

        ~MainWindow()
        {
            Util.db.Database.Connection.Close();
        }

        public event PropertyChangedEventHandler PropertyChanged;

        private void Window_Loaded(object sender, RoutedEventArgs e)
        {
            Timer timer = new Timer();

            timer.Interval = 1000;
            timer.Elapsed += Timer_Elapsed;

            timer.Start();
        }

        private void Timer_Elapsed(object sender, System.Timers.ElapsedEventArgs e)
        {
            PropertyChange("Time");
        }

        private void PropertyChange(string name)
        {
            if (PropertyChanged != null)
                PropertyChanged(this, new PropertyChangedEventArgs(name));
        }
    }
}
