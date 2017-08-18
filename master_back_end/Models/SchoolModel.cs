using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace master_back_end.Models
{
   

    public class SchoolModel
    {
        public int school_id { get; set; }
        public string id { get; set; }
        public string naziv { get; set; }
        public string adresa { get; set; }
        public string pbroj { get; set; }
        public string mesto { get; set; }
        public string opstina { get; set; }
        public string okrug { get; set; }
        public string suprava { get; set; }
        public string www { get; set; }
        public string tel { get; set; }
        public string fax { get; set; }
        public string vrsta { get; set; }
        public string odeljenja { get; set; }
        public string gps { get; set; }
    }

}