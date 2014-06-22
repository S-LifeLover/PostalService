using System;
using System.Threading;
using PostalService.Engine.Entities;

namespace PostalService.Engine
{
    internal sealed class CustomerGenerator : IDisposable
    {
        internal CustomerGenerator(WorldState worldState)
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
            var package = GeneratePackage();
            _worldState.Customers.Add(GenerateCustomer(package));
        }

        private Customer GenerateCustomer(Package package)
        {
            var location = RandomLocation();
            return new Customer(location, package);
        }

        private Package GeneratePackage()
        {
            var destination = RandomLocation();
            return new Package(destination);
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
