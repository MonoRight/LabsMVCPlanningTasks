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
    public class StatusTaskController : Controller
    {
        IStatusTaskService statusTaskService;
        UnitOfWork uow;

        public StatusTaskController()
        {
            uow = new UnitOfWork();
            statusTaskService = new StatusTaskService(uow);
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult GetStatusTaskById(int? id)
        {
            StatusTaskViewModel statusTask;
            try
            {
                var config = new MapperConfiguration(cfg => cfg.CreateMap<StatusTaskDTO, StatusTaskViewModel>());
                var mapper = new Mapper(config);
                try
                {
                    statusTask = mapper.Map<StatusTaskDTO, StatusTaskViewModel>(statusTaskService.GetStatusTaskById(id)); //id.Value?
                }
                catch (ValidationException e)
                {
                    ModelState.AddModelError(e.Message, e);
                    return Content(e.Message);
                }
                return View(statusTask);
            }
            catch (ValidationException e)
            {
                ModelState.AddModelError(e.Message, e);
                return Content(e.Message);
            }
        }

        public ActionResult CreateStatusTask(StatusTaskViewModel statusTaskView)
        {
            try
            {
                if (statusTaskView.DateTime != null && statusTaskView.Status != null)
                {
                    StatusTaskDTO statusTask = new StatusTaskDTO()
                    {
                        DateTime = statusTaskView.DateTime,
                        Status = statusTaskView.Status
                    };

                    statusTaskService.CreateStatusTask(statusTask);
                    return View(statusTaskView);
                }
                else
                {
                    return View(statusTaskView);
                }
            }
            catch (ValidationException e)
            {
                ModelState.AddModelError(e.Message, e);
                return Content(e.Message);
            }
        }

        public ActionResult UpdateStatusTask(StatusTaskViewModel statusTaskView)
        {
            try
            {
                if (statusTaskView.DateTime != null && statusTaskView.Status != null)
                {
                    var status = statusTaskService.GetStatusTaskById(statusTaskView.Id);
                    var config = new MapperConfiguration(cfg => cfg.CreateMap<StatusTaskViewModel, StatusTaskDTO>());
                    var mapper = new Mapper(config);
                    statusTaskService.UpdateStatusTask(mapper.Map<StatusTaskViewModel, StatusTaskDTO>(statusTaskView));
                    return View(statusTaskView);
                }
                else
                {
                    return View(statusTaskView);
                }
            }
            catch (ValidationException e)
            {
                ModelState.AddModelError(e.Message, e);
                return Content(e.Message);
            }
        }

        protected override void Dispose(bool disposing)
        {
            statusTaskService.Dispose();
            base.Dispose(disposing);
        }
    }
}