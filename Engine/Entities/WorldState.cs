using System.Collections.Generic;
using PostalService.Engine.Postmans;

namespace PostalService.Engine.Entities
{
    // ToDo: сделать интернал
    public sealed class WorldState
    {
        public WorldState(double width, double height)
        {
            Packages = new List<Package>();
            Customers = new List<Customer>();
            Postmans = new List<Postman>();

            Width = width;
            Height = height;
        }

        public double Width { get; private set; }

        public double Height { get; private set; }

        public IList<Package> Packages { get; private set; }

        public IList<Customer> Customers { get; private set; }

        public IList<Postman> Postmans { get; private set; }
    }
}
