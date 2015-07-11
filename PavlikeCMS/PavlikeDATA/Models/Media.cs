using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PavlikeDATA.Models
{
    public class Media
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Caption { get; set; }
        public string AltText { get; set; }
        public string Description { get; set; }
        public DateTime DateTime { get; set; }

        //public int FileTypeId { get; set; }
        //[ForeignKey("FileTypeId")]
        public FileType FileType { get; set; }


         //public int AuthorId { get; set; }
        //[ForeignKey("AuthorId")]
        public Author Author { get; set; }

        //public int FileId { get; set; }
        //[ForeignKey("FileId")]
        public File File { get; set; }

        public bool Active { get; set; }

        public virtual ICollection<AlbumMedia> AlbumMediaCollection { get; set; }
        public virtual ICollection<Author> AuthorCollection { get; set; }


    }
}
