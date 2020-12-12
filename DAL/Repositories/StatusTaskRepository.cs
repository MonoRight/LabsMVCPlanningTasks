using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Entites;
using DAL.Interfaces;

namespace DAL.Repositories
{
    public class StatusTaskRepository :IRepository<StatusTask>
    {
        private PlanningContext db;
        private bool disposedValue = false;

        public StatusTaskRepository(PlanningContext context)
        {
            this.db = context;
        }

        public IEnumerable<StatusTask> GetAll()
        {
            return db.StatusTasks;
        }

        public StatusTask Get(int id)
        {
            return db.StatusTasks.Find(id);
        }

        public void Create(StatusTask statusTask)
        {
            db.StatusTasks.Add(statusTask);
        }

        public void Update(StatusTask statusTask)
        {
            if (statusTask != null)
            {
                db.SaveChanges();
            }
            //db.Entry(statusTask).State = EntityState.Modified;
        }
        public IEnumerable<StatusTask> Find(Func<StatusTask, Boolean> predicate)
        {
            return db.StatusTasks.Where(predicate).ToList();
        }
        public void Delete(int id)
        {
            StatusTask statusTask = db.StatusTasks.Find(id);
            if (statusTask != null)
                db.StatusTasks.Remove(statusTask);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (!disposedValue)
            {
                if (disposing)
                {
                    db.Dispose();
                }
                disposedValue = true;
            }
        }

        public void Dispose()
        {
            Dispose(disposing: true);
            GC.SuppressFinalize(this);
        }
    }
}
