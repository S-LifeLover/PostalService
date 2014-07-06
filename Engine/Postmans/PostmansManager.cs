using System;
using System.Collections.Generic;
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
        private IDictionary<Customer, Postman> _handledCustomers = new Dictionary<Customer, Postman>();

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
            HandleNewCustomers();
            ActPostmans();
        }

        private void HandleNewCustomers()
        {
            // ToDo: добавить поддержку нескольких почтальонов
            var postman = _worldState.Postmans.Single();

            var newCustomers = _worldState.Customers.Except(_handledCustomers.Keys).ToList();
            newCustomers.ForEach(customer =>
            {
                _handledCustomers.Add(customer, postman);
                postman.AddSender(customer);
            });
        }

        private void ActPostmans()
        {
            _worldState.Postmans.ToList().ForEach(p => p.Act());
        }
    }
}
