using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PavlikeDATA.Models
{
    public class AlbumMedia
    {
        public int Id { get; set; }
        //public int AlbumId { get; set; }
        //public int MediaId { get; set; }

        //[ForeignKey("AlbumId")]
        public Album Album { get; set; }
        //[ForeignKey("MediaId")]
        public Media Media { get; set; }
    }
}
