using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace ShoppinigList.Models
{
    public class ShoppingListContext:DbContext
    {
        public ShoppingListContext():base("ShoppingListContext")
        {
            
        }
        public DbSet<ProductModel> Products { get; set; }


    }
}