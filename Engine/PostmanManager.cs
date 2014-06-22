using System;
using System.Linq;
using System.Threading;
using PostalService.Engine.Entities;

namespace PostalService.Engine
{
    internal sealed class PostmanManager : IDisposable
    {
        private readonly WorldState _worldState;
        // ToDO: Задавать через настройки
        private readonly Timer _timer;

        internal PostmanManager(WorldState worldState)
        {
            _worldState = worldState;
            _timer = new Timer(TimerCallback, null, 100, 100);
        }

        public void Dispose()
        {
            _timer.Dispose();
        }

        private void TimerCallback(object state)
        {
            var postmans = _worldState.Postmans.ToList();
            var freePostmans = postmans.Where(p => p.Destination == null).ToList();
            freePostmans.ForEach(SetDestinationPackage);

            postmans.ForEach(Move);

            var postmansWithDeliveredPackage = postmans.Where(p => p.Location == p.Destination).ToList();
        }

        private void SetDestinationPackage(Postman postman)
        {
            var packagesInDelivery = _worldState.Postmans.Select(p => p.Package).Distinct();
            var freePackages =
                _worldState.Packages.Where(p => !packagesInDelivery.Contains(p))
                    .ToDictionary(p => p.Location.DistanceTo(postman.Location));
            var closestPackage = freePackages.OrderBy(kvp => kvp.Key).Select(kvp => kvp.Value).FirstOrDefault();
            if (closestPackage != null)
                postman.SetDestination(closestPackage.Location);
        }

        private static void Move(Postman postman)
        {
            postman.MoveToDestination();
        }

        private static void CompletePackage(Postman postman)
        {
            throw new NotImplementedException("CompletePackage");
        }
    }
}
