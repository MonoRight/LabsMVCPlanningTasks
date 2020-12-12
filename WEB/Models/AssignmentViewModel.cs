using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace WEB.Models
{
    public class AssignmentViewModel
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public int Priority { get; set; }
        public int TimeToDo { get; set; }
        public int ProgrammerId { get; set; }
        public int StatusTaskId { get; set; }
    }
}