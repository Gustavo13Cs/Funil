//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Funil.Models
{
    using System;
    using System.Collections.Generic;
    
    public partial class VAGA
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public VAGA()
        {
            this.CANDIDATOVAGA = new HashSet<CANDIDATOVAGA>();
        }
    
        public int VAIID { get; set; }
        public string VAINOME { get; set; }
        public string VAIDESCRICAO { get; set; }
        public string VAIATRIBUICAO { get; set; }
        public Nullable<decimal> VAISALARIO { get; set; }
        public string VAIREQUISITO { get; set; }
        public System.DateTime VAIDATACADASTRO { get; set; }
    
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<CANDIDATOVAGA> CANDIDATOVAGA { get; set; }
    }
}
