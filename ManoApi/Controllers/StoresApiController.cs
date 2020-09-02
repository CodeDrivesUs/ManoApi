using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Description;
using ManoApi.Models;
using ManoApi.Models.ViewModels;
namespace ManoApi.Controllers
{
    public class StoresApiController : ApiController
    {
        private DataModel db = new DataModel();

        // GET: api/StoresApi
        public List<StoreVm> GetStores()
        {
            var list = new List<StoreVm>();
            foreach(var item in db.Stores.ToList()){
                var base64 = Convert.ToBase64String(item.Image);
                var imgSrc = String.Format("data:image/gif;base64,{0}", base64);
                list.Add(new StoreVm { address=item.address, Name=item.Name, status=item.status, StoreId=item.StoreId, Image= imgSrc});
            }
            return list;
        }

        // GET: api/StoresApi/5
        [ResponseType(typeof(Stores))]
        public StoreViewModel GetStores(int id)
        {
            var cat = db.Categories.Where(x => x.StoreId == id).ToList();
            var subCat = new List<SubCategory>();
            var prod = new List<ProductViewModel>();
            foreach (var item in cat )
            {
                foreach(SubCategory subCategory in db.SubCategories.Where(x => x.CategoryId == item.CategoryId).ToList())
                {
                    subCat.Add(subCategory);
                    foreach(Product product in db.Products.Where(x => x.SubCategoryId == subCategory.SubCategoryId).ToList())
                    {
                        var base64 = Convert.ToBase64String(product.Image);
                        var imgSrc = String.Format("data:image/gif;base64,{0}", base64);
                        prod.Add(new ProductViewModel { ProductId=product.ProductId, BrandId=product.BrandId, Brands=product.Brands, 
                        Category=product.Category, CategoryId=product.CategoryId,
                        Description=product.Description, Name=product.Name, Status=product.Status, SubCategory=product.SubCategory, 
                        UnitCost=product.UnitCost, SubCategoryId=product.SubCategoryId , Image= imgSrc  });
                    }
                }     
            }
            var store = new StoreViewModel { Categories=cat, Products=prod, SubCategories=subCat };
            return store;
        }

        // PUT: api/StoresApi/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutStores(int id, Stores stores)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != stores.StoreId)
            {
                return BadRequest();
            }

            db.Entry(stores).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!StoresExists(id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }

            return StatusCode(HttpStatusCode.NoContent);
        }

        // POST: api/StoresApi
        [ResponseType(typeof(Stores))]
        public IHttpActionResult PostStores(Stores stores)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.Stores.Add(stores);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = stores.StoreId }, stores);
        }

        // DELETE: api/StoresApi/5
        [ResponseType(typeof(Stores))]
        public IHttpActionResult DeleteStores(int id)
        {
            Stores stores = db.Stores.Find(id);
            if (stores == null)
            {
                return NotFound();
            }

            db.Stores.Remove(stores);
            db.SaveChanges();

            return Ok(stores);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool StoresExists(int id)
        {
            return db.Stores.Count(e => e.StoreId == id) > 0;
        }
    }
}