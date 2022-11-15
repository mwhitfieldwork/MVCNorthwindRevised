using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NWCodeFirstMVC.App.Contracts
{
    internal interface IProductService
    {
        JsonResult GetAllProducts();
    }
}
