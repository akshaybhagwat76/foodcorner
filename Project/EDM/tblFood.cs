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
    
    public partial class tblFood
    {
        public int f_id { get; set; }
        public string f_name { get; set; }
        public Nullable<int> c_id { get; set; }
        public Nullable<int> s_id { get; set; }
        public Nullable<int> f_price { get; set; }
        public Nullable<System.DateTime> f_date { get; set; }
        public string f_image { get; set; }
        public string f_description { get; set; }
        public Nullable<int> r_id { get; set; }
        public Nullable<int> f_status { get; set; }
        public Nullable<int> offer_id { get; set; }
    }
}
