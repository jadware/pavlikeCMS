using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PavlikeDATA.Models
{
    public class Album
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public int AuthorId { get; set; }
        [ForeignKey("AuthorId")]
        public Author Author { get; set; }

        /// <summary>
        /// deneme change
        /// </summary>
        public bool Active { get; set; }
        public virtual ICollection<AlbumMedia> AlbumMedia { get; set; }

    }
}
