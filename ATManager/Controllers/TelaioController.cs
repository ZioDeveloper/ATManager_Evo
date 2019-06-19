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
        public ActionResult Index(string Targa, string Matricola,int?SearchLocation ,string myTarga, string MessaggioQuery, string myMatricola, string myIDLuogo)
        {
            /* Controllo se la targa  :
                
                1. Non esiste in anagrafica.
                2. Esiste in anagrafica ma non ha perizia associata
                3. Esiste in anagrafica, ha perizia associata ma in location differente
                4. Esiste in anagrafica, e ha perizia associata a location corretta...
                9. NON ANDATO A BUON FINE
            */

            Session["TargaDaModificare"] = Targa;
            Session["MatricolaDaModificare"] = Matricola;
            int Controllo = 0;

            string myMessage = "";
            if (!String.IsNullOrEmpty(Targa))
            {
                Controllo = CheckTarga(Targa, Matricola, myIDLuogo, out myMessage);
            }
            else if (!String.IsNullOrEmpty(Matricola))
            {
                Controllo = CheckMatricola(Targa, Matricola, myIDLuogo, out myMessage);
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
            ViewBag.aMatricola = myMatricola;
            ViewBag.aIDLuogo = myIDLuogo;
            return View();


            //return View();
        }

        [HttpPost]
        public ActionResult CreaNuovaTarga(FormCollection form)
        {
            string myTarga = Session["TargaDaModificare"].ToString();
            string myMatricola = Session["MatricolaDaModificare"].ToString();
            string myUSer = Session["User"].ToString();
            string myPerito = Session["IDPErito"].ToString();

            if (String.IsNullOrEmpty(myTarga))
            {
                return View("Index");
            }

            string myIDLocation = form["SearchLocation"].ToString();

            // Insert SDU_Pratiche
            var sql = @" INSERT INTO SDU_PRATICHE (ID_Gestione, DataApertura, OraApertura, MinApertura, VersioneCliente, Targa, Insert_Usr, Insert_Time, Update_Usr ) " +
                        "  VALUES(@ID_Gestione, GETDATE(),0,0, @VersioneCliente, @Targa, @Insert_Usr, GETDATE(), @Update_Usr)";

            
            int noOfRowInsertedKm = db.Database.ExecuteSqlCommand(sql,
                           new SqlParameter("@ID_Gestione", "0036"),
                           new SqlParameter("@VersioneCliente", myMatricola),
                           new SqlParameter("@Targa", myTarga),
                           new SqlParameter("@Insert_Usr", myUSer),
                           new SqlParameter("@Update_Usr", myTarga));

            // recupero maX ID Pratica
             var myIDPratica = (from s in db.SDU_Pratiche
                          where s.ID_Gestione.ToString() == "0036"
                          orderby s.ID descending
                          select s.ID).FirstOrDefault();

            int myID = myIDPratica;

           


            SqlParameter[] @params = { new SqlParameter("@returnVal", SqlDbType.Int) {Direction = ParameterDirection.Output} };

            var query1 = db.Database.ExecuteSqlCommand("exec @returnVal = dbo.spw_GetNewNumberWise 'AV3_19'", @params);

            string result = @params[0].Value.ToString();

            string myBarcode = "U0019" + result.ToString().PadLeft(4,'0') + "0";
            
            // INSERT Perizia
            sql = " INSERT INTO SDU_PERIZIE (ID_Pratica, Barcode, ID_TipoPerizia, ID_LuogoIntervento, ID_Perito, DataIncarico, DataPerizia, Insert_Usr, Insert_Time) " +
                  "  VALUES(@ID_Pratica, @Barcode, @ID_TipoPerizia, @ID_LuogoIntervento, @ID_Perito, GETDATE(), GETDATE() , @Insert_Usr, GETDATE())";

            noOfRowInsertedKm = db.Database.ExecuteSqlCommand(sql,
                           new SqlParameter("@ID_Pratica", myID),
                           new SqlParameter("@Barcode", myBarcode),
                           new SqlParameter("@ID_TipoPerizia", "46"),
                           new SqlParameter("@ID_LuogoIntervento", myIDLocation),
                           new SqlParameter("@ID_Perito", myPerito),
                           new SqlParameter("@Insert_Usr", myUSer));

            // recupero maX ID Perizia
            var myIDerizia = (from s in db.SDU_Perizie
                              orderby s.ID descending
                              select s.ID).FirstOrDefault();

            int myIDPe = myIDerizia;

            // INSERT LINK
            sql = @" INSERT SDU_LINK_PRATICA_PERITI_INCARICO (IDPerito, ID_Pratica, ID_TipoPerizia, ID_LuogoIntervento, ID_Perizia, Insert_Usr, Insert_Time) " +
                   "  VALUES (@IDPerito, @ID_Pratica, @ID_TipoPerizia, @ID_LuogoIntervento, @ID_Perizia, @Insert_Usr, GETDATE() )";
            noOfRowInsertedKm = db.Database.ExecuteSqlCommand(sql,
                           new SqlParameter("@IDPerito", myPerito),
                           new SqlParameter("@ID_Pratica", myID),
                           new SqlParameter("@ID_TipoPerizia", "46"),
                           new SqlParameter("@ID_LuogoIntervento", myIDLocation),
                           new SqlParameter("@ID_Perizia", myIDPe),
                           new SqlParameter("@Insert_Usr", myUSer));

            // Insert STATUS
            var p1 = new SqlParameter("@login", Session["User"]);
            var p2 = new SqlParameter("@ID_perizia", myIDPe);
            var p3 = new SqlParameter("@ID_Stato", "15A");
            var p4 = new SqlParameter("@DataStato", DateTime.Now);
            var p5 = new SqlParameter("@Note", "");

            int noOfRowInserted = db.Database.ExecuteSqlCommand("EXEC sp_InsertStatus {0}, {1}, {2}, {3} , {4}", p1.Value, p2.Value, p3.Value, p4.Value, p5.Value);


            Session["ExecJS"] = "true";
            var model = new Models.HomeModel();

            var t = (from s in db.AT_ListaPratiche_vw
                         where s.Targa.ToString() == myTarga
                         select s).FirstOrDefault();
            return RedirectToAction("Create", "Home", new
                    {
                        id = t.Perizie_ID,
                        dataperizia = DateTime.Now.ToString("dd/MM/yyyy"),
                        marca = t.Prod_Descr,
                        targa = t.Targa,
                        dataimmatricolazione = t.DataImmatricolazione,
                        km = t.Km,
                        luogoperizia = t.DescrITA,
                        modello = t.Mod_Descr,
                        cartacircolazione = t.CartaCircolazione,
                        matricola = t.Matricola,
                        telaio = t.Chassis1 + t.Chassis2,
                        dataultimarevisione = t.DataUltimaRevisione,
                        aziendautilizzatrice = t.DescrizioneAzienda
                    });


        }

        [HttpPost]
        public ActionResult Salva(FormCollection form)
        {
            string myPerito = Session["IDPErito"].ToString();

            int IDP = 0;

            string myTarga = Session["TargaDaModificare"].ToString();
            string myMatricola = Session["MatricolaDaModificare"].ToString();

            if (!String.IsNullOrEmpty(myTarga))
            {

                IDP = (from s in db.AT_ListaPratiche_vw
                           where s.Targa.ToString() == myTarga
                           //where s.Perizie_IDPerito != myPerito
                           select s.Perizie_ID).FirstOrDefault();
            }
            else
            {
                IDP = (from s in db.AT_ListaPratiche_vw
                           where s.Matricola.ToString() == myMatricola
                           //where s.Perizie_IDPerito != myPerito
                           select s.Perizie_ID).FirstOrDefault();
            }

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
               // ViewBag.Message = "Telaio modificato correttamente";
            }
            catch
            {
                //ViewBag.Message = "Errore in modifica assegnazione località telaio";
            }

            var sqlL = @" UPDATE SDU_Link_Pratica_Periti_Incarico SET ID_LuogoIntervento = @ID_LuogoIntervento, " +
                       "                         ID_Perito = @ID_Perito " +
                       "  WHERE ID_Perizia = @ID_perizia AND 0=0 ";

            try
            {
                int noOfRowInsertedKm = db.Database.ExecuteSqlCommand(sqlL,
                            new SqlParameter("@ID_perizia", IDP),
                            new SqlParameter("@ID_Perito", myPerito),
                            new SqlParameter("@ID_LuogoIntervento", myID));
                ViewBag.Message = "Telaio modificato correttamente";
            }
            catch
            {
                ViewBag.Message = "Errore in modifica assegnazione località telaio";
            }



            Session["ExecJS"] = "true";
            var model = new Models.HomeModel();

            

            if (!String.IsNullOrEmpty(myTarga))
            {
                var t = (from s in db.AT_ListaPratiche_vw
                         where s.Targa.ToString() == myTarga
                         select s).FirstOrDefault();
                if (t.ID_SchedaTecnica == null)
                {

                    return RedirectToAction("Create", "Home", new
                    {
                        id = t.Perizie_ID,
                        dataperizia = DateTime.Now.ToString("dd/MM/yyyy"),
                        marca = t.Prod_Descr,
                        targa = t.Targa,
                        dataimmatricolazione = t.DataImmatricolazione,
                        km = t.Km,
                        luogoperizia = t.DescrITA,
                        modello = t.Mod_Descr,
                        cartacircolazione = t.CartaCircolazione,
                        matricola = t.Matricola,
                        telaio = t.Chassis1 + t.Chassis2,
                        dataultimarevisione = t.DataUltimaRevisione,
                        aziendautilizzatrice = t.DescrizioneAzienda
                    });
                }
                else
                {
                    return RedirectToAction("Create", "Home", new
                    {
                        id = t.Perizie_ID,
                        dataperizia = DateTime.Now.ToString("dd/MM/yyyy"),
                        marca = t.Prod_Descr,
                        targa = t.Targa,
                        dataimmatricolazione = t.DataImmatricolazione,
                        km = t.Km,
                        luogoperizia = t.DescrITA,
                        modello = t.Mod_Descr,
                        cartacircolazione = t.CartaCircolazione,
                        matricola = t.Matricola,
                        telaio = t.Chassis1 + t.Chassis2,
                        dataultimarevisione = t.DataUltimaRevisione,
                        aziendautilizzatrice = t.DescrizioneAzienda
                    });
                }
            }
            else
            {
                var t = (from s in db.AT_ListaPratiche_vw
                         where s.Matricola.ToString() == myMatricola
                         select s).FirstOrDefault();
                if (t.ID_SchedaTecnica == null)
                {

                    return RedirectToAction("Create", "Home", new
                    {
                        id = t.Perizie_ID,
                        dataperizia = DateTime.Now.ToString("dd/MM/yyyy"),
                        marca = t.Prod_Descr,
                        targa = t.Targa,
                        dataimmatricolazione = t.DataImmatricolazione,
                        km = t.Km,
                        luogoperizia = t.DescrITA,
                        modello = t.Mod_Descr,
                        cartacircolazione = t.CartaCircolazione,
                        matricola = t.Matricola,
                        telaio = t.Chassis1 + t.Chassis2,
                        dataultimarevisione = t.DataUltimaRevisione,
                        aziendautilizzatrice = t.DescrizioneAzienda
                    });
                }
                else
                {
                    return RedirectToAction("Create", "Home", new
                    {
                        id = t.Perizie_ID,
                        dataperizia = DateTime.Now.ToString("dd/MM/yyyy"),
                        marca = t.Prod_Descr,
                        targa = t.Targa,
                        dataimmatricolazione = t.DataImmatricolazione,
                        km = t.Km,
                        luogoperizia = t.DescrITA,
                        modello = t.Mod_Descr,
                        cartacircolazione = t.CartaCircolazione,
                        matricola = t.Matricola,
                        telaio = t.Chassis1 + t.Chassis2,
                        dataultimarevisione = t.DataUltimaRevisione,
                        aziendautilizzatrice = t.DescrizioneAzienda
                    });
                }
            }



 


            

            //return RedirectToAction("Index", "Telaio", new { MessaggioQuery = ViewBag.Message });

        }

        public ActionResult Sostituisci(FormCollection form)
        {
            string myPerito = Session["IDPErito"].ToString();

            int IDP = 0;

            string myTarga = Session["TargaDaModificare"].ToString();
            string myMatricola = Session["MatricolaDaModificare"].ToString();

            if (!String.IsNullOrEmpty(myTarga))
            {

                IDP = (from s in db.AT_ListaPratiche_vw
                       where s.Targa.ToString() == myTarga
                       //where s.Perizie_IDPerito != myPerito
                       select s.Perizie_ID).FirstOrDefault();
            }
            else
            {
                IDP = (from s in db.AT_ListaPratiche_vw
                       where s.Matricola.ToString() == myMatricola
                       //where s.Perizie_IDPerito != myPerito
                       select s.Perizie_ID).FirstOrDefault();
            }

            string myID = form["SearchLocation"].ToString();

            var sql = " DELETE FROM AT_SchedaTecnica WHERE IDPerizia = @IDPErizia ";
            db.Database.ExecuteSqlCommand(sql, new SqlParameter("@IDPErizia", IDP));

            sql = @" UPDATE SDU_PERIZIE SET ID_LuogoIntervento = @ID_LuogoIntervento, " +
                       "                         ID_Perito = @ID_Perito " +
                       "  WHERE ID = @ID_perizia AND 0=0 ";

            try
            {
                int noOfRowInsertedKm = db.Database.ExecuteSqlCommand(sql,
                            new SqlParameter("@ID_perizia", IDP),
                            new SqlParameter("@ID_Perito", myPerito),
                            new SqlParameter("@ID_LuogoIntervento", myID));
                // ViewBag.Message = "Telaio modificato correttamente";
            }
            catch
            {
                //ViewBag.Message = "Errore in modifica assegnazione località telaio";
            }

            var sqlL = @" UPDATE SDU_Link_Pratica_Periti_Incarico SET ID_LuogoIntervento = @ID_LuogoIntervento, " +
                       "                         ID_Perito = @ID_Perito " +
                       "  WHERE ID_Perizia = @ID_perizia AND 0=0 ";

            try
            {
                int noOfRowInsertedKm = db.Database.ExecuteSqlCommand(sqlL,
                            new SqlParameter("@ID_perizia", IDP),
                            new SqlParameter("@ID_Perito", myPerito),
                            new SqlParameter("@ID_LuogoIntervento", myID));
                ViewBag.Message = "Telaio modificato correttamente";
            }
            catch
            {
                ViewBag.Message = "Errore in modifica assegnazione località telaio";
            }



            Session["ExecJS"] = "true";
            var model = new Models.HomeModel();



            if (!String.IsNullOrEmpty(myTarga))
            {
                var t = (from s in db.AT_ListaPratiche_vw
                         where s.Targa.ToString() == myTarga
                         select s).FirstOrDefault();
                if (t.ID_SchedaTecnica == null)
                {

                    return RedirectToAction("Create", "Home", new
                    {
                        id = t.Perizie_ID,
                        dataperizia = DateTime.Now.ToString("dd/MM/yyyy"),
                        marca = t.Prod_Descr,
                        targa = t.Targa,
                        dataimmatricolazione = t.DataImmatricolazione,
                        km = t.Km,
                        luogoperizia = t.DescrITA,
                        modello = t.Mod_Descr,
                        cartacircolazione = t.CartaCircolazione,
                        matricola = t.Matricola,
                        telaio = t.Chassis1 + t.Chassis2,
                        dataultimarevisione = t.DataUltimaRevisione,
                        aziendautilizzatrice = t.DescrizioneAzienda
                    });
                }
                else
                {
                    return RedirectToAction("Create", "Home", new
                    {
                        id = t.Perizie_ID,
                        dataperizia = DateTime.Now.ToString("dd/MM/yyyy"),
                        marca = t.Prod_Descr,
                        targa = t.Targa,
                        dataimmatricolazione = t.DataImmatricolazione,
                        km = t.Km,
                        luogoperizia = t.DescrITA,
                        modello = t.Mod_Descr,
                        cartacircolazione = t.CartaCircolazione,
                        matricola = t.Matricola,
                        telaio = t.Chassis1 + t.Chassis2,
                        dataultimarevisione = t.DataUltimaRevisione,
                        aziendautilizzatrice = t.DescrizioneAzienda
                    });
                }
            }
            else
            {
                var t = (from s in db.AT_ListaPratiche_vw
                         where s.Matricola.ToString() == myMatricola
                         select s).FirstOrDefault();
                if (t.ID_SchedaTecnica == null)
                {

                    return RedirectToAction("Create", "Home", new
                    {
                        id = t.Perizie_ID,
                        dataperizia = DateTime.Now.ToString("dd/MM/yyyy"),
                        marca = t.Prod_Descr,
                        targa = t.Targa,
                        dataimmatricolazione = t.DataImmatricolazione,
                        km = t.Km,
                        luogoperizia = t.DescrITA,
                        modello = t.Mod_Descr,
                        cartacircolazione = t.CartaCircolazione,
                        matricola = t.Matricola,
                        telaio = t.Chassis1 + t.Chassis2,
                        dataultimarevisione = t.DataUltimaRevisione,
                        aziendautilizzatrice = t.DescrizioneAzienda
                    });
                }
                else
                {
                    return RedirectToAction("Create", "Home", new
                    {
                        id = t.Perizie_ID,
                        dataperizia = DateTime.Now.ToString("dd/MM/yyyy"),
                        marca = t.Prod_Descr,
                        targa = t.Targa,
                        dataimmatricolazione = t.DataImmatricolazione,
                        km = t.Km,
                        luogoperizia = t.DescrITA,
                        modello = t.Mod_Descr,
                        cartacircolazione = t.CartaCircolazione,
                        matricola = t.Matricola,
                        telaio = t.Chassis1 + t.Chassis2,
                        dataultimarevisione = t.DataUltimaRevisione,
                        aziendautilizzatrice = t.DescrizioneAzienda
                    });
                }
            }








            //return RedirectToAction("Index", "Telaio", new { MessaggioQuery = ViewBag.Message });

        }


        public int CheckTarga(string aTarga, string aMatricola, string aIDLuogo, out string aMessage)
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
                    using (AUTOSDUEntities val = new AUTOSDUEntities())
                    {
                        string myZone = Session["Zona"].ToString();
                        string myPerito = Session["IDPErito"].ToString();

                        var cnt = (from s in db.LuoghiTest_vw
                                   where s.IDPErito.ToString() == myPerito
                                   where s.ID == aIDLuogo.ToString()
                                   select s).ToList();
                        var fromDatabaseEF = new SelectList(cnt, "ID", "DescrITA");
                        ViewData["Luoghi"] = fromDatabaseEF;

                    }
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
                                   where s.ID == aIDLuogo.ToString()
                                   select s).ToList();
                        var fromDatabaseEF = new SelectList(cnt, "ID", "DescrITA");
                        ViewData["Luoghi"] = fromDatabaseEF;

                    }

                    return 3;
                }
                bool HasDifferentLocationExisting = EsisteConLocationDifferenteExisting(aTarga);
                if (HasDifferentLocationExisting)
                {
                    aMessage = "Mezzo già ispezionato c/o altro deposito !";

                    using (AUTOSDUEntities val = new AUTOSDUEntities())
                    {
                        string myZone = Session["Zona"].ToString();
                        string myPerito = Session["IDPErito"].ToString();

                        var cnt = (from s in db.LuoghiTest_vw
                                   where s.IDPErito.ToString() == myPerito
                                   where s.ID == aIDLuogo.ToString()
                                   select s).ToList();
                        var fromDatabaseEF = new SelectList(cnt, "ID", "DescrITA");
                        ViewData["Luoghi"] = fromDatabaseEF;

                    }


                    return 5;
                }
                bool HasDifferentLocationExistingIS6 = EsisteConLocationDifferenteExistingIS6(aTarga);
                if (HasDifferentLocationExistingIS6)
                {
                    aMessage = "Mezzo visto assente c/o altro deposito !";

                    using (AUTOSDUEntities val = new AUTOSDUEntities())
                    {
                        string myZone = Session["Zona"].ToString();
                        string myPerito = Session["IDPErito"].ToString();

                        var cnt = (from s in db.LuoghiTest_vw
                                   where s.IDPErito.ToString() == myPerito
                                   where s.ID == aIDLuogo.ToString()
                                   select s).ToList();
                        var fromDatabaseEF = new SelectList(cnt, "ID", "DescrITA");
                        ViewData["Luoghi"] = fromDatabaseEF;
                    }

                    return 7;
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

        public int CheckMatricola(string aTarga, string aMatricola, string aIDLuogo, out string aMessage)
        {
            aMessage = "";
            

            // Prima verifico se esite pratica CON perizia
            bool MatricolaEPeriziaEsistente = EsiteMatricolaConPerizia(aMatricola);
            if (!MatricolaEPeriziaEsistente)
            {

                // Poi verifico se esiste pratica SENZA perizia
                bool TargaSenzaPeriziaEsistente = EsiteMatricolaSenzaPerizia(aTarga);
                if (!TargaSenzaPeriziaEsistente)
                {
                    aMessage = "Matricola inesistente in anagrafica";
                    using (AUTOSDUEntities val = new AUTOSDUEntities())
                    {
                        string myZone = Session["Zona"].ToString();
                        string myPerito = Session["IDPErito"].ToString();

                        var cnt = (from s in db.LuoghiTest_vw
                                   where s.IDPErito.ToString() == myPerito
                                   where s.ID == aIDLuogo.ToString()
                                   select s).ToList();
                        var fromDatabaseEF = new SelectList(cnt, "ID", "DescrITA");
                        ViewData["Luoghi"] = fromDatabaseEF;

                    }
                    return 6;
                }
                else
                {
                    aMessage = "Matricola  SENZA PERIZIA ";
                    return 2;
                }
            }
            else
            {
                // Verifico se esiste targa e perizia assegnata a zona differente..
                bool HasDifferentLocation = EsisteMatricolaConLocationDifferente(aMatricola);
                if (HasDifferentLocation)
                {
                    aMessage = "Matricola esistente con location differente";

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
                bool HasDifferentLocationExisting = EsisteMatricolaConLocationDifferenteExisting(aTarga);
                if (HasDifferentLocationExisting)
                {
                    aMessage = "Targa esistente con scheda già associata";



                    return 5;
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
                       where ( s.ID_SchedaTecnica == null )
                       select s.Perizie_ID).Count();
            if (cnt > 0)
                return true;
            else
                return false;
        }

        public bool EsisteConLocationDifferenteExisting(string aTarga)
        {
            string myZone = Session["Zona"].ToString();
            string myPerito = Session["User"].ToString();
            var cnt = (from s in db.AT_ListaPratiche_vw
                       where s.Targa.ToString() == aTarga
                       where (s.ID_SchedaTecnica != null && s.IDVisualizzazioneMezzo != 6 )
                       select s.Perizie_ID).Count();
            if (cnt > 0)
                return true;
            else
                return false;
        }

        public bool EsisteConLocationDifferenteExistingIS6(string aTarga)
        {
            string myZone = Session["Zona"].ToString();
            string myPerito = Session["User"].ToString();
            var cnt = (from s in db.AT_ListaPratiche_vw
                       where s.Targa.ToString() == aTarga
                       where (s.ID_SchedaTecnica != null && s.IDVisualizzazioneMezzo == 6)
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




        public bool EsisteMatricolaConLocationDifferente(string aMatricola)
        {
            string myZone = Session["Zona"].ToString();
            string myPerito = Session["User"].ToString();
            var cnt = (from s in db.AT_ListaPratiche_vw
                       where s.Matricola.ToString() == aMatricola
                       where s.ID_SchedaTecnica == null
                       select s.Perizie_ID).Count();
            if (cnt > 0)
                return true;
            else
                return false;
        }

        public bool EsisteMatricolaConLocationDifferenteExisting(string aMatricola)
        {
            string myZone = Session["Zona"].ToString();
            string myPerito = Session["User"].ToString();
            var cnt = (from s in db.AT_ListaPratiche_vw
                       where s.Matricola.ToString() == aMatricola
                       where s.ID_SchedaTecnica != null
                       select s.Perizie_ID).Count();
            if (cnt > 0)
                return true;
            else
                return false;
        }

        public bool EsiteMatricolaConPerizia(string aMatricola)
        {
            var cnt = (from s in db.AT_ListaPratiche_vw
                       where s.Matricola.ToString() == aMatricola
                       select s.Perizie_ID).Count();
            if (cnt > 0)
                return true;
            else
                return false;
        }



        // TODO : sostituire targa con matricola
        public bool EsiteMatricolaSenzaPerizia(string aMatricola)
        {
            var cnt = (from s in db.AT_ListaPraticheSenzaPerizia_vw
                       where s.Targa.ToString() == aMatricola
                       select s.ID).Count();
            if (cnt > 0)
                return true;
            else
                return false;
        }

    }

   
}