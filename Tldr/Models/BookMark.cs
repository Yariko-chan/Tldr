using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Tldr.Models
{
    public class Bookmark:StateInfo
    {
        public int BookmarkId { get; set; }
        public int CreativeId { get; set; }
        public int UserId { get; set; }
        public int Mark { get; set; }

        public virtual Creative Creative { get; set; }
        public virtual User User { get; set; }
    }
}