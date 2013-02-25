using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Suzy.BO
{
    class _area_class
    {
        public int id { get; set; }
        public string name { get; set; }
        public double lattitude { get; set; }
        public double longtitude { get; set; }
        public double radius { get; set; }
        public int id_account { get; private set; }
        public DateTime time_of_marking { get; set; }
         {
            using (OurDB db = new OurDB())
            {
                var location=db.Locations.Find(id);
                db.SaveChanges();
            }

        }
    }
}
