using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entites
{
    public class Programmer
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int NumOfTusks { get; set; }
        public ICollection<Assignment> Assignments { get; set; }
        public Programmer()
        {
            Assignments = new List<Assignment>();
        }
    }
}
