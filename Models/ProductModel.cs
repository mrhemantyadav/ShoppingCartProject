using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel;
using System.Linq;
using System.Web;
using System.ComponentModel.DataAnnotations;

namespace ShoppinigList.Models
{
    public class ProductModel
    {
        [Key]
        public int PId { get; set; }

        [DisplayName("Product Name")]

        public string PName { get; set; }

        [DisplayName("Upload Images")]
        public string imagesPath { get; set; }

        [DisplayName("Product Price")]
        public int PPrice { get; set; }

        [DisplayName("Quantity")]
        public int Qty { get; set; }

        [NotMapped]
        public HttpPostedFileBase ImageFile { get; set; }
    }
}