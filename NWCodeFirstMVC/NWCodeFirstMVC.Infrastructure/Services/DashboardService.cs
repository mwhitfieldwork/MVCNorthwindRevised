using NWCodeFirstMVC.App.Contracts;
using NWCodeFirstMVC.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NWCodeFirstMVC.Infrastructure.Services
{
    public class DashboardService : GenericService<SalesByCategory>, IDashboardService
    {
        public DashboardService(northwindContext dc) : base(dc)
        {
        }
    }
}
