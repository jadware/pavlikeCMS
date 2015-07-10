using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using PavlikeDATA.Models;

namespace PavlikeDATA.Repos
{
    public class Articler
    {
         
        public List<Article> GetAll()
        {
            Context db = new Context();

            return db.Articles.ToList();
        }
    }
}
