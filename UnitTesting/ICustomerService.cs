using System.Collections.Generic;

public interface ICustomerService
{
    IEnumerable<Customer> GetCustomers(string flightNumber);
}