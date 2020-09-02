using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ManoApi.Models.ViewModels
{
    public class StoreViewModel
    {
        public List<Category>  Categories  { get; set; }
        public List<SubCategory>  SubCategories { get; set; }
        public List<ProductViewModel>  Products { get; set; }
    }
}