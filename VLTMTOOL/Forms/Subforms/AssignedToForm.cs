using log4net;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VLTMTool.Controller.Infrastructure;
using VLTMTool.Controller2.Controllers;
using VLTMTool.ViewModel;

namespace VLTMTool.Forms.Subforms
{
    public partial class AssignedToForm : Form
    {
        #region Properties
        internal static readonly ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public int IdUserAsigned { get; set; }
        #endregion

        #region constructor
        public AssignedToForm()
        {
            TicketGestionController Controller = CompositionRoot.Resolve<TicketGestionController>();
            InitializeComponent();
            inputAssignedTo.DataSource = Controller.GetAllTechnicals().ToList();
            inputAssignedTo.Splits[0].DisplayColumns[0].Visible = false;
            inputAssignedTo.Splits[0].DisplayColumns[1].Visible = false;
        }
        #endregion

        #region methods
        private void c1ButtonAccept_Click(object sender, EventArgs e)
        {
            IdUserAsigned = int.Parse(inputAssignedTo.SelectedValue.ToString());
            DialogResult = DialogResult.OK;
            Close();
        }
        private void c1ButtonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
        #endregion


    }
}
