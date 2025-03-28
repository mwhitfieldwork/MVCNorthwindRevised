﻿using AutoMapper;
using Microsoft.AspNetCore.Http;
using NWCodeFirstMVC.App.Contracts;
using Microsoft.AspNetCore.Mvc;
using NWCodeFirstMVC.App.Contracts;
using NWCodeFirstMVC.Infrastructure.Services;

namespace NWCodeFirstMVC.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderHistoryController : ControllerBase
    {
        private readonly IOrderHistory _orderHistoryService;
        private readonly IMapper mapper;
        public OrderHistoryController(IOrderHistory orderHistoryService, IMapper mapper) {
            _orderHistoryService = orderHistoryService;
            this.mapper = mapper;
        }

        [HttpGet]
        public async Task<IActionResult> GetOrderHistory()
        {
            var orderHistory = await _orderHistoryService.GetAllAsync();
            return Ok(orderHistory);
        }
    }
}
