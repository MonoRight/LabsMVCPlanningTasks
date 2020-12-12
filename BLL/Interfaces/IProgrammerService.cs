using DAL.Entites;
using BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IProgrammerService
    {
        IEnumerable<ProgrammerDTO> GetAllProgramists();
        ProgrammerDTO GetProgrammerById(int? id);
        void UpdateProgrammer(ProgrammerDTO programmer);
        IEnumerable<ProgrammerDTO> GetProgrammersByName(string name);
        void DeleteProgrammerById(int? id);
        void CreateProgrammer(ProgrammerDTO programmer);
        void Dispose();
    }
}
