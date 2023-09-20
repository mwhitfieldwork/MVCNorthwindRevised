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

        //public Task UpdateAsync(Task<Product?> product)
        //{
        //    throw new NotImplementedException();
        //}

        //private readonly northwindContext _dc;
        //private readonly IMapper mapper;

        //public ProductService(northwindContext dc, IMapper mapper)
        //{
        //    _dc = dc;
        //    this.mapper = mapper;
        //}



        //public List<GetProductDto> GetAllProduct()
        //{
        //    List<Product> products = _dc.Products.ToList();

        //   var results = mapper.Map<List<GetProductDto>>(products);

        //    return results;
        //}


        //public GetProductDto GetProduct(int id)
        //{

        //    var product = _dc.Products.Where(x => x.ProductId == id).FirstOrDefault();
        //    var records = mapper.Map<GetProductDto>(product);
        //    return records;
        //}


        //public List<Product> GetLuxuryUSProduct()
        //{
        //    List<Product> luxproduct = _dc.Products.Join(_dc.Suppliers,
        //                      x => x.SupplierId,
        //                      y => y.SupplierId,
        //                      (x, y) => new { Product = x, Supplier = y })
        //                   .Where(z => z.Product.UnitPrice > 10 && z.Supplier.Country == "USA").Select(x => x.Product).ToList();

        //    return luxproduct;
        //}

        //public List<Product> GetProductWithHighQuantityOrders()
        //{
        //    //ask why this is not returning a simple json response
        //    var prodorders = _dc.Products.Where(y => y.ProductId == 11).Include(x => x.OrderDetails.Where(o => o.Quantity == 30)).ToList();

        //    return prodorders;
        //}


        //public Product AddProduct(ProductDto createProduct)
        //{
        //    var product = mapper.Map<Product>(createProduct);

        //    _dc.Products.Add(product);
        //    _dc.SaveChanges();

        //    return product;

        //}

        //public void UpdateProduct(int id, Product product)
        //{
        //}

        //public void DeleteProduct(int id)
        //{
        //}
    }
}
