using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Entites
{
    public class StatusTask
    {
        public int Id { get; set; }
        public DateTime DateTime { get; set; }
        public string Status { get; set; }
        public ICollection<Assignment> Assignments { get; set; }

        public StatusTask()
        {
            Assignments = new List<Assignment>();
        }
    }
}
