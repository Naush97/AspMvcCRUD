using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data.Entity;
using MvcCRUDEntity.Models;

namespace MvcCRUDEntity.Models
{
    public class ProductContext : DbContext
    {
        public ProductContext():base("ProductConnection") { 
        }
        public DbSet<Product> ProductsTable { get; set;}
    }
}