using System;
using System.Linq;

namespace Testing
{
    public class NameMatchService : INameMatchService
    {
        // returns customers from database:
        private readonly ICustomerService _customerService;

        public NameMatchService(ICustomerService customerService)
        {
            // inject dependency via constructor:
            _customerService = customerService;
        }

        public bool IsFlying(Customer customer, string flightNumber)
        {
            if (customer == null) throw new ArgumentNullException(nameof(customer));

            var nameParts = customer.Name.Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries)
                .Select(c => c.ToUpperInvariant())
                .OrderBy(x => x)
                .ToArray();

            foreach (var other in _customerService.GetCustomers(flightNumber))
            {
                var namePartsOther = other.Name.Split(new[] {' '}, StringSplitOptions.RemoveEmptyEntries)
                    .Select(c => c.ToUpperInvariant())
                    .OrderBy(x => x);

                if (nameParts.SequenceEqual(namePartsOther))
                    return true;
            }
            return false;
        }
    }
}
