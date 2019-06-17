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
        public ActionResult Index(string Targa, string Matricola,int?SearchLocation ,string myTarga, string MessaggioQuery)
        {
            /* Controllo se la targa  :
                
                1. Non esiste in anagrafica.
                2. Esiste in anagrafica ma non ha perizia associata
                3. Esiste in anagrafica, ha perizia associata ma in location differente
                4. Esiste in anagrafica, e ha perizia associata a location corretta...
                9. NON ANDATO A BUON FINE
            */

            Session["TargaDaModificare"] = Targa;
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
            ViewBag.MessaggioQuery = MessaggioQuery;
            ViewBag.aTarga = myTarga;
            return View();


            //return View();
        }

        [HttpPost]
        public ActionResult Salva(FormCollection form)
        {
            string myPerito = Session["IDPErito"].ToString();

            string myTarga = Session["TargaDaModificare"].ToString();
            int IDP = (from s in db.AT_ListaPratiche_vw
                       where s.Targa.ToString() == myTarga
                       //where s.Perizie_IDPerito != myPerito
                       select s.Perizie_ID).FirstOrDefault();


            string myID = form["SearchLocation"].ToString();


            var sql = @" UPDATE SDU_PERIZIE SET ID_LuogoIntervento = @ID_LuogoIntervento, " +
                       "                         ID_Perito = @ID_Perito " +
                       "  WHERE ID = @ID_perizia AND 0=0 ";

            try
            {
                int noOfRowInsertedKm = db.Database.ExecuteSqlCommand(sql,
                            new SqlParameter("@ID_perizia", IDP),
                            new SqlParameter("@ID_Perito", myPerito),
                            new SqlParameter("@ID_LuogoIntervento", myID));
                ViewBag.Message = "Telaio modificato correttamente";
            }
            catch
            {
                ViewBag.Message = "Errore in modifica assegnazione località telaio";
            }

            return RedirectToAction("Index", "Telaio", new { MessaggioQuery = ViewBag.Message });

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

                    using (AUTOSDUEntities val = new AUTOSDUEntities())
                    {
                        string myZone = Session["Zona"].ToString();
                        string myPerito = Session["IDPErito"].ToString();

                        var cnt = (from s in db.LuoghiTest_vw
                                   where s.IDPErito.ToString() == myPerito
                                   select s).ToList();
                        var fromDatabaseEF = new SelectList(cnt, "ID", "DescrITA");
                        ViewData["Luoghi"] = fromDatabaseEF;

                    }

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
            string myPerito = Session["User"].ToString();
            var cnt = (from s in db.AT_ListaPratiche_vw
                       where s.Targa.ToString() == aTarga
                       where s.Perizie_IDPerito != myPerito
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

        public ActionResult ShowAllMobileDetails(FormCollection form)
        {
            string strDDLValue = form["ddlVendor"].ToString();

            return View();
        }


    }

   
}