using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace ShoppinigList.Models
{
    public class ListKartModel
    {
        [Key]
        public int LCId { get; set; }
        public int Qty { get; set; }
        public ProductModel Products { get; set; }
    }
}