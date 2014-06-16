using PostalService.Engine.Entities;

namespace PostalService.Engine
{
    internal sealed class WorldStateInitializer
    {
        private readonly WorldState _worldState;

        internal WorldStateInitializer(WorldState worldState)
        {
            _worldState = worldState;
        }

        public void Initialize()
        {
            var x = _worldState.Width / 2;
            var y = _worldState.Height / 2;
            _worldState.Postmans.Add(new Postman(new Location(x, y)));
        }
    }
}
