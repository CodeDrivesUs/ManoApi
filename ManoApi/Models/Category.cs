using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ManoApi.Models
{
    public class Category
    {
        [Key]
        public int CategoryId { get; set; }
        public int StoreId { get; set; }
        public string CategoryName { get; set; }
        public string Status { get; set; }
        public virtual Stores Stores { get; set; }
    }
}