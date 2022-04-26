using System;
using System.Linq;
using System.Windows.Forms;
using VLTMTool.Controller.Infrastructure;

namespace VLTMTool.Infrastructure
{
    public class ApplicationModuleView : ApplicationModuleController
    {
        public override void Load()
        {
            base.Load();
            //Para "Bind" todos los formularios.
            Type formType = typeof(Form);
            Type userType = typeof(UserControl);

            var assemblies = AppDomain.CurrentDomain.GetAssemblies().Where(w => w.FullName.StartsWith("VLTMTool"));

            foreach (var assembly in assemblies)
            {
                var types = assembly.GetTypes();

                foreach (var type in types)
                {
                   if (formType.IsAssignableFrom(type))
                    {
                        Bind(typeof(Form)).To(type).Named(type.Name);
                    }

                    else if (userType.IsAssignableFrom(type))
                    {
                        Bind(typeof(UserControl)).To(type).Named(type.Name);
                    }
                }
            }
        }
    }
}