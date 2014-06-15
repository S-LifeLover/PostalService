using PostalService.Engine.Entities;

namespace PostalService.Engine
{
    public sealed class EngineFacade
    {
        public EngineFacade()
        {

        }

        public WorldState GetState()
        {
            return new WorldState();
        }

        private WorldState _worldState;
    }
}
