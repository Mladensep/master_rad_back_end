using master_back_end.DatabaseModel;
using master_back_end.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using System.Web.Mvc;

namespace master_back_end.Controllers
{
    public class CommentController : ApiController
    {

        
        public IHttpActionResult Post(Comment model)
        {

            if (model != null)
            {

                using (var context = new SchoolMasterDBEntities())
                {
                    comment comm = new comment();
                    comm.school_id = model.school_id;
                    comm.com = model.com;

                    context.comment.Add(comm);
                    context.SaveChanges();
                }

                return Ok();
            }

            return BadRequest();
            
        }



        [System.Web.Http.HttpGet]
        public IEnumerable<Comment> Get(int id)
        {
            SchoolMasterDBEntities contextEntities = new SchoolMasterDBEntities();

            List<comment> items = contextEntities.comment.Where(x => x.school_id == id).ToList();

            List<Comment> listComment = new List<Comment>();

            foreach (var item in items)
            {
                Comment c = new Comment
                {
                    id = item.id,
                    com = item.com,
                    school_id = item.school_id
                };

                listComment.Add(c);

            }
            return listComment;
        }

    }
}