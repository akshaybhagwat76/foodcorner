//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated from a template.
//
//     Manual changes to this file may cause unexpected behavior in your application.
//     Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Project.EDM
{
    using System;
    using System.Collections.Generic;
    
    public partial class tblOrder
    {
        public int serial_no { get; set; }
        public Nullable<int> o_id { get; set; }
        public Nullable<int> f_id { get; set; }
        public Nullable<int> o_userid { get; set; }
        public string o_quantity { get; set; }
        public Nullable<System.DateTime> o_date { get; set; }
        public string o_status { get; set; }
        public Nullable<int> o_price { get; set; }
        public Nullable<int> r_id { get; set; }
        public Nullable<int> offer_id { get; set; }
        public string address { get; set; }
        public string mobile { get; set; }
    }
}
