using master_back_end.DatabaseModel;
using master_back_end.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace master_back_end.Controllers
{
    public class RecensionController : ApiController
    {

        //0 dobro
        //1 greska
        //2 vec je dodata recenzija

        public string Post(Recension model)
        {

            if (model != null)
            {



                using (var context = new SchoolMasterDBEntities())
                {
                    bool hasUserAddRecension = context.recension.Any(x => x.email.Equals(model.email) && x.school_id == model.school_id);
                    if (!hasUserAddRecension)
                    {

                        recension recen = new recension();
                        recen.school_id = model.school_id;
                        recen.rec = model.rec;
                        recen.email = model.email;

                        context.recension.Add(recen);
                        context.SaveChanges();

                        return "0";
                    }
                    else
                    {
                        return "2";
                    }
                }
                

            }
            return "1";
        }

        [System.Web.Http.HttpGet]
        public IEnumerable<Recension> Get(int schoolId)
        {
            SchoolMasterDBEntities contextEntities = new SchoolMasterDBEntities();

            List<recension> items = contextEntities.recension.Where(x => x.school_id == schoolId).ToList();

            List<Recension> listRecension = new List<Recension>();

            foreach (var item in items)
            {
                Recension c = new Recension
                {
                    id = item.id,
                    rec = item.rec,
                    school_id = item.school_id
                };

                listRecension.Add(c);

            }
            return listRecension;
        }


    }
}
