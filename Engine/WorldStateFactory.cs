using PostalService.Engine.Configuration;
using PostalService.Engine.Entities;
using PostalService.Engine.Postmans;

namespace PostalService.Engine
{
    internal sealed class WorldStateFactory
    {
        private readonly IConfigurationProvider _configurationProvider;

        public WorldStateFactory(IConfigurationProvider configurationProvider)
        {
            _configurationProvider = configurationProvider;
        }

        public WorldState Create()
        {
            var worldState = new WorldState(_configurationProvider.WorldWidth, _configurationProvider.WorldHeight);
            for (var i = 0; i < _configurationProvider.PostmansCount; i++)
                AddPostmans(worldState);
            return worldState;
        }

        private void AddPostmans(WorldState worldState)
        {
            var x = worldState.Width / 2;
            var y = worldState.Height / 2;
            worldState.Postmans.Add(
                new Postman(
                    _configurationProvider,
                    new Location(x, y)));
        }
    }
}
