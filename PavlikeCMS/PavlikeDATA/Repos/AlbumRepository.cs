﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using PavlikeDATA.Models;
using Enum = pavlikeLibrary.Enum;

namespace PavlikeDATA.Repos
{
    public class AlbumRepository
    {
        readonly Context _db = new Context();
        public List<Album> GetAll()
        {
            return _db.Albums.Where(c => c.Active).OrderBy(c => c.Title).Include(c => c.Author).Include(c => c.AlbumMediaCollection).ToList();
        }

        public int Count()
        {
            return _db.Albums.Count(c => c.Active);
        }

        public Enum.EntityResult Create(Album album)
        {
            try
            {
                album.Active = true;
                _db.Albums.Add(album);
                _db.SaveChanges();

                return Enum.EntityResult.Success;
            }
            catch (Exception)
            {
                return Enum.EntityResult.Failed;
            }

        }

        public Album FindbyId(int id)
        {
            return _db.Albums.SingleOrDefault(c => c.Id == id);

        }

        public Enum.EntityResult Update(Album modified)
        {
            try
            {
                _db.Entry(modified).State = EntityState.Modified;
                _db.SaveChanges();
                return Enum.EntityResult.Success;
            }
            catch (Exception r)
            {
                return Enum.EntityResult.Failed;
            }
        }

        public Enum.EntityResult Disable(Album disable)
        {
            disable.Active = false;
            return Update(disable);

        }

        public Enum.EntityResult Delete(Album delete)
        {
            try
            {
                _db.Albums.Remove(delete);
                return Enum.EntityResult.Success;
            }
            catch (Exception)
            {
                return Enum.EntityResult.Failed;
            }
            finally
            {
                _db.SaveChanges();
            }

        }
        public Enum.EntityResult FindbyIdandDisable(int id)
        {
            var disableitem = FindbyId(id);
            return disableitem == null ? Enum.EntityResult.Failed : Disable(disableitem);
        }
    }
}
