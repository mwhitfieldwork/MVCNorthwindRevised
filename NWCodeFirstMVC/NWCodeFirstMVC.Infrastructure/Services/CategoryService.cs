using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using NWCodeFirstMVC.App.Contracts;
using NWCodeFirstMVC.Domain.Dto;
using NWCodeFirstMVC.Domain.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NWCodeFirstMVC.Infrastructure.Services
{
    public class CategoryService:GenericService<Category>, ICategoryService
    {
        private readonly northwindContext _dc;
        public CategoryService(northwindContext dc) : base(dc)
        {
            this._dc = dc;
        }

        public async Task<List<SalesByCategoryDTO>> GetSalesByCategory(string categoryName, string orderYear)
        {
            var salesData = new List<SalesByCategoryDTO>();

            try
            {
                using var connection = _dc.Database.GetDbConnection();
                if (connection.State == ConnectionState.Closed)
                {
                    await connection.OpenAsync();
                }

                using var command = connection.CreateCommand();
                command.CommandText = "SalesByCategory";
                command.CommandType = CommandType.StoredProcedure;

                // Add parameters
                command.Parameters.AddRange(new[]
                {
                    new SqlParameter("@CategoryName", categoryName),
                    new SqlParameter("@OrdYear", orderYear)
                });

                using var reader = await command.ExecuteReaderAsync();
                while (await reader.ReadAsync())
                {
                    salesData.Add(new SalesByCategoryDTO
                    {
                        ProductName = reader["ProductName"].ToString(),
                        TotalPurchase = reader.GetDecimal(reader.GetOrdinal("TotalPurchase")).ToString()
                    });
                }
            }
            catch (Exception ex)
            {
                throw new Exception("Error retrieving sales data", ex);
            }

            return salesData;
        }


    }
}
