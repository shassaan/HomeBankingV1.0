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
    
    public partial class accountDetail
    {
        public int id { get; set; }
        public Nullable<System.DateTime> date { get; set; }
        public string concept { get; set; }
        public Nullable<double> import { get; set; }
        public Nullable<double> balance { get; set; }
        public string originate { get; set; }
        public string destination { get; set; }
        public string recivername { get; set; }
        public Nullable<int> aid { get; set; }
        public Nullable<bool> transType { get; set; }
    
        public virtual account account { get; set; }
    }
}