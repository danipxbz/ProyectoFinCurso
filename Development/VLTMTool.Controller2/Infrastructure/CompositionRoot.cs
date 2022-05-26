using Ninject;
using Ninject.Modules;

namespace VLTMTool.Controller.Infrastructure
{
    public class CompositionRoot
    {
        public static IKernel ninjectKernel;
        public static void Wire(INinjectModule module)
        {
            ninjectKernel = new StandardKernel(module);
        }

        public static T Resolve<T>()
        {
            return ninjectKernel.Get<T>();
        }
    }
}
