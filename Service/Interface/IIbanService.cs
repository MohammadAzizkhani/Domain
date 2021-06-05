using System.Collections.Generic;
using System.Threading.Tasks;
using Domain.Filters;
using Domain.Models;

namespace Service.Interface
{
    public interface IIbanService
    {
        Task<List<CustomersIban>> GetCustomerIbans(IbanCustomerFilter model);
        Task AddCustomerIbans(List<CustomersIban> ibans);
    }
}
