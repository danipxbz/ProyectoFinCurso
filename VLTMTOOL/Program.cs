using log4net;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using VLTMTool.Controller.Infrastructure;
using VLTMTool.Forms;
using VLTMTool.Infrastructure;
using VLTMTool.Model.Model;
using VLTMTool.ViewModel;

namespace VLTMTTool
{
    internal static class Program
    {
        internal static readonly ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        /// Punto de entrada principal para la aplicación.
        /// </summary>
        [STAThread]
        static void Main(string [] args)
        {
            log.Info("Start application");
            try
            {
                Application.EnableVisualStyles();
                Application.SetCompatibleTextRenderingDefault(false);
                log.Info("Application Started");
                CompositionRoot.Wire(new ApplicationModuleView());

                try
                {
                    try
                    {
                        Login login = CompositionRoot.Resolve<Login>();
                        Application.Run(login);

                        if (login.DialogResult == DialogResult.OK)
                        {
                            Application.Run(new TicketsGestion());
                        }
                    }
                    catch (Exception ex)
                    {
                        log.Error(ex);
                    }

                }
                catch (Exception ex)
                {
                    log.Error(ex.Message, ex);
                }
            }
            catch (Exception ex)
            {
                log.Error(ex.Message, ex);
            }
            
        }
    }
}
