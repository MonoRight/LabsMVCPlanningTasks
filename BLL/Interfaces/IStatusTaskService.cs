using DAL.Entites;
using BLL.DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Interfaces
{
    public interface IStatusTaskService
    {
        void UpdateStatusTask(StatusTaskDTO statusTask);
        StatusTaskDTO GetStatusTaskById(int? id);
        IEnumerable<StatusTaskDTO> GetAllStatusTask();
        void CreateStatusTask(StatusTaskDTO statusTask);
        void Dispose();
    }
}
