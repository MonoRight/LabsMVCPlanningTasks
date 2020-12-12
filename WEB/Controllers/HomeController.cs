using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BLL.Services;
using BLL.DTO;
using BLL.Interfaces;
using AutoMapper;
using WEB.Models;
using DAL;

namespace WEB.Controllers
{
    public class HomeController : Controller
    {
        IProgrammerService programmerService;
        IAssignmentService assignmentService;
        IStatusTaskService statusTaskService;
        UnitOfWork uow;

        public HomeController()
        {
            uow = new UnitOfWork();

            this.assignmentService = new AssignmentService(uow);
            this.programmerService = new ProgrammerService(uow);
            this.statusTaskService = new StatusTaskService(uow);
        }

        public ActionResult Index()
        {
            var config = new MapperConfiguration(cfg => cfg.CreateMap<AssignmentDTO, AssignmentViewModel>());
            var mapper = new Mapper(config);
            IEnumerable<AssignmentViewModel> assignments = mapper.Map<IEnumerable<AssignmentDTO>, List<AssignmentViewModel>>(assignmentService.GetAllAssignments());

            var config1 = new MapperConfiguration(cfg => cfg.CreateMap<ProgrammerDTO, ProgrammerViewModel>());
            var mapper1 = new Mapper(config1);
            IEnumerable<ProgrammerViewModel> programmers = mapper1.Map<IEnumerable<ProgrammerDTO>, List<ProgrammerViewModel>>(programmerService.GetAllProgramists());
            ViewBag.Programmers = programmers;

            var config2 = new MapperConfiguration(cfg => cfg.CreateMap<StatusTaskDTO, StatusTaskViewModel>());
            var mapper2 = new Mapper(config2);
            IEnumerable<StatusTaskViewModel> statuses = mapper2.Map<IEnumerable<StatusTaskDTO>, List<StatusTaskViewModel>>(statusTaskService.GetAllStatusTask());
            ViewBag.Status = statuses;

            return View(assignments);
        }

       
    }
}