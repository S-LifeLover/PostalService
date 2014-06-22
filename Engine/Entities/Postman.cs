using System;

namespace PostalService.Engine.Entities
{
    public sealed class Postman
    {
        // Скорость пиксели в одну десятую секунды
        // ToDO: через конфиг
        private const double _speedPixelsPerSecond = 3;

        public Postman(Location location)
        {
            Location = location;
        }

        public Location Location { get; private set; }

        public Location? Destination { get; private set; }

        public Package Package { get; private set; }

        //ToDO: все не так. Все переделать
        public void MoveToDestination()
        {
            if (Destination == null)
                return;

            Location = Location.ApproachTo((Location)Destination, _speedPixelsPerSecond);
        }

        public void SetDestination(Location location)
        {
            Destination = location;
        }

        private void TakePackage(Package package)
        {
            if (Location != package.Location)
                // ToDo: оформить ошибку как положено
                throw new Exception();

            Package = package;
        }
    }
}
