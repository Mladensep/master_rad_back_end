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


        public IHttpActionResult Post(Recension model)
        {

            if (model != null)
            {

                using (var context = new SchoolMasterDBEntities())
                {
                    recension recen = new recension();
                    recen.school_id = model.school_id;
                    recen.rec = model.rec;

                    context.recension.Add(recen);
                    context.SaveChanges();
                }

                return Ok();
            }

            return BadRequest();

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
