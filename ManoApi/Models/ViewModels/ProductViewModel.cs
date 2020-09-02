using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ManoApi.Models.ViewModels
{
    public class ProductViewModel
    {
        public int ProductId { get; set; }
        public int SubCategoryId { get; set; }
        public int CategoryId { get; set; }
        public string Name { get; set; }
        public int BrandId { get; set; }
        public string Description { get; set; }
        public decimal UnitCost { get; set; }
        public string Image { get; set; }
        public string Status { get; set; }
        public virtual SubCategory SubCategory { get; set; }
        public virtual Category Category { get; set; }
        public virtual Brands Brands { get; set; }
    }
}