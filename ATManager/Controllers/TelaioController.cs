using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using System.Data;
using System.Data.SqlClient;
using ATManager.Models;
using System.Net;
using System.Data.Entity;
using System.IO;

namespace ATManager.Controllers
{
    public class TelaioController : Controller
    {
        private AUTOSDUEntities db = new AUTOSDUEntities();

        // GET: Telaio
        public ActionResult Index(string Targa, string Matricola)
        {
            /* Controllo se la targa  :
                
                1. Non esiste in anagrafica.
                2. Esiste in anagrafica ma non ha perizia associata
                3. Esiste in anagrafica, ha perizia associata ma in location differente
                4. Esiste in anagrafica, e ha perizia associata a location corretta...
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

            // Prima verifico se esite pratica CON perizia
            bool TargaEPeriziaEsistente = EsiteTargaConPerizia(aTarga);
            if (!TargaEPeriziaEsistente)
            {

                // Poi verifico se esiste pratica SENZA perizia
                bool TargaSenzaPeriziaEsistente = EsiteTargaSenzaPerizia(aTarga);
                if (!TargaSenzaPeriziaEsistente)
                {
                    aMessage = "Targa inesistente in anagrafica";
                    return 1;
                }
                else
                {
                    aMessage = "Targa  SENZA PERIZIA ";
                    return 2;
                }
            }
            else
            {
                // Verifico se esiste targa e perizia assegnata a zona differente..
                bool HasDifferentLocation = EsisteConLocationDifferente(aTarga);
                if (HasDifferentLocation)
                {
                    aMessage = "Targa esistente con location differente";
                    return 3;
                }
                else
                {
                    aMessage = "La targa esiste già nella location corrente ";
                    return 4;
                }

            }

            aMessage = "";
            return 0;

        }

        public bool EsisteConLocationDifferente(string aTarga)
        {
            string myZone = Session["Zona"].ToString();
            var cnt = (from s in db.AT_ListaPratiche_vw
                       where s.Targa.ToString() == aTarga
                       where s.Trilettera != myZone
                       select s.Perizie_ID).Count();
            if (cnt > 0)
                return true;
            else
                return false;
        }

        public bool EsiteTargaConPerizia(string aTarga)
        {
            var cnt = (from s in db.AT_ListaPratiche_vw
                              where s.Targa.ToString() == aTarga
                          select s.Perizie_ID).Count();
            if (cnt > 0)
                return true;
            else
                return false;
        }

        public bool EsiteTargaSenzaPerizia(string aTarga)
        {
            var cnt = (from s in db.AT_ListaPraticheSenzaPerizia_vw
                       where s.Targa.ToString() == aTarga
                       select s.ID).Count();
            if (cnt > 0)
                return true;
            else
                return false;
        }


    }
}