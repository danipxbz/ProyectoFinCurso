using log4net;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Windows.Forms;
using VLTMTool.Controller.Infrastructure;
using VLTMTool.Controller2.Controllers;
using VLTMTool.ViewModel;
using LinqKit;
using VLTMTTool;
using C1.Win.C1FlexGrid;
using C1.Win.C1Input;
using C1.Win.C1List;
using VLTMTool.Model.Infrastructure;
using VLTMTool.Forms.Subforms;

namespace VLTMTool.Forms
{
    public partial class TicketsGestion : Form
    {
        #region Properties
        internal static readonly ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        TicketGestionController ControllerTG;
        VMTickets newTicket;
        List<Priority> listPriorities = new ListPriorities().listPriorities;
        Image imgFolder = (Image)VLTMTool.Properties.Resources.iconfinder_clipboard_list_16x16;
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
                dataGridViewTickets.Rows.Count = 20;
                
                if (ControllerTG.GetAllTechnicals().Select(x => x.TechnicalUser.ToLower()).ToList().Contains(LoginInfo.UserName.ToLower()))
                {
                    chbShowDeleteTickets.Visible = true;
                    btnDeleteTicket.Visible = true;
                }
                else
                {
                    inputCreationUser.Value = LoginInfo.UserName;
                    inputCreationUser.Enabled = false;
                    inputCreationUser.BackColor = Color.LightYellow;
                }
                dataGridViewTickets.Cols.Insert(13);
                dataGridViewTickets.Cols[13].Caption = "Subject";
                //dataGridViewTickets.Cols[13].
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
            FilterClear(this);
            btnDeleteTicket.Enabled = false;
        }
        private void buttonSearch_Click(object sender, EventArgs e)
        {
            FilterSearch();
            btnDeleteTicket.Enabled = true;
        }
        private void buttonAddTicket_Click(object sender, EventArgs e)
        {
            newTicket = new VMTickets(DateTime.Now, LoginInfo.UserName);
            OpenTicketForm();
        }
        
        private void inputTicketNumber_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                buttonSearch_Click(sender, e);
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
        private void buttonIdentificationManually_Click(object sender, EventArgs e)
        {
            InsertIdentificationManually IdentForm = new InsertIdentificationManually();
            if (IdentForm.ShowDialog() == DialogResult.OK)
            {
                // TODO 
            }
        }
        private void btnClose_Click(object sender, EventArgs e)
        {
            Close();
        }
        #endregion

        #region Methods
        private void FilterSearch()
        {
            try
            {
                ExpressionStarter <VMvTickets> predicate = PredicateBuilder.New<VMvTickets>();

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
                    int filterInputAppModule = int.Parse(inputAppModule.SelectedValue.ToString().ToLower().Trim());
                    predicate = predicate.And(x => x.IdSection == filterInputAppModule);
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
                    predicate = predicate.And(x => x.IdStatus == int.Parse(filterInputStatus.ToString()));
                }
                //else if (chbShowDeleteTickets.Checked)
                //    predicate = predicate.And(x => x.IdStatus == Constants.STATUS_DELETE_ID);
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

                if (!chbShowDeleteTickets.Checked)
                    bsFiltersTickets.DataSource = ControllerTG.LoadTickets(predicate).Where(x => x.IdStatus != Constants.STATUS_DELETE_ID).OrderBy(x => x.TicketDate).ToList();
                else
                    bsFiltersTickets.DataSource = ControllerTG.LoadTickets(predicate).OrderBy(x => x.TicketDate).ToList();
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
            inputApplication.DataSource = ControllerTG.GetAllTHORApplications().ToList();
            inputAppModule.DataSource = ControllerTG.GetAllTHORApplicationSections();
            inputType.DataSource = ControllerTG.GetAllTicketsTypes();
            inputStatus.DataSource = ControllerTG.GetAllStatus().Where(x => x.IdStatus != Constants.STATUS_DELETE_ID).ToList();
            inputPriority.ValueMember = "Value";
            inputPriority.DisplayMember = "Display";
            inputPriority.DataSource = listPriorities.Select(x => new { Value = x.Value, Display = x.Display }).ToList();
            inputPriority.Columns[0].Caption = "Value";
            inputPriority.Columns[1].Caption = "Display";
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

        #region Events
        private void inputApplication_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(inputApplication.Text))
                inputAppModule.DataSource = ControllerTG.GetAllTHORApplicationSections();
            else
                inputAppModule.DataSource = ControllerTG.GetAllTHORApplicationSections().Where(x => x.AppCode.Trim().Equals(inputApplication.SelectedValue)).ToList();
            this.SetC1ComboVisibleFields(this);
        }
        private void inputTicketNumber_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true;
            }
        }
        private void inputAppVersion_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar) &&
                (e.KeyChar != '.'))
            {
                e.Handled = true;
            }
        }
        private void chbShowDeleteTickets_CheckedChanged(object sender, EventArgs e)
        {
            if (chbShowDeleteTickets.Checked)
            {
                inputStatus.SelectedIndex = -1;
                inputStatus.Enabled = false;
            }
            else
                inputStatus.Enabled = true;
        }
        private void dataGridViewTickets_OwnerDrawCell(object sender, C1.Win.C1FlexGrid.OwnerDrawCellEventArgs e)
        {
            try
            {
                if (e.Row > 0 && e.Col == 1)
                {
                    DateTime lastAccess = ControllerTG.GetLastAccess(int.Parse(dataGridViewTickets.GetDataDisplay(e.Row, "IdTicket").ToString()));
                    DateTime lastMessageDate = ControllerTG.GetMessageHistory().OrderByDescending(x => x.MessageDate).Where(x => x.IdTicket == int.Parse(dataGridViewTickets.GetDataDisplay(e.Row, "IdTicket").ToString())).Select(x => x.MessageDate).First();
                    string lastMessageUser = ControllerTG.GetMessageHistory().OrderByDescending(x => x.MessageDate).Where(x => x.IdTicket == int.Parse(dataGridViewTickets.GetDataDisplay(e.Row, "IdTicket").ToString())).Select(x => x.User).First();
                    
                    if (lastAccess < lastMessageDate && !lastMessageUser.Equals(LoginInfo.UserName))
                    {
                        var img1_x = e.Bounds.X + dataGridViewTickets.Cols[e.Col].Width / 2 - imgFolder.Width / 2;

                        var img1_loc = new Point(img1_x, e.Bounds.Y);
                        e.Graphics.DrawImage(imgFolder, img1_loc);
                        e.Handled = true;
                    }
                }
            }
            catch (FormatException ec)
            {
                Console.WriteLine(ec.Message);
            }
            catch (Exception ex)
            {
                log.Error(ex);
            }
        }
        private void dataGridViewTickets_MouseDoubleClick(object sender, MouseEventArgs e)
        {
            try
            {
                C1FlexGrid grid = (C1FlexGrid)sender;
                if (dataGridViewTickets.Rows.Count > 1 && !string.IsNullOrEmpty(dataGridViewTickets.GetDataDisplay(dataGridViewTickets.RowSel, "IdTicket").ToString()))
                {
                    float lastPositionY = (dataGridViewTickets.Rows.Count * Constants.HEIGHT_ROW_GRID_TICKETS) + dataGridViewTickets.Location.Y;
                    if (e.Location.Y < lastPositionY && e.Location.Y > dataGridViewTickets.Location.Y)
                    {
                        int idTicket = (int)dataGridViewTickets.GetData(dataGridViewTickets.RowSel, "IdTicket");
                        newTicket = ControllerTG.GetAllTickets().Where(x => x.IdTicket == idTicket).FirstOrDefault();
                        ControllerTG.CreateTicketAccess(newTicket, LoginInfo.UserName, "Read");
                        OpenTicketForm();
                    }
                }
            }
            catch (Exception ex)
            {
                log.Error(ex);
            }
        }
        #endregion
    }
}
