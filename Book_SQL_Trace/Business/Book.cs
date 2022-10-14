using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Book_SQL_Trace.Business
{
   public class Book
    {
        public string Block { get; set; }
        public string Name { get; set; }
        public string Titel { get; set; }
        public int BookID { get; set; }
        public DateTime Date_out { get; set; }
        public DateTime Date_Due { get; set; }
    }
}
