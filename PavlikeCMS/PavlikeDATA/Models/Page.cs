using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
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

        public virtual ICollection<Page> Pages { get; set; }
        public virtual ICollection<Article> Articles { get; set; }


    }

    public class Page
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Url { get; set; }

        public int AuthorId { get; set; }
        [ForeignKey("AuthorId")]
        public Author Author { get; set; }

        public virtual ICollection<Article> Articles { get; set; }

    }

    public class Article
    {
        public int Id { get; set; }
        public int PageId { get; set; }
        [ForeignKey("PageId")]
        public Page Page { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }

        public int AuthorId { get; set; }
        [ForeignKey("AuthorId")]
        public Author Author { get; set; }

        public int ArticleTypeId { get; set; }
        [ForeignKey("ArticleTypeId")]
        public ArticleType ArticleType { get; set; }

    }

    public class ArticleType
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public virtual ICollection<Article> Articles { get; set; }

    }

    public class FileType
    {
        public int Id { get; set; }
        public string Title { get; set; }

        public virtual ICollection<File> Files { get; set; }

    }

    public class File
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Detail { get; set; }
        public string Folder { get; set; }
        public string Url { get; set; }

        public int FileTypeId { get; set; }
        [ForeignKey("FileTypeId")]
        public FileType FileType { get; set; }

        public int AuthorId { get; set; }
        [ForeignKey("AuthorId")]
        public Author Author { get; set; }

    }

    public class Slider
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string SubTitle { get; set; }
        public string Detail { get; set; }

        public int FileId { get; set; }
        [ForeignKey("FileId")]
        public File File { get; set; }

    }
}
