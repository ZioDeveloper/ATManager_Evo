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
    public class HomeController : Controller
    {


        private AUTOSDUEntities db = new AUTOSDUEntities();

        //public ActionResult Index(string usr, string Opt1, string CercaTarga, string SearchLocation, string CercaMatricola)
        //{

        //    if (usr != null)
        //        Session["User"] = usr;
        //    if (usr == null)
        //        usr = Session["User"].ToString();


        //    ViewBag.perito = Session["User"].ToString();

        //    var myZone = (from s in db.AT_PeritiXZone
        //                  where s.UserName.ToString() == "percossi"
        //                  select s.ID_zona).FirstOrDefault();

        //    var myNome = (from s in db.AT_PeritiXZone
        //                  where s.UserName.ToString() == "percossi"
        //                  select s.Nome).FirstOrDefault();

        //    var myCognome = (from s in db.AT_PeritiXZone
        //                     where s.UserName.ToString() == "percossi"
        //                     select s.Cognome).FirstOrDefault();

        //    var myIDPErito = (from s in db.AT_PeritiXZone
        //                      where s.UserName.ToString() == "percossi"
        //                      select s.ID_Perito).FirstOrDefault();

        //    ViewBag.nome = myNome;
        //    ViewBag.cognome = myCognome;

        //    Session["Zona"] = myZone;
        //    Session["IDPErito"] = myIDPErito;

        //    bool isAuth = false;

        //    if (usr != String.Empty)
        //    {
        //        string UserName = "";

        //        string cookieName = FormsAuthentication.FormsCookieName; //Find cookie name
        //        HttpCookie cookie = HttpContext.Request.Cookies[cookieName]; //Get the cookie by it's name
        //        FormsAuthenticationTicket ticket = FormsAuthentication.Decrypt(cookie.Value); //Decrypt it
        //        UserName = ticket.Name; //You have the UserName!


        //        if (usr == UserName)
        //        {
        //            ViewBag.Messaggio = "BENE il cookie corrisponde!";
        //            //ViewBag.Messaggio = personaggio;
        //            isAuth = true;
        //            using (AUTOSDUEntities val = new AUTOSDUEntities())
        //            {
        //                Session["Status"] = "";

        //                var fromDatabaseEF = new SelectList(val.Luoghi_vw.ToList(), "ID", "DescrITA");
        //                ViewData["Luoghi"] = fromDatabaseEF;


        //            }

        //            if (String.IsNullOrEmpty(CercaTarga))
        //            {
        //                if (String.IsNullOrEmpty(CercaMatricola))
        //                {
        //                    return View();
        //                }
        //                else
        //                {
        //                    var model = new Models.HomeModel();
        //                    var telai = from s in db.AT_ListaPratiche_vw
        //                                where s.Matricola.ToString() == CercaMatricola
        //                                where s.Trilettera == myZone
        //                                select s;
        //                    model.AT_ListaPratiche_vw = telai.ToList();
        //                    return View("ElencoTelai", model);
        //                }
        //            }
        //            else if (!String.IsNullOrEmpty(CercaTarga))
        //            {

        //                var model = new Models.HomeModel();
        //                var telai = from s in db.AT_ListaPratiche_vw
        //                            where s.Targa.ToString() == CercaTarga
        //                            where s.Trilettera == myZone
        //                            select s;
        //                model.AT_ListaPratiche_vw = telai.ToList();
        //                return View("ElencoTelai", model);
        //            }
        //            else
        //            {
        //                return View();
        //            }

        //            ////if (String.IsNullOrEmpty(CercaMatricola))
        //            ////{
        //            ////    return View();
        //            ////}
        //            ////else
        //            ////{
        //            ////    var model = new Models.HomeModel();
        //            ////    var telai = from s in db.AT_ListaPratiche_vw
        //            ////                where s.Matricola.ToString() == CercaMatricola
        //            ////                where s.Trilettera == myZone
        //            ////                select s;
        //            ////    model.AT_ListaPratiche_vw = telai.ToList();
        //            ////    return View("ElencoTelai", model);
        //            ////}


        //            ////if (String.IsNullOrEmpty(CercaTarga))
        //            ////{
        //            ////    return View();
        //            ////}
        //            ////else if (!String.IsNullOrEmpty(CercaTarga))
        //            ////{
        //            ////    string myZone2 = Session["Zona"].ToString();
        //            ////    var model = new Models.HomeModel();
        //            ////    var telai = from s in db.AT_ListaPratiche_vw
        //            ////                where s.Targa.ToString() == CercaTarga
        //            ////                where s.Trilettera == myZone
        //            ////                select s;
        //            ////    model.AT_ListaPratiche_vw = telai.ToList();
        //            ////    return View("ElencoTelai", model);
        //            ////}
        //            ////else
        //            ////{
        //            ////    return View();
        //            ////}
        //        }
        //        else
        //        {
        //            ViewBag.Messaggio = "il cookie contenente lo 'username' non corrisponde allo User della queryString!";
        //            isAuth = false;
        //            return View("IncorrectLogin");
        //        }

        //    }
        //    else
        //    {
        //        string UserName = "";

        //        string cookieName = FormsAuthentication.FormsCookieName; //Find cookie name
        //        HttpCookie cookie = HttpContext.Request.Cookies[cookieName]; //Get the cookie by it's name
        //        FormsAuthenticationTicket ticket = FormsAuthentication.Decrypt(cookie.Value); //Decrypt it
        //        UserName = ticket.Name; //You have the UserName!
        //    }
        //    return View();


        //}

        public ActionResult Index(string Opt1, string CercaTarga, string SearchLocation, string CercaMatricola)
        {
            Session["User"] = "percossi";
            ViewBag.perito = Session["User"].ToString();

            var myZone = (from s in db.AT_PeritiXZone
                          where s.UserName.ToString() == "percossi"
                          select s.ID_zona).FirstOrDefault();

            var myNome = (from s in db.AT_PeritiXZone
                          where s.UserName.ToString() == "percossi"
                          select s.Nome).FirstOrDefault();

            var myCognome = (from s in db.AT_PeritiXZone
                             where s.UserName.ToString() == "percossi"
                             select s.Cognome).FirstOrDefault();

            var myIDPErito = (from s in db.AT_PeritiXZone
                              where s.UserName.ToString() == "percossi"
                              select s.ID_Perito).FirstOrDefault();

            ViewBag.nome = myNome;
            ViewBag.cognome = myCognome;

            Session["Zona"] = myZone;
            Session["IDPErito"] = myIDPErito;

            using (AUTOSDUEntities val = new AUTOSDUEntities())
            {
                Session["Status"] = "";

                var fromDatabaseEF = new SelectList(val.Luoghi_vw.ToList(), "ID", "DescrITA");
                ViewData["Luoghi"] = fromDatabaseEF;


            }

            if (String.IsNullOrEmpty(CercaTarga))
            {
                if (String.IsNullOrEmpty(CercaMatricola))
                {
                    return View();
                }
                else
                {
                    var model = new Models.HomeModel();
                    var telai = from s in db.AT_ListaPratiche_vw
                                where s.Matricola.ToString() == CercaMatricola
                                where s.Trilettera == myZone
                                select s;
                    model.AT_ListaPratiche_vw = telai.ToList();
                    return View("ElencoTelai", model);
                }
            }
            else if (!String.IsNullOrEmpty(CercaTarga))
            {

                var model = new Models.HomeModel();
                var telai = from s in db.AT_ListaPratiche_vw
                            where s.Targa.ToString() == CercaTarga
                            where s.Trilettera == myZone
                            select s;
                model.AT_ListaPratiche_vw = telai.ToList();
                return View("ElencoTelai", model);
            }
            else
            {
                return View();
            }

            //return RedirectToAction("DoRefresh", "Home");
        }

        public ActionResult DoRefresh(string Opt1, string CercaTarga, string SearchLocation, string CercaMatricola)
        {

            //string UserName = "";

            //string cookieName = FormsAuthentication.FormsCookieName; //Find cookie name
            //HttpCookie cookie = HttpContext.Request.Cookies[cookieName]; //Get the cookie by it's name
            //FormsAuthenticationTicket ticket = FormsAuthentication.Decrypt(cookie.Value); //Decrypt it
            //UserName = ticket.Name; //You have the UserName!



            if (Opt1 != null)
                Session["Status"] = Opt1;
            else
                Opt1 = Session["Status"].ToString();

            using (AUTOSDUEntities val = new AUTOSDUEntities())
            {
                //Session["Scelta1"] = "";

                var fromDatabaseEF = new SelectList(val.Luoghi_vw.ToList(), "ID", "DescrITA");
                ViewData["Luoghi"] = fromDatabaseEF;


            }

           

            if (!String.IsNullOrEmpty(CercaMatricola))
            {
                string myZone = Session["Zona"].ToString();

                Session["TipoRicerca"] = "MONO";
                var IsInserted = (from s in db.AT_ListaPratiche_vw
                                  where s.Matricola.ToString() == CercaMatricola
                                  select s.Perizie_ID).Count();
                if (IsInserted > 0)
                {
                    try
                    {
                        var IsClosed = (from s in db.AT_ListaPratiche_vw
                                        where s.Matricola.ToString() == CercaMatricola
                                        where s.Trilettera == myZone
                                        select s.IsCompleted).FirstOrDefault();
                        if (IsClosed.Value == false)
                            Session["Status"] = "FATTE";
                        else
                            Session["Status"] = "FATTECHIUSE";
                    }
                    catch
                    {
                        Session["Status"] = "DA FARE";
                    }


                }
                else
                {
                    Session["Status"] = "DA FARE";
                }

                var model = new Models.HomeModel();
                var telai = from s in db.AT_ListaPratiche_vw
                            where s.Matricola.ToString() == CercaMatricola
                            where s.Trilettera == myZone
                            select s;
                model.AT_ListaPratiche_vw = telai.ToList();
                return View("ElencoTelai", model);
            }

            if (CercaTarga != null && CercaTarga != "")
            {
                string myZone = Session["Zona"].ToString();

                Session["TipoRicerca"] = "MONO";
                var IsInserted = (from s in db.AT_ListaPratiche_vw
                                  where s.Targa.ToString() == CercaTarga
                                  select s.Perizie_ID).Count();
                if (IsInserted > 0)
                {
                    try
                    {
                        var IsClosed = (from s in db.AT_ListaPratiche_vw
                                        where s.Targa.ToString() == CercaTarga
                                        where s.Trilettera == myZone
                                        select s.IsCompleted).FirstOrDefault();
                        if (IsClosed.Value == false)
                            Session["Status"] = "FATTE";
                        else
                            Session["Status"] = "FATTECHIUSE";
                    }
                    catch
                    {
                        Session["Status"] = "DA FARE";
                    }


                }
                else
                {
                    Session["Status"] = "DA FARE";
                }

                var model = new Models.HomeModel();
                var telai = from s in db.AT_ListaPratiche_vw
                            where s.Targa.ToString() == CercaTarga
                            where s.Trilettera == myZone
                            select s;
                model.AT_ListaPratiche_vw = telai.ToList();
                return View("ElencoTelai", model);
            }

            else if (Opt1 == "TUTTE")
            {
                string myZone = Session["Zona"].ToString();
                var model = new Models.HomeModel();
                var telai = from s in db.AT_ListaPratiche_vw
                            where s.Trilettera == myZone
                            select s;
                model.AT_ListaPratiche_vw = telai.ToList();
                return View("ElencoTelai", model);
            }

            else if (Opt1 == "DA FARE")
            {
                string myZone = Session["Zona"].ToString();
                var model = new Models.HomeModel();
                var telai = from s in db.AT_ListaPratiche_vw
                            where s.ID_SchedaTecnica == null
                            where s.Trilettera == myZone
                            select s;
                model.AT_ListaPratiche_vw = telai.ToList();
                return View("ElencoTelai", model);
            }
            else if (Opt1 == "FATTE")
            {
                string myZone = Session["Zona"].ToString();
                var model = new Models.HomeModel();
                var telai = from s in db.AT_ListaPratiche_vw
                            where s.ID_SchedaTecnica != null
                            where s.IsCompleted == false
                            where s.Trilettera == myZone
                            select s;
                model.AT_ListaPratiche_vw = telai.ToList();
                return View("ElencoTelai", model);
            }
            else if (Opt1 == "FATTECHIUSE")
            {
                string myZone = Session["Zona"].ToString();
                var model = new Models.HomeModel();
                var telai = from s in db.AT_ListaPratiche_vw
                            where s.ID_SchedaTecnica != null
                            where s.IsCompleted == true
                            where s.Trilettera == myZone
                            select s;
                model.AT_ListaPratiche_vw = telai.ToList();
                return View("ElencoTelai", model);
            }

            else
            {
                return View("Index");
            }
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Contatti.";

            return View();
        }

        public ActionResult RitornaPannelloUtente()
        {
            string myParams = "Username=" + User.Identity.Name + "&param=0&from=1";

            return Redirect("https://webservices.interconsult.it/applogin/Utente/UtentePanel?" + myParams);
        }


        public ActionResult Logout()
        {
            FormsAuthentication.SignOut();

            return Redirect("https://webservices.interconsult.it/applogin/");

        }

        //public ActionResult Edit(int ID)
        //{
        //    AT_SchedaTecnica telai = db.AT_SchedaTecnica.Find(ID);

        //    return View(telai);
        //}

        public ActionResult Create(string ID, string marca, string dataperizia, 
                                    string targa,string dataimmatricolazione,string km,
                                    string luogoperizia,string modello, string cartacircolazione,string matricola,string telaio,
                                    string dataultimarevisione, string aziendautilizzatrice)
        {

            if (ID == null)
                ID = TempData["IDPerizia"].ToString();
            else
                TempData["IDPerizia"] = ID;

            ViewBag.IDPerizia = ID;

            DateTime tmpDate = DateTime.Now;
            ViewBag.dataperizia = tmpDate.ToString("dd/MM/yyyy");

            ViewBag.marca = marca;
            ViewBag.targa = targa;

            if (!string.IsNullOrEmpty(dataimmatricolazione))
            {
                tmpDate = DateTime.ParseExact(dataimmatricolazione, "MM/dd/yyyy hh:mm:ss", null);
                ViewBag.dataimmatricolazione = tmpDate.ToString("dd/MM/yyyy");
            }
            else
            {
                ViewBag.dataimmatricolazione = dataimmatricolazione;
            }

            //tmpDate = DateTime.ParseExact(dataimmatricolazione, "MM/dd/yyyy hh:mm:ss", null);
            //ViewBag.dataimmatricolazione = tmpDate.ToString("dd/MM/yyyy");
            ViewBag.km = km;
            ViewBag.cartacircolazione = cartacircolazione;
            ViewBag.luogoperizia = luogoperizia;
            ViewBag.modello = modello;
            ViewBag.matricola = matricola;
            ViewBag.telaio = telaio;
            ViewBag.aziendautilizzatrice = aziendautilizzatrice;

            if (!string.IsNullOrEmpty(dataultimarevisione))
            {
                tmpDate = DateTime.ParseExact(dataultimarevisione, "MM/dd/yyyy hh:mm:ss", null);
                ViewBag.dataultimarevisione = tmpDate.ToString("dd/MM/yyyy"); 
            }
            else
            {
                ViewBag.dataultimarevisione = dataultimarevisione;
            }

            var myScheda = (from s in db.AT_ListaPratiche_vw
                              where s.Perizie_ID.ToString() == ID
                                select s.CartaCircolazione).FirstOrDefault();
            ViewBag.cartacircolazione = myScheda.ToString();

            

            ViewBag.IDTipoScheda = new SelectList(db.AT_TipiScheda, "ID", "Descr");
            ViewBag.IDStatoMezzo = new SelectList(db.AT_StatiMezzo, "ID", "Descr");
            ViewBag.IDPreventivoDanno = new SelectList(db.AT_PreventiviDanno, "ID", "Descr");

            return View();
        }

        public string CompileErrorMessage(string aFiled)
        {
            string myMessage = "Campo " + aFiled + ", selezionare un valore";

            return myMessage;
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "ID,IDPerizia,IDTipoScheda,IDStatoMezzo,IDPreventivoDanno,IsCompleted,CE110,CE112,CE115,CE840,CE841,CE842,CE843,CE816," +
                                                   "CE265,CE135,CE160,CE145,CE150,CI820,CI825,CI835,CI837,CI1135, " +
                                                   "NoteCE110,NoteCE112,NoteCE115,NoteCE840,NoteCE841,NoteCE842,NoteCE843,NoteCE816," +
                                                   "NoteCE265,NoteCE135,NoteCE160,NoteCE145,NoteCE150,NoteCI820,NoteCI825,NoteCI835,NoteCI837,NoteCI1135," +
                                                   "Note_danno, Note_generali")] AT_SchedaTecnica aT_SchedaTecnica,string txtdataultimarevisione,string txtTarga,string txtKm,
            string txtMatricola,string txtDataPerizia,string txtMarca, string txtDataImmatricolazione, string txtCartaCircolazione,
            string txtLuogoPerizia, string txtModello, string txtTelaio,string txtAziendaUtilizzatrice, FormCollection frmCreate)
        {

            

            if (aT_SchedaTecnica.CE110 == null && aT_SchedaTecnica.IsCompleted == true)
                ModelState.AddModelError("CE110", CompileErrorMessage("CE110"));

            if (aT_SchedaTecnica.CE112 == null && aT_SchedaTecnica.IsCompleted == true)
                ModelState.AddModelError("CE112", CompileErrorMessage("CE112"));

            if (aT_SchedaTecnica.CE115 == null && aT_SchedaTecnica.IsCompleted == true)
                ModelState.AddModelError("CE115", CompileErrorMessage("CE115"));

            if (aT_SchedaTecnica.CE840 == null && aT_SchedaTecnica.IsCompleted == true)
                ModelState.AddModelError("CE840", CompileErrorMessage("CE840"));

            if (aT_SchedaTecnica.CE841 == null && aT_SchedaTecnica.IsCompleted == true)
                ModelState.AddModelError("CE841", CompileErrorMessage("CE841"));

            if (aT_SchedaTecnica.CE842 == null && aT_SchedaTecnica.IsCompleted == true)
                ModelState.AddModelError("CE842", CompileErrorMessage("CE842"));

            if (aT_SchedaTecnica.CE843 == null && aT_SchedaTecnica.IsCompleted == true)
                ModelState.AddModelError("CE843", CompileErrorMessage("CE843"));

            if (aT_SchedaTecnica.CE816 == null && aT_SchedaTecnica.IsCompleted == true)
                ModelState.AddModelError("CE816", CompileErrorMessage("CE816"));

            if (aT_SchedaTecnica.CE265 == null && aT_SchedaTecnica.IsCompleted == true)
                ModelState.AddModelError("CE265", CompileErrorMessage("CE265"));

            if (aT_SchedaTecnica.CE135 == null && aT_SchedaTecnica.IsCompleted == true)
                ModelState.AddModelError("CE135", CompileErrorMessage("CE135"));

            if (aT_SchedaTecnica.CE160 == null && aT_SchedaTecnica.IsCompleted == true)
                ModelState.AddModelError("CE160", CompileErrorMessage("CE160"));

            if (aT_SchedaTecnica.CE145 == null && aT_SchedaTecnica.IsCompleted == true)
                ModelState.AddModelError("CE145", CompileErrorMessage("CE145"));

            if (aT_SchedaTecnica.CE150 == null && aT_SchedaTecnica.IsCompleted == true)
                ModelState.AddModelError("CE150", CompileErrorMessage("CE150"));

            if (aT_SchedaTecnica.CI820 == null && aT_SchedaTecnica.IsCompleted == true)
                ModelState.AddModelError("CI820", CompileErrorMessage("CI820"));

            if (aT_SchedaTecnica.CI825 == null && aT_SchedaTecnica.IsCompleted == true)
                ModelState.AddModelError("CI825", CompileErrorMessage("CI825"));

            if (aT_SchedaTecnica.CI835 == null && aT_SchedaTecnica.IsCompleted == true)
                ModelState.AddModelError("CI835", CompileErrorMessage("CI835"));

            if (aT_SchedaTecnica.CI837 == null && aT_SchedaTecnica.IsCompleted == true)
                ModelState.AddModelError("CI837", CompileErrorMessage("CI837"));

            if (aT_SchedaTecnica.CI1135 == null && aT_SchedaTecnica.IsCompleted == true)
                ModelState.AddModelError("CI1135", CompileErrorMessage("CI1135"));

            if (aT_SchedaTecnica.IDStatoMezzo == 2  && aT_SchedaTecnica.IDPreventivoDanno == 0 && aT_SchedaTecnica.IsCompleted == true)
                ModelState.AddModelError("IDStatoMezzo", "Valorizzazione mezzo obbligatoria.");

            if ((aT_SchedaTecnica.IDStatoMezzo == 2) && (string.IsNullOrEmpty(aT_SchedaTecnica.Note_danno)) && aT_SchedaTecnica.IsCompleted == true)
                ModelState.AddModelError("IDStatoMezzo", "Note valorizzazione mezzo obbligatorie.");

            var myPRatID = from s in db.AT_ListaPratiche_vw
                           where s.Perizie_ID == aT_SchedaTecnica.IDPerizia
                           select s.PRAT_ID;
            int myIDPrat = myPRatID.ToList().First();

            var myDocID = from s in db.SDU_documentiPratica
                          where s.ID_pratica == myIDPrat
                          where s.ID_tipoDocumento == 1
                          select s.ID;


            if ((String.IsNullOrEmpty(txtdataultimarevisione)) && (txtCartaCircolazione == "SI") && (aT_SchedaTecnica.IsCompleted == true))
            {
                ModelState.AddModelError("IDStatoMezzo", "Data ultima revisione obbligatoria");
            }

            // Verifica presenza foto in caso di ID Stato mezzo = 2

            var myNumFotoPerizia = (from s in db.SDU_DocumentiPerizia
                                    where s.ID_Perizia == aT_SchedaTecnica.IDPerizia
                                    select s.ID).Count();

            if ((aT_SchedaTecnica.IDStatoMezzo == 2) && (myNumFotoPerizia == 0))
            {
                ModelState.AddModelError("IDStatoMezzo", "Foto mezzo obbligatorie per mezzi da ricontrollare fase 2 !");
            }

            if (ModelState.IsValid)
            {
               

                // Aggiorno Targa
                var mySchedaXTarga = from s in db.AT_ListaPratiche_vw
                               where s.Perizie_ID == aT_SchedaTecnica.IDPerizia
                                     select s.PRAT_ID;
                int myIDPratica = mySchedaXTarga.ToList().First();

                var sqlTarga = @" UPDATE SDU_Pratiche SET Targa = @Targa WHERE ID = @IDPratica AND 0=0 ";
                var mySchedaTarga = from s in db.AT_ListaPratiche_vw
                                    where s.Perizie_ID == aT_SchedaTecnica.ID
                                    select s.Perizie_ID;
                int myIDeriziaTarga = mySchedaTarga.FirstOrDefault();
                int noOfRowInsertedTarga = db.Database.ExecuteSqlCommand(sqlTarga,
                        new SqlParameter("@IDPratica", myIDPratica),
                        new SqlParameter("@Targa", txtTarga));

                // Aggiorno KM
                var sqlKm = @" UPDATE SDU_PERIZIE SET Km = @Km, DataPerizia = @DataPerizia WHERE ID = @ID_perizia AND 0=0 ";
                var mySchedaKm = from s in db.AT_ListaPratiche_vw
                               where s.Perizie_ID == aT_SchedaTecnica.ID
                               select s.Perizie_ID;
                int myIDeriziaKm = mySchedaKm.FirstOrDefault();
                int noOfRowInsertedKm = db.Database.ExecuteSqlCommand(sqlKm,
                        new SqlParameter("@ID_perizia", myIDeriziaKm),
                        new SqlParameter("@Km", txtKm),
                        new SqlParameter("@DataPerizia", DateTime.Now));


                // Aggiorno ultimo status
                if (aT_SchedaTecnica.IsCompleted == true)
                {
                    var mySchedaStatus = from s in db.AT_ListaPratiche_vw
                                         where s.Perizie_ID == aT_SchedaTecnica.ID
                                         select s.Perizie_ID;
                    int myIDeriziaStatus = mySchedaStatus.FirstOrDefault();

                    //string myDataUltimaRevisione = txtdataultimarevisione.Substring(6, 4) + txtdataultimarevisione.Substring(0, 2) + txtdataultimarevisione.Substring(3, 2);

                    var p1 = new SqlParameter("@login", Session["User"]);
                    var p2 = new SqlParameter("@ID_perizia", myIDeriziaStatus);
                    var p3 = new SqlParameter("@ID_Stato", "00H");
                    var p4 = new SqlParameter("@DataStato", DateTime.Now);
                    var p5 = new SqlParameter("@Note", "");
                    
                    int noOfRowInserted = db.Database.ExecuteSqlCommand("EXEC sp_InsertStatus {0}, {1}, {2}, {3} , {4}", p1.Value, p2.Value, p3.Value, p4.Value , p5.Value);

                    // Aggiorno IDPerito Scheda
                    string myIDPerito = Session["IDPErito"].ToString();

                    var sqlperito = @" UPDATE SDU_PERIZIE SET ID_Perito = @ID_Perito WHERE ID = @ID_perizia AND 0=0 ";
                    var mySchedaperito = from s in db.AT_ListaPratiche_vw
                                     where s.Perizie_ID == aT_SchedaTecnica.ID
                                     select s.Perizie_ID;
                    int myIDeriziaperito = mySchedaperito.FirstOrDefault();
                    int noOfRowInsertedperito = db.Database.ExecuteSqlCommand(sqlperito,
                            new SqlParameter("@ID_perizia", myIDeriziaperito),
                            new SqlParameter("@ID_Perito", myIDPerito));

                    // Aggiorno IDPerito Pratica
                    var sqllink = @" UPDATE SDU_Link_Pratica_Periti_Incarico SET IDPerito = @IDPerito WHERE ID = @ID_perizia AND 0=0 ";
                    
                    int noOfRowInsertedlink = db.Database.ExecuteSqlCommand(sqllink,
                            new SqlParameter("@ID_perizia", myIDeriziaperito),
                            new SqlParameter("@IDPerito", myIDPerito));


                }

                // Aggiorno Data ultima revisione
                var sql = @" UPDATE SDU_PERIZIE SET DataPubblicazionePerizia = @DataPubblicazionePerizia WHERE ID = @ID_perizia AND 0=0 ";
                var myScheda = from s in db.AT_ListaPratiche_vw
                               where s.Perizie_ID == aT_SchedaTecnica.ID
                               select s.Perizie_ID;
                int myIDerizia = myScheda.FirstOrDefault();

                if (!String.IsNullOrEmpty(txtdataultimarevisione))
                {
                    //string myDataUltimaRevisione = txtdataultimarevisione.Substring(6, 4) + txtdataultimarevisione.Substring(3, 2) + txtdataultimarevisione.Substring(0, 2);
                    DateTime tmpDate = DateTime.ParseExact(txtdataultimarevisione, "dd/MM/yyyy", null);

                    int noOfRowInserted = db.Database.ExecuteSqlCommand(sql,
                        new SqlParameter("@ID_perizia", myIDerizia),
                        new SqlParameter("@DataPubblicazionePerizia", tmpDate));
                }
                else
                {
                    int noOfRowInserted = db.Database.ExecuteSqlCommand(sql,
                        new SqlParameter("@ID_perizia", myIDerizia),
                        new SqlParameter("@DataPubblicazionePerizia", DBNull.Value));
                }

                // Se cancello foto scheda id 1 , ovvero carta di circolazione...
                if (txtCartaCircolazione.ToUpper() == "NO")
                {
                    var sqlCC = @" UPDATE SDU_PERIZIE SET DataPubblicazionePerizia = @DataPubblicazionePerizia WHERE ID = @IDPerizia AND 0=0 ";
                    var mySchedaCC = from s in db.AT_ListaPratiche_vw
                                     where s.Perizie_ID == aT_SchedaTecnica.ID
                                     select s.Perizie_ID;
                    int myIDeriziaCC = mySchedaCC.FirstOrDefault();
                    int noOfRowInsertedCC = db.Database.ExecuteSqlCommand(sqlCC,
                            new SqlParameter("@IDPerizia", myIDeriziaCC),
                            new SqlParameter("@DataPubblicazionePerizia", DBNull.Value));
                }




                db.AT_SchedaTecnica.Add(aT_SchedaTecnica);
                db.SaveChanges();

                /*
                // Test
                ViewBag.IDTipoScheda = new SelectList(db.AT_TipiScheda, "ID", "Descr", aT_SchedaTecnica.AT_TipiScheda);
                ViewBag.IDStatoMezzo = new SelectList(db.AT_StatiMezzo, "ID", "Descr", aT_SchedaTecnica.AT_StatiMezzo);
                ViewBag.IDPreventivoDanno = new SelectList(db.AT_PreventiviDanno, "ID", "Descr", aT_SchedaTecnica.AT_PreventiviDanno);
                ViewBag.km = txtKm;
                ViewBag.matricola = txtMatricola;
                ViewBag.dataperizia = txtDataPerizia;
                ViewBag.marca = txtMarca;
                ViewBag.dataimmatricolazione = txtDataImmatricolazione;
                ViewBag.cartacircolazione = txtCartaCircolazione;
                ViewBag.luogoperizia = txtLuogoPerizia;
                ViewBag.modello = txtModello;
                ViewBag.telaio = txtTelaio;
                ViewBag.aziendautilizzatrice = txtAziendaUtilizzatrice;
                ViewBag.IDPErizia = aT_SchedaTecnica.IDPerizia.ToString();
                return View(aT_SchedaTecnica);*/

                //return RedirectToAction("Edit", "Home", new
                //{
                //    myIDerizia,
                //    txtMarca,
                //    a = DateTime.Now.ToString("dd/MM/yyyy"),
                //    txtTarga,
                //    txtDataImmatricolazione,
                //    txtKm,
                //    txtLuogoPerizia,
                //    txtModello,
                //    txtCartaCircolazione,
                //    txtMatricola,
                //    txtTelaio,
                //    txtdataultimarevisione,
                //    b = "NO",
                //    txtAziendaUtilizzatrice
                    
                //});
                

                // END Test

                return RedirectToAction("DoRefresh", "Home");
            }

            ViewBag.IDTipoScheda = new SelectList(db.AT_TipiScheda, "ID", "Descr",aT_SchedaTecnica.AT_TipiScheda);
            ViewBag.IDStatoMezzo = new SelectList(db.AT_StatiMezzo, "ID", "Descr", aT_SchedaTecnica.AT_StatiMezzo);
            ViewBag.IDPreventivoDanno = new SelectList(db.AT_PreventiviDanno, "ID", "Descr", aT_SchedaTecnica.AT_PreventiviDanno);
            ViewBag.km = txtKm;
            ViewBag.matricola = txtMatricola;
            ViewBag.dataperizia = txtDataPerizia;
            ViewBag.marca = txtMarca;
            ViewBag.dataimmatricolazione = txtDataImmatricolazione;
            ViewBag.cartacircolazione = txtCartaCircolazione;
            ViewBag.luogoperizia = txtLuogoPerizia;
            ViewBag.modello = txtModello;
            ViewBag.telaio = txtTelaio;
            ViewBag.aziendautilizzatrice = txtAziendaUtilizzatrice;
            ViewBag.IDPErizia = aT_SchedaTecnica.IDPerizia.ToString();


            return View(aT_SchedaTecnica);
        }

        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var model = new Models.AT_ListaPratiche_vw();
            var myScheda = from s in db.AT_ListaPratiche_vw
                        where s.Perizie_ID == id
                           select s.Targa;
            model.Targa = myScheda.ToList().First();
            return View(model);
        }

        // POST: AT_SchedaTecnica/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            var sql = @"DELETE FROM  AT_SchedaTecnica WHERE IDPerizia = @IDPErizia";
            int myDeleted = db.Database.ExecuteSqlCommand(sql,  new SqlParameter("@IDPErizia", id));

            sql = @"DELETE FROM  SDU_DocumentiPerizia WHERE ID_Perizia = @IDPErizia";
            int myDeletedDocPErizia = db.Database.ExecuteSqlCommand(sql, new SqlParameter("@IDPErizia", id));


            var model = new Models.AT_ListaPratiche_vw();
            var myScheda = from s in db.AT_ListaPratiche_vw
                           where s.Perizie_ID == id
                           select s.PRAT_ID.ToString();
           string myID = myScheda.ToList().First();

            sql = @"DELETE FROM  SDU_documentiPratica WHERE ID_Pratica = @IDPratica";
            int myDeletedDocPratica = db.Database.ExecuteSqlCommand(sql, new SqlParameter("@IDPratica", myID));


            //AT_SchedaTecnica aT_SchedaTecnica = db.AT_SchedaTecnica.Find(id);
            //db.AT_SchedaTecnica.Remove(aT_SchedaTecnica);
            //db.SaveChanges();
            return RedirectToAction("DoRefresh");
        }

        public ActionResult Edit(string id, string marca, string dataperizia,
                                    string targa, string dataimmatricolazione, string km,
                                    string luogoperizia, string modello, string cartacircolazione, string matricola, string telaio, 
                                    string dataultimarevisione, string blocked, string aziendautilizzatrice)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            var model = new Models.AT_SchedaTecnica();
            var myScheda = from s in db.AT_SchedaTecnica
                           where s.IDPerizia.ToString() == id
                           select s;
            model = myScheda.ToList().First();

            ViewBag.IDPerizia = id;

            //DateTime tmpDate = DateTime.ParseExact(dataperizia, "dd/MM/yyyy hh:mm:ss", null);
            //ViewBag.dataperizia = tmpDate.ToString("dd/MM/yyyy");

            DateTime tmpDate = DateTime.Now;
            ViewBag.dataperizia = tmpDate.ToString("dd/MM/yyyy");

            ViewBag.marca = marca;
            ViewBag.targa = targa;

            if (!string.IsNullOrEmpty(dataimmatricolazione))
            {
                tmpDate = DateTime.ParseExact(dataimmatricolazione, "MM/dd/yyyy hh:mm:ss", null);
                ViewBag.dataimmatricolazione = tmpDate.ToString("dd/MM/yyyy");
            }
            else
            {
                ViewBag.dataimmatricolazione = dataimmatricolazione;
            }

            ViewBag.km = km;
            ViewBag.cartacircolazione = cartacircolazione;
            ViewBag.luogoperizia = luogoperizia;
            ViewBag.modello = modello;
            ViewBag.matricola = matricola;
            ViewBag.telaio = telaio;
            ViewBag.aziendautilizzatrice = aziendautilizzatrice;

            
            ViewBag.cartacircolazione = myScheda.ToString();

            var mySchedacc = (from s in db.AT_ListaPratiche_vw
                            where s.Perizie_ID.ToString() == id
                            select s.CartaCircolazione).FirstOrDefault();
            ViewBag.cartacircolazione = mySchedacc.ToString();


            if (!string.IsNullOrEmpty(dataultimarevisione))
            {
                tmpDate = DateTime.ParseExact(dataultimarevisione, "MM/dd/yyyy hh:mm:ss", null);
                ViewBag.dataultimarevisione = tmpDate.ToString("dd/MM/yyyy"); 
            }
            else
            {
                ViewBag.dataultimarevisione = dataultimarevisione; }
            //return View(model);


            //AT_SchedaTecnica aT_SchedaTecnica = db.AT_SchedaTecnica.Find(id);
            //if (aT_SchedaTecnica == null)
            //{
            //    return HttpNotFound();
            //}
            ViewBag.myIDScheda = model.ID;
            TempData["myIDScheda"] = model.ID;
            ViewBag.IDStatoMezzo = new SelectList(db.AT_StatiMezzo, "ID", "Descr", model.IDStatoMezzo);
            ViewBag.IDTipoScheda = new SelectList(db.AT_TipiScheda, "ID", "Descr", model.IDTipoScheda);
            ViewBag.CE110 = new SelectList(db.AT_IndiciValutazione, "ID", "Descr", model.CE110);
            ViewBag.CE112 = new SelectList(db.AT_IndiciValutazione, "ID", "Descr", model.CE112);
            ViewBag.CE115 = new SelectList(db.AT_IndiciValutazione, "ID", "Descr", model.CE115);
            //ViewBag.CE125 = new SelectList(db.AT_IndiciValutazione, "ID", "Descr", model.CE125);
            ViewBag.CE135 = new SelectList(db.AT_IndiciValutazione, "ID", "Descr", model.CE135);
            ViewBag.CE145 = new SelectList(db.AT_IndiciValutazione, "ID", "Descr", model.CE145);
            ViewBag.CE150 = new SelectList(db.AT_IndiciValutazione, "ID", "Descr", model.CE150);
            ViewBag.CE160 = new SelectList(db.AT_IndiciValutazione, "ID", "Descr", model.CE160);
            //ViewBag.CE170 = new SelectList(db.AT_IndiciValutazione, "ID", "Descr", model.CE170);
            ViewBag.CE265 = new SelectList(db.AT_IndiciValutazione, "ID", "Descr", model.CE265);
            //ViewBag.CE415 = new SelectList(db.AT_IndiciValutazione, "ID", "Descr", model.CE415);
            ViewBag.CE816 = new SelectList(db.AT_IndiciValutazione, "ID", "Descr", model.CE816);
            ViewBag.CE840 = new SelectList(db.AT_IndiciValutazione, "ID", "Descr", model.CE840);
            ViewBag.CE841 = new SelectList(db.AT_IndiciValutazione, "ID", "Descr", model.CE841);
            ViewBag.CE842 = new SelectList(db.AT_IndiciValutazione, "ID", "Descr", model.CE842);
            ViewBag.CE843 = new SelectList(db.AT_IndiciValutazione, "ID", "Descr", model.CE843);
            //ViewBag.CE844 = new SelectList(db.AT_IndiciValutazione, "ID", "Descr", model.CE844);
            //ViewBag.CE960 = new SelectList(db.AT_IndiciValutazione, "ID", "Descr", model.CE960);
            //ViewBag.CI820 = new SelectList(db.AT_IndiciValutazione, "ID", "Descr", model.CI820);
            ViewBag.CI825 = new SelectList(db.AT_IndiciValutazione, "ID", "Descr", model.CI825);
            ViewBag.CI835 = new SelectList(db.AT_IndiciValutazione, "ID", "Descr", model.CI835);
            ViewBag.CI837 = new SelectList(db.AT_IndiciValutazione, "ID", "Descr", model.CI837);
            //ViewBag.CI843 = new SelectList(db.AT_IndiciValutazione, "ID", "Descr", model.CI843);
            //ViewBag.CI910 = new SelectList(db.AT_IndiciValutazione, "ID", "Descr", model.CI910);
            //ViewBag.CI930 = new SelectList(db.AT_IndiciValutazione, "ID", "Descr", model.CI930);
            //ViewBag.CS240 = new SelectList(db.AT_IndiciValutazione, "ID", "Descr", model.CS240);
            //ViewBag.CS510 = new SelectList(db.AT_IndiciValutazione, "ID", "Descr", model.CS510);
            //ViewBag.CS511 = new SelectList(db.AT_IndiciValutazione, "ID", "Descr", model.CS511);
            //ViewBag.CS710 = new SelectList(db.AT_IndiciValutazione, "ID", "Descr", model.CS710);
            //ViewBag.CS715 = new SelectList(db.AT_IndiciValutazione, "ID", "Descr", model.CS715);
            //ViewBag.CS810 = new SelectList(db.AT_IndiciValutazione, "ID", "Descr", model.CS810);
            //ViewBag.CS815 = new SelectList(db.AT_IndiciValutazione, "ID", "Descr", model.CS815);
            //ViewBag.PS165 = new SelectList(db.AT_IndiciValutazione, "ID", "Descr", model.PS165);
            //ViewBag.PS225 = new SelectList(db.AT_IndiciValutazione, "ID", "Descr", model.PS225);
            //ViewBag.PS230 = new SelectList(db.AT_IndiciValutazione, "ID", "Descr", model.PS230);
            //ViewBag.PS235 = new SelectList(db.AT_IndiciValutazione, "ID", "Descr", model.PS235);
            //ViewBag.PS250 = new SelectList(db.AT_IndiciValutazione, "ID", "Descr", model.PS250);
            //ViewBag.PS260 = new SelectList(db.AT_IndiciValutazione, "ID", "Descr", model.PS260);
            //ViewBag.PS512 = new SelectList(db.AT_IndiciValutazione, "ID", "Descr", model.PS512);
            //ViewBag.PS610 = new SelectList(db.AT_IndiciValutazione, "ID", "Descr", model.PS610);
            //ViewBag.CE420 = new SelectList(db.AT_IndiciValutazione, "ID", "Descr", model.CE420);
            //ViewBag.PS410 = new SelectList(db.AT_IndiciValutazione, "ID", "Descr", model.PS410);
            ViewBag.CI1135 = new SelectList(db.AT_IndiciValutazione, "ID", "Descr", model.CI1135);
            ViewBag.IDPreventivoDanno = new SelectList(db.AT_PreventiviDanno, "ID", "Descr", model.IDPreventivoDanno);
            ViewBag.NoteCE110 = model.NoteCE110;
            return View(model);
        }

        // POST: AT_SchedaTecnica/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see https://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "ID,IDPerizia,IDTipoScheda,IDStatoMezzo,IDPreventivoDanno,IsCompleted,CE110,CE112,CE115,CE840,CE841,CE842,CE843,CE816," +
                                                   "CE265,CE135,CE160,CE145,CE150,CI820,CI825,CI835,CI837,CI1135, " +
                                                   "NoteCE110,NoteCE112,NoteCE115,NoteCE840,NoteCE841,NoteCE842,NoteCE843,NoteCE816," +
                                                   "NoteCE265,NoteCE135,NoteCE160,NoteCE145,NoteCE150,NoteCI820,NoteCI825,NoteCI835,NoteCI837,NoteCI1135," +
                                                   "Note_danno, Note_generali")] AT_SchedaTecnica aT_SchedaTecnica, string txtdataultimarevisione, string txtTarga, string txtKm,
            string txtMatricola, string txtDataPerizia, string txtMarca, string txtDataImmatricolazione, string txtCartaCircolazione,
            string txtLuogoPerizia, string txtModello, string txtTelaio, string txtAziendaUtilizzatrice)
        {


            int myID = 0;
            myID = (int)TempData["myIDScheda"];
           



            if (aT_SchedaTecnica.CE110 == null && aT_SchedaTecnica.IsCompleted == true)
                ModelState.AddModelError("CE110", CompileErrorMessage("CE110"));

            if (aT_SchedaTecnica.CE112 == null && aT_SchedaTecnica.IsCompleted == true)
                ModelState.AddModelError("CE112", CompileErrorMessage("CE112"));

            if (aT_SchedaTecnica.CE115 == null && aT_SchedaTecnica.IsCompleted == true)
                ModelState.AddModelError("CE115", CompileErrorMessage("CE115"));

            if (aT_SchedaTecnica.CE840 == null && aT_SchedaTecnica.IsCompleted == true)
                ModelState.AddModelError("CE840", CompileErrorMessage("CE840"));

            if (aT_SchedaTecnica.CE841 == null && aT_SchedaTecnica.IsCompleted == true)
                ModelState.AddModelError("CE841", CompileErrorMessage("CE841"));

            if (aT_SchedaTecnica.CE842 == null && aT_SchedaTecnica.IsCompleted == true)
                ModelState.AddModelError("CE842", CompileErrorMessage("CE842"));

            if (aT_SchedaTecnica.CE843 == null && aT_SchedaTecnica.IsCompleted == true)
                ModelState.AddModelError("CE843", CompileErrorMessage("CE843"));

            if (aT_SchedaTecnica.CE816 == null && aT_SchedaTecnica.IsCompleted == true)
                ModelState.AddModelError("CE816", CompileErrorMessage("CE816"));

            if (aT_SchedaTecnica.CE265 == null && aT_SchedaTecnica.IsCompleted == true)
                ModelState.AddModelError("CE265", CompileErrorMessage("CE265"));

            if (aT_SchedaTecnica.CE135 == null && aT_SchedaTecnica.IsCompleted == true)
                ModelState.AddModelError("CE135", CompileErrorMessage("CE135"));

            if (aT_SchedaTecnica.CE160 == null && aT_SchedaTecnica.IsCompleted == true)
                ModelState.AddModelError("CE160", CompileErrorMessage("CE160"));

            if (aT_SchedaTecnica.CE145 == null && aT_SchedaTecnica.IsCompleted == true)
                ModelState.AddModelError("CE145", CompileErrorMessage("CE145"));

            if (aT_SchedaTecnica.CE150 == null && aT_SchedaTecnica.IsCompleted == true)
                ModelState.AddModelError("CE150", CompileErrorMessage("CE150"));

            if (aT_SchedaTecnica.CI820 == null && aT_SchedaTecnica.IsCompleted == true)
                ModelState.AddModelError("CI820", CompileErrorMessage("CI820"));

            if (aT_SchedaTecnica.CI825 == null && aT_SchedaTecnica.IsCompleted == true)
                ModelState.AddModelError("CI825", CompileErrorMessage("CI825"));

            if (aT_SchedaTecnica.CI835 == null && aT_SchedaTecnica.IsCompleted == true)
                ModelState.AddModelError("CI835", CompileErrorMessage("CI835"));

            if (aT_SchedaTecnica.CI837 == null && aT_SchedaTecnica.IsCompleted == true)
                ModelState.AddModelError("CI837", CompileErrorMessage("CI837"));

            if (aT_SchedaTecnica.CI1135 == null && aT_SchedaTecnica.IsCompleted == true)
                ModelState.AddModelError("CI1135", CompileErrorMessage("CI1135"));

            
            if (aT_SchedaTecnica.IDStatoMezzo == 2 && aT_SchedaTecnica.IDPreventivoDanno == 0 && aT_SchedaTecnica.IsCompleted == true)
                ModelState.AddModelError("IDStatoMezzo", "Valorizzazione mezzo obbligatoria.");

            if ((aT_SchedaTecnica.IDStatoMezzo == 2) && (string.IsNullOrEmpty(aT_SchedaTecnica.Note_danno)) && aT_SchedaTecnica.IsCompleted == true)
                ModelState.AddModelError("IDStatoMezzo", "Note valorizzazione mezzo obbligatorie.");

            var myPRatID = from s in db.AT_ListaPratiche_vw
                           where s.Perizie_ID == aT_SchedaTecnica.IDPerizia
                           select s.PRAT_ID;
            int myIDPrat = myPRatID.ToList().First();

            var myDocID = from s in db.SDU_documentiPratica
                           where s.ID_pratica == myIDPrat
                           where s.ID_tipoDocumento == 1
                           select s.ID;

            // Verifica presenza foto in caso di ID Stato mezzo = 2

            var myNumFotoPerizia = (from s in db.SDU_DocumentiPerizia
                                   where s.ID_Perizia == aT_SchedaTecnica.IDPerizia
                                   select s.ID).Count();

            if ((aT_SchedaTecnica.IDStatoMezzo == 2) && (myNumFotoPerizia == 0))
            {
                ModelState.AddModelError("IDStatoMezzo", "Foto mezzo obbligatorie per mezzi da ricontrollare fase 2 !");
            }
                           
            //int myIDPrat = myPRatID.ToList().First();

            //if ( (String.IsNullOrEmpty(txtdataultimarevisione)) && (!String.IsNullOrEmpty(myDocID.FirstOrDefault().ToString()) && (aT_SchedaTecnica.IsCompleted == true)))
            if ( (String.IsNullOrEmpty(txtdataultimarevisione)) && (txtCartaCircolazione == "SI") && (aT_SchedaTecnica.IsCompleted == true) )
            {
                ModelState.AddModelError("IDStatoMezzo", "Data ultima revisione obbligatoria");
            }

            if (ModelState.IsValid)
            {

                // Aggiorno Targa
                var myScheda = from s in db.AT_ListaPratiche_vw
                               where s.Perizie_ID == aT_SchedaTecnica.IDPerizia
                               select s.PRAT_ID;
                int myIDPratica = myScheda.ToList().First();

                var sqlTarga = @" UPDATE SDU_Pratiche SET Targa = @Targa WHERE ID = @IDPratica AND 0=0 ";
                var mySchedaTarga = from s in db.AT_ListaPratiche_vw
                                    where s.Perizie_ID == aT_SchedaTecnica.ID
                                    select s.Perizie_ID;
                int myIDeriziaTarga = mySchedaTarga.FirstOrDefault();
                int noOfRowInsertedTarga = db.Database.ExecuteSqlCommand(sqlTarga,
                        new SqlParameter("@IDPratica", myIDPratica),
                        new SqlParameter("@Targa", txtTarga));


                // Aggiorno KM
                var sqlKm = @" UPDATE SDU_PERIZIE SET Km = @Km, DataPerizia = @DataPerizia WHERE ID = @ID_perizia AND 0=0 ";
                var mySchedaKm = from s in db.AT_ListaPratiche_vw
                                 where s.Perizie_ID == aT_SchedaTecnica.ID
                                 select s.Perizie_ID;
                int myIDeriziaKm = mySchedaKm.FirstOrDefault();
                int noOfRowInsertedKm = db.Database.ExecuteSqlCommand(sqlKm,
                        new SqlParameter("@ID_perizia", myIDeriziaKm),
                        new SqlParameter("@Km", txtKm),
                        new SqlParameter("@DataPerizia", DateTime.Now));


                // Aggiorno ultimo status
                if (aT_SchedaTecnica.IsCompleted == true)
                {

                    // Aggiorno IDPerito Scheda
                    string myIDPerito = Session["IDPErito"].ToString();

                    var sqlperito = @" UPDATE SDU_PERIZIE SET ID_Perito = @ID_Perito WHERE ID = @ID_perizia AND 0=0 ";
                    var mySchedaperito = from s in db.AT_ListaPratiche_vw
                                         where s.Perizie_ID == aT_SchedaTecnica.ID
                                         select s.Perizie_ID;
                    int myIDeriziaperito = mySchedaperito.FirstOrDefault();
                    int noOfRowInsertedperito = db.Database.ExecuteSqlCommand(sqlperito,
                            new SqlParameter("@ID_perizia", myIDeriziaperito),
                            new SqlParameter("@ID_Perito", myIDPerito));

                    // Aggiorno IDPerito Pratica
                    var sqllink = @" UPDATE SDU_Link_Pratica_Periti_Incarico SET IDPerito = @IDPerito WHERE ID_perizia = @ID_perizia AND 0=0 ";

                    int noOfRowInsertedlink = db.Database.ExecuteSqlCommand(sqllink,
                            new SqlParameter("@ID_perizia", myIDeriziaperito),
                            new SqlParameter("@IDPerito", myIDPerito));

                    var mySchedaStatus = from s in db.AT_ListaPratiche_vw
                                         where s.Perizie_ID == aT_SchedaTecnica.ID
                                         select s.Perizie_ID;
                    int myIDeriziaStatus = mySchedaStatus.FirstOrDefault();

                    //string myDataUltimaRevisione = txtdataultimarevisione.Substring(6, 4) + txtdataultimarevisione.Substring(0, 2) + txtdataultimarevisione.Substring(3, 2);

                    var p1 = new SqlParameter("@login", Session["User"]);
                    var p2 = new SqlParameter("@ID_perizia", myIDeriziaStatus);
                    var p3 = new SqlParameter("@ID_Stato", "00H");
                    var p4 = new SqlParameter("@DataStato", DateTime.Now);
                    var p5 = new SqlParameter("@Note", "");

                    int noOfRowInserted = db.Database.ExecuteSqlCommand("EXEC sp_InsertStatus {0}, {1}, {2}, {3} , {4}", p1.Value, p2.Value, p3.Value, p4.Value, p5.Value);


                }

                //Aggiorno Data ultima revisione
                var sql = @" UPDATE SDU_PERIZIE SET DataPubblicazionePerizia = @DataPubblicazionePerizia WHERE ID = @ID_perizia AND 0=0 ";
                var mySchedaRev = from s in db.AT_ListaPratiche_vw
                               where s.Perizie_ID == aT_SchedaTecnica.ID
                               select s.Perizie_ID;
                int myIDerizia = mySchedaRev.FirstOrDefault();

                if (!String.IsNullOrEmpty(txtdataultimarevisione))
                {
                    DateTime tmpDate = DateTime.ParseExact(txtdataultimarevisione, "dd/MM/yyyy", null);

                    int noOfRowInserted = db.Database.ExecuteSqlCommand(sql,
                        new SqlParameter("@ID_perizia", myIDerizia),
                        new SqlParameter("@DataPubblicazionePerizia", tmpDate));
                }
                else
                {
                    int noOfRowInserted = db.Database.ExecuteSqlCommand(sql,
                        new SqlParameter("@ID_perizia", myIDerizia),
                        new SqlParameter("@DataPubblicazionePerizia", DBNull.Value));
                }


                // Se cancello foto scheda id 1 , ovvero carta di circolazione...
                if (txtCartaCircolazione.ToUpper() == "NO")
                {
                    var sqlCC = @" UPDATE SDU_PERIZIE SET DataPubblicazionePerizia = @DataPubblicazionePerizia WHERE ID = @IDPerizia AND 0=0 ";
                    var mySchedaCC = from s in db.AT_ListaPratiche_vw
                                     where s.Perizie_ID == aT_SchedaTecnica.ID
                                     select s.Perizie_ID;
                    int myIDeriziaCC = mySchedaCC.FirstOrDefault();
                    int noOfRowInsertedCC = db.Database.ExecuteSqlCommand(sqlCC,
                            new SqlParameter("@IDPerizia", myIDeriziaCC),
                            new SqlParameter("@DataPubblicazionePerizia", DBNull.Value));
                }


                aT_SchedaTecnica.ID = myID;// model.ID;
                TempData["myIDScheda"] = myID;
                db.Entry(aT_SchedaTecnica).State = EntityState.Modified;
                
                db.SaveChanges();
                //return RedirectToAction("Index");
                
               // Test
                ViewBag.IDTipoScheda = new SelectList(db.AT_TipiScheda, "ID", "Descr", aT_SchedaTecnica.AT_TipiScheda);
                ViewBag.IDStatoMezzo = new SelectList(db.AT_StatiMezzo, "ID", "Descr", aT_SchedaTecnica.AT_StatiMezzo);
                ViewBag.IDPreventivoDanno = new SelectList(db.AT_PreventiviDanno, "ID", "Descr", aT_SchedaTecnica.AT_PreventiviDanno);
                ViewBag.km = txtKm;
                ViewBag.matricola = txtMatricola;
                ViewBag.dataperizia = txtDataPerizia;
                ViewBag.marca = txtMarca;
                ViewBag.dataimmatricolazione = txtDataImmatricolazione;
                ViewBag.cartacircolazione = txtCartaCircolazione;
                ViewBag.luogoperizia = txtLuogoPerizia;
                ViewBag.modello = txtModello;
                ViewBag.telaio = txtTelaio;
                ViewBag.aziendautilizzatrice = txtAziendaUtilizzatrice;
                ViewBag.IDPErizia = aT_SchedaTecnica.IDPerizia.ToString();
                return View(aT_SchedaTecnica); 
                // END Test
                //return RedirectToAction("DoRefresh", "Home");
            }
            ViewBag.IDStatoMezzo = new SelectList(db.AT_StatiMezzo, "ID", "Descr", aT_SchedaTecnica.IDStatoMezzo);
            ViewBag.IDTipoScheda = new SelectList(db.AT_TipiScheda, "ID", "Descr", aT_SchedaTecnica.IDTipoScheda);
            ViewBag.CE110 = new SelectList(db.AT_IndiciValutazione, "ID", "Descr", aT_SchedaTecnica.CE110);
            ViewBag.CE112 = new SelectList(db.AT_IndiciValutazione, "ID", "Descr", aT_SchedaTecnica.CE112);
            ViewBag.CE115 = new SelectList(db.AT_IndiciValutazione, "ID", "Descr", aT_SchedaTecnica.CE115);
            //ViewBag.CE125 = new SelectList(db.AT_IndiciValutazione, "ID", "Descr", aT_SchedaTecnica.CE125);
            ViewBag.CE135 = new SelectList(db.AT_IndiciValutazione, "ID", "Descr", aT_SchedaTecnica.CE135);
            ViewBag.CE145 = new SelectList(db.AT_IndiciValutazione, "ID", "Descr", aT_SchedaTecnica.CE145);
            ViewBag.CE150 = new SelectList(db.AT_IndiciValutazione, "ID", "Descr", aT_SchedaTecnica.CE150);
            ViewBag.CE160 = new SelectList(db.AT_IndiciValutazione, "ID", "Descr", aT_SchedaTecnica.CE160);
            //ViewBag.CE170 = new SelectList(db.AT_IndiciValutazione, "ID", "Descr", aT_SchedaTecnica.CE170);
            ViewBag.CE265 = new SelectList(db.AT_IndiciValutazione, "ID", "Descr", aT_SchedaTecnica.CE265);
            //ViewBag.CE415 = new SelectList(db.AT_IndiciValutazione, "ID", "Descr", aT_SchedaTecnica.CE415);
            ViewBag.CE816 = new SelectList(db.AT_IndiciValutazione, "ID", "Descr", aT_SchedaTecnica.CE816);
            ViewBag.CE840 = new SelectList(db.AT_IndiciValutazione, "ID", "Descr", aT_SchedaTecnica.CE840);
            ViewBag.CE841 = new SelectList(db.AT_IndiciValutazione, "ID", "Descr", aT_SchedaTecnica.CE841);
            ViewBag.CE842 = new SelectList(db.AT_IndiciValutazione, "ID", "Descr", aT_SchedaTecnica.CE842);
            ViewBag.CE843 = new SelectList(db.AT_IndiciValutazione, "ID", "Descr", aT_SchedaTecnica.CE843);
            //ViewBag.CE844 = new SelectList(db.AT_IndiciValutazione, "ID", "Descr", aT_SchedaTecnica.CE844);
            //ViewBag.CE960 = new SelectList(db.AT_IndiciValutazione, "ID", "Descr", aT_SchedaTecnica.CE960);
            ViewBag.CI820 = new SelectList(db.AT_IndiciValutazione, "ID", "Descr", aT_SchedaTecnica.CI820);
            ViewBag.CI825 = new SelectList(db.AT_IndiciValutazione, "ID", "Descr", aT_SchedaTecnica.CI825);
            ViewBag.CI835 = new SelectList(db.AT_IndiciValutazione, "ID", "Descr", aT_SchedaTecnica.CI835);
            ViewBag.CI837 = new SelectList(db.AT_IndiciValutazione, "ID", "Descr", aT_SchedaTecnica.CI837);
            //ViewBag.CI843 = new SelectList(db.AT_IndiciValutazione, "ID", "Descr", aT_SchedaTecnica.CI843);
            //ViewBag.CI910 = new SelectList(db.AT_IndiciValutazione, "ID", "Descr", aT_SchedaTecnica.CI910);
            //ViewBag.CI930 = new SelectList(db.AT_IndiciValutazione, "ID", "Descr", aT_SchedaTecnica.CI930);
            //ViewBag.CS240 = new SelectList(db.AT_IndiciValutazione, "ID", "Descr", aT_SchedaTecnica.CS240);
            //ViewBag.CS510 = new SelectList(db.AT_IndiciValutazione, "ID", "Descr", aT_SchedaTecnica.CS510);
            //ViewBag.CS511 = new SelectList(db.AT_IndiciValutazione, "ID", "Descr", aT_SchedaTecnica.CS511);
            //ViewBag.CS710 = new SelectList(db.AT_IndiciValutazione, "ID", "Descr", aT_SchedaTecnica.CS710);
            //ViewBag.CS715 = new SelectList(db.AT_IndiciValutazione, "ID", "Descr", aT_SchedaTecnica.CS715);
            //ViewBag.CS810 = new SelectList(db.AT_IndiciValutazione, "ID", "Descr", aT_SchedaTecnica.CS810);
            //ViewBag.CS815 = new SelectList(db.AT_IndiciValutazione, "ID", "Descr", aT_SchedaTecnica.CS815);
            //ViewBag.PS165 = new SelectList(db.AT_IndiciValutazione, "ID", "Descr", aT_SchedaTecnica.PS165);
            //ViewBag.PS225 = new SelectList(db.AT_IndiciValutazione, "ID", "Descr", aT_SchedaTecnica.PS225);
            //ViewBag.PS230 = new SelectList(db.AT_IndiciValutazione, "ID", "Descr", aT_SchedaTecnica.PS230);
            //ViewBag.PS235 = new SelectList(db.AT_IndiciValutazione, "ID", "Descr", aT_SchedaTecnica.PS235);
            //ViewBag.PS250 = new SelectList(db.AT_IndiciValutazione, "ID", "Descr", aT_SchedaTecnica.PS250);
            //ViewBag.PS260 = new SelectList(db.AT_IndiciValutazione, "ID", "Descr", aT_SchedaTecnica.PS260);
            //ViewBag.PS512 = new SelectList(db.AT_IndiciValutazione, "ID", "Descr", aT_SchedaTecnica.PS512);
            //ViewBag.PS610 = new SelectList(db.AT_IndiciValutazione, "ID", "Descr", aT_SchedaTecnica.PS610);
            //ViewBag.CE420 = new SelectList(db.AT_IndiciValutazione, "ID", "Descr", aT_SchedaTecnica.CE420);
            //ViewBag.PS410 = new SelectList(db.AT_IndiciValutazione, "ID", "Descr", aT_SchedaTecnica.PS410);
            ViewBag.CI1135 = new SelectList(db.AT_IndiciValutazione, "ID", "Descr", aT_SchedaTecnica.CI1135);
            ViewBag.NoteCE110 = new SelectList(db.AT_IndiciValutazione, "ID", "Descr", aT_SchedaTecnica.NoteCE110);
            ViewBag.IDPreventivoDanno = new SelectList(db.AT_PreventiviDanno, "ID", "Descr", aT_SchedaTecnica.IDPreventivoDanno);
            TempData["myIDScheda"] = myID ;

            ViewBag.km = txtKm;
            ViewBag.matricola = txtMatricola;
            ViewBag.dataperizia = txtDataPerizia;
            ViewBag.marca = txtMarca;
            ViewBag.dataimmatricolazione = txtDataImmatricolazione;
            ViewBag.cartacircolazione = txtCartaCircolazione;
            ViewBag.luogoperizia = txtLuogoPerizia;
            ViewBag.modello = txtModello;
            ViewBag.telaio = txtTelaio;
            ViewBag.aziendautilizzatrice = txtAziendaUtilizzatrice;
            ViewBag.IDPerizia = aT_SchedaTecnica.IDPerizia.ToString();



            return View(aT_SchedaTecnica);
        }

        public ActionResult FotoPerizia(int? ID)
        {
            if (ID == null)
                ID = (int)TempData["myIDPerizia"];

            var model = new Models.HomeModel();
            var telai = from s in db.AT_ListaPratiche_vw
                        where s.Perizie_ID.ToString() == ID.ToString()
                        select s;
            model.AT_ListaPratiche_vw = telai.ToList();
            ViewBag.targa = telai.FirstOrDefault().Targa;
            ViewBag.marca = telai.FirstOrDefault().Prod_Descr;
            ViewBag.dataimmatricolazione = telai.FirstOrDefault().DataImmatricolazione;
            ViewBag.km = telai.FirstOrDefault().Km;
            ViewBag.luogoperizia = telai.FirstOrDefault().DescrITA;
            ViewBag.modello = telai.FirstOrDefault().Mod_Descr;
            ViewBag.cartacircolazione = telai.FirstOrDefault().CartaCircolazione;
            ViewBag.matricola = telai.FirstOrDefault().Matricola;

            ViewBag.telaio = telai.FirstOrDefault().Chassis1 + telai.FirstOrDefault().Chassis2;
            ViewBag.dataultimarevisione = telai.FirstOrDefault().DataUltimaRevisione;
            ViewBag.aziendautilizzatrice = telai.FirstOrDefault().DescrizioneAzienda;

            ViewBag.IDPerizia = ID;
            TempData["myIDPerizia"] = ID;
            return View();
        }

        public ActionResult FotoPeriziaEdit(int? ID)
        {
            int myIDPerizia = 0;
            if (TempData["myIDPerizia"] != null)
                myIDPerizia = (int)TempData["myIDPerizia"];

            var model = new Models.HomeModel();
            var telai = from s in db.AT_ListaPratiche_vw
                        where s.Perizie_ID.ToString() == ID.ToString()
                        select s;
            model.AT_ListaPratiche_vw = telai.ToList();
            ViewBag.targa = telai.FirstOrDefault().Targa;
            ViewBag.marca = telai.FirstOrDefault().Prod_Descr;
            ViewBag.dataimmatricolazione = telai.FirstOrDefault().DataImmatricolazione;
            ViewBag.km = telai.FirstOrDefault().Km;
            ViewBag.luogoperizia = telai.FirstOrDefault().DescrITA;
            ViewBag.modello = telai.FirstOrDefault().Mod_Descr;
            ViewBag.cartacircolazione = telai.FirstOrDefault().CartaCircolazione;
            ViewBag.matricola = telai.FirstOrDefault().Matricola;

            ViewBag.telaio = telai.FirstOrDefault().Chassis1 + telai.FirstOrDefault().Chassis2;
            ViewBag.dataultimarevisione = telai.FirstOrDefault().DataUltimaRevisione;
            ViewBag.aziendautilizzatrice = telai.FirstOrDefault().DescrizioneAzienda;
            ViewBag.blocked = "NO";
            ViewBag.IDPerizia = ID;
            return View();
        }

        public ActionResult FotoPratica(int? ID)
        {

            var model = new Models.HomeModel();
            var telai = from s in db.AT_ListaPratiche_vw
                        where s.Perizie_ID.ToString() == ID.ToString()
                        select s;
            model.AT_ListaPratiche_vw = telai.ToList();

            ViewBag.SDU_DocTipi = new SelectList(db.SDU_documentiTipi, "ID", "descrizioneDocumento");
            ViewBag.IDPerizia = ID;
            ViewBag.targa = telai.FirstOrDefault().Targa;
            ViewBag.marca = telai.FirstOrDefault().Prod_Descr;
            ViewBag.dataimmatricolazione = telai.FirstOrDefault().DataImmatricolazione;
            ViewBag.km = telai.FirstOrDefault().Km;
            ViewBag.luogoperizia = telai.FirstOrDefault().DescrITA;
            ViewBag.modello = telai.FirstOrDefault().Mod_Descr;
            ViewBag.cartacircolazione = telai.FirstOrDefault().CartaCircolazione;
            ViewBag.matricola = telai.FirstOrDefault().Matricola;

            ViewBag.telaio = telai.FirstOrDefault().Chassis1 + telai.FirstOrDefault().Chassis2;
            ViewBag.dataultimarevisione = telai.FirstOrDefault().DataUltimaRevisione;
            ViewBag.aziendautilizzatrice = telai.FirstOrDefault().DescrizioneAzienda;
            return View();
        }

        public ActionResult FotoPraticaEdit(int? ID)
        {

            var model = new Models.HomeModel();
            var telai = from s in db.AT_ListaPratiche_vw
                        where s.Perizie_ID.ToString() == ID.ToString()
                        select s;
            model.AT_ListaPratiche_vw = telai.ToList();

            ViewBag.SDU_DocTipi = new SelectList(db.SDU_documentiTipi, "ID", "descrizioneDocumento");
            ViewBag.IDPerizia = ID;
            ViewBag.targa = telai.FirstOrDefault().Targa;
            ViewBag.marca = telai.FirstOrDefault().Prod_Descr;
            ViewBag.dataimmatricolazione = telai.FirstOrDefault().DataImmatricolazione;
            ViewBag.km = telai.FirstOrDefault().Km;
            ViewBag.luogoperizia = telai.FirstOrDefault().DescrITA;
            ViewBag.modello = telai.FirstOrDefault().Mod_Descr;
            ViewBag.cartacircolazione = telai.FirstOrDefault().CartaCircolazione;
            ViewBag.matricola = telai.FirstOrDefault().Matricola;

            ViewBag.telaio = telai.FirstOrDefault().Chassis1 + telai.FirstOrDefault().Chassis2;
            ViewBag.dataultimarevisione = telai.FirstOrDefault().DataUltimaRevisione;
            ViewBag.aziendautilizzatrice = telai.FirstOrDefault().DescrizioneAzienda;
            ViewBag.blocked = "NO";
            return View();
        }



        public ActionResult UploadFotoPerizia(IEnumerable<HttpPostedFileBase> files, int? ID ,string marca, string targa, string dataimmatricolazione, string km,
                                              string luogoperizia, string modello, string cartacircolazione, string matricola, string telaio ,
                                              string dataultimarevisione, string aziendautilizzatrice)
        {


            int myIDPerizia = (int)TempData["myIDPerizia"];

            string path = "";
            //var model = new Models.AT_ListaPratiche_vw();
            var myScheda = from s in db.AT_ListaPratiche_vw
                           where s.Perizie_ID == ID
                           select s.Perizie_Barcode; 
            string myBarcode = myScheda.ToList().First();
            
            var myScheda2 = from s in db.AT_ListaPratiche_vw
                           where s.Perizie_ID == ID
                           select s.Targa;
            string myTarga = myScheda2.ToList().First();


            string myDate = DateTime.Now.Year.ToString("0000") + 
                            DateTime.Now.Month.ToString("00") + 
                            DateTime.Now.Day.ToString("00") + 
                            DateTime.Now.Hour.ToString("00") + 
                            DateTime.Now.Minute.ToString("00") + 
                            DateTime.Now.Second.ToString("00");

            //string fullPath = Request.MapPath("~/UploadedFiles/" + picName);

            foreach (var file in files)
            {
                try
                {
                    int fileCount = (from filecnt in Directory.EnumerateFiles(Request.MapPath(@"~\FotoPerizia"), myBarcode + "*.*", SearchOption.AllDirectories)
                                     select file).Count();

                    path = System.IO.Path.Combine(Request.MapPath(@"~\FotoPerizia"), myBarcode + "_" +
                                                                            myTarga + "_" +
                                                                            fileCount.ToString("000") + "_" +
                                                                            System.IO.Path.GetExtension(file.FileName));
                    if (file != null)
                    {
                        file.SaveAs(path);
                    }

                    string myFileName = Path.GetFileName(path);
                    var sql = @"INSERT INTO SDU_DocumentiPerizia (ID_Perizia, percorsoFile) Values (@ID_Perizia, @percorsoFile)";
                    int noOfRowInserted = db.Database.ExecuteSqlCommand(sql,
                        new SqlParameter("@ID_Perizia", ID),
                        new SqlParameter("@percorsoFile", myFileName));

                }
                catch { }

            }

            var model = new Models.HomeModel();
                var telai = from s in db.AT_ListaPratiche_vw
                        where s.Perizie_ID == ID
                        select s;
            model.AT_ListaPratiche_vw = telai.ToList();

            TempData["myIDPerizia"] = myIDPerizia;

            return RedirectToAction("Create", "Home", new
            {
                ID,
                marca,
                targa,
                km,
                luogoperizia,
                modello,
                cartacircolazione,
                matricola,
                telaio,
                dataultimarevisione,
                aziendautilizzatrice
            });


                                                          
        }

        public ActionResult UploadFotoPeriziaEdit(IEnumerable<HttpPostedFileBase> files, int? ID, string marca, string targa, string dataimmatricolazione, string km,
                                              string luogoperizia, string modello, string cartacircolazione, string matricola, string telaio,
                                              string dataultimarevisione, string aziendautilizzatrice, string blocked)
        {



            string path = "";
            //var model = new Models.AT_ListaPratiche_vw();
            var myScheda = from s in db.AT_ListaPratiche_vw
                           where s.Perizie_ID == ID
                           select s.Perizie_Barcode;
            string myBarcode = myScheda.ToList().First();

            var myScheda2 = from s in db.AT_ListaPratiche_vw
                            where s.Perizie_ID == ID
                            select s.Targa;
            string myTarga = myScheda2.ToList().First();


            string myDate = DateTime.Now.Year.ToString("0000") +
                            DateTime.Now.Month.ToString("00") +
                            DateTime.Now.Day.ToString("00") +
                            DateTime.Now.Hour.ToString("00") +
                            DateTime.Now.Minute.ToString("00") +
                            DateTime.Now.Second.ToString("00");

            //string fullPath = Request.MapPath("~/UploadedFiles/" + picName);

           

            foreach (var file in files)
            {
                try
                {
                    int fileCount = (from filecnt in Directory.EnumerateFiles(Request.MapPath(@"~\FotoPerizia"), myBarcode + "*.*", SearchOption.AllDirectories)
                                     select file).Count();

                    path = System.IO.Path.Combine(Request.MapPath(@"~\FotoPerizia"), myBarcode + "_" +
                                                                            myTarga + "_" +
                                                                            fileCount.ToString("000") + "_" +
                                                                            System.IO.Path.GetExtension(file.FileName));
                    if (file != null)
                    {
                        file.SaveAs(path);
                    }

                    string myFileName = Path.GetFileName(path);
                    var sql = @"INSERT INTO SDU_DocumentiPerizia (ID_Perizia, percorsoFile) Values (@ID_Perizia, @percorsoFile)";
                    int noOfRowInserted = db.Database.ExecuteSqlCommand(sql,
                        new SqlParameter("@ID_Perizia", ID),
                        new SqlParameter("@percorsoFile", myFileName));
                }
                catch {
                    //return View("FotoPeriziaEdit", new { ID });
                }

            }

            var model = new Models.HomeModel();
            var telai = from s in db.AT_ListaPratiche_vw
                        where s.Perizie_ID == ID
                        select s;
            model.AT_ListaPratiche_vw = telai.ToList();

            return RedirectToAction("Edit", "Home", new
            {
                ID,
                marca,
                targa,
                km,
                luogoperizia,
                modello,
                cartacircolazione,
                matricola,
                telaio,
                dataultimarevisione,
                aziendautilizzatrice,
                blocked
            });



        }

        public ActionResult UploadFotoPratica(IEnumerable<HttpPostedFileBase> files, int? ID , FormCollection form,  string marca, string targa, string dataimmatricolazione, string km,
                                              string luogoperizia, string modello, string cartacircolazione, string matricola, string telaio,
                                              string dataultimarevisione, string aziendautilizzatrice)
        {

            string path = "";
            string myIDTipoDoc = form["SDU_DocTipi"].ToString();

            var model = new Models.AT_ListaPratiche_vw();
            var myScheda = from s in db.AT_ListaPratiche_vw
                           where s.Perizie_ID == ID
                           select s.PRAT_ID; 
            int IDPratica = myScheda.ToList().First();
            string myDate = DateTime.Now.Year.ToString("0000") + 
                            DateTime.Now.Month.ToString("00") + 
                            DateTime.Now.Day.ToString("00") + 
                            DateTime.Now.Hour.ToString("00") + 
                            DateTime.Now.Minute.ToString("00") + 
                            DateTime.Now.Second.ToString("00");

            foreach (var file in files)
            {
                try
                {
                    int fileCount = (from filecnt in Directory.EnumerateFiles(Request.MapPath(@"~\FotoPratica"), IDPratica + "*.*", SearchOption.AllDirectories)
                                     select file).Count();
                    fileCount++;

                    path = System.IO.Path.Combine(Request.MapPath(@"~\FotoPratica"), IDPratica + "_" +
                                                                            myDate + "_" +
                                                                            fileCount.ToString("000") + "_" +
                                                                            myIDTipoDoc +
                                                                            System.IO.Path.GetExtension(file.FileName));



                    if (file != null)
                    {
                        file.SaveAs(path);
                    }

                    string myFileName = Path.GetFileName(path);


                    var sql = @"INSERT INTO SDU_documentiPratica (ID_pratica, ID_tipoDocumento,percorsoFile) Values (@ID_pratica, 
                                                                                                                 @ID_tipoDocumento, 
                                                                                                                 @percorsoFile)";
                    int noOfRowInserted = db.Database.ExecuteSqlCommand(sql,
                        new SqlParameter("@ID_pratica", IDPratica),
                        new SqlParameter("@ID_tipoDocumento", myIDTipoDoc),
                        new SqlParameter("@percorsoFile", myFileName));
                }
                catch
                { }
            }


            return RedirectToAction("Create", "Home", new
            {
                ID,
                marca,
                targa,
                km,
                luogoperizia,
                modello,
                cartacircolazione,
                matricola,
                telaio,
                dataultimarevisione,
                aziendautilizzatrice
            });
            //return RedirectToAction("DoRefresh", "Home");
        }

        public ActionResult UploadFotoPraticaEdit(IEnumerable<HttpPostedFileBase> files, int? ID, FormCollection form, string marca, string targa, string dataimmatricolazione, string km,
                                              string luogoperizia, string modello, string cartacircolazione, string matricola, string telaio,
                                              string dataultimarevisione, string aziendautilizzatrice,string blocked)
        {

            string path = "";
            string myIDTipoDoc = form["SDU_DocTipi"].ToString();

            var model = new Models.AT_ListaPratiche_vw();
            var myScheda = from s in db.AT_ListaPratiche_vw
                           where s.Perizie_ID == ID
                           select s.PRAT_ID;
            int IDPratica = myScheda.ToList().First();
            string myDate = DateTime.Now.Year.ToString("0000") +
                            DateTime.Now.Month.ToString("00") +
                            DateTime.Now.Day.ToString("00") +
                            DateTime.Now.Hour.ToString("00") +
                            DateTime.Now.Minute.ToString("00") +
                            DateTime.Now.Second.ToString("00");

            foreach (var file in files)
            {
                try
                {
                    int fileCount = (from filecnt in Directory.EnumerateFiles(Request.MapPath(@"~\FotoPratica"), IDPratica + "*.*", SearchOption.AllDirectories)
                                     select file).Count();
                    fileCount++;

                    path = System.IO.Path.Combine(Request.MapPath(@"~\FotoPratica"), IDPratica + "_" +
                                                                            myDate + "_" +
                                                                            fileCount.ToString("000") + "_" +
                                                                            myIDTipoDoc +
                                                                            System.IO.Path.GetExtension(file.FileName));



                    if (file != null)
                    {
                        file.SaveAs(path);
                    }

                    string myFileName = Path.GetFileName(path);

                    var sql = @"INSERT INTO SDU_documentiPratica (ID_pratica, ID_tipoDocumento,percorsoFile) Values (@ID_pratica, 
                                                                                                                 @ID_tipoDocumento, 
                                                                                                                 @percorsoFile)";
                    int noOfRowInserted = db.Database.ExecuteSqlCommand(sql,
                        new SqlParameter("@ID_pratica", IDPratica),
                        new SqlParameter("@ID_tipoDocumento", myIDTipoDoc),
                        new SqlParameter("@percorsoFile", myFileName));
                }
                catch
                {

                }

            }


            return RedirectToAction("Edit", "Home", new
            {
                ID,
                marca,
                targa,
                km,
                luogoperizia,
                modello,
                cartacircolazione,
                matricola,
                telaio,
                dataultimarevisione,
                aziendautilizzatrice,
                blocked
            });
            //return RedirectToAction("DoRefresh", "Home");
        }

        public ActionResult PerizieImages(int? ID)
        {
            var model = new Models.HomeModel();
            int myIDTelaio = 0;
            if (TempData["myIDTelaio"] != null)
                myIDTelaio = (int)TempData["myIDTelaio"];
            else
                myIDTelaio = (int)ID;

            var model1 = new Models.HomeModel();
            var telai = from s in db.AT_ListaPratiche_vw
                        where s.Perizie_ID.ToString() == ID.ToString()
                        select s;
            model1.AT_ListaPratiche_vw = telai.ToList();
            ViewBag.targa = telai.FirstOrDefault().Targa;
            ViewBag.marca = telai.FirstOrDefault().Prod_Descr;
            ViewBag.dataimmatricolazione = telai.FirstOrDefault().DataImmatricolazione;
            ViewBag.km = telai.FirstOrDefault().Km;
            ViewBag.luogoperizia = telai.FirstOrDefault().DescrITA;
            ViewBag.modello = telai.FirstOrDefault().Mod_Descr;
            ViewBag.cartacircolazione = telai.FirstOrDefault().CartaCircolazione;
            ViewBag.matricola = telai.FirstOrDefault().Matricola;

            ViewBag.telaio = telai.FirstOrDefault().Chassis1 + telai.FirstOrDefault().Chassis2;
            ViewBag.dataultimarevisione = telai.FirstOrDefault().DataUltimaRevisione;
            ViewBag.aziendautilizzatrice = telai.FirstOrDefault().DescrizioneAzienda;

            ViewBag.IDPerizia = ID;


            var foto = from s in db.SDU_DocumentiPerizia
                       where s.ID_Perizia.ToString() == ID.ToString()
                       select s;
            model.SDU_DocumentiPerizia = foto.ToList();

            //TempData["myIDTelaio"] = myIDTelaio;

            return View(foto);
        }

        public ActionResult PerizieImagesEdit(int? ID)
        {
            var model = new Models.HomeModel();
            int myIDTelaio = 0;
            if (TempData["myIDTelaio"] != null)
                myIDTelaio = (int)TempData["myIDTelaio"];
            else
                myIDTelaio = (int)ID;

            var model1 = new Models.HomeModel();
            var telai = from s in db.AT_ListaPratiche_vw
                        where s.Perizie_ID.ToString() == ID.ToString()
                        select s;
            model1.AT_ListaPratiche_vw = telai.ToList();
            ViewBag.targa = telai.FirstOrDefault().Targa;
            ViewBag.marca = telai.FirstOrDefault().Prod_Descr;
            ViewBag.dataimmatricolazione = telai.FirstOrDefault().DataImmatricolazione;
            ViewBag.km = telai.FirstOrDefault().Km;
            ViewBag.luogoperizia = telai.FirstOrDefault().DescrITA;
            ViewBag.modello = telai.FirstOrDefault().Mod_Descr;
            ViewBag.cartacircolazione = telai.FirstOrDefault().CartaCircolazione;
            ViewBag.matricola = telai.FirstOrDefault().Matricola;

            ViewBag.telaio = telai.FirstOrDefault().Chassis1 + telai.FirstOrDefault().Chassis2;
            ViewBag.dataultimarevisione = telai.FirstOrDefault().DataUltimaRevisione;
            ViewBag.aziendautilizzatrice = telai.FirstOrDefault().DescrizioneAzienda;

            ViewBag.IDPerizia = ID;


            var foto = from s in db.SDU_DocumentiPerizia
                       where s.ID_Perizia.ToString() == ID.ToString()
                       select s;
            model.SDU_DocumentiPerizia = foto.ToList();

            //TempData["myIDTelaio"] = myIDTelaio;

            return View(foto);
        }

        public ActionResult PraticheImages(int? ID)
        {
            var model = new Models.HomeModel();
            int myIDTelaio = 0;
            if (TempData["myIDTelaio"] != null)
                myIDTelaio = (int)TempData["myIDTelaio"];
            else
                myIDTelaio = (int)ID;

            var myScheda = from s in db.AT_ListaPratiche_vw
                           where s.Perizie_ID == ID
                           select s.PRAT_ID;

            var foto = from m in db.SDU_documentiPratica
                       where m.ID_pratica.ToString() == myScheda.FirstOrDefault().ToString()
                       select m;
            model.SDU_documentiPratica = foto.ToList();

            var model1 = new Models.HomeModel();
            var telai = from s in db.AT_ListaPratiche_vw
                        where s.Perizie_ID.ToString() == ID.ToString()
                        select s;
            model1.AT_ListaPratiche_vw = telai.ToList();
            ViewBag.targa = telai.FirstOrDefault().Targa;
            ViewBag.marca = telai.FirstOrDefault().Prod_Descr; 
            ViewBag.dataimmatricolazione = telai.FirstOrDefault().DataImmatricolazione;
            ViewBag.km = telai.FirstOrDefault().Km;
            ViewBag.luogoperizia = telai.FirstOrDefault().DescrITA;
            ViewBag.modello = telai.FirstOrDefault().Mod_Descr;
            ViewBag.cartacircolazione = telai.FirstOrDefault().CartaCircolazione;
            ViewBag.matricola = telai.FirstOrDefault().Matricola;
            ViewBag.IDPErizia = ID;
            ViewBag.telaio = telai.FirstOrDefault().Chassis1 + telai.FirstOrDefault().Chassis2;
            ViewBag.dataultimarevisione = telai.FirstOrDefault().DataUltimaRevisione;
            ViewBag.aziendautilizzatrice = telai.FirstOrDefault().DescrizioneAzienda;

            //TempData["myIDTelaio"] = myIDTelaio;

            return View(foto);
        }

        public ActionResult PraticheImagesEdit(int? ID)
        {
            var model = new Models.HomeModel();
            int myIDTelaio = 0;
            if (TempData["myIDTelaio"] != null)
                myIDTelaio = (int)TempData["myIDTelaio"];
            else
                myIDTelaio = (int)ID;

            var myScheda = from s in db.AT_ListaPratiche_vw
                           where s.Perizie_ID == ID
                           select s.PRAT_ID;

            var foto = from m in db.SDU_documentiPratica
                       where m.ID_pratica.ToString() == myScheda.FirstOrDefault().ToString()
                       select m;
            model.SDU_documentiPratica = foto.ToList();

            var model1 = new Models.HomeModel();
            var telai = from s in db.AT_ListaPratiche_vw
                        where s.Perizie_ID.ToString() == ID.ToString()
                        select s;
            model1.AT_ListaPratiche_vw = telai.ToList();
            ViewBag.targa = telai.FirstOrDefault().Targa;
            ViewBag.marca = telai.FirstOrDefault().Prod_Descr;
            ViewBag.dataimmatricolazione = telai.FirstOrDefault().DataImmatricolazione;
            ViewBag.km = telai.FirstOrDefault().Km;
            ViewBag.luogoperizia = telai.FirstOrDefault().DescrITA;
            ViewBag.modello = telai.FirstOrDefault().Mod_Descr;
            ViewBag.cartacircolazione = telai.FirstOrDefault().CartaCircolazione;
            ViewBag.matricola = telai.FirstOrDefault().Matricola;
            ViewBag.IDPErizia = ID;
            ViewBag.telaio = telai.FirstOrDefault().Chassis1 + telai.FirstOrDefault().Chassis2;
            ViewBag.dataultimarevisione = telai.FirstOrDefault().DataUltimaRevisione;
            ViewBag.aziendautilizzatrice = telai.FirstOrDefault().DescrizioneAzienda;

            //TempData["myIDTelaio"] = myIDTelaio;

            return View(foto);
        }

        public ActionResult DeleteSingleFotoPerizia(int id,  string picName , int? IDPerizia)
        {

            var sql = @"DELETE FROM SDU_DocumentiPerizia WHERE ID = @IDFoto";
            int myRecordCounter = db.Database.ExecuteSqlCommand(sql, new SqlParameter("@IDFoto", id));

            string fullPath = Request.MapPath("~/FotoPerizia/" + picName);
            if (System.IO.File.Exists(fullPath))
            {
                System.IO.File.Delete(fullPath);
            }

            var model = new Models.HomeModel();
            int myIDPerizia = 0;
            if (TempData["myIDPerizia"] != null)
                myIDPerizia = (int)TempData["myIDPerizia"];
            else
                myIDPerizia = (int)IDPerizia;


            var foto = from s in db.SDU_DocumentiPerizia
                       where s.ID_Perizia.ToString() == IDPerizia.ToString()
                       select s;
            model.SDU_DocumentiPerizia = foto.ToList();

            var model1 = new Models.HomeModel();
            var telai = from s in db.AT_ListaPratiche_vw
                        where s.Perizie_ID.ToString() == myIDPerizia.ToString()
                        select s;
            model1.AT_ListaPratiche_vw = telai.ToList();
            ViewBag.targa = telai.FirstOrDefault().Targa;
            ViewBag.marca = telai.FirstOrDefault().Prod_Descr;
            ViewBag.dataimmatricolazione = telai.FirstOrDefault().DataImmatricolazione;
            ViewBag.km = telai.FirstOrDefault().Km;
            ViewBag.luogoperizia = telai.FirstOrDefault().DescrITA;
            ViewBag.modello = telai.FirstOrDefault().Mod_Descr;
            ViewBag.cartacircolazione = telai.FirstOrDefault().CartaCircolazione;
            ViewBag.matricola = telai.FirstOrDefault().Matricola;
            ViewBag.IDPErizia = myIDPerizia;
            ViewBag.telaio = telai.FirstOrDefault().Chassis1 + telai.FirstOrDefault().Chassis2;
            ViewBag.dataultimarevisione = telai.FirstOrDefault().DataUltimaRevisione;
            ViewBag.aziendautilizzatrice = telai.FirstOrDefault().DescrizioneAzienda;



            return View("PerizieImages", foto);
        }

        public ActionResult DeleteSingleFotoPeriziaEdit(int id, string picName, int? IDPerizia)
        {

            var sql = @"DELETE FROM SDU_DocumentiPerizia WHERE ID = @IDFoto";
            int myRecordCounter = db.Database.ExecuteSqlCommand(sql, new SqlParameter("@IDFoto", id));

            string fullPath = Request.MapPath("~/FotoPerizia/" + picName);
            if (System.IO.File.Exists(fullPath))
            {
                System.IO.File.Delete(fullPath);
            }

            var model = new Models.HomeModel();
            int myIDPerizia = 0;
            if (TempData["myIDPerizia"] != null)
                myIDPerizia = (int)TempData["myIDPerizia"];
            else
                myIDPerizia = (int)IDPerizia;


            var foto = from s in db.SDU_DocumentiPerizia
                       where s.ID_Perizia.ToString() == IDPerizia.ToString()
                       select s;
            model.SDU_DocumentiPerizia = foto.ToList();

            var model1 = new Models.HomeModel();
            var telai = from s in db.AT_ListaPratiche_vw
                        where s.Perizie_ID.ToString() == myIDPerizia.ToString()
                        select s;
            model1.AT_ListaPratiche_vw = telai.ToList();
            ViewBag.targa = telai.FirstOrDefault().Targa;
            ViewBag.marca = telai.FirstOrDefault().Prod_Descr;
            ViewBag.dataimmatricolazione = telai.FirstOrDefault().DataImmatricolazione;
            ViewBag.km = telai.FirstOrDefault().Km;
            ViewBag.luogoperizia = telai.FirstOrDefault().DescrITA;
            ViewBag.modello = telai.FirstOrDefault().Mod_Descr;
            ViewBag.cartacircolazione = telai.FirstOrDefault().CartaCircolazione;
            ViewBag.matricola = telai.FirstOrDefault().Matricola;
            ViewBag.IDPErizia = myIDPerizia;
            ViewBag.telaio = telai.FirstOrDefault().Chassis1 + telai.FirstOrDefault().Chassis2;
            ViewBag.dataultimarevisione = telai.FirstOrDefault().DataUltimaRevisione;
            ViewBag.aziendautilizzatrice = telai.FirstOrDefault().DescrizioneAzienda;



            return View("PerizieImagesEdit", foto);
        }
        public ActionResult DeleteSingleFotoPratica(int id, string picName, int? IDPratica)
        {

            var sql = @"DELETE FROM SDU_DocumentiPratica WHERE ID = @IDFoto";
            int myRecordCounter = db.Database.ExecuteSqlCommand(sql, new SqlParameter("@IDFoto", id));

            string fullPath = Request.MapPath("~/FotoPratica/" + picName);
            if (System.IO.File.Exists(fullPath))
            {
                System.IO.File.Delete(fullPath);
            }

            var model = new Models.HomeModel();
            var foto = from s in db.SDU_documentiPratica
                       where s.ID_pratica.ToString() == IDPratica.ToString()
                       select s;
            model.SDU_documentiPratica = foto.ToList();

            var model1 = new Models.HomeModel();
            var telai = from s in db.AT_ListaPratiche_vw
                        where s.PRAT_ID.ToString() == IDPratica.ToString()
                        select s;

            ViewBag.targa = telai.FirstOrDefault().Targa;
            ViewBag.marca = telai.FirstOrDefault().Prod_Descr;
            ViewBag.dataimmatricolazione = telai.FirstOrDefault().DataImmatricolazione;
            ViewBag.km = telai.FirstOrDefault().Km;
            ViewBag.luogoperizia = telai.FirstOrDefault().DescrITA;
            ViewBag.modello = telai.FirstOrDefault().Mod_Descr;
            ViewBag.cartacircolazione = telai.FirstOrDefault().CartaCircolazione;
            ViewBag.matricola = telai.FirstOrDefault().Matricola;
            ViewBag.IDPeErizia = telai.FirstOrDefault().Perizie_ID;
            ViewBag.telaio = telai.FirstOrDefault().Chassis1 + telai.FirstOrDefault().Chassis2;
            ViewBag.dataultimarevisione = telai.FirstOrDefault().DataUltimaRevisione;
            ViewBag.aziendautilizzatrice = telai.FirstOrDefault().DescrizioneAzienda;


            return View("PraticheImages", foto);
        }

        public ActionResult DeleteSingleFotoPraticaEdit(int id, string picName, int? IDPratica)
        {

            var sql = @"DELETE FROM SDU_DocumentiPratica WHERE ID = @IDFoto";
            int myRecordCounter = db.Database.ExecuteSqlCommand(sql, new SqlParameter("@IDFoto", id));

            string fullPath = Request.MapPath("~/FotoPratica/" + picName);
            if (System.IO.File.Exists(fullPath))
            {
                System.IO.File.Delete(fullPath);
            }

            var model = new Models.HomeModel();
            var foto = from s in db.SDU_documentiPratica
                       where s.ID_pratica.ToString() == IDPratica.ToString()
                       select s;
            model.SDU_documentiPratica = foto.ToList();

            var model1 = new Models.HomeModel();
            var telai = from s in db.AT_ListaPratiche_vw
                        where s.PRAT_ID.ToString() == IDPratica.ToString()
                        select s;

            ViewBag.targa = telai.FirstOrDefault().Targa;
            ViewBag.marca = telai.FirstOrDefault().Prod_Descr;
            ViewBag.dataimmatricolazione = telai.FirstOrDefault().DataImmatricolazione;
            ViewBag.km = telai.FirstOrDefault().Km;
            ViewBag.luogoperizia = telai.FirstOrDefault().DescrITA;
            ViewBag.modello = telai.FirstOrDefault().Mod_Descr;
            ViewBag.cartacircolazione = telai.FirstOrDefault().CartaCircolazione;
            ViewBag.matricola = telai.FirstOrDefault().Matricola;
            ViewBag.IDPerizia = telai.FirstOrDefault().Perizie_ID;
            ViewBag.telaio = telai.FirstOrDefault().Chassis1 + telai.FirstOrDefault().Chassis2;
            ViewBag.dataultimarevisione = telai.FirstOrDefault().DataUltimaRevisione;
            ViewBag.aziendautilizzatrice = telai.FirstOrDefault().DescrizioneAzienda;
            ViewBag.IDPratica = telai.FirstOrDefault().Perizie_ID;

            return View("PraticheImagesEdit", foto);
        }
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                db.Dispose();
            }
            base.Dispose(disposing);
        }
    }
}