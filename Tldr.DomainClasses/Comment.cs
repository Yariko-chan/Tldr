using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Tldr.DomainClasses
{
    public class Comment:StateInfo
    {
        public int CommentId { get; set; }
        public int UserId { get; set; }
        public int CreativeId { get; set; }
        public DateTime CommentCreateDate { get; set; }
        public string CommentText { get; set; }
        public int CommentLikes { get; set; }

        public virtual User User { get; set; }
        public virtual Creative Creative { get; set; }
    }
}