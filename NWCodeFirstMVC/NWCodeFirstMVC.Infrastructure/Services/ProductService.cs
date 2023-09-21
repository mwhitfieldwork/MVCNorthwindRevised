using Microsoft.AspNetCore.Mvc;
using NWCodeFirstMVC.App.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Microsoft.EntityFrameworkCore;
using NWCodeFirstMVC.Domain.Models;
using NWCodeFirstMVC.Domain;
using NWCodeFirstMVC.Domain.Dto;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using AutoMapper;

namespace NWCodeFirstMVC.Infrastructure.Services
{    
    // Implements the inteface. This is the depndency inversion
    // Which states that higher level components dont depend on lower level ones
    // So the interface implementation doenst depend on the controller.
    // Instead there is an intermediary. The service implements the interface and is used
    // inside the contorller and keeps higher level functions

    public class ProductService: GenericService<Product>,IProductService 
    {
        public ProductService(northwindContext dc):base(dc)
        {

        }
    }
}
