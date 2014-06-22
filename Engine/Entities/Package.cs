namespace PostalService.Engine.Entities
{
    public sealed class Package
    {
        public Package(Location location, Location destination)
        {
            Location = location;
            Destination = destination;
        }

        public Location Location { get; private set; }

        public Location Destination { get; private set; }
    }
}
