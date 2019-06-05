using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ATManager.Controllers
{
    public class TelaioController : Controller
    {
        // GET: Telaio
        public ActionResult Index(string Targa, string Matricola)
        {
            /* Controllo se la targa  :
                
                1. Non esiste in anagrafica.
                2. Esiste in anagrafica ma non ha perizia associata
                3. Esiste in anagrafica, ha perizia associata ma in location differente
                9. NON ANDATO A BUON FINE
            */

            int Controllo = 0;

            string myMessage = "";
            if (!String.IsNullOrEmpty(Targa))
            {
                Controllo = CheckTarga(Targa, Matricola, out myMessage);
            }
            else
            {
                Controllo = 0;
                myMessage = "";
            }
           
            ViewBag.Controllo = Controllo;
            ViewBag.Messaggio = myMessage;
            return View();


            //return View();
        }

        public int CheckTarga(string aTarga, string aMatricola, out string aMessage)
        {
            aMessage = "";
            if (aTarga.Length != 7)
            {
                aMessage = "Lunghezza targa non corretta !";
                return 0;
            }

            bool TargaEsistente = EsiteInAnagrafica();
            if (!TargaEsistente)
            {
                aMessage = "Targa inesistente";
                return 0;
            }

            aMessage = "";
            return 0;

        }

        public bool EsiteInAnagrafica()
        {
            return false;
        }
    }
}