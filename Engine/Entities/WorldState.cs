using System.Collections.Generic;

namespace PostalService.Engine.Entities
{
    public sealed class WorldState
    {
        public WorldState()
        {
            _packages = new List<Package>();
        }

        private readonly IList<Package> _packages;

        public IEnumerable<Package> Packages { get { return _packages; } }
    }
}
