
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
    
public partial class SDU_documentiPratica
{

    public int ID { get; set; }

    public int ID_pratica { get; set; }

    public Nullable<int> ID_tipoDocumento { get; set; }

    public string noteDocumento { get; set; }

    public string percorsoFile { get; set; }

    public string insertUser { get; set; }

    public System.DateTime insertTime { get; set; }

    public Nullable<int> KM { get; set; }



    public virtual SDU_documentiTipi SDU_documentiTipi { get; set; }

}

}
