using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Enums;
using Domain.Filters;
using Domain.Models;
using Domain.Utility;

namespace Service.Interface
{
    public interface ICustomerService
    {
        Task<Customer> AddCustomer(Customer model);
        Task AddPerson(Person model);
        Task<PageCollection<Customer>> GetCustomers(CustomerFilter filter);
        Task EditGuild(long customerId, int guildId);
        Task EditPostalCode(long customerId, string postalCode);
        Task ActivateTerminals(long customerId);
        Task DeactivateTerminals(long customerId);
        Task<List<CustomersIban>> GetCustomerIban(long customerId);
        Task EditCustomerIbans(List<CustomersIban> ibans);
        Task AddCustomerIbans(List<CustomersIban> ibans);
        Task<PageCollection<Request>> GetRequests(RequestFilter filter);
        Task<Person> GetPerson(PersonType type, string uniqueIdentifier);
        Task StartEditRequest(long requestId, string userName);
    }
}
