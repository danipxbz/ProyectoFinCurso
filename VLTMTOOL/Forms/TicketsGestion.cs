using log4net;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.IO;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VLTMTool.Controller.Infrastructure;
using VLTMTool.Controller2.Controllers;
using VLTMTool.Messages;
using VLTMTool.Model.Model;
using VLTMTool.ViewModel;
using LinqKit;
using VLTMTTool;
using C1.Win.C1FlexGrid;
using C1.Win.C1Input;
using C1.Win.C1List;

namespace VLTMTool.Forms
{
    public partial class TicketsGestion : Form
    {

        #region Properties
        internal static readonly ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        TicketGestionController ControllerTG;
        VMTickets newTicket;
        List<Priority> listPriorities = new ListPriorities().listPriorities;
        #endregion

        #region Constructors
        public TicketsGestion()
        {
            try
            {
                InitializeComponent();
                log.Info("Abriendo formulario de gestión de tickets.");
                ControllerTG = CompositionRoot.Resolve<TicketGestionController>();
                ChargeCombos();
                if (ControllerTG.GetAllTechnicals().Select(x => x.TechnicalUser).ToList().Contains(LoginInfo.UserName))
                {
                    btnDeleteTicket.Enabled = true;
                }
                else
                {
                    inputCreationUser.Value = LoginInfo.UserName;
                    inputCreationUser.Enabled = false;
                    inputCreationUser.BackColor = Color.LightYellow;
                }
            }
            catch (Exception ex)
            {
                log.Error(ex);
            }
        }
        #endregion

        #region Actions

        private void buttonClear_Click(object sender, EventArgs e)
        {
            FilterClear(panelFilters);
            FilterClear(panelGrid);
        }
        private void buttonSearch_Click(object sender, EventArgs e)
        {
            FilterSearch();
        }
        private void buttonAddTicket_Click(object sender, EventArgs e)
        {
            newTicket = new VMTickets(DateTime.Now, LoginInfo.UserName);
            OpenTicketForm();
        }
        private void dataGridViewTickets_DoubleClick(object sender, EventArgs e)
        {
            if (dataGridViewTickets.Rows.Count > 1 && !string.IsNullOrEmpty(dataGridViewTickets.GetDataDisplay(dataGridViewTickets.RowSel, "IdTicket").ToString()))
            {
                int idTicket = (int)dataGridViewTickets.GetData(dataGridViewTickets.RowSel, "IdTicket");
                newTicket = ControllerTG.GetAllTickets().Where(x => x.IdTicket == idTicket).FirstOrDefault();
                ControllerTG.CreateTicketAccess(newTicket, LoginInfo.UserName, "Read");
                OpenTicketForm();
            }
        }
        private void inputTicketNumber_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                FilterSearch();
            }
        }
        private void btnDeleteTicket_Click(object sender, EventArgs e)
        {
            int idTicket = (int)dataGridViewTickets.GetData(dataGridViewTickets.RowSel, "IdTicket");
            newTicket = ControllerTG.GetAllTickets().Where(x => x.IdTicket == idTicket).FirstOrDefault();

            ControllerTG.CreateTicketStatus(newTicket, Constants.STATUS_DELETE_ID, Constants.STATUS_DELETE_NAME);
            ControllerTG.CreateTicketAccess(newTicket, LoginInfo.UserName, "Delete");
            ControllerTG.SaveTicket(newTicket);

            FilterSearch();
        }
        #endregion

        #region Methods
        private void FilterSearch()
        {
            try
            {
                ExpressionStarter<VMvTickets> predicate = PredicateBuilder.New<VMvTickets>();

                #region Filters Texts

                if (!string.IsNullOrEmpty(inputTicketNumber.Text))
                {
                    int filterInputTicketNumber = int.Parse(inputTicketNumber.Text.Trim().ToString());
                    predicate = predicate.And(x => x.IdTicket == filterInputTicketNumber);
                }

                if (!string.IsNullOrEmpty(inputAppVersion.Text))
                {
                    string filterInputAppVersion = inputAppVersion.Text.ToLower().Trim();
                    predicate = predicate.And(x => x.AppVersion.ToLower().Contains(filterInputAppVersion));
                }

                if (!string.IsNullOrEmpty(inputCreationUser.Text))
                {
                    string filterInputCreationUser = inputCreationUser.Text.ToLower().Trim();
                    predicate = predicate.And(x => x.User.ToLower().Contains(filterInputCreationUser));
                }

                #endregion

                #region Filters Combos

                if (!string.IsNullOrEmpty(inputApplication.Text))
                {
                    string filterInputApplication = inputApplication.SelectedValue.ToString().ToLower().Trim();
                    predicate = predicate.And(x => x.AppCode.ToLower().Contains(filterInputApplication));
                }
                if (!string.IsNullOrEmpty(inputAppModule.Text))
                {
                    string filterInputAppModule = inputAppModule.SelectedValue.ToString().ToLower().Trim();
                    predicate = predicate.And(x => x.AppModuleCode.ToLower().Equals(filterInputAppModule));
                }
                if (!string.IsNullOrEmpty(inputType.Text))
                {
                    int filterInputType = int.Parse(inputType.SelectedValue.ToString().ToLower().Trim());
                    predicate = predicate.And(x => x.IdType == filterInputType);
                }
                if (!string.IsNullOrEmpty(inputPriority.Text))
                {
                    int filterInputPriority = int.Parse(inputPriority.SelectedValue.ToString().ToLower().Trim());
                    predicate = predicate.And(x => x.PriorityLevel == filterInputPriority);
                }
                if (!string.IsNullOrEmpty(inputStatus.Text))
                {
                    string filterInputStatus = inputStatus.SelectedValue.ToString().ToLower().Trim();
                    predicate = predicate.And(x => x.StatusName.ToLower().Equals(filterInputStatus));
                }
                #endregion

                #region Filters Dates

                if (inputCreationDateFrom.Value != null && !string.IsNullOrEmpty(inputCreationDateFrom.Text))
                {
                    DateTime filterInputCreationDateFrom = ((DateTime)inputCreationDateFrom.Value).Date;
                    predicate = predicate.And(x => x.TicketDate != null && x.TicketDate.CompareTo(filterInputCreationDateFrom) >= 0);
                }

                if (inputCreationDateTo.Value != null && !string.IsNullOrEmpty(inputCreationDateTo.Text))
                {
                    DateTime filterInputCreationDateTo = ((DateTime)inputCreationDateTo.Value).Date;
                    predicate = predicate.And(x => x.TicketDate != null && x.TicketDate.CompareTo(filterInputCreationDateTo) < 0);
                }

                if (inputCurrStDateFrom.Value != null && !string.IsNullOrEmpty(inputCurrStDateFrom.Text))
                {
                    DateTime filterinputCurrStDateFrom = ((DateTime)inputCurrStDateFrom.Value).Date;
                    predicate = predicate.And(x => x.TicketDate != null && x.TicketDate.CompareTo(filterinputCurrStDateFrom) >= 0);
                }

                if (inputCurrStDateTo.Value != null && !string.IsNullOrEmpty(inputCurrStDateTo.Text))
                {
                    DateTime filterinputCurrStDateTo = ((DateTime)inputCurrStDateTo.Value).Date;
                    predicate = predicate.And(x => x.TicketDate != null && x.TicketDate.CompareTo(filterinputCurrStDateTo) < 0);
                }

                #endregion

                bsFiltersTickets.DataSource = ControllerTG.LoadTickets(predicate).Where(x => x.IdStatus != Constants.STATUS_DELETE_ID).ToList();
            }
            catch (Exception ex)
            {
                log.Error(ex);
            }
        }
        private void FilterClear(Control ctl)
        {
            if (ctl.Controls.Count > 0)
            {
                foreach (Control item in ctl.Controls)
                {
                    if (item.Enabled)
                    {
                        if (typeof(C1TextBox) == item.GetType() || typeof(C1Combo) == item.GetType())
                        {
                            item.Text = String.Empty;
                        }
                        else if (typeof(C1DateEdit) == item.GetType())
                        {
                            C1DateEdit c1DateEdit = (C1DateEdit)item;
                            c1DateEdit.Value = DBNull.Value;
                        }
                        else if (typeof(C1FlexGrid) == item.GetType())
                        {
                            C1FlexGrid FlexGrid = (C1FlexGrid)item;
                            while (FlexGrid.Rows.Count > 1)
                            {
                                FlexGrid.Rows.Remove(1);
                            }
                        }
                    }
                    if (item.HasChildren)
                    {
                        FilterClear(item);
                    }
                }
            }
            else
            {
                if (ctl.Enabled)
                {
                    if (typeof(C1TextBox) == ctl.GetType() || typeof(C1Combo) == ctl.GetType())
                    {
                        ctl.Text = String.Empty;
                    }
                    else if (typeof(C1DateEdit) == ctl.GetType())
                    {
                        C1DateEdit c1DateEdit = (C1DateEdit)ctl;
                        c1DateEdit.Value = DBNull.Value;
                    }
                }
            }
        }
        private void ChargeCombos()
        {
            inputApplication.DataSource = ControllerTG.GetAllTHORApplications();
            inputAppModule.DataSource = ControllerTG.GetAllTHORApplicationsModules();
            inputType.DataSource = ControllerTG.GetAllTicketsTypes();
            inputStatus.DataSource = ControllerTG.GetAllStatus();
            inputPriority.ValueMember = "Value";
            inputPriority.DisplayMember = "Display";
            inputPriority.DataSource = listPriorities.Select(x => new { Value = x.Value, Display = x.Display }).ToList();
            inputPriority.Columns[0].Caption = "Value";
            inputPriority.Columns[1].Caption = "Display";
            inputPriority.Splits[0].DisplayColumns[0].AutoSize();
            inputPriority.Splits[0].DisplayColumns[0].Visible = false;
            inputPriority.AutoSize = true;
            this.SetC1ComboVisibleFields(this);
        }
        private void OpenTicketForm()
        {
            AutoTicketGeneration newForm = new AutoTicketGeneration(newTicket);
            if (newForm.ShowDialog() == DialogResult.OK)
            {
                FilterSearch();
            }
        }
        #endregion

    }
}
