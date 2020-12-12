using BLL.DTO;
using DAL.Entites;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IAssignmentService
    {
        IEnumerable<AssignmentDTO> GetAllAssignments();
        AssignmentDTO GetAssignmentById(int? id);
        IEnumerable<AssignmentDTO> GetAllAssignmentsByTimeToDo(double time);
        void UpdateAssignment(AssignmentDTO assignment);
        void DeleteAssignmentById(int? id);
        void CreateAssignment(AssignmentDTO assignment);
        void Dispose();
    }
}
