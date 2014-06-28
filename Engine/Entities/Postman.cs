using System;
using PostalService.Engine.Configuration;

namespace PostalService.Engine.Entities
{
    // ToDo: сделать интернал
    public sealed class Postman
    {
        private readonly IConfigurationProvider _configurationProvider;

        public Postman(IConfigurationProvider configurationProvider, Location location)
        {
            _configurationProvider = configurationProvider;
            Location = location;
        }

        public Location Location { get; private set; }

        // ToDo: Может как-то сделать через стратегии или типа того?
        public Location? Destination { get; private set; }

        public Package Package { get; private set; }

        //ToDO: все не так. Все переделать
        public void MoveToDestination()
        {
            if (Destination == null)
                return;

            Location = Location.ApproachTo((Location)Destination, _configurationProvider.PostmanSpeed);
        }

        public void SetDestination(Location location)
        {
            Destination = location;
        }

        public void TakePackage(Package package)
        {
            // ToDo: коряво
            if (Package != null)
                throw new Exception();

            Package = package;
            Destination = package.Destination;
        }
    }
}
