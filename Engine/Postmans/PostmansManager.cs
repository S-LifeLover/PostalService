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
            // ToDo: перееделать
            var postman = _worldState.Postmans.Single();
            postman.AddSender(_worldState.Customers.FirstOrDefault());

            ActPostmans();
        }

        private void ActPostmans()
        {
            _worldState.Postmans.ToList().ForEach(p => p.Act());
        }
    }
}
