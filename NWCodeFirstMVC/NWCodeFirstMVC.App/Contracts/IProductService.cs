using Microsoft.AspNetCore.Mvc;
using NWCodeFirstMVC.Domain.Dto;
using NWCodeFirstMVC.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NWCodeFirstMVC.App.Contracts
{
    public interface IProductService : IGenericRepository<Product>
    {
    }
}
