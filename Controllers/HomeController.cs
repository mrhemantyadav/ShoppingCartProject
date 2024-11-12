using ShoppinigList.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ShoppinigList.Controllers
{
    public class HomeController : Controller
    {
        ShoppingListContext db = new ShoppingListContext();


        public ActionResult index()
        {
            List<ProductModel> pn = db.Products.ToList();
            decimal total = pn.Sum(p => p.PPrice);
            decimal totalQty = pn.Sum(P => P.Qty);
            ViewBag.TotalPrice = total;
            ViewBag.totalQty = totalQty;


            //decimal discountPercentage = ;
            //decimal discountAmount = total * (discountPercentage / 100);
            //decimal totalWithDiscount = total - discountAmount;


            return View(db.Products.ToList());
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(ProductModel pm)
        {

            if (ModelState.IsValid)
            {

                if (pm != null)
                {
                    HttpPostedFileBase imageFileIF = pm.ImageFile;
                    if (imageFileIF != null)
                    {

                        string fileName = Path.GetFileNameWithoutExtension(imageFileIF.FileName);
                        string extension = Path.GetExtension(imageFileIF.FileName);

                        fileName = fileName + extension;
                        pm.imagesPath = "~/images/" + fileName;

                        fileName = Path.Combine(Server.MapPath("~/images/") + fileName);
                        imageFileIF.SaveAs(fileName);

                    }
                    else
                    {
                        pm.imagesPath = "~/images/" + "default.png";
                    }

                }
                db.Products.Add(pm);
                int affected = db.SaveChanges();

                if (affected > 0)
                {
                    ViewBag.Affected = "Add product";
                }
                else
                {
                    ViewBag.Affected = "Not add product";
                }
            }
            return View();
        }
        [HttpGet]
        public ActionResult Delete(int id, string name)
        {
            return View(db.Products.Where(X => X.PId == id).FirstOrDefault());

        }

        [HttpPost]
        public ActionResult Delete(int id)
        {
            var dataRow = db.Products.Where(X => X.PId == id).FirstOrDefault();
            db.Entry(dataRow).State = System.Data.Entity.EntityState.Deleted;
            int affected = db.SaveChanges();
            if (affected > 0)
            {
                TempData["deleteMSG"] = "Delete sucessfull";
                return RedirectToAction("Index");
            }
            else
            {
                TempData["deleteMSG"] = "Delete not sucessfull";

            }
            return View();
        }

     
    }
}