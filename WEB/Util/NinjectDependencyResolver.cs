using BLL.Services;
using System.Web.Mvc;
using Ninject;
using System.Collections.Generic;
using System;
using BLL.Interfaces;

namespace WEB.Util
{
    public class NinjectDependencyResolver :IDependencyResolver
    {
        private IKernel kernel;
        public NinjectDependencyResolver(IKernel kernelParam)
        {
            kernel = kernelParam;
            AddBindings();
        }
        public object GetService(Type serviceType)
        {
            return kernel.TryGet(serviceType);
        }
        public IEnumerable<object> GetServices(Type serviceType)
        {
            return kernel.GetAll(serviceType);
        }
        private void AddBindings()
        {
            kernel.Bind<IAssignmentService>().To<AssignmentService>();
            kernel.Bind<IProgrammerService>().To<ProgrammerService>();
            kernel.Bind<IStatusTaskService>().To<StatusTaskService>();
        }
    }
}