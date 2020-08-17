using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ManoApi.Models
{
    public class SubCategory
    {
        [Key]
        public int SubCategoryId { get; set; }
        public int CategoryId { get; set; }
        public string SubCatName { get; set; }
        public string Status { get; set; }
        public virtual Category Category { get; set; }

    }
}