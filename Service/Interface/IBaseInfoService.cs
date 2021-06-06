using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;

namespace Service.Interface
{
    public interface IBaseInfoService
    {
        Task<List<Psp>> GetPsps();
        Task<List<Contract>> GetContracts();
        Task<List<Project>> GetProjects();
        Task<List<MarketerContract>> GetMarketContract();

    }
}
