using System;
using System.Linq;
using System.Threading;
using PostalService.Engine.Configuration;
using PostalService.Engine.Entities;

namespace PostalService.Engine.Postmans
{
    internal sealed class PostmansManager : IDisposable
    {
        private readonly WorldState _worldState;
        private readonly Timer _timer;

        internal PostmansManager(WorldState worldState, IConfigurationProvider configurationProvider)
        {
            _worldState = worldState;
            var period = 1000 / configurationProvider.FPS;
            _timer = new Timer(TimerCallback, null, period, period);
        }

        public void Dispose()
        {
            _timer.Dispose();
        }

        private void TimerCallback(object state)
        {
            var postmans = _worldState.Postmans.ToList();

            var freePostmans = postmans.Where(p => p.Destination == null).ToList();
            freePostmans.ForEach(FindJob);

            postmans.ForEach(Move);

            //ToDo: корявая логика
            var postmansOnDestination = postmans.Where(p => p.Location == p.Destination).ToList();
            foreach (var postman in postmansOnDestination)
            {
                var customer = _worldState.Customers.FirstOrDefault(c => c.Location == postman.Location);
                if (customer == null)
                    continue;
                postman.TakePackage(customer.Package);
                _worldState.Customers.Remove(customer);
            }
        }

        //ToDO: в текущей реализации берем первого попавшегося клиента. В будущем надо бы изменить логику
        private void FindJob(Postman postman)
        {
            var customer = _worldState.Customers.FirstOrDefault();
            if (customer != null)
                postman.SetDestination(customer.Location);
        }

        private static void Move(Postman postman)
        {
            postman.MoveToDestination();
        }

        // ToDO
        private static void CompletePackage(Postman postman)
        {
            throw new NotImplementedException("CompletePackage");
        }
    }
}
