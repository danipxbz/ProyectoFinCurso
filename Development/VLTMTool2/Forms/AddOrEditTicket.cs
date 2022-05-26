using log4net;
using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;
using VLTMTool.Controller.Infrastructure;
using VLTMTool.Controller2.Controllers;
using VLTMTool.Forms.Subforms;
using VLTMTool.Messages;
using VLTMTool.ViewModel;

namespace VLTMTTool
{
    public partial class AddOrEditTicket : Form
    {

        #region Properties
        internal static readonly ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        AutoTicketGenerationController ControllerFormGeneration;
        VMTickets Ticket;
        #endregion

        #region Constructors
        public AddOrEditTicket()
        {
            InitializeComponent();
        }
        public AddOrEditTicket(VMTickets ticket)
        {
            InitializeComponent();
            try
            {
                log.Info("Cargando AutoFormulario.");
                ControllerFormGeneration = CompositionRoot.Resolve<AutoTicketGenerationController>();
                Ticket = ticket;

                Initialize();
                
                log.Info("Cargando datos en los combo.");
                bsTicket.DataSource = Ticket;

                ChargeForm();
            }
            catch (Exception ex)
            {
                log.Error(ex);
            }
        }

        private void Initialize()
        {
            inputType.DataSource = ControllerFormGeneration.GetAllTicketsTypes();
            inputType.Splits[0].DisplayColumns[0].Visible = false;

            inputPrioritySuppUser.DataSource = ControllerFormGeneration.GetAllTechnicals();
            inputPrioritySuppUser.Splits[0].DisplayColumns[0].Visible = false;
            inputPrioritySuppUser.Splits[0].DisplayColumns[1].Visible = false;
            inputPrioritySuppUser.Splits[0].DisplayColumns[2].AutoSize();
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
            bool error = false;

            Ticket.Comment = inputDescription.Text;

            if (Ticket.IdTicket<=0 && Ticket.TicketDate.Day != DateTime.Now.Date.Day) error = true;
            else if (string.IsNullOrEmpty(Ticket.AppCode)) error = true;
            else if (string.IsNullOrEmpty(Ticket.AppVersion)) error = true;
            else if (string.IsNullOrEmpty(Ticket.IdSection.ToString())) error = true;
            else if (string.IsNullOrEmpty(Ticket.User)) error = true;
            else if (Ticket.IdType == 0) error = true;
            else if (string.IsNullOrEmpty(Ticket.SourceIdentification)) error = true;
            else if (Ticket.IdType == 2 && string.IsNullOrEmpty(inputErrorTrace.Text)) error = true;

            if (error) 
                MessageBox.Show(Messages.AlertIncorrectsFields, Messages.AlertTitle, MessageBoxButtons.OK, MessageBoxIcon.Warning);
            else
            {
                try
                {
                    ControllerFormGeneration.SaveTicket(Ticket);

                }
                catch (Exception ex)
                {
                    MessageBox.Show(Messages.ErrorSaveTicket, Messages.ErrorTitle, MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            this.Close();
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
        private void c1ButtonStatusAssignTo_Click(object sender, EventArgs e)
        {
            AssignedToForm formAssignedTo = new AssignedToForm();
            if (formAssignedTo.ShowDialog() == DialogResult.OK)
            {
                Ticket.AsignedTo = formAssignedTo.IdUserAsigned;
                //He creado un método para crear estados, ya que tengo que crear estados en más sitios
                Ticket.TicketsStatusHistory.Add(
                    new VMTicketsStatusHistory
                    {
                        IdTicket = Ticket.IdTicket,
                        StatusDate = DateTime.Now,
                        IdStatus = 2,
                        User = Ticket.User,
                        AsignedTo = Ticket.AsignedTo,
                        ResolvedVersion = Ticket.AppVersion
                    });
                bsStatus.ResetBindings(false);
            }
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
                if (Ticket.IdTicket <= 0)// Esto significa que es nuevo.
                {
                    CreateTicketStatus(1);

                    //Cambiamos el diseño del formulario, para nuevos tickets
                    tableLayoutPanelGeneral.RowStyles[0].SizeType = SizeType.Absolute;
                    tableLayoutPanelGeneral.RowStyles[0].Height = 0; //Quitar fila de botones para asignar estados
                    tableLayoutPanelGeneral.RowStyles[3].SizeType = SizeType.Absolute;
                    tableLayoutPanelGeneral.RowStyles[3].Height = 0; //Quitar fila del grid para ver mensajes, accesos y estados
                    this.Size = new System.Drawing.Size(this.MinimumSize.Width, this.MinimumSize.Height); //Establecer el tamaño del formulario más pequeño porque no se establecía automaticamente

                }
                else
                {
                    //Le ponemos al formulario directamente un nombre que sea identificativo.
                    //Text = "Ticket Data";

                    inputType.ReadOnly = true;
                    inputType.EditorBackColor = Color.LemonChiffon;
                    inputIdentification.BackColor = Color.LemonChiffon;
                    inputIdentification.ReadOnly = true;
                    inputDescription.BackColor = Color.LemonChiffon;
                    inputDescription.ReadOnly = true;

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

                    LoadMessages();
                    LoadStatus();
                    LoadAccess();

                }

                //Si no es nuevo, es de tipo error y la exceptionTrace esta vacía
                if (Ticket.IdType != 2 || (Ticket.IdTicket>0 && Ticket.IdType == 2 && Ticket.TicketsExceptionInfo.ExceptionTrace== ""))
                {
                    tblData.RowStyles[1].SizeType = SizeType.Absolute;
                    tblData.RowStyles[1].Height = 0;
                }
            }
            catch (Exception ex)
            {
                log.Error(ex);
            }
            
        }
        private void CreateTicketStatus(int idStatus)
        {
            Ticket.TicketsStatusHistory.Add( 
                new VMTicketsStatusHistory
                {
                    IdTicket = Ticket.IdTicket,
                    StatusDate = DateTime.Now,
                    IdStatus = idStatus,
                    User = Ticket.User,
                    AsignedTo = null,
                    ResolvedVersion = Ticket.AppVersion
                }
            );
        }

        //
        //Method for search files when is clicked in PicturesBox
        //
        private void searchFile(PictureBox picture)
        {
            if (Ticket.IdTicket == 0)
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
            c1TextBoxMessagesHistory.Value = "";
            foreach (var item in Ticket.TicketsMessagesHistory)
            {
                //En lugar de usar el += puedes hacer una concatenacion haciendo esto:
                c1TextBoxMessagesHistory.Value = $"[{item.User} - {item.MessageDate.ToShortDateString()}                            {Environment.NewLine}\t - {item.Message}.{Environment.NewLine}]";
            }
            c1TextBoxMessagesHistory.ReadOnly = true;
        }
        private void LoadStatus()
        {
            bsStatus.DataSource = Ticket.TicketsStatusHistory.OrderByDescending(x => x.StatusDate);
        }
        private void LoadAccess()
        {
            bsAccess.DataSource = Ticket.TicketsAccessHistory.OrderByDescending(x => x.AccessDate);
            bsAccess.ResetBindings(true);
        }
        private void sendMessage()
        {
            if (!string.IsNullOrEmpty(c1TextBoxMesssageToSend.Text))
            {
                string user = Ticket.User;
                DateTime date = DateTime.Now;
                string message = c1TextBoxMesssageToSend.Text;

                VMTicketsMessagesHistory ticketMessage = new VMTicketsMessagesHistory()
                {
                    IdTicket = Ticket.IdTicket,
                    MessageDate = DateTime.Now,
                    User = Ticket.User,
                    Message = message
                };
                VMTicketsAccessHistory ticketAccess = new VMTicketsAccessHistory
                {
                    IdTicket = Ticket.IdTicket,
                    AccessDate = date,
                    User = Ticket.User,
                    AccessActivity = "Send message"
                };
                ControllerFormGeneration.SaveTicketAccess(ticketAccess);

                c1TextBoxMesssageToSend.Text = "";
                ControllerFormGeneration.SaveTicketMessage(ticketMessage);
                LoadMessages();
            }
        }
        #endregion

        #region Events
        private void inputDescription_TextChanged(object sender, EventArgs e)
        {
            labelTextLength.Text = inputDescription.Text.Length+"/1500";
        }

        #endregion

    }
}