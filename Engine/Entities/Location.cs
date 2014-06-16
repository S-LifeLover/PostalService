namespace PostalService.Engine.Entities
{
    public sealed class Location
    {
        public Location(double x, double y)
        {
            X = x;
            Y = y;
        }

        public double X { get; private set; }

        public double Y { get; private set; }
    }
}
