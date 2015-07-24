using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using PavlikeDATA.Models;
using Enum = pavlikeLibrary.Enum;

namespace PavlikeDATA.Repos
{
    public class ArticleRepository
    {
        readonly Context _db = new Context();
        private readonly EntityLog _entityLog = new EntityLog { Class = MethodBase.GetCurrentMethod().DeclaringType.Name, EntityModel = "Article" };
        public List<Article> GetAll()
        {
            _entityLog.Job = Enum.EntityJob.Read;
            _entityLog.Method = MethodBase.GetCurrentMethod().Name;
            _db.EntityLogs.Add(_entityLog);
            _db.SaveChanges();
            return _db.Articles.Where(c => c.Active).OrderBy(c => c.Title).Include(c => c.Author).Include(c => c.ArticleType).Include(c=>c.Page).ToList();

        }

        public List<ArticleType> Types()
        {
            _entityLog.Job = Enum.EntityJob.Read;
            _entityLog.Method = MethodBase.GetCurrentMethod().Name;
            _db.EntityLogs.Add(_entityLog);
            _db.SaveChanges();
            return _db.ArticleTypes.ToList();
        } 

        public Enum.EntityResult Create(Article article)
        {
            try
            {
                article.Active = true;
                _db.Articles.Add(article);
                _entityLog.EntityResult = Enum.EntityResult.Success;
                return Enum.EntityResult.Success;
            }
            catch (Exception e)
            {
                _entityLog.ErrorId = e.HResult;
                _entityLog.Detail = e.Message;
                _entityLog.EntityResult = Enum.EntityResult.Failed;

                return Enum.EntityResult.Failed;
            }
            finally
            {
                _entityLog.Job = Enum.EntityJob.Create;
                _entityLog.Method = MethodBase.GetCurrentMethod().Name;
                _db.EntityLogs.Add(_entityLog);
                _db.SaveChanges();
            }
        }

        public Article FindbyId(int id)
        {
            _entityLog.Job = Enum.EntityJob.Read;
            _entityLog.Method = MethodBase.GetCurrentMethod().Name;
            _db.EntityLogs.Add(_entityLog);
            _db.SaveChanges();
            return _db.Articles.SingleOrDefault(c => c.Id == id);

        }

        public Enum.EntityResult Update(Article modified)
        {
            try
            {
                _db.Entry(modified).State = EntityState.Modified;
                _entityLog.EntityResult = Enum.EntityResult.Success;
                return Enum.EntityResult.Success;
            }
            catch (Exception e)
            {
                _entityLog.ErrorId = e.HResult;
                _entityLog.Detail = e.Message;
                _entityLog.EntityResult = Enum.EntityResult.Failed;

                return Enum.EntityResult.Failed;
            }
            finally
            {
                _entityLog.Job = Enum.EntityJob.Update;
                _entityLog.Method = MethodBase.GetCurrentMethod().Name;
                _db.EntityLogs.Add(_entityLog);
                _db.SaveChanges();
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
                _entityLog.EntityResult = Enum.EntityResult.Success;
                return Enum.EntityResult.Success;
            }
            catch (Exception e)
            {
                _entityLog.ErrorId = e.HResult;
                _entityLog.Detail = e.Message;
                _entityLog.EntityResult = Enum.EntityResult.Failed;

                return Enum.EntityResult.Failed;
            }
            finally
            {
                _entityLog.Job = Enum.EntityJob.Delete;
                _entityLog.Method = MethodBase.GetCurrentMethod().Name;
                _db.EntityLogs.Add(_entityLog);
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
