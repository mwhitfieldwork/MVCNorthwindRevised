using Microsoft.AspNetCore.Mvc;
using NWCodeFirstMVCSacffold.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NWCodeFirstMVC.App.Contracts
{
    public interface IProductService
    {
        List<Product> GetAllProduct();
    }
}
