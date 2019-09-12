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
using Api_Ajax_Demo.Common;
using Api_Ajax_Demo.Models;

namespace Api_Ajax_Demo.Controllers.Api
{
    public class CustomersController : ApiController
    {
        private CustomerDbContext db = new CustomerDbContext();

        // GET: api/Customers
        public IQueryable<Customers> GetDbCustomer()
        {
            return db.DbCustomer;
        }

        // GET: api/Customers/5
        [ResponseType(typeof(Customers))]
        public IHttpActionResult GetCustomers(Guid id)
        {
            Customers customers = db.DbCustomer.Find(id);
            if (customers == null)
            {
                return NotFound();
            }

            return Ok(customers);
        }

        // PUT: api/Customers/5
        [ResponseType(typeof(void))]
        [HttpPut]
        public IHttpActionResult PutCustomers(Guid id, Customers customers)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            if (id != customers.Customer_Id)
            {
                return BadRequest();
            }

            db.Entry(customers).State = EntityState.Modified;

            try
            {
                db.SaveChanges();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!CustomersExists(id))
                //if (!CustomersExists(customers.Customer_Id))
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

        // POST: api/Customers
        [ResponseType(typeof(Customers))]
        public IHttpActionResult PostCustomers(Customers customers)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }
            customers.Customer_Id = Guid.NewGuid();

           db.DbCustomer.Add(customers);

            try
            {
                  db.SaveChanges();
            }
            catch (DbUpdateException)
            {
                if (CustomersExists(customers.Customer_Id))
                {
                    return Conflict();
                }
                else
                {
                    throw;
                }
            }

            return RedirectToRoute("/api/Customers","Customers");
        }

        // DELETE: api/Customers/5
        [HttpDelete]
        [ResponseType(typeof(Customers))]
        public IHttpActionResult DeleteCustomers(Guid id)
        {
            Customers customers = db.DbCustomer.Find(id);
            if (customers == null)
            {
                return NotFound();
            }

            db.DbCustomer.Remove(customers);
            db.SaveChanges();

            return Ok(customers);
        }

        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }

        private bool CustomersExists(Guid id)
        {
            return db.DbCustomer.Count(e => e.Customer_Id == id) > 0;
        }
    }
}