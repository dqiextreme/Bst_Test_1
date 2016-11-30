using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Bst_Test_1.Clases;
using Bst_Test_1.Models;

namespace Bst_Test_1.Controllers
{
    public class TestController : Controller
    {
        //
        // GET: /Test/

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult Ntes()
        {
            return View();
        }

        public ActionResult jstest(int id)
        {
            ViewBag.res = id;
            return View();
        }

        public ActionResult jstest2(int id)
        {
            ViewBag.res = id;
            ViewBag.res2 = Convert.ToString(System.DateTime.Now);
            return View();
        }


        TClass_1 tc1 = new TClass_1();
        public ActionResult jstest3(int id)
        {
            var a = tc1.test();
            //ViewBag.res = a.Where(x => x.ID == id).ToList();
            ViewBag.res = tc1.test();
            return View();
        }

        TClass_2 tc2 = new TClass_2();
        public ActionResult jstest4(int id)
        {
            //token tk = new token();
            //tk.master();
            
            
            List<Adjunto> lst = tc2.ts();
            Adjunto lst2 = lst.SingleOrDefault();
            
            TempData.Clear();
            TempData["t1"] = lst2;
            ViewBag.list1 = lst;

            return View();
        }

        public ActionResult fuck(int id, string id2)
        {
            token tk = new token();
            tk.check(id2);
            return View();
        }

        public ActionResult ModalTestPartial(int id)
        {
            tc1.local();
            ViewBag.id = id;
            return PartialView();
        }

        public ActionResult ModalTestPartial2(int id)
        {
            ViewBag.id = id;
            return PartialView();
        }

    }
}
