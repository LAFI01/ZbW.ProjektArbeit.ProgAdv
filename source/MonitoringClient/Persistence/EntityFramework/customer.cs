//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace MonitoringClient.Persistence.EntityFramework
{
    using System;
    using System.Collections.Generic;
    
    public partial class customer
    {
        public int id { get; set; }
        public string name { get; set; }
        public string surname { get; set; }
        public Nullable<int> address_id { get; set; }
        public string kundenNr { get; set; }
        public string phone { get; set; }
        public string email { get; set; }
        public string website { get; set; }
        public string password { get; set; }
    }
}
