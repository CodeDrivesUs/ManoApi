namespace ManoApi.Models
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    public class DataModel : DbContext
    {
       
        public DataModel()
            : base("name=DataModel")
        {
             
        }
        public System.Data.Entity.DbSet<ManoApi.Models.Category> Categories { get; set; }
        public DbSet<Stores> Stores { get; set; }
        public System.Data.Entity.DbSet<ManoApi.Models.SubCategory> SubCategories { get; set; }
        public System.Data.Entity.DbSet<ManoApi.Models.Brands> Brands { get; set; }
        public System.Data.Entity.DbSet<ManoApi.Models.Product> Products { get; set; }
    }

}