using System.Threading.Tasks;
using Domain.Filters;
using Domain.Models;
using Domain.Utility;

namespace Service.Interface
{
    public interface ICustomerService
    {
        Task<Customer> AddCustomer(Customer model);
        Task<Person> AddPerson(Person model);
        Task<PageCollection<Customer>> GetCustomers(CustomerFilter filter);
        
    }
}
