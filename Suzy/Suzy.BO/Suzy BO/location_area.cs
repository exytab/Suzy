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
    
    public partial class location_area
    {
        public int id { get; set; }
        public string name { get; set; }
        public Nullable<float> lattitude { get; set; }
        public Nullable<float> longtitude { get; set; }
        public Nullable<float> radius { get; set; }
        public int id_account { get; set; }
        public Nullable<System.DateTime> time_of_marking { get; set; }
    
        public virtual account account { get; set; }

        public override bool Equals(object obj)
        {
            if (obj is location_area)
            {
                location_area areaObj = obj as location_area;
                if (areaObj == null)
                    return false;
                else if (this.name == areaObj.name
                    && this.lattitude == areaObj.lattitude
                    && this.longtitude == areaObj.longtitude
                    && this.radius == areaObj.radius
                    && this.id_account == areaObj.id_account
                    && this.time_of_marking == areaObj.time_of_marking
                    )
                    return true;
                else
                    return false;
            }
            else
                return false;
        }
    }
}
