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

        
        public string Post(Comment model)
        {
            string status = "";

            if (model != null)
            {

                using (var context = new SchoolMasterDBEntities())
                {
                    comment comm = new comment();
                    comm.school_id = model.school_id;
                    comm.titleComment = model.titleComment;
                    comm.contentComment = model.contentComment;
                    comm.fbName = model.fbName;
                    comm.dateTime = model.dateTime;

              
                    context.comment.Add(comm);
                    context.SaveChanges();
                }

                status = "radi";

                return status;
            }

            status = "ne radi";

            return status;
            
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
//                    com = item.com,

                    titleComment = item.titleComment,
                    contentComment = item.contentComment,
                    fbName = item.fbName,
                    dateTime = item.dateTime,


                    school_id = item.school_id
                };

                listComment.Add(c);

            }
            return listComment;
        }

    }
}