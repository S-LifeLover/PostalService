using System.Collections.Generic;
using System.Linq;
using PostalService.Engine.Configuration;
using PostalService.Engine.Entities;

namespace PostalService.Engine.Postmans
{
    // ToDo: сделать интернал
    public sealed class Postman
    {
        public Location Location { get; private set; }

        private readonly List<Package> _packages = new List<Package>();

        private readonly List<Customer> _senders = new List<Customer>();

        private readonly IConfigurationProvider _configurationProvider;

        public Postman(IConfigurationProvider configurationProvider, Location location)
        {
            _configurationProvider = configurationProvider;
            Location = location;
        }

        public void Act()
        {
            var customer = _senders.FirstOrDefault();
            if (customer != null)
                MoveTo(customer.Location);
        }

        // ToDo: Сделать паблик
        internal void AddSender(Customer customer)
        {
            if (_senders.Any() || customer == null)
                return;
            _senders.Add(customer);
        }

        private void MoveTo(Location destination)
        {
            Location = Location.ApproachTo(destination, _configurationProvider.PostmanSpeed);
        }

        private void TakePackage(Package package)
        {
            _packages.Add(package);
        }
    }
}
