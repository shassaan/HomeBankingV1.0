//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace HomeBankingV1._0
{
    using System;
    using System.Collections.Generic;
    
    public partial class deposit
    {
        public int id { get; set; }
        public Nullable<int> u_id { get; set; }
        public Nullable<System.DateTime> date { get; set; }
        public string concept { get; set; }
        public Nullable<double> amount { get; set; }
    
        public virtual USER USER { get; set; }
    }
}