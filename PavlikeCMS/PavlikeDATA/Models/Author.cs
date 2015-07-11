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
        public string RoleGuid { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public DateTime DateofBirth { get; set; }
        public string EMail { get; set; }
        public Media Picture { get; set; }
        public bool Active { get; set; }
        public virtual ICollection<Page> PageCollection { get; set; }
        public virtual ICollection<Article> ArticleCollection { get; set; }
        public virtual ICollection<File> FileCollection { get; set; }
        public virtual ICollection<Album> AlbumCollection { get; set; }
        public virtual ICollection<Media> MediaCollection { get; set; }

    }
}
