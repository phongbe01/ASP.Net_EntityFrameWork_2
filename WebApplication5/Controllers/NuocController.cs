using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication5.Models;

namespace WebApplication5.Controllers
{
    public class NuocController : Controller
    {
        // GET: Nuoc
        public ActionResult Index()
        {
            Model1 db = new Model1();
            var list = db.tQuocGias.ToList();
            return PartialView(list);
        }
    }
}