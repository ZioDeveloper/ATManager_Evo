﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ATManager.Models
{
    public class HomeModel
    {

        public IEnumerable<AT_ListaPratiche_vw> AT_ListaPratiche_vw { get; set; }
        public IEnumerable<AT_IndiciValutazione> AT_IndiciValutazione { get; set; }
        public IEnumerable<AT_SchedaTecnica> AT_SchedaTecnica { get; set; }
        public IEnumerable<AT_StatiMezzo> AT_StatiMezzo { get; set; }
        public IEnumerable<AT_TipiScheda> AT_TipiScheda { get; set; }

        public IEnumerable<Luoghi> Luoghi { get; set; }
        public IEnumerable<Luoghi_vw> Luoghi_vw { get; set; }
        public IEnumerable<LuoghiTest_vw> LuoghiTest_vw { get; set; }

        public IEnumerable<SDU_documentiTipi> SDU_documentiTipi { get; set; }

        public IEnumerable<AT_PeritiXZone> AT_PeritiXZone { get; set; }

        public IEnumerable<SDU_DocumentiPerizia> SDU_DocumentiPerizia { get; set; }

        public IEnumerable<SDU_documentiPratica> SDU_documentiPratica { get; set; }

        public IEnumerable<AT_ListaPraticheSenzaPerizia_vw> AT_ListaPraticheSenzaPerizia_vw { get; set; }

        public IEnumerable<AT_ListaPraticheConPerizia_vw> AT_ListaPraticheConPerizia_vw { get; set; }

        public IEnumerable<SDU_Pratiche> SDU_Pratiche { get; set; }

    }
}