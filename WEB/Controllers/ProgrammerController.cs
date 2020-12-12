using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using AutoMapper;
using BLL.DTO;
using BLL.Interfaces;
using BLL.Services;
using DAL;
using BLL.Infrastructure;
using WEB.Models;

namespace WEB.Controllers
{
    public class ProgrammerController : Controller
    {
        IProgrammerService programmerService;
        UnitOfWork uow;

        public ProgrammerController()
        {
            uow = new UnitOfWork();
            programmerService = new ProgrammerService(uow);
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetProgrammerById(int? id)
        {
            ProgrammerViewModel programmer;
            try
            {
                var config = new MapperConfiguration(cfg => cfg.CreateMap<ProgrammerDTO, ProgrammerViewModel>());
                var mapper = new Mapper(config);
                try
                {
                    programmer = mapper.Map<ProgrammerDTO, ProgrammerViewModel>(programmerService.GetProgrammerById(id)); //id.Value?
                }
                catch (ValidationException e)
                {
                    ModelState.AddModelError(e.Message, e);
                    return Content(e.Message);
                }
                return View(programmer);
            }
            catch (ValidationException e)
            {
                ModelState.AddModelError(e.Message, e);
                return Content(e.Message);
            }
        }

        [Route("Programmer/GetProgrammersByName/{*name}")]
        public ActionResult GetProgrammersByName(string name)
        {
            try
            {
                var config = new MapperConfiguration(cfg => cfg.CreateMap<ProgrammerDTO, ProgrammerViewModel>());
                var mapper = new Mapper(config);
                IEnumerable<ProgrammerViewModel> programmers = mapper.Map<IEnumerable<ProgrammerDTO>, IEnumerable<ProgrammerViewModel>>(programmerService.GetProgrammersByName(name));
                return View(programmers);
            }
            catch(Exception e)
            {
                return Content(e.Message);
            }
        }

        public ActionResult CreateProgrammer(ProgrammerViewModel programmerView)
        {
            try
            {
                if (programmerView.Name != null && programmerView.Surname != null && programmerView.NumOfTusks > 0) 
                {
                    ProgrammerDTO progr = new ProgrammerDTO()
                    {
                        Name = programmerView.Name,
                        Surname = programmerView.Surname,
                        NumOfTusks = programmerView.NumOfTusks
                    };

                    programmerService.CreateProgrammer(progr);
                    return View(programmerView);
                }
                else
                {
                    return View(programmerView);
                }
            }
            catch(ValidationException e)
            {
                ModelState.AddModelError(e.Message, e);
                return Content(e.Message);
            }
        }

        public ActionResult UpdateProgrammer(ProgrammerViewModel programmerView)
        {
            try
            {
                if (programmerView.Name != null && programmerView.Surname != null && programmerView.NumOfTusks > 0 && programmerView.Id > 0)
                {
                    var progr = programmerService.GetProgrammerById(programmerView.Id);
                    var config = new MapperConfiguration(cfg => cfg.CreateMap<ProgrammerViewModel, ProgrammerDTO>());
                    var mapper = new Mapper(config);
                    programmerService.UpdateProgrammer(mapper.Map<ProgrammerViewModel, ProgrammerDTO>(programmerView));
                    return View(programmerView);
                }
                else
                {
                    return View(programmerView);
                }
            }
            catch(ValidationException e)
            {
                ModelState.AddModelError(e.Message, e);
                return Content(e.Message);
            }
        }

        public ActionResult DeleteProgrammer(int? id)
        {
            try
            {
                programmerService.DeleteProgrammerById(id);
            }
            catch(ValidationException e)
            {
                return Content(e.Message);
            }

            return View();
        }


        protected override void Dispose(bool disposing)
        {
            programmerService.Dispose();
            base.Dispose(disposing);
        }
    }
}