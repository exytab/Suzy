using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace Suzy.Logger
{
    public class Logg: IDisposable
    {
        private System.IO.StreamWriter file;

        private Logg()
        {
            
        }

        private static Logg _logg = new Logg();

        public static Logg er
        {
            get { return _logg; }
        }

        public void Log(String message)
        {
            if(file != null)
                file.WriteLine(message);
        }

        public void Log(Exception ex)
        {
            if (file != null)
                file.WriteLine(ex);
        }

        public void Start(String Path)
        {
            file = new StreamWriter(string.Format("{0}/{1:yyyy.MM.dd.mm.ss}.txt", Path, DateTime.Now));
        }

        public void End()
        {
            this.Dispose();
        }

        public void Dispose()
        {
            file.Dispose();
        }
    }
}
