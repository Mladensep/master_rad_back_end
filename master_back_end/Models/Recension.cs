using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace master_back_end.Models
{
    public class Recension
    {
        public int id { get; set; }
        public double rec { get; set; }
        public int school_id { get; set; }
        public string email { get; set; }
    }
}