using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PavlikeDATA.Models;

namespace PavlikeDATA.Repos
{
    public class Albumler
    {
        readonly Context _db = new Context();
        public List<Album> GetAll()
        {
            return _db.Albums.ToList();
        }

        public Album GetbyId(int id)
        {
            return _db.Albums.SingleOrDefault(c => c.Id == id);
        }
        public Album GetbyTitle(string title)
        {
            return _db.Albums.SingleOrDefault(c => c.Title == title);
        }
        public Album GetbyAuthor(Author author)
        {
            return _db.Albums.SingleOrDefault(c => c.Author == author);
        }




    }
}
