using System;
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

        //public int AuthorId { get; set; }
        //[ForeignKey("AuthorId")]
        public Author Author { get; set; }
        public bool Published { get; set; }
        public bool Active { get; set; }

        public virtual ICollection<Article> ArticleCollection { get; set; }

    }

}
