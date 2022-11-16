using Microsoft.AspNetCore.Mvc;
using NWCodeFirstMVC.App.Contracts;
using NWCodeFirstMVCSacffold.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace NWCodeFirstMVC.Infrastructure.Services
{
    public class ProductService:IProductService
    {

        private readonly northwindContext _dc;

        public ProductService(northwindContext dc)
        {
            _dc = dc;
        }

        
        public List<Product> GetAllProduct()
        {
            IQueryable<Product> products = _dc.Products;

            var results = products.Select(x =>
            new Product
            {
                ProductId = x.ProductId,
                ProductName = x.ProductName,
                SupplierId = x.SupplierId,
                CategoryId = x.CategoryId,
                QuantityPerUnit = x.QuantityPerUnit,
                UnitPrice = x.UnitPrice,
                UnitsInStock = x.UnitsInStock,
                UnitsOnOrder = x.UnitsOnOrder,
                ReorderLevel = x.ReorderLevel,
                Discontinued = x.Discontinued
            }).ToList();

            return results;
        }
    }
}
