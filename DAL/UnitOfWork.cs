using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Entites;
using DAL.Interfaces;
using DAL.Repositories;

namespace DAL
{
    public class UnitOfWork: IUnitOfWork
    {
        private PlanningContext db;
        private AssignmentRepository assignmentRepository;
        private ProgrammerRepository programmerRepository;
        private StatusTaskRepository statusTaskRepository;

        public UnitOfWork()
        {
            db = new PlanningContext();
        }
        public IRepository<Assignment> Assignments
        {
            get
            {
                if (assignmentRepository == null)
                {
                    assignmentRepository = new AssignmentRepository(db);
                }
                return assignmentRepository;
            }
        }

        public IRepository<Programmer> Programmers
        {
            get
            {
                if (programmerRepository == null)
                {
                    programmerRepository = new ProgrammerRepository(db);
                }
                return programmerRepository;
            }
        }

        public IRepository<StatusTask> StatusTasks
        {
            get
            {
                if (statusTaskRepository == null)
                {
                    statusTaskRepository = new StatusTaskRepository(db);
                }
                return statusTaskRepository;
            }
        }

        public void Save()
        {
            db.SaveChanges();
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    db.Dispose();
                }
                disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
