using System;
using System.Timers;
using System.Windows;
using System.Windows.Input;

namespace PostalService.UI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        private readonly Timer _mainTimer = new Timer(100);

        public MainWindow()
        {
            InitializeComponent();

            _mainTimer.Elapsed += MainTimerOnElapsed;
            _mainTimer.Start();
        }

        private void MainTimerOnElapsed(object sender, ElapsedEventArgs elapsedEventArgs)
        {
            var s = new Random();
            MainPolyline.Points.Add(new Point(s.NextDouble() + 100, s.NextDouble() * 100));
        }

        private void Canvas_MouseMove(object sender, MouseEventArgs e)
        {
            MainPolyline.Points.Add(e.GetPosition(MainCanvas));
            var s = e.GetPosition(MainCanvas);
            s.X -= 10;
            s.Y -= 50;
            MainPolyline2.Points.Add(s);
        }
    }
}
