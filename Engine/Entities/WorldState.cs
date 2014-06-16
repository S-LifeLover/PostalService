using System.Collections.Generic;

namespace PostalService.Engine.Entities
{
    public sealed class WorldState
    {
        public WorldState(double width, double height)
        {
            Packages = new List<Package>();
            Postmans = new List<Postman>();

            Width = width;
            Height = height;
        }

        public double Width { get; private set; }

        public double Height { get; private set; }

        public IList<Package> Packages { get; private set; }

        public IList<Postman> Postmans { get; private set; }
    }
}
