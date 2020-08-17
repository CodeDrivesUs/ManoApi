using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ManoApi.Models
{
    public class Stores
    {
        [Key]
        public int StoreId { get; set; }
        public string Name { get; set; }
        public string address { get; set; }
        public string status { get; set; }
        public byte[] Image { get; set; }
    }
}