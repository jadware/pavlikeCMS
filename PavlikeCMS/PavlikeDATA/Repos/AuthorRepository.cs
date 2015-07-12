using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using PavlikeDATA.Models;
using Enum = pavlikeLibrary.Enum;

namespace PavlikeDATA.Repos
{
    public class AuthorRepository
    {
        readonly Context _db = new Context();
        private readonly EntityLog _entityLog = new EntityLog { Class = MethodBase.GetCurrentMethod().DeclaringType.Name, EntityModel = "Author" };

        public List<Author> GetAll()
        {
            _entityLog.Job = Enum.EntityJob.Read;
            _entityLog.Method = MethodBase.GetCurrentMethod().Name;
            _db.EntityLogs.Add(_entityLog);
            _db.SaveChanges();
            return _db.Authors.ToList();
        }

        public Enum.EntityResult Create(Author authormodel)
        {

            try
            {
                _db.Authors.Add(authormodel);
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
    }
}
