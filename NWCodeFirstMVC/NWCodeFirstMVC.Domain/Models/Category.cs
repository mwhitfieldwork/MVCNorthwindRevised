using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;

namespace NWCodeFirstMVCSacffold.Models
{
    public partial class Category
    {
        public Category()
        {
            Products = new HashSet<Product>();
        }

        public int CategoryID { get; set; }
        public string CategoryName { get; set; } = null!;
        public string? Description { get; set; }
        public byte[]? Picture { get; set; }

        [NotMapped]
        public IEnumerable<SelectListItem> categoryList { get; set; }
        public ICollection<Category> categories { get; set; }

        public void Initialize(northwindContext dc)
        {
            categoryList = dc.Categories.OrderBy(x => x.CategoryName).Select(x => new SelectListItem
            {

                Value = x.CategoryID.ToString(),
                Text = x.CategoryName
            });
        }
        public virtual ICollection<Product> Products { get; set; }
    }
}
