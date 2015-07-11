using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PavlikeDATA.Models
{

    public class Article
    {
        public int Id { get; set; }
        //public int PageId { get; set; }
        //[ForeignKey("PageId")]
        public Page Page { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }

         //public int AuthorId { get; set; }
        //[ForeignKey("AuthorId")]
        public Author Author { get; set; }

        //public int ArticleTypeId { get; set; }
        //[ForeignKey("ArticleTypeId")]
        public ArticleType ArticleType { get; set; }

        public bool Active { get; set; }

    }
}

