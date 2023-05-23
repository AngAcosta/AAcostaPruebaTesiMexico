using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PL.Controllers
{
    public class PazientiController : Controller
    {
        // GET: Pazienti
        public ActionResult GetAll()
        {
            ML.Result result = BL.Pazienti.GetAll();
            ML.Pazienti pazienti = new ML.Pazienti();

            if (result.Correct)
            {
                pazienti.Pazientis = result.Objects;
                return View(pazienti);
            }
            else
            {
                return View(pazienti);
            }
        }

        [HttpPost]
        public ActionResult GetAll(string nome, int IdPaziente)
        {
            ML.Result result = BL.Pazienti.GetAll(nome, IdPaziente);
            ML.Pazienti pazienti = new ML.Pazienti();

            if (result.Correct)
            {
                pazienti.Pazientis = result.Objects;
                return View(pazienti);
            }
            else
            {
                return View(pazienti);
            }
        }
    }
}