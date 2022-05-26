using log4net;
using System;
using System.Windows.Forms;

namespace VLTMTool.Forms.Subforms
{
    public partial class TimeToResolve : Form
    {
        #region properties
        internal static readonly ILog log = log4net.LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);
        public double timeForResolved { get; set; }
        public string versionResolved { get; set; }
        #endregion
        public TimeToResolve()
        {
            InitializeComponent();
        }
        #region Methods
        private bool FieldsValidations()
        {
            bool error = false;

            if (string.IsNullOrEmpty(inputUsedTime.Text)) error = true;
            if (string.IsNullOrEmpty(inputVersionResolved.Text)) error = true;

            return error;
        }
        #endregion
        #region Actions
        private void buttonAccept_Click(object sender, EventArgs e)
        {
            try
            {
                if (FieldsValidations()) MessageBox.Show("Campos introducidos incorrectos.\nCompruebe de nuevo los campos.", "¡Atención!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                else
                {
                    timeForResolved = double.Parse(inputUsedTime.Value.ToString());
                    versionResolved = inputVersionResolved.Value.ToString();
                    DialogResult = DialogResult.OK;
                    Close();
                }
            }
            catch (Exception ex)
            {
                log.Error(ex);
            }
        }
        private void input_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                buttonAccept_Click(sender, e);
            }
        }
        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
        #endregion

    }
}
