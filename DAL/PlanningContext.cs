using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using DAL.Entites;

namespace DAL
{
    public class PlanningContext : DbContext
    {
        public PlanningContext() : base("DBConnection") 
        {
            //Database.Create(); //была ошибка связанна с созданием БД
        }
        public DbSet<Programmer> Programmers { get; set; }
        public DbSet<Assignment> Assignments { get; set; }
        public DbSet<StatusTask> StatusTasks { get; set; }
    }
}
