using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DAL.Entites;

namespace DAL.Interfaces
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<Assignment> Assignments { get; }
        IRepository<Programmer> Programmers { get; }
        IRepository<StatusTask> StatusTasks { get; }
        void Save();
    }
}
