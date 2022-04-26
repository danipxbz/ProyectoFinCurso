using log4net;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using VLTMTool;
using VLTMTool.Controller.Infrastructure;
using VLTMTool.Controller2.Controllers;
using VLTMTool.Forms.Subforms;
using VLTMTool.Messages;
using VLTMTool.ViewModel;

namespace VLTMTTool
{
    public partial class AutoTicketGeneration : Form
    {

        #region Properties
        internal static readonly ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        AutoTicketGenerationController ControllerFormGeneration;
        VMTickets Ticket;
        List<Priority> listPriorities = new ListPriorities().listPriorities;
        #endregion

        #region Constructors
        public AutoTicketGeneration()
        {
            InitializeComponent();
        }
        public AutoTicketGeneration(VMTickets ticket)
        {
            InitializeComponent();
            try
            {
                log.Info("Cargando AutoFormulario.");
                ControllerFormGeneration = CompositionRoot.Resolve<AutoTicketGenerationController>();
                Ticket = ticket;
                log.Info("Cargando datos en los combo.");
                ChargeCombos();
                bsTicket.DataSource = Ticket;
                ChargeForm();
            }
            catch (Exception ex)
            {
                log.Error(ex);
            }
        }
        #endregion

        #region Actions

        #region Buttons
        private void buttonCancel_Click(object sender, EventArgs e)
        {
            log.Info("Cerrando formulario");
            this.Close();
        }
        private void buttonAccept_Click(object sender, EventArgs e)
        {
            Ticket.Comment = inputDescription.Text;

            if (FieldsValidations()) MessageBox.Show(Messages.AlertIncorrectsFields, Messages.AlertTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
            {
                try
                {
                    ControllerFormGeneration.SaveTicket(Ticket);
                    DialogResult = DialogResult.OK;
                    MessageBox.Show(Messages.SaveTicket, Messages.CorrectFieldsTitle, MessageBoxButtons.OK, MessageBoxIcon.Information);
                    Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(Messages.ErrorSaveTicket, Messages.ErrorTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
        }
        private void buttonSendMessage_Click(object sender, EventArgs e)
        {
            sendMessage();
        }
        private void c1TextBoxMesssageToSend_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                sendMessage();
            }
        }
        private void btnChangeStatus_Click(object sender, EventArgs e)
        {
            Button btn = sender as Button;
            if (btn.Equals(btnStatusAssignTo))
            {
                AssignedToForm formAssignedTo = new AssignedToForm();
                if (formAssignedTo.ShowDialog() == DialogResult.OK)
                {
                    Ticket.AsignedTo = formAssignedTo.IdUserAsigned;
                    ControllerFormGeneration.CreateTicketStatus(Ticket, Constants.STATUS_ASSIGN_ID, Constants.STATUS_ASSIGN_NAME);
                }
            }
            else if (btn.Equals(btnStatusResolveForVersion))
            {
                ControllerFormGeneration.CreateTicketStatus(Ticket, Constants.STATUS_RESOLVE_VERSION_ID, Constants.STATUS_RESOLVE_VERSION_NAME);
            }
            else if (btn.Equals(btnStatusResolveForValidation))
            {
                ControllerFormGeneration.CreateTicketStatus(Ticket, Constants.STATUS_RESOLVE_VALIDATION_ID, Constants.STATUS_RESOLVE_VALIDATION_NAME);
            }
            else if (btn.Equals(btnStatusPending))
            {
                ControllerFormGeneration.CreateTicketStatus(Ticket, Constants.STATUS_PENDING_ID, Constants.STATUS_PENDING_NAME);
            }
            else
            {
                ControllerFormGeneration.CreateTicketStatus(Ticket, Constants.STATUS_CLOSE_ID, Constants.STATUS_CLOSE_NAME);
            }
            StatusButtonsControls();
            LoadStatus();
            LoadAccess();
        }
        #endregion

        #region Pictures
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            searchFile(pictureBox1);
        }
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            searchFile(pictureBox2);
        }
        private void pictureBox3_Click(object sender, EventArgs e)
        {
            searchFile(pictureBox3);
        }
        private void pictureBox4_Click(object sender, EventArgs e)
        {
            searchFile(pictureBox4);
        }
        private void delPicture4_Click(object sender, EventArgs e)
        {
            delPicture(pictureBox4);
        }
        private void delPicture3_Click(object sender, EventArgs e)
        {
            delPicture(pictureBox3);
        }
        private void delPicture2_Click(object sender, EventArgs e)
        {
            delPicture(pictureBox2);
        }
        private void delPicture1_Click(object sender, EventArgs e)
        {
            delPicture(pictureBox1);
        }
        #endregion

        #endregion

        #region Methods
        private void ChargeForm()
        {
            try
            {
                if (Ticket.IdTicket <= 0)
                {
                    //Creo un nuevo estado como pendiente
                    ControllerFormGeneration.CreateTicketStatus(Ticket, Constants.STATUS_PENDING_ID, Constants.STATUS_PENDING_NAME);
                    // - Cambiamos el diseño del formulario, para nuevos tickets
                    //Quitar fila de botones para asignar estados
                    tableLayoutPanelGeneral.RowStyles[0].SizeType = SizeType.Absolute;
                    tableLayoutPanelGeneral.RowStyles[0].Height = 0;
                    //Quitar fila del grid para ver mensajes, accesos y estados
                    tableLayoutPanelGeneral.RowStyles[3].SizeType = SizeType.Absolute;
                    tableLayoutPanelGeneral.RowStyles[3].Height = 0;
                    //Establecer el tamaño del formulario más pequeño porque no se establecía automaticamente
                    this.Size = new System.Drawing.Size(this.MinimumSize.Width, this.MinimumSize.Height);

                }
                else
                {
                    //Titulo del formulario si está editando un ticket (Por defecto está el titulo Insert Ticket)
                    Text = "Ticket Data";
                    if (Ticket.AsignedTo.Equals(LoginInfo.UserName) || LoginInfo.UserName.Equals("RPEREZ"))
                    {
                        StatusButtonsControls();
                    }
                    else
                    {
                        tableLayoutPanelGeneral.RowStyles[0].SizeType = SizeType.Absolute;
                        tableLayoutPanelGeneral.RowStyles[0].Height = 0;
                        if (ControllerFormGeneration.GetAllTechnicals().Select(x => x.TechnicalUser).Contains(LoginInfo.UserName))
                        {
                            c1TextBoxMesssageToSend.ReadOnly = true;
                            buttonSendMessage.Enabled = false;
                            buttonAccept.Enabled = false;
                        }
                    }
                    InputsControls();
                    ImagesControls();
                    LoadMessages();
                    LoadStatus();
                    LoadAccess();
                }

                if (Ticket.IdType != Constants.IDTICKETERROR || (Ticket.IdTicket > 0 && Ticket.IdType == Constants.IDTICKETERROR && Ticket.TicketsExceptionInfo.ExceptionTrace == ""))
                {
                    //Quitar la fila del input Error Trace
                    tblData.RowStyles[1].SizeType = SizeType.Absolute;
                    tblData.RowStyles[1].Height = 0;
                }
                else
                {
                    bsExceptions.DataSource = Ticket.TicketsExceptionInfo;
                }
            }
            catch (Exception ex)
            {
                log.Error(ex);
            }
        }
        private void ChargeCombos()
        {
            inputApplication.DataSource = ControllerFormGeneration.GetAllTHORApplications();
            inputApplication.Splits[0].DisplayColumns[1].Visible = false;
            inputApplication.Splits[0].DisplayColumns[2].Visible = false;
            inputApplication.Splits[0].DisplayColumns[3].Visible = false;
            inputType.DataSource = ControllerFormGeneration.GetAllTicketsTypes();
            inputType.Splits[0].DisplayColumns[0].Visible = false;
            inputPrioritySuppUser.DataSource = ControllerFormGeneration.GetAllTechnicals();
            inputPrioritySuppUser.Splits[0].DisplayColumns[0].Visible = false;
            inputPrioritySuppUser.Splits[0].DisplayColumns[1].Visible = false;
            inputPrioritySuppUser.Splits[0].DisplayColumns[2].AutoSize();
            inputPriority.ValueMember = "Value";
            inputPriority.DisplayMember = "Display";
            inputPriority.DataSource = listPriorities.Select(x => new { Value = x.Value, Display = x.Display }).ToList();
            this.SetC1ComboVisibleFields(this);
        }
        private void InputsControls()
        {
            inputApplication.ReadOnly = true;
            inputApplication.EditorBackColor = Color.Beige;
            inputVersion.ReadOnly = true;
            inputVersion.BackColor = Color.Beige;
            inputModule.ReadOnly = true;
            inputModule.BackColor = Color.Beige;
            inputType.ReadOnly = true;
            inputType.EditorBackColor = Color.Beige;
            inputIdentification.BackColor = Color.Beige;
            inputIdentification.ReadOnly = true;
            inputDescription.BackColor = Color.Beige;
            inputDescription.ReadOnly = true;
        }
        private void ImagesControls()
        {
            if (Ticket.ImageFile1 == null)
            {
                tableLayoutPanelGeneral.RowStyles[2].SizeType = SizeType.Absolute;
                tableLayoutPanelGeneral.RowStyles[2].Height = 0;
            }
            else if (Ticket.ImageFile2 == null) pictureBox2.Visible = false;
            else if (Ticket.ImageFile3 == null) pictureBox3.Visible = false;
            else if (Ticket.ImageFile4 == null) pictureBox4.Visible = false;
            delPicture1.Visible = false;
            delPicture2.Visible = false;
            delPicture3.Visible = false;
            delPicture4.Visible = false;
        }
        private bool FieldsValidations()
        {
            bool error = false;

            if (Ticket.IdTicket <= 0 && Ticket.TicketDate.Day != DateTime.Now.Date.Day) error = true;
            else if (string.IsNullOrEmpty(Ticket.AppCode)) error = true;
            else if (string.IsNullOrEmpty(Ticket.AppVersion)) error = true;
            else if (string.IsNullOrEmpty(Ticket.AppModuleCode)) error = true;
            else if (string.IsNullOrEmpty(Ticket.User)) error = true;
            else if (Ticket.IdType == 0) error = true;
            else if (string.IsNullOrEmpty(Ticket.SourceIdentification)) error = true;
            else if (Ticket.IdType == Constants.IDTICKETERROR && string.IsNullOrEmpty(inputErrorTrace.Text)) error = true;
            return error;
        }
        private void CreateTicketMessage(string message)
        {
            VMTicketsMessagesHistory ticketMessage = new VMTicketsMessagesHistory()
            {
                IdTicket = Ticket.IdTicket,
                MessageDate = DateTime.Now,
                User = LoginInfo.UserName,
                Message = message
            };
            Ticket.TicketsMessagesHistory.Add(ticketMessage);
            ControllerFormGeneration.SaveTicketMessage(ticketMessage);
        }
        //
        //Method for search files when is clicked in PicturesBox
        //
        private void searchFile(PictureBox picture)
        {
            if (Ticket.IdTicket <= 0)
            {
                OpenFileDialog searchImage = new OpenFileDialog();
                searchImage.Filter = "JPG(*.jpg)|*.jpg|PNG(*.png)|*.png|All Files|*.*";
                searchImage.Title = "Explorador de archivos";
                searchImage.FilterIndex = 3;
                searchImage.RestoreDirectory = true;

                if (searchImage.ShowDialog() == DialogResult.OK && File.Exists(searchImage.FileName))
                {
                    string file = searchImage.FileName;

                    if (picture.Name.Equals("pictureBox1"))
                    {
                        picture.ImageLocation = file;
                        picture.SizeMode = PictureBoxSizeMode.StretchImage;
                        delPicture1.Visible = true;
                        delPicture1.BringToFront();
                        pictureBox2.Visible = true;
                    }
                    else if (picture.Name.Equals("pictureBox2"))
                    {
                        picture.ImageLocation = file;
                        picture.SizeMode = PictureBoxSizeMode.StretchImage;
                        delPicture2.Visible = true;
                        delPicture2.BringToFront();
                        pictureBox3.Visible = true;
                    }
                    else if (picture.Name.Equals("pictureBox3"))
                    {
                        picture.ImageLocation = file;
                        picture.SizeMode = PictureBoxSizeMode.StretchImage;
                        delPicture3.Visible = true;
                        delPicture3.BringToFront();
                        pictureBox4.Visible = true;
                    }
                    else if (picture.Name.Equals("pictureBox4"))
                    {
                        picture.ImageLocation = file;
                        picture.SizeMode = PictureBoxSizeMode.StretchImage;
                        delPicture4.Visible = true;
                        delPicture4.BringToFront();
                    }
                }
            }
            else
            {
                System.Diagnostics.Process.Start(picture.ImageLocation);
            }
        }
        //
        //Method for delele loads pictures in PictureBoxs (try out other method)
        //
        private void delPicture(PictureBox picture)
        {
            string file = "C:/Fuentes/VLTMTool/Repo/Development/VLTMTool2/Resources/insert_photo.png";
            //
            //Check if picture 4 is going to be deleted
            //
            if (picture.Name.Equals("pictureBox4"))
            {
                picture.ImageLocation = file;
                delPicture4.Visible = false;
            }
            //
            //Check if picture 3 is going to be deleted
            //
            if (picture.Name.Equals("pictureBox3"))
            {
                if (pictureBox4.ImageLocation.Equals(file))
                {
                    pictureBox4.Visible = false;
                    picture.ImageLocation = file;
                    delPicture3.Visible = false;
                }
                else
                {
                    picture.ImageLocation = pictureBox4.ImageLocation;
                    pictureBox4.ImageLocation = file;
                    delPicture4.Visible = false;
                }
            }
            //
            //Check if picture 2 is going to be deleted
            //
            if (picture.Name.Equals("pictureBox2"))
            {
                if (pictureBox3.ImageLocation.Equals(file))
                {
                    pictureBox3.Visible = false;
                    picture.ImageLocation = file;
                    delPicture2.Visible = false;
                }
                else if (pictureBox4.ImageLocation.Equals(file))
                {
                    pictureBox4.Visible = false;
                    picture.ImageLocation = pictureBox3.ImageLocation;
                    pictureBox3.ImageLocation = file;
                    delPicture3.Visible = false;
                }
                else
                {
                    picture.ImageLocation = pictureBox3.ImageLocation;
                    pictureBox3.ImageLocation = pictureBox4.ImageLocation;
                    pictureBox4.ImageLocation = file;
                    delPicture4.Visible = false;
                }
            }
            //
            //Check if picture 1 is going to be deleted
            //
            if (picture.Name.Equals("pictureBox1"))
            {
                if (pictureBox2.ImageLocation.Equals(file))
                {
                    pictureBox2.Visible = false;
                    picture.ImageLocation = file;
                    delPicture1.Visible = false;
                }
                else if (pictureBox3.ImageLocation.Equals(file))
                {
                    pictureBox3.Visible = false;
                    picture.ImageLocation = pictureBox2.ImageLocation;
                    pictureBox2.ImageLocation = file;
                    delPicture2.Visible = false;
                }
                else if (pictureBox4.ImageLocation.Equals(file))
                {
                    pictureBox4.Visible = false;
                    picture.ImageLocation = pictureBox2.ImageLocation;
                    pictureBox2.ImageLocation = pictureBox3.ImageLocation;
                    pictureBox3.ImageLocation = file;
                    delPicture3.Visible = false;
                }
                else
                {
                    picture.ImageLocation = pictureBox2.ImageLocation;
                    pictureBox2.ImageLocation = pictureBox3.ImageLocation;
                    pictureBox3.ImageLocation = pictureBox4.ImageLocation;
                    pictureBox4.ImageLocation = file;
                    delPicture4.Visible = false;
                }
            }
        }
        private void LoadMessages()
        {
            c1TextBoxMessagesHistory.ReadOnly = false;

            c1TextBoxMessagesHistory.Value = "";
            foreach (var item in Ticket.TicketsMessagesHistory.OrderByDescending(x => x.MessageDate))
            {
                string history = $"[ {item.User} - {item.MessageDate.ToShortDateString()} ]                            {Environment.NewLine}\t - {item.Message}{Environment.NewLine}";
                c1TextBoxMessagesHistory.Value += history;
            }
            c1TextBoxMessagesHistory.ReadOnly = true;
        }
        private void LoadStatus()
        {
            bsStatus.DataSource = Ticket.TicketsStatusHistory.OrderByDescending(x => x.StatusDate);
            bsStatus.ResetBindings(false);
        }
        private void LoadAccess()
        {
            bsAccess.DataSource = Ticket.TicketsAccessHistory.OrderByDescending(x => x.AccessDate);
            bsAccess.ResetBindings(false);
        }
        private void sendMessage()
        {
            if (!string.IsNullOrEmpty(c1TextBoxMesssageToSend.Text))
            {
                string message = c1TextBoxMesssageToSend.Text;

                CreateTicketMessage(message);
                ControllerFormGeneration.CreateTicketAccess(Ticket, LoginInfo.UserName, "Send message");

                c1TextBoxMesssageToSend.Value = "";

                LoadMessages();
                LoadAccess();
            }
        }
        private void StatusButtonsControls()
        {
            int status = Ticket.TicketsStatusHistory.OrderByDescending(x => x.StatusDate).Select(x => x.IdStatus).FirstOrDefault();
            switch (status)
            {
                case 1:
                    btnStatusAssignTo.Enabled = true;
                    btnStatusAssignTo.BackColor = Color.Transparent;
                    btnStatusResolveForVersion.Visible = false;
                    btnStatusResolveForValidation.Visible = false;
                    btnStatusPending.BackColor = Color.LightGreen;
                    btnStatusClose.Visible = false;
                    break;
                case 2:
                    btnStatusAssignTo.BackColor = Color.LightGreen;
                    btnStatusResolveForVersion.Enabled = true;
                    btnStatusResolveForVersion.BackColor = Color.Transparent;
                    btnStatusResolveForValidation.Visible = false;
                    btnStatusPending.Enabled = true;
                    btnStatusPending.BackColor = Color.Transparent;
                    btnStatusClose.Visible = false;
                    break;
                case 3:
                    btnStatusAssignTo.BackColor = Color.LightGreen;
                    btnStatusResolveForVersion.BackColor = Color.LightGreen;
                    btnStatusResolveForValidation.Enabled = true;
                    btnStatusResolveForValidation.BackColor = Color.Transparent;
                    btnStatusPending.Enabled = true;
                    btnStatusPending.BackColor = Color.Transparent;
                    btnStatusClose.Visible = false;
                    break;
                case 4:
                    btnStatusAssignTo.BackColor = Color.LightGreen;
                    btnStatusResolveForVersion.BackColor = Color.LightGreen;
                    btnStatusResolveForValidation.BackColor = Color.LightGreen;
                    btnStatusPending.Enabled = true;
                    btnStatusPending.BackColor = Color.Transparent;
                    btnStatusClose.Enabled = true;
                    btnStatusClose.BackColor = Color.Transparent;
                    break;
                case 5:
                    btnStatusAssignTo.Visible = false;
                    btnStatusResolveForVersion.Visible = false;
                    btnStatusResolveForValidation.Visible = false;
                    btnStatusPending.Enabled = true;
                    btnStatusClose.BackColor = Color.Transparent;
                    btnStatusClose.BackColor = Color.LightGreen;
                    break;
            }
        }
        #endregion

        #region Events
        private void inputDescription_TextChanged(object sender, EventArgs e)
        {
            labelTextLength.Text = inputDescription.Text.Length + "/1500";
        }

        #endregion
    }
}