using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Suzy.BO
{
    public static class Helper
    {
        public static void Init()
        {
            Database.SetInitializer<OurDB>(null);
            //http://patrickdesjardins.com/blog/the-model-backing-the-context-has-changed-since-the-database-was-created-ef4-3
            //http://stackoverflow.com/questions/12067955/cant-make-ef-code-first-work-with-manually-changed-data-base
        }
    }
}
