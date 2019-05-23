using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace JobListing.UI.Controllers
{
    [Authorize]
    public class JobController : Controller
    {
        // GET: Job
        public ActionResult List()
        {
            return View();
        }
        public ActionResult List2()
        {
            return View();
        }
        [AllowAnonymous]
        public ActionResult List3()
        {
            return View();

        }
    }
}