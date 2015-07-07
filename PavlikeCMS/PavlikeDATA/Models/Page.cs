﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PavlikeDATA.Models
{

    public class Page
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Url { get; set; }
        public string SeoUrl { get; set; }

        public int ParentPageID { get; set; }
        [ForeignKey("ParentPageID")]
        public Page ParentPage { get; set; }

        public int AuthorId { get; set; }
        [ForeignKey("AuthorId")]
        public Author Author { get; set; }

        public virtual ICollection<Article> Articles { get; set; }

    }

}
