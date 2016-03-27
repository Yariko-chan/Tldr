using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Tldr.Enums;

namespace Tldr.Models
{
    public class Creative:StateInfo
    {
        private ICollection<Tag> _tags;
        private ICollection<CreativePart> _parts;
        private ICollection<Comment> _comments;

        public Creative()
        {
            _tags = new List<Tag>();
            _parts = new List<CreativePart>();
            _comments = new List<Comment>();
        }

        public int CreativeId { get; set; }
        public string CreativeName { get; set; }
        public int UserId { get; set; }
        public int CategoryId { get; set; }

        public virtual ICollection<Tag> Tags
        {
            get { return _tags; }
            set { _tags = value;  }
        }
        
        public int CreativeRate { get; set; }

        public virtual ICollection<CreativePart> Parts
        {
            get { return _parts; }
            set { _parts = value; }
        }

        public virtual ICollection<Comment> Comments
        {
            get { return _comments; }
            set { _comments = value; }
        }

        public virtual User User { set; get; }
        public virtual Category Category { set; get; }
    }
}