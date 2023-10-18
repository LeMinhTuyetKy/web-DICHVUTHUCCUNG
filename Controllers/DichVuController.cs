using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;
using clonePetService.Models;

namespace clonePetService.Controllers
{
    public class DichVuController : Controller
    {
        // GET: DichVu
        public ActionResult Index(string Search)
        {
            dichVuCreate dichVuCreate = new dichVuCreate();


            List<DichVu> dichVu;
            if (Search == null)
            {
                dichVu = dichVuCreate.Get(5);
                return View(dichVu);
            }
            else
            {
                dichVu = dichVuCreate.Search(Search);
                return View(dichVu);
            }

        }
        public ActionResult Create(DichVu dv)
        {
            if (!ModelState.IsValid)
            {
                return View(dv);
            }
            dichVuCreate dichVuCreate = new dichVuCreate();
            dichVuCreate.Create(dv);
            return RedirectToAction("Index", "DichVu");
        }
        public ActionResult Change(int id )
        {
            dichVuCreate dichVuCreate = new dichVuCreate();
            DichVu dv = dichVuCreate.GetByID(id);
            return View(dv);
        }

        public ActionResult ChangeData(DichVu dv)
        {

            if (!ModelState.IsValid)
            {
                return RedirectToAction("Index", "DichVu");
            }

            dichVuCreate dichVuCreate = new dichVuCreate();
            dichVuCreate.Change(dv);
             return RedirectToAction("Index", "DichVu");
        }

        public ActionResult Delete(int id)
        {

            dichVuCreate dichVuCreate = new dichVuCreate();
            dichVuCreate.Delete(id);
            return RedirectToAction("Index", "DichVu");
        }


        public ActionResult ShowAll(string Search)
          {
            dichVuCreate dichVuCreate = new dichVuCreate();
            List<DichVu> dichVu;
            if (Search == null)
            {
                dichVu = dichVuCreate.Get(7);
                return View(dichVu);
            }
            else
            {
                dichVu = dichVuCreate.Search(Search);
                return View(dichVu);
            }
        }
    }
}