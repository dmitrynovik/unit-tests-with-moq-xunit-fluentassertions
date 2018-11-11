using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Testing
{
    public class CustomerContext : DbContext
    {
        public DbSet<Customer> Customers { get; set; }
    }

    public class CustomerService : ICustomerService
    {
        // Dependency - a proxy to the database
        private readonly CustomerContext _context;

        public CustomerService(CustomerContext context)
        {
            // Inject dependency (Database context) via constructor:
            _context = context;
        }

        // Get customers from database
        public IEnumerable<Customer> GetCustomers(string flightNumber)
        {
            return _context.Customers.Where(c => c.Name == flightNumber);
        }
    }
}