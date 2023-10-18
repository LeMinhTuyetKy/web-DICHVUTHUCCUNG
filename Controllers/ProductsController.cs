using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Net;
using System.Web;
using System.Web.Mvc;
using clonePetService.Models;

namespace clonePetService.Controllers
{
    public class ProductsController : Controller
    {
        private ProductMethod pm=new ProductMethod();

        // GET: Products
        public ActionResult Index()
        {
            List<Product1> products = pm.Get(9);
            return View(products);
        }

        //// GET: Products/Details/5
        public ActionResult Details(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product1 product =  pm.GetByID(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        //// GET: Products/Create
        public ActionResult Create()
        {
            //ViewBag.PC_Id = new SelectList(db.ProductCategories, "Id", "Title");
            return View();
        }

        // POST: Products/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public  ActionResult Create([Bind(Include = "Id,Title,PC_Id,Description,Detail,Image,Price,inventery,Quantity,Icon,CreateDate,CreateBy")] Product1 product)
        {
            if (ModelState.IsValid)
            {
                pm.Create(product);
                //db.Products.Add(product);
                //await db.SaveChangesAsync();
                return RedirectToAction("Index");
            }

            //ViewBag.PC_Id = new SelectList(db.ProductCategories, "Id", "Title", product.PC_Id);
            return View(product);
        }

        // GET: Products/Edit/5
        public ActionResult Edit(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product1 product = pm.GetByID(id);
            if (product == null)
            {
                return HttpNotFound();
            }
           //ViewBag.PC_Id = new SelectList(db.ProductCategories, "Id", "Title", product.PC_Id);
            return View(product);
        }

        // POST: Products/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "Id,Title,PC_Id,Description,Detail,Image,Price,inventery,Quantity,Icon,CreateDate,CreateBy")] Product1 product)
        {
            if (ModelState.IsValid)
            {
                //   db.Entry(product).State = EntityState.Modified;
                pm.Change(product);
                return RedirectToAction("Index");
            }
            //ViewBag.PC_Id = new SelectList(db.ProductCategories, "Id", "Title", product.PC_Id);
            return View(product);
        }

        // GET: Products/Delete/5
        public ActionResult Delete(int id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }
            Product1 product = pm.GetByID(id);
            if (product == null)
            {
                return HttpNotFound();
            }
            return View(product);
        }

        // POST: Products/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            pm.Delete(id);
            return RedirectToAction("Index");
        }


    }
}
