﻿using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.ModelConfiguration.Conventions;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNet.Identity.EntityFramework;
using pavlikeMVC.Models;

namespace PavlikeDATA.Models
{
    public class Context : DbContext
    {

        public Context()
                : base("pavlikeCMS_DBModel")
        {
            Database.SetInitializer(new Initializer());

        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Conventions.Remove<PluralizingTableNameConvention>();
        }

        #region dbset init
        public virtual DbSet<Album> Albums { get; set; }
        public virtual DbSet<AlbumMedia> AlbumMedias { get; set; }
        public virtual DbSet<Article> Articles { get; set; }
        public virtual DbSet<ArticleType> ArticleTypes { get; set; }
        public virtual DbSet<Author> Authors { get; set; }
        public virtual DbSet<Document> Documents { get; set; }
        public virtual DbSet<File> Files { get; set; }
        public virtual DbSet<FileType> FileTypes { get; set; }
        public virtual DbSet<Media> Medias { get; set; }
        public virtual DbSet<Page> Pages { get; set; }
        public virtual DbSet<Seo> Seos { get; set; }
        public virtual DbSet<Settings> Settings { get; set; }
        public virtual DbSet<Slider> Sliders { get; set; }
        public virtual DbSet<Social> Socials { get; set; }
        public virtual DbSet<MailSettings> MailSettings { get; set; }
        #endregion
    }


}
