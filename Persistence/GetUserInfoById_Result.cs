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
    
    public partial class GetUserInfoById_Result
    {
        public System.Guid ID_USER { get; set; }
        public Nullable<bool> IS_ENABLED { get; set; }
        public string EMAIL { get; set; }
        public string PASSWORD { get; set; }
        public string NICKNAME { get; set; }
        public System.Guid ID_PROFILE { get; set; }
        public string DESCRIZIONE_PROFILO { get; set; }
        public Nullable<System.Guid> MENU_ID_FATHER { get; set; }
        public System.Guid MENU_ID { get; set; }
        public string CODE { get; set; }
        public string DESCRIZIONE_MENU { get; set; }
    }
}
