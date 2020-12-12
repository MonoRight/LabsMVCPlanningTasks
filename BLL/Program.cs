using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BLL.DTO;
using BLL.Infrastructure;
using BLL.Interfaces;
using BLL.Services;
using DAL;

namespace BLL
{
    class Program
    {
        static void Main(string[] args)
        {
            UnitOfWork unitOfWork = new UnitOfWork();


            AssignmentService assignmentService = new AssignmentService(unitOfWork);

            AssignmentDTO assignmentDTO = new AssignmentDTO()
            {
                Id = 1,
                Description = "Do homework",
                Priority = 1,
                TimeToDo = 3,
                ProgrammerId = 1,
                StatusTaskId = 2
            };

            IEnumerable<AssignmentDTO> assignmentDTOs = assignmentService.GetAllAssignments();

            foreach (var i in assignmentDTOs)
            {
                Console.WriteLine(i.Id + " " + i.Description + " " + i.Priority + " " + i.TimeToDo + " " + i.ProgrammerId + " " + i.StatusTaskId);
            }

            Console.WriteLine("\n\n");
            assignmentService.UpdateAssignment(assignmentDTO);

            IEnumerable<AssignmentDTO> assignmentDTOss = assignmentService.GetAllAssignments();

            foreach(var i in assignmentDTOss)
            {
                Console.WriteLine(i.Id + " " + i.Description + " " + i.Priority + " " + i.TimeToDo + " " + i.ProgrammerId + " " + i.StatusTaskId);
            }

            ProgrammerService programmerService = new ProgrammerService(unitOfWork);

            ProgrammerDTO programmerDTO = new ProgrammerDTO()
            {
                Id = 4,
                Name = "KATYA",
                Surname = "YAYA",
                NumOfTusks = 2
            };

            var programmers = programmerService.GetAllProgramists();

            foreach (var i in programmers)
            {
                Console.WriteLine(i.Id + " " + i.Name + " " + i.Surname + " "  + i.NumOfTusks);
            }

            Console.WriteLine("\n\n");
            programmerService.UpdateProgrammer(programmerDTO);

            var programmerss = programmerService.GetAllProgramists();

            foreach (var i in programmerss)
            {
                Console.WriteLine(i.Id + " " + i.Name + " " + i.Surname + " " + i.NumOfTusks);
            }

            StatusTaskService statusTaskService = new StatusTaskService(unitOfWork);

            StatusTaskDTO taskStatus = new StatusTaskDTO()
            {
                Id = 1,
                Status = "WTF???",
                DateTime = DateTime.Now
            };

            var statustasks = statusTaskService.GetAllStatusTask();

            foreach (var i in statustasks)
            {
                Console.WriteLine(i.Id + " " + i.Status + " " + i.DateTime);
            }

            Console.WriteLine("\n\n");
            statusTaskService.UpdateStatusTask(taskStatus);

            var statustaskss = statusTaskService.GetAllStatusTask();

            foreach (var i in statustaskss)
            {
                Console.WriteLine(i.Id + " " + i.Status + " " + i.DateTime);
            }

            /*ProgrammerService programmerService = new ProgrammerService(unitOfWork);

            IEnumerable<ProgrammerDTO> programmerDTOs = programmerService.GetAllProgramists();

            foreach (var programmer in programmerDTOs)
            {
                Console.WriteLine(programmer.Id + " " + programmer.Name + " " + programmer.Surname + " " + programmer.NumOfTusks);
            }

            ProgrammerDTO programmerDTO = new ProgrammerDTO() { Id = 2, Name = "Olha", Surname = "Moshchytska", NumOfTusks = 1 };
            programmerService.UpdateProgrammer(programmerDTO);
            
            IEnumerable<ProgrammerDTO> programmerDTOss = programmerService.GetAllProgramists();

            foreach(var programmer in programmerDTOss)
            {
                Console.WriteLine(programmer.Id + " " + programmer.Name + " " + programmer.Surname + " " + programmer.NumOfTusks);
            }
            
            // Console.WriteLine(programmerService.GetAllProgramists());
                    
            var progr = programmerService.GetProgrammerById(1);
            Console.WriteLine("\n\n" + progr.Id + " " + progr.Name + " " + progr.Surname + " " + progr.NumOfTusks + "\n\n");

            // ProgrammerDTO programmerDTO = new ProgrammerDTO() { Name = "Kiril", Surname = "Ivanov", NumOfTusks = 2 };
            //programmerService.CreateProgrammer(programmerDTO);

            IEnumerable<ProgrammerDTO> programmerDTOsw = programmerService.GetAllProgramists().OrderBy(i => i.NumOfTusks).ThenBy(n => n.Name);

            foreach (var programmer in programmerDTOsw)
            {
                Console.WriteLine(programmer.Id + " " + programmer.Name + " " + programmer.Surname + " " + programmer.NumOfTusks);
            }

            AssignmentService assig = new AssignmentService(unitOfWork);
            var ass = assig.GetAllAssignments();

            foreach(var i in ass)
            {
                Console.WriteLine(i.Id + " " + i.Description + " " + i.ProgrammerId + " " + i.StatusTaskId + " " + i.Priority + " "+ i.TimeToDo);
            }

            var prog = programmerService.GetProgrammersByName("Olha");
            foreach(var i in prog)
            {
                Console.WriteLine(i.Name);
            }
            */

            //var assignmentService = new AssignmentService(unitOfWork);

            //assignmentService.CreateAssignment(new AssignmentDTO() { Description = "buy chocolate", Priority = 10, ProgrammerId = 6, StatusTaskId = 4, TimeToDo = 1 });

            //var Newprog = new ProgrammerDTO() { Name = "Oleksii", Surname = "Zahlistin", NumOfTusks = 1 };
            // programmerService.CreateProgrammer(Newprog);
        }
    }

}
