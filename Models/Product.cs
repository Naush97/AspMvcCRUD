using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace MvcCRUDEntity.Models
{
    [Table("Product")]
    public class Product
    {
        [Key]
        public int ProId { get; set; }
        public string Name { get; set; }
        public Nullable<decimal> Price { get; set; }
        public string Remark { get; set; }
    }
}