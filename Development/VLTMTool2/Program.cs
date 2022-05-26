using log4net;
using System;
using System.Windows.Forms;
using VLTMTool.Controller.Infrastructure;
using VLTMTool.Forms;
using VLTMTool.Infrastructure;

namespace VLTMTTool
{
    static class Program
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
                    //try
                    //{
                    //    if (args.Any())
                    //    {
                    //        if (args.Where(s => s.StartsWith("/u")).Any())
                    //        {
                    //            // user is first argument, required
                    //            LoginInfo.UserName = args.Where(s => s.StartsWith("/u")).FirstOrDefault().ToString().Remove(0, 2);

                    //            System.Guid guidExt = new Guid();
                    //            // guid external is second argument, optional
                    //            if (args.Where(s => s.StartsWith("/g")).Any())
                    //            {
                    //                guidExt = new Guid(args.Where(s => s.StartsWith("/g")).FirstOrDefault().ToString().Remove(0, 2));
                    //            }

                    //            // form name is third argument, if it is empty, the form name default is Main
                    //            string formName = ConfigurationManager.AppSettings["Main"];
                    //            if (args.Where(s => s.StartsWith("/f")).Any())
                    //            {
                    //                formName = args.Where(s => s.StartsWith("/f")).FirstOrDefault().ToString().Remove(0, 2);
                    //                switch (formName.ToLower())
                    //                {
                    //                    case "certificates":
                    //                        if (!AppRole.HasFunctionsGrants(Functions.PRODUCT_CERTIF_ACCESS))
                    //                            return;
                    //                        break;
                    //                    case "equipmentcalibrations":
                    //                        if (!AppRole.HasFunctionsGrants(Functions.EQUIPMENT_CALIBRATIONS_ACCESS))
                    //                            return;
                    //                        break;
                    //                    case "masterprocedure":
                    //                        if (!AppRole.HasFunctionsGrants(Functions.MASTER_PROCEDURES_ACCESS))
                    //                            return;
                    //                        break;
                    //                    case "masterstandards":
                    //                        if (!AppRole.HasFunctionsGrants(Functions.MASTER_STANDARDS_ACCESS))
                    //                            return;
                    //                        break;
                    //                    case "mastertests":
                    //                        if (!AppRole.HasFunctionsGrants(Functions.MASTER_TESTS_ACCESS))
                    //                            return;
                    //                        break;
                    //                    case "mastertestplans":
                    //                        if (!AppRole.HasFunctionsGrants(Functions.MASTER_TESTS_PLANS_ACCESS))
                    //                            return;
                    //                        break;
                    //                    case "radiationsdb":
                    //                        if (!AppRole.HasFunctionsGrants(Functions.MASTER_RADIATIONS_ACCESS))
                    //                            return;
                    //                        break;
                    //                    default:
                    //                        if (!AppRole.HasFunctionsGrants(Functions.ACCESS))
                    //                            return;
                    //                        break;
                    //                }
                    //            }
                    //            session.guid = guidExt;
                    //            session.Start();
                    //            session.accessType = AccessType.FromOtherApp;
                    //            Form form = CompositionRoot.Resolve<Form>(formName);
                    //            form.WindowState = FormWindowState.Maximized;
                    //            Application.Run(form);
                    //            return;
                    //        }
                    //        else
                    //        {
                    //            log.Warn("Argument number is incorrect.");
                    //        }
                    //    }
                    //}
                    //catch (Exception ex)
                    //{
                    //    log.Error(ex.Message, ex);
                    //}
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
