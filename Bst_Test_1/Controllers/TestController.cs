using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Bst_Test_1.Clases;

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

    }
}
