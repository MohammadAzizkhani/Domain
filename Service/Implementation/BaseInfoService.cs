using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;
using Microsoft.EntityFrameworkCore;
using Service.Interface;

namespace Service.Implementation
{
    public class BaseInfoService : IBaseInfoService
    {
        private readonly MMS_PortalContext _context;

        public BaseInfoService(MMS_PortalContext context)
        {
            _context = context;
        }
        public async Task<List<Psp>> GetPsps()
        {
            return await _context.Psps.ToListAsync();
        }

        public async Task<List<Contract>> GetContracts()
        {
            return await _context.Contracts.ToListAsync();
        }

        public async Task<List<Project>> GetProjects()
        {
            return await _context.Projects.ToListAsync();
        }

        public async Task<List<MarketerContract>> GetMarketContract()
        {
            return await _context.MarketerContracts.ToListAsync();
        }
    }
}
