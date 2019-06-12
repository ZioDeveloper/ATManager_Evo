
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
    using System.Collections.Generic;
    
public partial class AT_SchedaTecnica
{

    public int ID { get; set; }

    public int IDTipoScheda { get; set; }

    public int IDStatoMezzo { get; set; }

    public Nullable<int> CE110 { get; set; }

    public Nullable<int> CE112 { get; set; }

    public Nullable<int> CE115 { get; set; }

    public Nullable<int> CE125 { get; set; }

    public Nullable<int> CE135 { get; set; }

    public Nullable<int> CE145 { get; set; }

    public Nullable<int> CE150 { get; set; }

    public Nullable<int> CE160 { get; set; }

    public Nullable<int> CE170 { get; set; }

    public Nullable<int> CE415 { get; set; }

    public Nullable<int> CE265 { get; set; }

    public Nullable<int> CE420 { get; set; }

    public Nullable<int> CE816 { get; set; }

    public Nullable<int> CE840 { get; set; }

    public Nullable<int> CE841 { get; set; }

    public Nullable<int> CE842 { get; set; }

    public Nullable<int> CE843 { get; set; }

    public Nullable<int> CE844 { get; set; }

    public Nullable<int> CE960 { get; set; }

    public Nullable<int> CI820 { get; set; }

    public Nullable<int> CI825 { get; set; }

    public Nullable<int> CI835 { get; set; }

    public Nullable<int> CI837 { get; set; }

    public Nullable<int> CI843 { get; set; }

    public Nullable<int> CI910 { get; set; }

    public Nullable<int> CI930 { get; set; }

    public Nullable<int> CS240 { get; set; }

    public Nullable<int> CS510 { get; set; }

    public Nullable<int> CS511 { get; set; }

    public Nullable<int> CS710 { get; set; }

    public Nullable<int> CS715 { get; set; }

    public Nullable<int> CS810 { get; set; }

    public Nullable<int> CS815 { get; set; }

    public Nullable<int> PS165 { get; set; }

    public Nullable<int> PS225 { get; set; }

    public Nullable<int> PS230 { get; set; }

    public Nullable<int> PS235 { get; set; }

    public Nullable<int> PS250 { get; set; }

    public Nullable<int> PS260 { get; set; }

    public Nullable<int> PS410 { get; set; }

    public Nullable<int> PS512 { get; set; }

    public Nullable<int> PS610 { get; set; }

    public Nullable<int> CI1135 { get; set; }

    public int IDPerizia { get; set; }

    public int IDPreventivoDanno { get; set; }

    public bool IsCompleted { get; set; }

    public string NoteCE110 { get; set; }

    public string NoteCE112 { get; set; }

    public string NoteCE115 { get; set; }

    public string NoteCE125 { get; set; }

    public string NoteCE135 { get; set; }

    public string NoteCE145 { get; set; }

    public string NoteCE150 { get; set; }

    public string NoteCE160 { get; set; }

    public string NoteCE170 { get; set; }

    public string NoteCE415 { get; set; }

    public string NoteCE265 { get; set; }

    public string NoteCE420 { get; set; }

    public string NoteCE816 { get; set; }

    public string NoteCE840 { get; set; }

    public string NoteCE841 { get; set; }

    public string NoteCE842 { get; set; }

    public string NoteCE843 { get; set; }

    public string NoteCE844 { get; set; }

    public string NoteCE960 { get; set; }

    public string NoteCI820 { get; set; }

    public string NoteCI825 { get; set; }

    public string NoteCI835 { get; set; }

    public string NoteCI837 { get; set; }

    public string NoteCI843 { get; set; }

    public string NoteCI910 { get; set; }

    public string NoteCI930 { get; set; }

    public string NoteCI1135 { get; set; }

    public string NoteCS240 { get; set; }

    public string NoteCS510 { get; set; }

    public string NoteCS511 { get; set; }

    public string NoteCS710 { get; set; }

    public string NoteCS715 { get; set; }

    public string NoteCS810 { get; set; }

    public string NoteCS815 { get; set; }

    public string NotePS165 { get; set; }

    public string NotePS225 { get; set; }

    public string NotePS230 { get; set; }

    public string NotePS235 { get; set; }

    public string NotePS250 { get; set; }

    public string NotePS260 { get; set; }

    public string NotePS410 { get; set; }

    public string NotePS512 { get; set; }

    public string NotePS610 { get; set; }

    public string Note_generali { get; set; }

    public string Note_danno { get; set; }

    public string insertUser { get; set; }

    public System.DateTime insertTime { get; set; }

    public int IDVisualizzazioneMezzo { get; set; }

    public Nullable<bool> isMarciante { get; set; }

    public string isAvviante { get; set; }

    public Nullable<bool> IsManutOrdinaria { get; set; }



    public virtual AT_StatiMezzo AT_StatiMezzo { get; set; }

    public virtual AT_TipiScheda AT_TipiScheda { get; set; }

    public virtual AT_IndiciValutazione AT_IndiciValutazione { get; set; }

    public virtual AT_IndiciValutazione AT_IndiciValutazione1 { get; set; }

    public virtual AT_IndiciValutazione AT_IndiciValutazione2 { get; set; }

    public virtual AT_IndiciValutazione AT_IndiciValutazione3 { get; set; }

    public virtual AT_IndiciValutazione AT_IndiciValutazione4 { get; set; }

    public virtual AT_IndiciValutazione AT_IndiciValutazione5 { get; set; }

    public virtual AT_IndiciValutazione AT_IndiciValutazione6 { get; set; }

    public virtual AT_IndiciValutazione AT_IndiciValutazione7 { get; set; }

    public virtual AT_IndiciValutazione AT_IndiciValutazione8 { get; set; }

    public virtual AT_IndiciValutazione AT_IndiciValutazione9 { get; set; }

    public virtual AT_IndiciValutazione AT_IndiciValutazione10 { get; set; }

    public virtual AT_IndiciValutazione AT_IndiciValutazione11 { get; set; }

    public virtual AT_IndiciValutazione AT_IndiciValutazione12 { get; set; }

    public virtual AT_IndiciValutazione AT_IndiciValutazione13 { get; set; }

    public virtual AT_IndiciValutazione AT_IndiciValutazione14 { get; set; }

    public virtual AT_IndiciValutazione AT_IndiciValutazione15 { get; set; }

    public virtual AT_IndiciValutazione AT_IndiciValutazione16 { get; set; }

    public virtual AT_IndiciValutazione AT_IndiciValutazione17 { get; set; }

    public virtual AT_IndiciValutazione AT_IndiciValutazione19 { get; set; }

    public virtual AT_IndiciValutazione AT_IndiciValutazione20 { get; set; }

    public virtual AT_IndiciValutazione AT_IndiciValutazione21 { get; set; }

    public virtual AT_IndiciValutazione AT_IndiciValutazione22 { get; set; }

    public virtual AT_IndiciValutazione AT_IndiciValutazione23 { get; set; }

    public virtual AT_IndiciValutazione AT_IndiciValutazione24 { get; set; }

    public virtual AT_IndiciValutazione AT_IndiciValutazione25 { get; set; }

    public virtual AT_IndiciValutazione AT_IndiciValutazione26 { get; set; }

    public virtual AT_IndiciValutazione AT_IndiciValutazione27 { get; set; }

    public virtual AT_IndiciValutazione AT_IndiciValutazione28 { get; set; }

    public virtual AT_IndiciValutazione AT_IndiciValutazione29 { get; set; }

    public virtual AT_IndiciValutazione AT_IndiciValutazione30 { get; set; }

    public virtual AT_IndiciValutazione AT_IndiciValutazione31 { get; set; }

    public virtual AT_IndiciValutazione AT_IndiciValutazione32 { get; set; }

    public virtual AT_IndiciValutazione AT_IndiciValutazione33 { get; set; }

    public virtual AT_IndiciValutazione AT_IndiciValutazione34 { get; set; }

    public virtual AT_IndiciValutazione AT_IndiciValutazione35 { get; set; }

    public virtual AT_IndiciValutazione AT_IndiciValutazione36 { get; set; }

    public virtual AT_IndiciValutazione AT_IndiciValutazione37 { get; set; }

    public virtual AT_IndiciValutazione AT_IndiciValutazione38 { get; set; }

    public virtual AT_IndiciValutazione AT_IndiciValutazione39 { get; set; }

    public virtual AT_IndiciValutazione AT_IndiciValutazione40 { get; set; }

    public virtual AT_IndiciValutazione AT_IndiciValutazione111 { get; set; }

    public virtual AT_IndiciValutazione AT_IndiciValutazione401 { get; set; }

    public virtual AT_IndiciValutazione AT_IndiciValutazione181 { get; set; }

    public virtual AT_PreventiviDanno AT_PreventiviDanno { get; set; }

    public virtual AT_VisualizzazioneMezzo AT_VisualizzazioneMezzo { get; set; }

}

}
