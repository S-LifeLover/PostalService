using PostalService.Engine.Entities;

namespace PostalService.Engine
{
    internal sealed class WorldStateFactory
    {
        // TODo: Вынести значения в настройки
        public WorldState Create()
        {
            var worldState = new WorldState(500, 500);
            AddPostmans(worldState);
            return worldState;
        }

        private static void AddPostmans(WorldState worldState)
        {
            var x = worldState.Width / 2;
            var y = worldState.Height / 2;
            worldState.Postmans.Add(new Postman(new Location(x, y)));
        }
    }
}
