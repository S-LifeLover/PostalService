using System.ComponentModel;
using System.Timers;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
using PostalService.Engine;

namespace PostalService.UI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    // ReSharper disable once UnusedMember.Global
    public partial class MainWindow
    {
        public MainWindow()
        {
            InitializeComponent();

            _mainTimer.Elapsed += MainTimerOnElapsed;
            _mainTimer.Start();
        }

        private void MainTimerOnElapsed(object sender, ElapsedEventArgs elapsedEventArgs)
        {
            Dispatcher.Invoke(ShowWorldState);
        }

        private void ShowWorldState()
        {
            var worldState = _engineFacade.GetState();
            MainCanvas.Children.Clear();
            foreach (var customer in worldState.Customers)
            {
                var locationRec = new Rectangle { Fill = Brushes.Red, Width = 3, Height = 3 };
                Canvas.SetLeft(locationRec, customer.Location.X - 1);
                Canvas.SetTop(locationRec, customer.Location.Y - 1);
                MainCanvas.Children.Add(locationRec);

                var destinationLine = new Line
                {
                    Stroke = new SolidColorBrush(Colors.Yellow),
                    X1 = customer.Location.X,
                    Y1 = customer.Location.Y,
                    X2 = customer.Package.Destination.X,
                    Y2 = customer.Package.Destination.Y
                };
                MainCanvas.Children.Add(destinationLine);
            }

            foreach (var postman in worldState.Postmans)
            {
                var ellipse = new Ellipse { Fill = Brushes.Green, Width = 5, Height = 5 };
                Canvas.SetLeft(ellipse, postman.Location.X - 3);
                Canvas.SetTop(ellipse, postman.Location.Y - 3);
                MainCanvas.Children.Add(ellipse);
            }
        }

        private readonly Timer _mainTimer = new Timer(100);

        private readonly EngineFacade _engineFacade = new EngineFacade();

        private void MainWindowOnClosing(object sender, CancelEventArgs e)
        {
            _engineFacade.Dispose();
        }
    }
}
