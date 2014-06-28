using PostalService.Engine.Entities;
using PostalService.Engine.Postmans;

namespace PostalService.Engine.Job
{
    internal class TakePackageFromCustomer : IJob
    {
        private readonly Postman _postman;
        private readonly Customer _customer;

        internal TakePackageFromCustomer(Postman postman, Customer customer)
        {
            _postman = postman;
            _customer = customer;
        }

        public void DoJob()
        {

        }
    }
}
