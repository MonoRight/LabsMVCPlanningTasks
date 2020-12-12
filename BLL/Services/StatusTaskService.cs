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
    public class StatusTaskService :IStatusTaskService
    {
        public IUnitOfWork Database { get; set; }

        public StatusTaskService(IUnitOfWork unitOfWork)
        {
            Database = unitOfWork;
        }
        public IEnumerable<StatusTaskDTO> GetAllStatusTask()
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<StatusTask, StatusTaskDTO>());
            var mapper = new Mapper(config);
            var statuses = mapper.Map<IEnumerable<StatusTask>, List<StatusTaskDTO>>(Database.StatusTasks.GetAll());
            return statuses;
        }
        public StatusTaskDTO GetStatusTaskById(int? id)
        {
            if (id == null)
            {
                throw new ValidationException("No statuses with this ID!");
            }

            var config = new MapperConfiguration(cfg => cfg.CreateMap<StatusTask, StatusTaskDTO>());
            var mapper = new Mapper(config);
            var status = Database.StatusTasks.Get(id.Value);

            if (status == null)
            {
                throw new ValidationException("TaskStatus was not found!");
            }

            return mapper.Map<StatusTask, StatusTaskDTO>(status);
        }
        public void UpdateStatusTask(StatusTaskDTO statusTask)
        {
            StatusTask status = Database.StatusTasks.Get(statusTask.Id);
            if (status == null)
            {
                throw new ValidationException("TaskStatus was not found!");
            }

            status.Status = statusTask.Status;
            status.DateTime = statusTask.DateTime;

            Database.StatusTasks.Update(status);
        }
        public void CreateStatusTask(StatusTaskDTO statusTask)
        {
            StatusTask status = new StatusTask()
            {
                Status = statusTask.Status,
                DateTime = statusTask.DateTime
            };

            Database.StatusTasks.Create(status);
            Database.Save();
        }

        public void Dispose()
        {
            Database.Dispose();
        }
    }
}
