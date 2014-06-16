using System;
using PostalService.Engine.Entities;

namespace PostalService.Engine
{
    public sealed class EngineFacade : IDisposable
    {
        public EngineFacade()
        {
            _worldState = new WorldState();
            _packageGenerator = new PackageGenerator(_worldState);

            // ToDO: заменить на фабрику
            var worldStateInitializer = new WorldStateInitializer(_worldState);
            worldStateInitializer.Initialize();
        }

        public WorldState GetState()
        {
            return _worldState;
        }

        public void Dispose()
        {
            _packageGenerator.Dispose();
        }

        private readonly WorldState _worldState;

        private readonly PackageGenerator _packageGenerator;
    }
}
