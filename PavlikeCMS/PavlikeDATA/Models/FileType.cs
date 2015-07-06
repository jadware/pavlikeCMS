using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PavlikeDATA.Models
{
    public class FileType
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public virtual ICollection<File> Files { get; set; }
        public virtual ICollection<Media> Media { get; set; }
    }
}
