//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace RelationshipMVC
{
    using System;
    using System.Collections.Generic;
    
    public partial class Number
    {
        public int LicenseNumberID { get; set; }
        public string Number1 { get; set; }
        public int DriverID { get; set; }
    
        public virtual Driver Driver { get; set; }
    }
}
