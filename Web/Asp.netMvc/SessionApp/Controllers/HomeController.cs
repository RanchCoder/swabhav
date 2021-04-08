using SessionApp.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SessionApp.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            StateViewModel svm;
            if(Session["CurrentCounter"] != null)
            {
                svm = (StateViewModel)Session["CurrentCounter"];
            }
            else
            {
                svm = new StateViewModel();
            }

            svm.OldValue = svm.Counter;
            svm.Counter++;
            svm.NewValue = svm.Counter;
            Session["CurrentCounter"] = svm;
            return View(svm);
        }

        public ActionResult IndexHttpContext()
        {
            StateViewModel svm;
            if (HttpContext.Application["CurrentCounter"] != null)
            {
                svm = (StateViewModel)HttpContext.Application["CurrentCounter"];
            }
            else
            {
                svm = new StateViewModel();
            }

            svm.OldValue = svm.Counter;
            svm.Counter++;
            svm.NewValue = svm.Counter;
            HttpContext.Application["CurrentCounter"] = svm;
            return View(svm);
        }

    }
}