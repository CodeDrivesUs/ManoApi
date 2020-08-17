using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ManoApi.Models
{
    public class ClientViewModels
    {
    }
    public class StoreVm
    {
        public int StoreId { get; set; }
        public string Name { get; set; }
        public string address { get; set; }
        public string status { get; set; }
        public string Image { get; set; }
    }
}