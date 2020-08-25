using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ManoApi.Models
{
    public class Brands
    {
        [Key]
        public int BrandId { get; set; }
        public int StoreId { get; set; }
        [Display(Name="Name Of Brand")]
        public string Name { get; set; }
        public virtual Stores Stores { get; set; }

    }
}