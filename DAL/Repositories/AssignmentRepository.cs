using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL;
using DAL.Entites;
using DAL.Interfaces;

namespace DAL.Repositories
{
    public class AssignmentRepository : IRepository<Assignment>
    {
        private PlanningContext db;
        private bool disposedValue = false;

        public AssignmentRepository(PlanningContext context)
        {
            this.db = context;
        }

        public IEnumerable<Assignment> GetAll()
        {
            return db.Assignments;
        }

        public Assignment Get(int id)
        {
            return db.Assignments.Find(id);
        }

        public void Create(Assignment assignment)
        {
            db.Assignments.Add(assignment);
        }

        public void Update(Assignment assignment)
        {
            if (assignment != null)
            {
                db.SaveChanges();
            }
        }

        public IEnumerable<Assignment> Find(Func<Assignment, Boolean> predicate)
        {
            return db.Assignments.Where(predicate).ToList();
        }
        public void Delete(int id)
        {
            Assignment assignment = db.Assignments.Find(id);
            if (assignment != null)
                db.Assignments.Remove(assignment);
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
