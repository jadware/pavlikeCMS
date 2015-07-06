using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PavlikeDATA.Models
{

    public class File
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Detail { get; set; }
        public string Folder { get; set; }
        public string Url { get; set; }

        public string FileName { get; set; }
        public string Extension { get; set; }
        public DateTime UploadDateTime { get; set; }

        public int FileTypeId { get; set; }
        [ForeignKey("FileTypeId")]
        public FileType FileType { get; set; }

        public int AuthorId { get; set; }
        [ForeignKey("AuthorId")]
        public Author Author { get; set; }

        public virtual ICollection<Slider> Sliders { get; set; }
        public virtual ICollection<Media> Media { get; set; }


    }
}
