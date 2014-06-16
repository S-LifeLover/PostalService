using System;
using PostalService.Engine.Entities;

namespace PostalService.Engine
{
    public sealed class EngineFacade : IDisposable
    {
        public EngineFacade()
        {
            var worldStateFactory = new WorldStateFactory();
            _worldState = worldStateFactory.Create();

            _packageGenerator = new PackageGenerator(_worldState);
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
