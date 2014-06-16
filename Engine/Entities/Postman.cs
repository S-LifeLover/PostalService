namespace PostalService.Engine.Entities
{
    public sealed class Postman
    {
        public Postman(Location location)
        {
            Location = location;
        }

        public Location Location { get; private set; }
    }
}
