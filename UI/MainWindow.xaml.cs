﻿using System.ComponentModel;
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
            foreach (var package in worldState.Packages)
            {
                var locationRec = new Rectangle { Fill = Brushes.Red, Width = 3, Height = 3 };
                Canvas.SetLeft(locationRec, package.Location.X - 1);
                Canvas.SetTop(locationRec, package.Location.Y - 1);
                MainCanvas.Children.Add(locationRec);

                var destinationLine = new Line
                {
                    Stroke = new SolidColorBrush(Colors.Yellow),
                    X1 = package.Location.X,
                    Y1 = package.Location.Y,
                    X2 = package.Destination.X,
                    Y2 = package.Destination.Y
                };
                MainCanvas.Children.Add(destinationLine);
            }

            foreach (var postman in worldState.Postmans)
            {
                var ellipse = new Ellipse { Fill = Brushes.Green, Width = 5, Height = 5 };
                Canvas.SetLeft(ellipse, postman.Location.X - 3);
                Canvas.SetTop(ellipse, postman.Location.Y - 3);
                MainCanvas.Children.Add(ellipse);

                if (postman.Destination == null)
                    continue;
                var destinationLine = new Line
                {
                    Stroke = new SolidColorBrush(Colors.Yellow),
                    X1 = postman.Location.X,
                    Y1 = postman.Location.Y,
                    X2 = postman.Destination.Value.X,
                    Y2 = postman.Destination.Value.Y
                };
                MainCanvas.Children.Add(destinationLine);
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
