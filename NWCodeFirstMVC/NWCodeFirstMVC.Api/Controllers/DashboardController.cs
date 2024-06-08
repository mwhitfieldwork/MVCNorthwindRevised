using System.Collections.Generic;
using System.Threading.Tasks;
using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using NWCodeFirstMVC.App.Contracts;
using NWCodeFirstMVC.Domain.Dto;

namespace NWCodeFirstMVC.Api.Controllers
{
    [Route("[controller]")]
    [ApiController]
    public class DashboardController : ControllerBase
    {
        // GET: DashboardController
        private readonly IDashboardService dashboardService;
        private readonly IMapper mapper;

        public DashboardController(IDashboardService dashboardService, IMapper mapper)
        {
            this.dashboardService = dashboardService;
            this.mapper = mapper;
        }
        // GET: CategoryController
        [HttpGet]
        public async Task<IActionResult> GetAllCategories()
        {
            var sales = await dashboardService.GetAllAsync();
            return Ok(sales);
        }
    }
}
