using System;
using PostalService.Engine.Configuration;
using PostalService.Engine.Entities;

namespace PostalService.Engine
{
    public sealed class EngineFacade : IDisposable
    {
        private readonly WorldState _worldState;
        private readonly CustomerGenerator _customerGenerator;
        private readonly PostmanManager _postmanManager;

        public EngineFacade()
        {
            var configurationProvider = new ConfigurationProvider();
            var worldStateFactory = new WorldStateFactory(configurationProvider);
            _worldState = worldStateFactory.Create();

            _customerGenerator = new CustomerGenerator(_worldState, configurationProvider);
            _postmanManager = new PostmanManager(_worldState);
        }

        public WorldState GetState()
        {
            return _worldState;
        }

        public void Dispose()
        {
            _customerGenerator.Dispose();
            _postmanManager.Dispose();
        }
    }
}
