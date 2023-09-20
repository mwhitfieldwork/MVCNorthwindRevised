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
        //List<GetProductDto> GetAllProduct();

        //GetProductDto GetProduct(int id);

        //List<Product> GetLuxuryUSProduct();

        //List<Product> GetProductWithHighQuantityOrders();

        //void UpdateProduct(int id, Product product);

        //Product AddProduct(ProductDto product);

        //void DeleteProduct(int id);
       // Task UpdateAsync(Task<Product?> product);
    }
}
