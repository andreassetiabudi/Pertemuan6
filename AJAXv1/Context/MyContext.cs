using AJAXv1.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace AJAXv1.Context
{
    public class MyContext : DbContext
    {
        public MyContext() : base("MyConnection")
        {

        }

        public System.Data.Entity.DbSet<AJAXv1.Models.Supplier> Suppliers { get; set; }
        public DbSet<Province> Provinces { get; set; }
    }
}