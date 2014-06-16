using System.Collections.Generic;

namespace PostalService.Engine.Entities
{
    public sealed class WorldState
    {
        public WorldState()
        {
            Packages = new List<Package>();
            Postmans = new List<Postman>();

            // TODo: настроить
            Width = 500;
            Height = 500;
        }

        public int Width { get; private set; }

        public int Height { get; private set; }

        public IList<Package> Packages { get; private set; }

        public IList<Postman> Postmans { get; private set; }
    }
}
