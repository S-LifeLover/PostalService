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
            //MainCanvas.Children.Clear();
            foreach (var package in worldState.Packages)
            {
                var rectangle = new Rectangle { Stroke = Brushes.Red, Width = 3, Height = 3 };
                Canvas.SetLeft(rectangle, package.Location.X - 1);
                Canvas.SetTop(rectangle, package.Location.Y - 1);
                MainCanvas.Children.Add(rectangle);
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
