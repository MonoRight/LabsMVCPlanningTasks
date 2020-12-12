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
    public class ProgrammerRepository: IRepository<Programmer>
    {
        private PlanningContext db;
        private bool disposedValue = false;

        public ProgrammerRepository(PlanningContext context)
        {
            this.db = context;
        }

        public IEnumerable<Programmer> GetAll()
        {
            return db.Programmers;
        }

        public Programmer Get(int id)
        {
            return db.Programmers.Find(id);
        }

        public void Create(Programmer programmer)
        {
            db.Programmers.Add(programmer);
        }

        public void Update(Programmer programmer)
        {
            if(programmer != null)
            {
                db.SaveChanges();
            }

            //db.Entry(programmer).State = EntityState.Modified;
        }
        public IEnumerable<Programmer> Find(Func<Programmer, Boolean> predicate)
        {
            return db.Programmers.Where(predicate).ToList();
        }
        public void Delete(int id)
        {
            Programmer programmer = db.Programmers.Find(id);
            if (programmer != null)
                db.Programmers.Remove(programmer);
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
