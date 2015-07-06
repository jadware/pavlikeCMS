using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PavlikeDATA.Models
{
    public class Author
    {
        public int Id { get; set; }
        public string UserGuid { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime DateofBirth { get; set; }
        public string EMail { get; set; }
        public virtual ICollection<Page> Pages { get; set; }
        public virtual ICollection<Article> Articles { get; set; }
        public virtual ICollection<File> Files { get; set; }
        public virtual ICollection<Album> Albums { get; set; }

        public virtual ICollection<Media> Media { get; set; }

    }
}
