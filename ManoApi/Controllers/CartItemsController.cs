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
using Microsoft.AspNet.Identity;
namespace ManoApi.Controllers
{
    public class CartItemsController : ApiController
    {
        private DataModel db = new DataModel();

        // GET: api/CartItems
        public IQueryable<CartItem> GetcartItems(int id)
        {
            return db.cartItems.Where(x=>x.CartId==id);

        }

        // GET: api/CartItems/5
        [ResponseType(typeof(CartItem))]
        public IHttpActionResult GetCartItem()
        {
            CartItem cartItem = db.cartItems.Find(453);
            if (cartItem == null)
            {
                return NotFound();
            }

            return Ok(cartItem);
        }

        // PUT: api/CartItems/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutCartItem(int id, CartItem cartItem)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != cartItem.CartItemId)
            {
                return BadRequest();
            }

            db.Entry(cartItem).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CartItemExists(id))
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

        // POST: api/CartItems
        [ResponseType(typeof(CartItem))]
        public IHttpActionResult PostCartItem(CartItem cartItem)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            db.cartItems.Add(cartItem);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = cartItem.CartItemId }, cartItem);
        }

        // DELETE: api/CartItems/5
        [ResponseType(typeof(CartItem))]
        public IHttpActionResult DeleteCartItem(int id)
        {
            CartItem cartItem = db.cartItems.Find(id);
            if (cartItem == null)
            {
                return NotFound();
            }

            db.cartItems.Remove(cartItem);
            db.SaveChanges();

            return Ok(cartItem);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CartItemExists(int id)
        {
            return db.cartItems.Count(e => e.CartItemId == id) > 0;
        }
    }
}