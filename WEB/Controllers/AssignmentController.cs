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
    public class AssignmentController : Controller
    {
        IAssignmentService assignmentService;
        UnitOfWork uow;

        public AssignmentController()
        {
            uow = new UnitOfWork();
            assignmentService = new AssignmentService(uow);
        }
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetAssignmentById(int? id)
        {
            AssignmentViewModel assignment;
            try
            {
                var config = new MapperConfiguration(cfg => cfg.CreateMap<AssignmentDTO, AssignmentViewModel>());
                var mapper = new Mapper(config);
                try
                {
                    assignment = mapper.Map<AssignmentDTO, AssignmentViewModel>(assignmentService.GetAssignmentById(id)); //id.Value?
                }
                catch (ValidationException e)
                {
                    ModelState.AddModelError(e.Message, e);
                    return Content(e.Message);
                }
                return View(assignment);
            }
            catch (ValidationException e)
            {
                ModelState.AddModelError(e.Message, e);
                return Content(e.Message);
            }
        }

        public ActionResult UpdateAssignment(AssignmentViewModel assignmentView)
        {
            try
            {
                if (assignmentView.Id > 0 && assignmentView.Priority > 0 && assignmentView.Description != null
                    && assignmentView.TimeToDo > 0 && assignmentView.ProgrammerId > 0 && assignmentView.StatusTaskId > 0)
                {
                    var progr = assignmentService.GetAssignmentById(assignmentView.Id);
                    var config = new MapperConfiguration(cfg => cfg.CreateMap<AssignmentViewModel, AssignmentDTO>());
                    var mapper = new Mapper(config);
                    assignmentService.UpdateAssignment(mapper.Map<AssignmentViewModel, AssignmentDTO>(assignmentView));
                    return View(assignmentView);
                }
                else
                {
                    return View(assignmentView);
                }
            }
            catch (ValidationException e)
            {
                ModelState.AddModelError(e.Message, e);
                return Content(e.Message);
            }
        }
        
        public ActionResult DeleteAssignment(int? id)
        {
            try
            {
                assignmentService.DeleteAssignmentById(id);
            }
            catch (ValidationException e)
            {
                return Content(e.Message);
            }

            return View();
        }

        [HttpPost]
        public ActionResult CreateAssignment(AssignmentViewModel assignmentView)
        {
            try
            {
                if (assignmentView.Id > 0 && assignmentView.Priority > 0 && assignmentView.Description != null
                    && assignmentView.TimeToDo > 0 && assignmentView.ProgrammerId > 0 && assignmentView.StatusTaskId > 0)
                {
                    AssignmentDTO assignment = new AssignmentDTO()
                    {
                        Description = assignmentView.Description,
                        Priority = assignmentView.Priority,
                        TimeToDo = assignmentView.TimeToDo,
                        ProgrammerId = assignmentView.ProgrammerId,
                        StatusTaskId = assignmentView.StatusTaskId
                    };

                    assignmentService.CreateAssignment(assignment);
                    return Content("<h2>Assignment was added!</h2>");
                    //return View(assignmentView);
                }
                else
                {
                    return View(assignmentView);
                }
            }
            catch (ValidationException e)
            {
                ModelState.AddModelError(e.Message, e);
                //return Content(e.Message);
            }
            return View(assignmentView);
        }

        public ActionResult CreateAssignment(int? id)
        {
            try
            {
                var config = new MapperConfiguration(cfg => cfg.CreateMap<AssignmentDTO, AssignmentViewModel>());
                var mapper = new Mapper(config);
                var assignment = mapper.Map<AssignmentDTO, AssignmentViewModel>(assignmentService.GetAssignmentById(id));
                return View(assignment);
            }
            catch (ValidationException e)
            {
                ModelState.AddModelError(e.Message, e);
                return Content(e.Message);
            }
        }

        protected override void Dispose(bool disposing)
        {
            assignmentService.Dispose();
            base.Dispose(disposing);
        }
    }
}