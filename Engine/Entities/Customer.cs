namespace PostalService.Engine.Entities
{
    // ToDo: сделать интернал
    public sealed class Customer
    {
        public Location Location { get; private set; }

        public Package Package { get; private set; }

        public Customer(Location location, Package package)
        {
            Location = location;
            Package = package;
        }
    }
}
