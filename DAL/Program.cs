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
    class Program
    {
        static void Main(string[] args)
        {
            UnitOfWork db = new UnitOfWork();

            Console.WriteLine(db.Programmers.Get(1));
 
        }
    }
}
