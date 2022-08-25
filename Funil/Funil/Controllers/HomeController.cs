using Funil.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Funil.Controllers
{
    public class HomeController : Controller
    {
        BDFunilEntities bd = new BDFunilEntities();
        public ActionResult Index()
        {
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

        public ActionResult BDError()
        {
            ViewBag.Mensagem = MensagemError.textoErro;
            return View();
        }

        public ActionResult Dashboard()
        {
            return View(bd.QtdCandidatoPorVaga.ToList());
        }



    }
}