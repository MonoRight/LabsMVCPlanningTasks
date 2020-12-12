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
    public class ProgrammerService : IProgrammerService
    {
        public IUnitOfWork Database { get; set; }

        public ProgrammerService(IUnitOfWork unitOfWork)
        {
            Database = unitOfWork;
        }

        public IEnumerable<ProgrammerDTO> GetAllProgramists()
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Programmer, ProgrammerDTO>());
            var mapper = new Mapper(config);
            var programmers = mapper.Map<IEnumerable<Programmer>, List<ProgrammerDTO>>(Database.Programmers.GetAll());
            return programmers;
        }
        public ProgrammerDTO GetProgrammerById(int? id)
        {
            if (id == null)
            {
                throw new ValidationException("No programmer with this ID!");
            }

            var config = new MapperConfiguration(cfg => cfg.CreateMap<Programmer, ProgrammerDTO>());
            var mapper = new Mapper(config);
            var programmer = Database.Programmers.Get(id.Value);

            if (programmer == null)
            {
                throw new ValidationException("Programmer was not found!");
            }

            return mapper.Map<Programmer, ProgrammerDTO>(programmer);
        }
        public IEnumerable<ProgrammerDTO> GetProgrammersByName(string name)
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<Programmer, ProgrammerDTO>());
            var mapper = new Mapper(config);
            var programmers = mapper.Map<IEnumerable<Programmer>, List<ProgrammerDTO>>(Database.Programmers.Find(progr => progr.Name == name));
            return programmers;
        }
        public void CreateProgrammer(ProgrammerDTO programmer)
        {
            Programmer progr = new Programmer()
            {
                Name = programmer.Name,
                Surname = programmer.Surname,
                NumOfTusks = programmer.NumOfTusks
            };

            Database.Programmers.Create(progr);
            Database.Save();
        }
        public void UpdateProgrammer(ProgrammerDTO programmer)
        {
            Programmer progr = Database.Programmers.Get(programmer.Id);
            if (progr == null)
            {
                throw new ValidationException("Programmer was not found!");
            }

            progr.Name = programmer.Name;
            progr.Surname = programmer.Surname;
            progr.NumOfTusks = programmer.NumOfTusks;

            Database.Programmers.Update(progr);
        }
        public void DeleteProgrammerById(int? id)
        {
            if (id == null)
            {
                throw new ValidationException("No programmer with this ID!");
            }
            Database.Programmers.Delete(id.Value);
            Database.Save();
        }
        public void Dispose()
        {
            Database.Dispose();
        }
    }
}
