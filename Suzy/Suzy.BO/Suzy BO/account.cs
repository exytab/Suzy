//------------------------------------------------------------------------------
// <auto-generated>
//    This code was generated from a template.
//
//    Manual changes to this file may cause unexpected behavior in your application.
//    Manual changes to this file will be overwritten if the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

namespace Suzy.BO
{
    using System;
    using System.Collections.Generic;
    
    public partial class account
    {
        public account()
        {
            this.subscriber = new HashSet<subscriber>();
            this.location_area = new HashSet<location_area>();
            this.subscriber1 = new HashSet<subscriber>();
        }
    
        public int id { get; set; }
        public string name { get; set; }
        public string surname { get; set; }
        public string login { get; set; }
        public string password { get; set; }
        public string email { get; set; }
        public int id_avatar { get; set; }
        public bool ban { get; set; }
        public bool admin { get; set; }
    
        public virtual avatar avatar { get; set; }
        public virtual avatar avatar1 { get; set; }
        public virtual ICollection<subscriber> subscriber { get; set; }
        public virtual ICollection<location_area> location_area { get; set; }
        public virtual ICollection<subscriber> subscriber1 { get; set; }
    }
}
