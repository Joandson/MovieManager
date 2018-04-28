using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MovieManager.Core;

namespace MovieManager.Controllers
{
    [Authorize]
    public class HomeController : Controller
    {
        private readonly IUnitOfWork _unitOfWork;
        //All of your controllers should be using the IUnitOfWork injected into the controller in order to use the Dependency Injection
        public HomeController(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public ActionResult Index()
        {
            /* In order to use these notifications simply set the message type  and actual message and that's it!, Everything else has been done already for ya :) */
            TempData["success"] = "Success Notifications Are Working Hooray!!!";
            TempData["info"] = "Info Notifications Are Working Hooray!!!";
            TempData["warning"] = "Warning Notifications Are Working Hooray!!!";
            TempData["Error"] = "Error Notifications Are Working Hooray!!!";
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";


            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}