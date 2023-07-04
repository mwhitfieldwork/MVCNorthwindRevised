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

        Product GetProduct(int id);

        List<Product> GetLuxuryUSProduct();

        List<Product> GetProductWithHighQuantityOrders();

        void UpdateProduct(int id, Product product);

        Product AddProduct(Product product);
    }
}
