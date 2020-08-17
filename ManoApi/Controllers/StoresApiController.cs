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

namespace ManoApi.Controllers
{
    public class StoresApiController : ApiController
    {
        private ApplicationDbContext db = new ApplicationDbContext();

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
        public IHttpActionResult GetStores(int id)
        {
            Stores stores = db.Stores.Find(id);
            if (stores == null)
            {
                return NotFound();
            }

            return Ok(stores);
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