﻿

//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------


namespace ATManager.Models
{

using System;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;


public partial class AUTOSDUEntities : DbContext
{
    public AUTOSDUEntities()
        : base("name=AUTOSDUEntities")
    {

    }

    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
        throw new UnintentionalCodeFirstException();
    }


    public virtual DbSet<AT_IndiciValutazione> AT_IndiciValutazione { get; set; }

    public virtual DbSet<AT_SchedaTecnica> AT_SchedaTecnica { get; set; }

    public virtual DbSet<AT_StatiMezzo> AT_StatiMezzo { get; set; }

    public virtual DbSet<AT_TipiScheda> AT_TipiScheda { get; set; }

    public virtual DbSet<AT_ListaPratiche_vw> AT_ListaPratiche_vw { get; set; }

    public virtual DbSet<Luoghi> Luoghi { get; set; }

    public virtual DbSet<Luoghi_vw> Luoghi_vw { get; set; }

    public virtual DbSet<AT_PreventiviDanno> AT_PreventiviDanno { get; set; }

    public virtual DbSet<SDU_documentiPratica> SDU_documentiPratica { get; set; }

    public virtual DbSet<SDU_documentiTipi> SDU_documentiTipi { get; set; }

    public virtual DbSet<SDU_StoricoStatusPerizia> SDU_StoricoStatusPerizia { get; set; }

    public virtual DbSet<AT_PeritiXZone> AT_PeritiXZone { get; set; }

    public virtual DbSet<SDU_DocumentiPerizia> SDU_DocumentiPerizia { get; set; }

    public virtual DbSet<AT_ListaPraticheSenzaPerizia_vw> AT_ListaPraticheSenzaPerizia_vw { get; set; }

    public virtual DbSet<AT_ListaPraticheConPerizia_vw> AT_ListaPraticheConPerizia_vw { get; set; }

    public virtual DbSet<AT_VisualizzazioneMezzo> AT_VisualizzazioneMezzo { get; set; }

    public virtual DbSet<LuoghiTest_vw> LuoghiTest_vw { get; set; }

    public virtual DbSet<SDU_Pratiche> SDU_Pratiche { get; set; }

    public virtual DbSet<SDU_Perizie> SDU_Perizie { get; set; }

}

}

