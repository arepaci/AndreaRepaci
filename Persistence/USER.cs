//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Core
{
    using System;
    using System.Collections.Generic;
    
    public partial class USER
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public USER()
        {
            this.SERVIZIs = new HashSet<SERVIZI>();
        }
    
        public System.Guid ID_USER { get; set; }
        public string NAME { get; set; }
        public string SURNAME { get; set; }
        public string TITLE { get; set; }
        public System.Guid ID_PROFILE { get; set; }
        public string EMAIL { get; set; }
        public Nullable<bool> IS_ENABLED { get; set; }
        public string PHONE_NUMBER { get; set; }
        public string MOBILE_PHONE_NUMBER { get; set; }
        public System.Guid ID_LANGUAGE { get; set; }
        public string PASSWORD { get; set; }
    
        public virtual LANGUAGE LANGUAGE { get; set; }
        public virtual PROFILE PROFILE { get; set; }
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SERVIZI> SERVIZIs { get; set; }
    }
}
