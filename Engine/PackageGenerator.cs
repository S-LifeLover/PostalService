using System;
using System.Threading;
using PostalService.Engine.Entities;

namespace PostalService.Engine
{
    internal sealed class PackageGenerator : IDisposable
    {
        internal PackageGenerator(WorldState worldState)
        {
            _worldState = worldState;
            _random = new Random();
            _timer = new Timer(TimerCallback, null, 1000, 1000);
        }

        public void Dispose()
        {
            _timer.Dispose();
        }

        private void TimerCallback(object state)
        {
            _worldState.Packages.Add(GeneratePackage());
        }

        private Package GeneratePackage()
        {
            var location = RandomLocation();
            var destination = RandomLocation();
            return new Package(location, destination);
        }

        private Location RandomLocation()
        {
            var x = _random.NextDouble() * _worldState.Width;
            var y = _random.NextDouble() * _worldState.Height;
            return new Location(x, y);
        }

        private readonly WorldState _worldState;

        private readonly Random _random;

        // ToDO: настроить время появления посылки
        private readonly Timer _timer;
    }
}
