using master_back_end.DatabaseModel;
using master_back_end.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Data.Entity.Validation;
using System.IO;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace master_back_end.Controllers
{
    public class SchoolsController : ApiController
    {

    
        public IEnumerable<string> InsertSchoolInDb()
        {
            var x =System.Web.HttpContext.Current.Server.MapPath("~/Content/products.json");
            using (StreamReader r = new StreamReader(x))
            {
                string json = r.ReadToEnd();
                List<SchoolModel> items = JsonConvert.DeserializeObject<List<SchoolModel>>(json);

                foreach (var item in items)
                {
                    schools s = new schools
                    {
                        id = item.id,
                        naziv = item.naziv,
                        adresa = item.adresa,
                        pbroj = item.pbroj,
                        mesto = item.mesto,
                        opstina = item.opstina,
                        okrug = item.okrug,
                        suprava = item.suprava,
                        www = item.www,
                        tel = item.tel,
                        fax = item.fax,
                        vrsta = item.vrsta,
                        odeljenja = item.odeljenja,
                        gps = item.gps
                        
                    };

                    SchoolMasterDBEntities contextEntities = new SchoolMasterDBEntities();
                    if (!contextEntities.schools.Any(z => z.id == s.id))
                    {
                        contextEntities.schools.Add(s);

                        try
                        {
                            contextEntities.SaveChanges();
                        }
                        catch (DbEntityValidationException e)
                        {
                            foreach (var eve in e.EntityValidationErrors)
                            {
                                Console.WriteLine("Entity of type \"{0}\" in state \"{1}\" has the following validation errors:",
                                    eve.Entry.Entity.GetType().Name, eve.Entry.State);
                                foreach (var ve in eve.ValidationErrors)
                                {
                                    Console.WriteLine("- Property: \"{0}\", Error: \"{1}\"",
                                        ve.PropertyName, ve.ErrorMessage);
                                }
                            }
                            throw;
                        }
                    }


                }
            }
                return new string[] { "value1", "value2" };
        }





        public IEnumerable<SchoolModel> Get()
        {
            SchoolMasterDBEntities contextEntities = new SchoolMasterDBEntities();

            List<schools> items = contextEntities.schools.ToList();

            List<SchoolModel> listSchool = new List<SchoolModel>();

            foreach (var item in items)
            {
                SchoolModel s = new SchoolModel
                {
                    school_id = item.school_id,
                    id = item.id,
                    naziv = item.naziv,
                    adresa = item.adresa,
                    pbroj = item.pbroj,
                    mesto = item.mesto,
                    opstina = item.opstina,
                    okrug = item.okrug,
                    suprava = item.suprava,
                    www = item.www,
                    tel = item.tel,
                    fax = item.fax,
                    vrsta = item.vrsta,
                    odeljenja = item.odeljenja,
                    gps = item.gps

                };

                listSchool.Add(s);
            
           
            }
            return listSchool;
    }

    }
}