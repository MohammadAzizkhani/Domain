using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Filters;
using Domain.Models;

namespace Service.Interface
{
    public interface ICustomerService
    {
        Task<Customer> AddCustomer(Customer model);
        Task<Person> AddPerson(Person model);
        Task<List<Customer>> GetCustomers(CustomerFilter filter);
        
    }
}
