
using C1.Win.C1Input;
using C1.Win.C1List;
using log4net;
using Microsoft.VisualBasic.Devices;
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
using VLTMTool.Model.Infrastructure;
using VLTMTool.Properties;
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
        Computer myComputer = new Computer();
        #endregion

        #region Constructors
        public AutoTicketGeneration(VMTickets ticket)
        {
            InitializeComponent();
            try
            {
                log.Info("Cargando formulario de incidencia.");
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
                    try
                    {
                        SaveImages(pictureBox1, 1);
                        SaveImages(pictureBox2, 2);
                        SaveImages(pictureBox3, 3);
                        SaveImages(pictureBox4, 4);
                    }
                    catch (Exception ex)
                    {
                        log.Error(ex);
                        MessageBox.Show(Messages.ErrorSaveImages, Messages.AlertTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                    ControllerFormGeneration.SaveTicket(Ticket);
                    ControllerFormGeneration.NotifyEmail(Ticket);
                    DialogResult = DialogResult.OK;
                    Close();
                }
                catch (Exception ex)
                {
                    log.Error(ex);
                    MessageBox.Show(Messages.ErrorSaveTicket, Messages.ErrorTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
        private void btnIdentificationManually_Click(object sender, EventArgs e)
        {
            InsertIdentificationManually IdentForm = new InsertIdentificationManually();
            if (IdentForm.ShowDialog() == DialogResult.OK)
            {
                Ticket.SourceIdentification = IdentForm.identificationJSON;
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
            try
            {
                if (btn.Equals(btnStatusAssignTo))
                {
                    AssignedToForm formAssignedTo = new AssignedToForm();
                    if (formAssignedTo.ShowDialog() == DialogResult.OK)
                    {
                        Ticket.AsignedTo = formAssignedTo.IdUserAsigned;
                        ControllerFormGeneration.CreateTicketStatus(Ticket, Constants.STATUS_ASSIGN_ID, Constants.STATUS_ASSIGN_NAME);
                    }
                }
                else if (btn.Equals(btnAssumeIt))
                {
                    int idTechAssume = ControllerFormGeneration.GetAllTechnicals().Where(x => x.TechnicalUser == LoginInfo.UserName).Select(x => x.IdTechnical).First();
                    Ticket.AsignedTo = idTechAssume;
                    ControllerFormGeneration.CreateTicketStatus(Ticket, Constants.STATUS_ASSIGN_ID, Constants.STATUS_ASSIGN_NAME);
                }
                else if (btn.Equals(btnStatusResolveForVersion))
                {
                    TimeToResolve timeResolvedForm = new TimeToResolve();
                    if (timeResolvedForm.ShowDialog() == DialogResult.OK)
                    {
                    ControllerFormGeneration.CreateTicketStatus(
                        Ticket,
                        Constants.STATUS_RESOLVE_VERSION_ID,
                        Constants.STATUS_RESOLVE_VERSION_NAME,
                        timeResolvedForm.versionResolved,
                        timeResolvedForm.timeForResolved
                        );
                    }
                }
                else if (btn.Equals(btnStatusResolveForValidation))
                {
                    ControllerFormGeneration.CreateTicketStatus(
                        Ticket,
                        Constants.STATUS_RESOLVE_VALIDATION_ID,
                        Constants.STATUS_RESOLVE_VALIDATION_NAME,
                        Ticket.TicketsStatusHistory.Where(x => x.IdStatus == Constants.STATUS_RESOLVE_VERSION_ID).OrderByDescending(x => x.StatusDate).Select(x => x.ResolvedVersion).FirstOrDefault()
                        );
                }
                else if (btn.Equals(btnStatusPending) && !LoginInfo.UserName.ToLower().Equals(Constants.TECHNIC_ADMIN.ToLower()))
                {
                    Ticket.AsignedTo = null;
                    ControllerFormGeneration.CreateTicketStatus(Ticket, Constants.STATUS_PENDING_ID, Constants.STATUS_PENDING_NAME);
                }
                else
                {
                    ControllerFormGeneration.CreateTicketStatus(
                        Ticket,
                        Constants.STATUS_CLOSE_ID,
                        Constants.STATUS_CLOSE_NAME,
                        Ticket.TicketsStatusHistory.Where(x => x.IdStatus == Constants.STATUS_RESOLVE_VALIDATION_ID).OrderByDescending(x => x.StatusDate).Select(x => x.ResolvedVersion).FirstOrDefault()
                        );
                }
                StatusButtonsControls();
                LoadStatus();
                LoadAccess();
            }
            catch (Exception ex)
            {
                log.Error(ex);
            }
        }
        #endregion

        #region Pictures
        private void pictureBox1_Click(object sender, EventArgs e)
        {
            searchFile(pictureBox1, Ticket.ImageFile1);
        }
        private void pictureBox2_Click(object sender, EventArgs e)
        {
            searchFile(pictureBox2, Ticket.ImageFile2);
        }
        private void pictureBox3_Click(object sender, EventArgs e)
        {
            searchFile(pictureBox3, Ticket.ImageFile3);
        }
        private void pictureBox4_Click(object sender, EventArgs e)
        {
            searchFile(pictureBox4, Ticket.ImageFile4);
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
                    // - Cambiamos el diseño del formulario, para nuevos tickets
                    //Quitar fila de botones para asignar estados
                    tableLayoutPanelGeneral.RowStyles[0].SizeType = SizeType.Absolute;
                    tableLayoutPanelGeneral.RowStyles[0].Height = 0;
                    pictureBox1.Image = Resources.insert_photo;
                    pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
                    //Quitar fila del grid para ver mensajes, accesos y estados
                    tableLayoutPanelGeneral.RowStyles[3].SizeType = SizeType.Absolute;
                    tableLayoutPanelGeneral.RowStyles[3].Height = 0;
                    //Establecer el tamaño del formulario más pequeño porque no se establecía automaticamente
                    this.Size = new System.Drawing.Size(this.MinimumSize.Width, this.MinimumSize.Height);
                    if (!string.IsNullOrEmpty(Ticket.AppCode))
                        InputsControls(panelData);
                }
                else
                {
                    //Titulo del formulario si está editando un ticket (Por defecto está el titulo Insert Ticket)
                    Text = "Ticket Data";
                    
                    StatusButtonsControls();
                    InputsControls(panelData);
                    ImagesControls();
                    LoadMessages();
                    LoadStatus();
                    LoadAccess();
                    LoadButtons();
                }

                if (Ticket.IdType != Constants.IDTICKETERROR || (Ticket.IdTicket > 0 && Ticket.IdType == Constants.IDTICKETERROR && Ticket.TicketsExceptionInfo == null))
                {
                    //Quitar la fila del input Error Trace
                    tblData.RowStyles[1].SizeType = SizeType.Absolute;
                    tblData.RowStyles[1].Height = 0;
                }
                else
                {
                    bsExceptions.DataSource = Ticket.TicketsExceptionInfo;
                    InputsControls(panelData);
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
            inputModule.DataSource = ControllerFormGeneration.GetAllTHORApplicationSections();
            inputType.DataSource = ControllerFormGeneration.GetAllTicketsTypes();
            inputPrioritySuppUser.DataSource = ControllerFormGeneration.GetAllTechnicals();
            inputPriority.DataSource = new ListPriorities().listPriorities;
            this.SetC1ComboVisibleFields(this);
        }
        private void InputsControls(Control itemControl)
        {
            foreach (Control item in itemControl.Controls)
            {
                if (item.Enabled)
                {
                    if (typeof(C1TextBox) == item.GetType())
                    {
                        C1TextBox c1TextBox = (C1TextBox)item;
                        c1TextBox.ReadOnly = true;
                        c1TextBox.BackColor = Color.Beige;
                    }
                    else if (typeof(C1Combo) == item.GetType())
                    {
                        C1Combo c1Combo = (C1Combo)item;
                        c1Combo.ReadOnly = true;
                        c1Combo.EditorBackColor = Color.Beige;
                    }
                }
                if (item.HasChildren)
                {
                    InputsControls(item);
                }
            }
            if (Ticket.IdTicket <= 0)
            {
                inputPrioritySuppUser.ReadOnly = false;
                inputPrioritySuppUser.EditorBackColor = Color.White;
                inputDescription.ReadOnly = false;
                inputDescription.BackColor = Color.White;
                if (Ticket.IdType != Constants.IDTICKETERROR)
                {
                    inputType.ReadOnly = false;
                    inputType.EditorBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(128)))), ((int)(((byte)(255)))), ((int)(((byte)(255)))));
                }
            }
        }
        private void ImagesControls()
        {
            string pathTicketImage = Path.Combine(Constants.DEFAULTFILEPATH + "\\" + Ticket.IdTicket);
            DirectoryInfo dir = new DirectoryInfo(pathTicketImage);
            if (!dir.Exists)
            {
                tableLayoutPanelGeneral.RowStyles[2].SizeType = SizeType.Absolute;
                tableLayoutPanelGeneral.RowStyles[2].Height = 0;
            }
            else
            {
                FileInfo [] files = dir.GetFiles();
                if (files.Length == 0)
                {
                    tableLayoutPanelGeneral.RowStyles[2].SizeType = SizeType.Absolute;
                    tableLayoutPanelGeneral.RowStyles[2].Height = 0;
                }
                else
                {
                    ShowImage(pictureBox1, files[0].FullName);
                    if (files.Length > 2)
                    {
                        ShowImage(pictureBox2, files[1].FullName);
                        if (files.Length > 3)
                        {
                            ShowImage(pictureBox3, files[2].FullName);
                            if (files.Length > 4)
                            {
                                ShowImage(pictureBox4, files[3].FullName);
                            }
                        }
                    }
                }
                delPicture1.Visible = false;
                delPicture2.Visible = false;
                delPicture3.Visible = false;
                delPicture4.Visible = false;
            }
        }
        private void ShowImage(PictureBox picture, string finalPath)
        {
            picture.Visible = true;
            picture.ImageLocation = finalPath;
            picture.SizeMode = PictureBoxSizeMode.StretchImage;
        }
        private bool FieldsValidations()
        {
            bool error = false;

            if (Ticket.IdTicket <= 0 && Ticket.TicketDate.Day != DateTime.Now.Date.Day) error = true;
            else if (string.IsNullOrEmpty(Ticket.AppCode)) error = true;
            else if (string.IsNullOrEmpty(Ticket.AppVersion)) error = true;
            else if (string.IsNullOrEmpty(Ticket.IdSection.ToString())) error = true;
            else if (string.IsNullOrEmpty(Ticket.User)) error = true;
            else if (Ticket.IdType == 0) error = true;
            else if (Ticket.IdType == Constants.IDTICKETERROR && string.IsNullOrEmpty(inputErrorTrace.Text) && inputType.ReadOnly == true) error = true;
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
        private void searchFile(PictureBox picture, string imageFile)
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
                        Ticket.ImageFile1 = file;
                        delPicture1.Visible = true;
                        pictureBox2.Visible = true;
                        pictureBox2.Image = VLTMTool.Properties.Resources.insert_photo;
                    }
                    else if (picture.Name.Equals("pictureBox2"))
                    {
                        picture.ImageLocation = file;
                        picture.SizeMode = PictureBoxSizeMode.StretchImage;
                        Ticket.ImageFile2 = file;
                        delPicture2.Visible = true;
                        delPicture2.BringToFront();
                        pictureBox3.Visible = true;
                        pictureBox3.Image = VLTMTool.Properties.Resources.insert_photo;
                    }
                    else if (picture.Name.Equals("pictureBox3"))
                    {
                        picture.ImageLocation = file;
                        picture.SizeMode = PictureBoxSizeMode.StretchImage;
                        Ticket.ImageFile3 = file;
                        delPicture3.Visible = true;
                        delPicture3.BringToFront();
                        pictureBox4.Visible = true;
                        pictureBox4.Image = VLTMTool.Properties.Resources.insert_photo;
                    }
                    else if (picture.Name.Equals("pictureBox4"))
                    {
                        picture.ImageLocation = file;
                        picture.SizeMode = PictureBoxSizeMode.StretchImage;
                        Ticket.ImageFile4 = file;
                        delPicture4.Visible = true;
                        delPicture4.BringToFront();
                    }
                }
            }
            else
            {
                System.Diagnostics.Process.Start(imageFile);
            }
        }
        private void delPicture(PictureBox picture)
        {
            if (picture.Name.Equals("pictureBox4"))
            {
                picture.ImageLocation = "";
                picture.Image = VLTMTool.Properties.Resources.insert_photo;
                delPicture4.Visible = false;
            }
            if (picture.Name.Equals("pictureBox3"))
            {
                if (pictureBox4.ImageLocation.Equals(""))
                {
                    pictureBox4.Visible = false;
                    picture.ImageLocation = "";
                    picture.Image = VLTMTool.Properties.Resources.insert_photo;
                    delPicture3.Visible = false;
                }
                else
                {
                    picture.ImageLocation = pictureBox4.ImageLocation;
                    pictureBox4.ImageLocation = "";
                    pictureBox4.Image = VLTMTool.Properties.Resources.insert_photo;
                    delPicture4.Visible = false;
                }
            }
            if (picture.Name.Equals("pictureBox2"))
            {
                if (pictureBox3.ImageLocation.Equals(""))
                {
                    pictureBox3.Visible = false;
                    picture.ImageLocation = "";
                    picture.Image = VLTMTool.Properties.Resources.insert_photo;
                    delPicture2.Visible = false;
                }
                else if (pictureBox4.ImageLocation.Equals(""))
                {
                    pictureBox4.Visible = false;
                    picture.ImageLocation = pictureBox3.ImageLocation;
                    pictureBox3.ImageLocation = "";
                    pictureBox3.Image = VLTMTool.Properties.Resources.insert_photo;
                    delPicture3.Visible = false;
                }
                else
                {
                    picture.ImageLocation = pictureBox3.ImageLocation;
                    pictureBox3.ImageLocation = pictureBox4.ImageLocation;
                    pictureBox4.ImageLocation = "";
                    pictureBox4.Image = VLTMTool.Properties.Resources.insert_photo;
                    delPicture4.Visible = false;
                }
            }
            if (picture.Name.Equals("pictureBox1"))
            {
                if (pictureBox2.ImageLocation.Equals(""))
                {
                    pictureBox2.Visible = false;
                    picture.ImageLocation = "";
                    picture.Image = VLTMTool.Properties.Resources.insert_photo;
                    delPicture1.Visible = false;
                }
                else if (pictureBox3.ImageLocation.Equals(""))
                {
                    pictureBox3.Visible = false;
                    picture.ImageLocation = pictureBox2.ImageLocation;
                    pictureBox2.ImageLocation = "";
                    pictureBox2.Image = VLTMTool.Properties.Resources.insert_photo;
                    delPicture2.Visible = false;
                }
                else if (pictureBox4.ImageLocation.Equals(""))
                {
                    pictureBox4.Visible = false;
                    picture.ImageLocation = pictureBox2.ImageLocation;
                    pictureBox2.ImageLocation = pictureBox3.ImageLocation;
                    pictureBox3.ImageLocation = "";
                    pictureBox3.Image = VLTMTool.Properties.Resources.insert_photo;
                    delPicture3.Visible = false;
                }
                else
                {
                    picture.ImageLocation = pictureBox2.ImageLocation;
                    pictureBox2.ImageLocation = pictureBox3.ImageLocation;
                    pictureBox3.ImageLocation = pictureBox4.ImageLocation;
                    pictureBox4.ImageLocation = "";
                    pictureBox4.Image = VLTMTool.Properties.Resources.insert_photo;
                    delPicture4.Visible = false;
                }
            }
        }
        private void SaveImages(PictureBox picture, int numberImage)
        {
            if (!string.IsNullOrEmpty(picture.ImageLocation) && !picture.ImageLocation.Equals(""))
            {
                FileInfo fileInfo = new FileInfo(picture.ImageLocation);
                string finalPath = Path.Combine(Constants.DEFAULTFILEPATH + "\\" + Ticket.IdTicket + "\\" + numberImage + fileInfo.Extension);
                if (!File.Exists(finalPath))
                {
                    myComputer.FileSystem.CopyFile(picture.ImageLocation, finalPath, true);
                    switch (numberImage)
                    {
                        case 1:
                            Ticket.ImageFile1 = finalPath;
                            break;
                        case 2:
                            Ticket.ImageFile2 = finalPath;
                            break;
                        case 3:
                            Ticket.ImageFile3 = finalPath;
                            break;
                        case 4:
                            Ticket.ImageFile4 = finalPath;
                            break;
                    }
                }
            }
        }
        private void LoadMessages()
        {
            if (!Ticket.User.ToLower().Equals(LoginInfo.UserName.ToLower())
                && !LoginInfo.UserName.Equals(Constants.TECHNIC_ADMIN)
                && ControllerFormGeneration.GetAllTechnicals().Where(x => x.IdTechnical == Ticket.AsignedTo).Select(x => x.TechnicalUser.ToLower()).ToString() != LoginInfo.UserName.ToLower())
            {
                c1TextBoxMesssageToSend.ReadOnly = true;
                buttonSendMessage.Enabled = false;
            }
            c1TextBoxMessagesHistory.ReadOnly = false;

            c1TextBoxMessagesHistory.Value = "";
            foreach (var item in Ticket.TicketsMessagesHistory.OrderByDescending(x => x.MessageDate))
            {
                string history = $"[ {item.User} - {item.MessageDate} ]                            {Environment.NewLine}\t - {item.Message}{Environment.NewLine}";
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
            //Si no eres un tecnico
            if (!ControllerFormGeneration.GetAllTechnicals().Select(x => x.TechnicalUser.ToLower()).Contains(LoginInfo.UserName.ToLower()))
            {
                tableLayoutPanelGeneral.RowStyles[0].SizeType = SizeType.Absolute;
                tableLayoutPanelGeneral.RowStyles[0].Height = 0;
                if (!LoginInfo.UserName.ToLower().Equals(ControllerFormGeneration.GetLastUserChangeStatus(Ticket)))
                    buttonAccept.Visible = false;

                //Si no eres el usuario que creó el ticket
                if (!LoginInfo.UserName.Equals(Ticket.User))
                    InputsControls(panelData);
            }
            switch (status)
            {
                case 1:
                    btnAssumeIt.Visible = true;
                    btnStatusAssignTo.Enabled = true;
                    btnStatusAssignTo.BackColor = Color.Transparent;
                    if (!LoginInfo.UserName.ToLower().Equals(Constants.TECHNIC_ADMIN.ToLower()))
                    {
                        btnStatusAssignTo.Visible = false;
                    }
                    btnStatusResolveForVersion.Visible = false;
                    btnStatusResolveForValidation.Visible = false;
                    btnStatusPending.BackColor = Color.LightGreen;
                    btnStatusClose.Visible = false;
                    Ticket.AsignedTo = null;
                    break;
                case 2:
                    btnAssumeIt.Visible = false;
                    btnStatusAssignTo.Visible = true;
                    btnStatusAssignTo.Enabled = false;
                    btnStatusAssignTo.BackColor = Color.LightGreen;
                    btnStatusResolveForVersion.Visible = true;
                    btnStatusResolveForVersion.Enabled = true;
                    btnStatusResolveForVersion.BackColor = Color.Transparent;
                    btnStatusResolveForValidation.Visible = false;
                    btnStatusPending.Enabled = true;
                    btnStatusPending.BackColor = Color.Transparent;
                    btnStatusClose.Visible = false;
                    break;
                case 3:
                    if (LoginInfo.UserName == Ticket.User)
                    {
                        tableLayoutPanelGeneral.RowStyles[0].Height = 43;
                    }
                    btnStatusAssignTo.BackColor = Color.LightGreen;
                    btnStatusAssignTo.Enabled = false;
                    btnStatusResolveForVersion.BackColor = Color.LightGreen;
                    btnStatusResolveForVersion.Enabled = false;
                    btnStatusResolveForValidation.Enabled = true;
                    btnStatusResolveForValidation.BackColor = Color.Transparent;
                    btnStatusPending.Enabled = true;
                    btnStatusPending.BackColor = Color.Transparent;
                    btnStatusClose.Visible = false;
                    break;
                case 4:
                    btnStatusAssignTo.BackColor = Color.LightGreen;
                    btnStatusAssignTo.Enabled = false;
                    btnStatusResolveForVersion.BackColor = Color.LightGreen;
                    btnStatusResolveForVersion.Enabled = false;
                    btnStatusResolveForValidation.BackColor = Color.LightGreen;
                    btnStatusResolveForValidation.Enabled = false;
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
                case 6:
                    buttonSendMessage.Enabled = false;
                    c1TextBoxMesssageToSend.Enabled = false;
                    break;
            }
        }
        private string IsAssigned()
        {
            string assigned = "";
            if (Ticket.AsignedTo != null)
                assigned = ControllerFormGeneration.GetAllTechnicals().Where(x => x.IdTechnical == Ticket.AsignedTo).Select(x => x.TechnicalUser).ToList().First();
            return assigned;
        }
        private void LoadButtons()
        {
            if (!LoginInfo.UserName.Equals(Ticket.User) && !LoginInfo.UserName.ToLower().Equals(Constants.TECHNIC_ADMIN.ToLower()) && !LoginInfo.UserName.Equals(IsAssigned()))
                buttonAccept.Visible = false;
        }
        #endregion

        #region Events
        private void input_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                buttonAccept_Click(sender, e);
            }
        }
        private void inputDescription_TextChanged(object sender, EventArgs e)
        {
            labelTextLength.Text = inputDescription.Text.Length+"/1500";
        }
        private void inputApplication_TextChanged(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(inputApplication.Text))
                inputModule.DataSource = ControllerFormGeneration.GetAllTHORApplicationSections();
            else
                inputModule.DataSource = ControllerFormGeneration.GetAllTHORApplicationSections().Where(x => x.AppCode.Trim().Equals(inputApplication.SelectedValue.ToString().Trim())).ToList();
            this.SetC1ComboVisibleFields(this);
        }
        private void inputType_SelectedValueChanged(object sender, EventArgs e)
        {
            if (Ticket.IdTicket <= 0)
            {
                switch (inputType.SelectedValue)
                {
                    case Constants.TYPE_INTERNAL_INCIDENCE:
                        inputPriority.SelectedValue = 1;
                        Ticket.PriorityLevel = 1;
                        break;
                    case Constants.TYPE_ERROR:
                        inputPriority.SelectedValue = 1;
                        Ticket.PriorityLevel = 1;
                        break;
                    case Constants.TYPE_INCORRECT_FUNCTIONALITY:
                        inputPriority.SelectedValue = 3;
                        Ticket.PriorityLevel = 3;
                        break;
                    case Constants.TYPE_UPGRADE:
                        inputPriority.SelectedValue = 5;
                        Ticket.PriorityLevel = 5;
                        break;
                    case Constants.TYPE_SUPPORT_REQUEST:
                        inputPriority.SelectedValue = 3;
                        Ticket.PriorityLevel = 3;
                        break;
                    default:
                        inputPriority.SelectedIndex = -1;
                        break;
                }
            }
        }
        #endregion
    }
}