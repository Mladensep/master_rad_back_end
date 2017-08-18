using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace master_back_end.Models
{
    public class Comment
    {
        public int id { get; set; }
        public String com { get; set; }
        public int school_id { get; set; }
    }
}