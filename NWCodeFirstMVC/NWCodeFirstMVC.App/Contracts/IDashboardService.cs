using NWCodeFirstMVC.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NWCodeFirstMVC.Domain.Dto;

namespace NWCodeFirstMVC.App.Contracts
{
    public interface IDashboardService: IGenericRepository<SalesByCategory>
    {
        Task<List<TopCardTotalDTO>> GetAllTopCardTotals();

    }
}
