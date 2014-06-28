namespace PostalService.Engine.Entities
{
    // ToDo: сделать интернал
    public sealed class Package
    {
        public Package(Location destination)
        {
            Destination = destination;
        }

        public Location Destination { get; private set; }
    }
}
