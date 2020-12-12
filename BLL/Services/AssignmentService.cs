using BLL.Interfaces;
using BLL.DTO;
using DAL.Interfaces;
using DAL.Entites;
using DAL.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using BLL.Infrastructure;

namespace BLL.Services
{
    public class AssignmentService : IAssignmentService
    {
        public IUnitOfWork Database { get; set; }

        public AssignmentService(IUnitOfWork unitOfWork)
        {
            Database = unitOfWork;
        }
        public IEnumerable<AssignmentDTO> GetAllAssignments()
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Assignment, AssignmentDTO>());
            var mapper = new Mapper(config);
            var assignments = mapper.Map<IEnumerable<Assignment>, List<AssignmentDTO>>(Database.Assignments.GetAll());
            return assignments;
        }

        public AssignmentDTO GetAssignmentById(int? id)
        {
            if (id == null)
            {
                throw new ValidationException("No assignment with this ID!");
            }

            var config = new MapperConfiguration(cfg => cfg.CreateMap<Assignment, AssignmentDTO>());
            var mapper = new Mapper(config);
            var assignment = Database.Assignments.Get(id.Value);

            if (assignment == null) 
            {
                throw new ValidationException("Assignment was not found!");
            }

            return mapper.Map<Assignment, AssignmentDTO>(assignment);
        }
        public IEnumerable<AssignmentDTO> GetAllAssignmentsByTimeToDo(double time) //doesn't using ;(
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Assignment, AssignmentDTO>());
            var mapper = new Mapper(config);
            var assignments = mapper.Map<IEnumerable<Assignment>, List<AssignmentDTO>>(Database.Assignments.Find(assig => assig.TimeToDo == time));
            return assignments;
        }
        public void UpdateAssignment(AssignmentDTO assignment)
        {
            Assignment assig = Database.Assignments.Get(assignment.Id);
            if (assig == null)
            {
                throw new ValidationException("Assignment was not found!");
            }

            assig.Description = assignment.Description;
            assig.Priority = assignment.Priority;
            assig.TimeToDo = assignment.TimeToDo;
            assig.ProgrammerId = assignment.ProgrammerId;
            assig.StatusTaskId = assignment.StatusTaskId;

            Database.Assignments.Update(assig);
        }
        public void DeleteAssignmentById(int? id)
        {
            if (id == null)
            {
                throw new ValidationException("No assignment with this ID!");
            }
            Database.Assignments.Delete(id.Value);
            Database.Save();
        }
        public void CreateAssignment(AssignmentDTO assignment)
        {
            Programmer programmer = Database.Programmers.Get(assignment.ProgrammerId);
            StatusTask statusTask = Database.StatusTasks.Get(assignment.StatusTaskId);
            if (programmer == null && statusTask == null)
            {
                throw new ValidationException("Programmer or Status Task is null!");
            }

            Assignment assig = new Assignment()
            {
                Description = assignment.Description,
                Priority = assignment.Priority,
                TimeToDo = assignment.TimeToDo,
                ProgrammerId = programmer.Id,
                StatusTaskId = statusTask.Id
            };

            Database.Assignments.Create(assig);
            Database.Save();
        }
        public void Dispose()
        {
            Database.Dispose();
        }
    }
}
