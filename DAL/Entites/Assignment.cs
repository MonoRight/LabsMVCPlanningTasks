using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entites
{
    public class Assignment
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public int Priority { get; set; }
        public int TimeToDo { get; set; }
        public int ProgrammerId { get; set; }
        public Programmer Programmers { get; set; }
        public int StatusTaskId { get; set; }
        public StatusTask StatusTask { get; set; }
    }
}
