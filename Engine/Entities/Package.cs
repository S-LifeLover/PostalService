namespace PostalService.Engine.Entities
{
    public sealed class Package
    {
        private readonly Location _location;

        public Package(Location location)
        {
            _location = location;
        }

        public Location Location { get { return _location; } }
    }
}
