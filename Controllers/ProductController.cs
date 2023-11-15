using MvcCRUDEntity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Net;

namespace MvcCRUDEntity.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        ProductContext db=new ProductContext();
        public ActionResult Index()
        {
            return View(db.ProductsTable.ToList());
        }
        public ActionResult Details(int? id)
        {
            if(id==null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest,"Product Id is Required"); 
            }
            Product product=db.ProductsTable.Find(id);
            if(product==null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.NotFound, "Product Not Found");
            }
            return View(product);
        }
        public ActionResult Create()
        { 
            return View(); 
        }
        [HttpPost]
        public ActionResult Create(FormCollection formCollection) //public ActionResult Create(string Name,decimal Price,string Remark)
        {
            Product product = new Product();
            product.Name = formCollection["name"];
            product.Price = Convert.ToDecimal(formCollection["Price"]);
            product.Remark = formCollection["Remark"];
            
            db.ProductsTable.Add(product);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

        //Another way to create post method
        /*public ActionResult Create(Product product) 
        {
            db.ProductsTable.Add(product);
            db.SaveChanges();
            return RedirectToAction("Index");
        }*/

        public ActionResult Edit(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest, "Product Id is Required");
            Product product = db.ProductsTable.Find(id);
            if(product==null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.NotFound, "Product is Not Found");
            }
            return View(product);
        }
        [HttpPost]
        public ActionResult Edit(int id)
        {
            Product product=db.ProductsTable.Find(id);
            UpdateModel(product);
            db.SaveChanges();
            return RedirectToAction("Index");
        }
        public ActionResult Delete(int? id)
        {
            if (id == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest, "Product Id is Required");
            Product product = db.ProductsTable.Find(id);
            if (product == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.NotFound, "Product is Not Found");
            }
            return View(product);
        }
        [HttpPost,ActionName("Delete")]
        public ActionResult Remove(int ? id)
        {
            Product product = db.ProductsTable.Find(id);
            db.ProductsTable.Remove(product);
            db.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}