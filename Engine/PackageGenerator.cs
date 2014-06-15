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
            var x = _random.Next(0, _worldState.Width);
            var y = _random.Next(0, _worldState.Height);
            return new Package(new Location(x, y));
        }

        private readonly WorldState _worldState;

        private readonly Random _random;

        // ToDO: настроить время появления посылки
        private readonly Timer _timer;
    }
}
