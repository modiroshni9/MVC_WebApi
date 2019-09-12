using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Api_Ajax_Demo.Models
{
    public class Customers
    {
        [Key]
        public Guid Customer_Id { get; set; }

        public string Name { get; set; }
        public string Address { get; set; }
        public string MobileNo { get; set; }
        public string EmailId { get; set; }
    }
}