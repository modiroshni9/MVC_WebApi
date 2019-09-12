using Api_Ajax_Demo.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Api_Ajax_Demo.Common
{
    public class CustomerDbContext: DbContext
    {
        public CustomerDbContext() : base("MVC_Demo") { }
        public DbSet<Customers> DbCustomer { get; set; }
    }
}