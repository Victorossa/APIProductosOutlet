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
using OutletApi.Models;

namespace OutletApi.Controllers
{
    public class Prod_TipoProductosController : ApiController
    {
        private DBModel db = new DBModel();

        // GET: api/Prod_TipoProductos
        public IQueryable<Prod_TipoProductos> GetProd_TipoProductos()
        {
            return db.Prod_TipoProductos;
        }

        // PUT: api/Prod_TipoProductos/5
        [ResponseType(typeof(void))]
        public IHttpActionResult PutProd_TipoProductos(int id, Prod_TipoProductos prod_TipoProductos)
        {
            if (id != prod_TipoProductos.TipoProductoID)
            {
                return BadRequest();
            }

            db.Entry(prod_TipoProductos).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!Prod_TipoProductosExists(id))
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

        // POST: api/Prod_TipoProductos
        [ResponseType(typeof(Prod_TipoProductos))]
        public IHttpActionResult PostProd_TipoProductos(Prod_TipoProductos prod_TipoProductos)
        {
            db.Prod_TipoProductos.Add(prod_TipoProductos);
            db.SaveChanges();

            return CreatedAtRoute("DefaultApi", new { id = prod_TipoProductos.TipoProductoID }, prod_TipoProductos);
        }

        // DELETE: api/Prod_TipoProductos/5
        [ResponseType(typeof(Prod_TipoProductos))]
        public IHttpActionResult DeleteProd_TipoProductos(int id)
        {
            Prod_TipoProductos prod_TipoProductos = db.Prod_TipoProductos.Find(id);
            if (prod_TipoProductos == null)
            {
                return NotFound();
            }

            db.Prod_TipoProductos.Remove(prod_TipoProductos);
            db.SaveChanges();

            return Ok(prod_TipoProductos);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool Prod_TipoProductosExists(int id)
        {
            return db.Prod_TipoProductos.Count(e => e.TipoProductoID == id) > 0;
        }
    }
}