﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Tldr.Enums;

namespace Tldr.Models
{
    public class User
    {
        private ICollection<BookMark> _bookmarks;
        private ICollection<Creative> _creatives;

        public User()
        {
            _bookmarks = new List<BookMark>();
            _creatives = new List<Creative>();
        }

        public int UserID { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }
        public UserType Type { get; set; }
        public string Name { get; set; }
        public string Picture { get; set; }
        public DateTime BirthDate{get; set; }
        public string Status { get; set; }

        public virtual ICollection<BookMark> Bookmarks
        {
            get { return _bookmarks; }
            set { _bookmarks = value; }
        }

        public virtual ICollection<Creative> Creatives
        {
            get { return _creatives; }
            set { _creatives = value; }
        }
    }
}