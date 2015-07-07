using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PavlikeDATA.Models
{
    public class Slider
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string SubTitle { get; set; }
        public string Detail { get; set; }

        //public int FileId { get; set; }
        //[ForeignKey("FileId")]
        public File File { get; set; }

        public bool Active { get; set; }


    }
}
