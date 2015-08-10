﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using PavlikeDATA.Models;
using Enum = pavlikeLibrary.Enum;

namespace PavlikeDATA.Repos
{
    public class ArticleRepository
    {
        readonly Context _db = new Context();
        public List<Article> GetAll()
        {
            return _db.Articles.Where(c => c.Active).OrderBy(c => c.Title).Include(c => c.Author).Include(c => c.ArticleType).Include(c => c.Page).ToList();
        }

        public List<ArticleType> Types()
        {
            return _db.ArticleTypes.ToList();
        }

        public Enum.EntityResult Create(Article article)
        {
            try
            {
                article.Active = true;
                _db.Articles.Add(article);
                _db.SaveChanges();
                return Enum.EntityResult.Success;
            }
            catch (Exception e)
            {
                return Enum.EntityResult.Failed;
            }
        }

        public Article FindbyId(int id)
        {
            return _db.Articles.SingleOrDefault(c => c.Id == id);

        }

        public Enum.EntityResult Update(Article modified)
        {
            try
            {
                _db.Entry(modified).State = EntityState.Modified;
                _db.SaveChanges();
                return Enum.EntityResult.Success;
            }
            catch (Exception e)
            {
                return Enum.EntityResult.Failed;
            }
        }

        public Enum.EntityResult Disable(Article disable)
        {
            disable.Active = false;
            return Update(disable);
        }

        public Enum.EntityResult Delete(Article delete)
        {
            try
            {
                _db.Articles.Remove(delete);
                _db.SaveChanges();
                return Enum.EntityResult.Success;
            }
            catch (Exception e)
            {
                return Enum.EntityResult.Failed;
            }
        }
        public Enum.EntityResult FindbyIdandDisable(int id)
        {
            var disableitem = FindbyId(id);
            return disableitem == null ? Enum.EntityResult.Failed : Disable(disableitem);
        }

    }
}
