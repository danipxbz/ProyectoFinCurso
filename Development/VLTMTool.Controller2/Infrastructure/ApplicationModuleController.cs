using AutoMapper;
using Ninject.Modules;
using System;
using System.Linq;
using VLTMTool.Controller2.Mapping;
using VLTMTool.Model.Infractrusture;
using VLTMTool.Model.Services;

namespace VLTMTool.Controller.Infrastructure
{
    public class ApplicationModuleController : NinjectModule
    {
        public override void Load()
        {
            Bind(typeof(IDbFactoryVLTM)).To(typeof(DBFactory)).InSingletonScope();

            Type controllerType = typeof(ServiceBDBase);
            var assemblies = AppDomain.CurrentDomain.GetAssemblies().Where(w => w.FullName.StartsWith("VLTMTool"));

            foreach (var assembly in assemblies)
            {
                var types = assembly.GetTypes();
                foreach (var type in types)
                {
                    if (controllerType.IsAssignableFrom(type))
                    {
                        Bind(typeof(ServiceBDBase)).To(type).Named(type.Name);
                    }
                }
            }

            IMapper d = AutoMapperConfiguration.Configure();
            Bind(typeof(IMapper)).ToConstant(d);
        }
    }
}
