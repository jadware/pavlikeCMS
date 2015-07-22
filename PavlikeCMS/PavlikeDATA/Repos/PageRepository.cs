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
    public class PageRepository
    {
        readonly Context _db = new Context();
        private readonly EntityLog _entityLog = new EntityLog { Class = MethodBase.GetCurrentMethod().DeclaringType.Name, EntityModel = "Author" };
        public List<Page> GetAll()
        {
            _entityLog.Job = Enum.EntityJob.Read;
            _entityLog.Method = MethodBase.GetCurrentMethod().Name;
            _db.EntityLogs.Add(_entityLog);
            _db.SaveChanges();
            return _db.Pages.Where(c => c.Active).Include(c => c.Author).Include(c => c.RootPage).OrderBy(c => c.PageOrder).ToList();

        }

        public Enum.EntityResult Create(Page page)
        {
            try
            {
                page.Active = true;
                _db.Pages.Add(page);
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

        public Page FindbyId(int id)
        {
            _entityLog.Job = Enum.EntityJob.Read;
            _entityLog.Method = MethodBase.GetCurrentMethod().Name;
            _db.EntityLogs.Add(_entityLog);
            _db.SaveChanges();
            return _db.Pages.SingleOrDefault(c => c.Id == id);

        }

        public Enum.EntityResult Update(Page modified)
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

        public Enum.EntityResult Disable(Page disable)
        {
            disable.Active = false;
            return Update(disable);

        }

        public Enum.EntityResult Delete(Page delete)
        {
            try
            {
                _db.Pages.Remove(delete);
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
