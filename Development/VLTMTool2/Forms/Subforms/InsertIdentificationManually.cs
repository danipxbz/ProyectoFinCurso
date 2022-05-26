using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using VLTMTool.Models.Json;

namespace VLTMTool.Forms.Subforms
{
    public partial class InsertIdentificationManually : Form
    {
        public string identificationJSON { get; set; }
        public InsertIdentificationManually()
        {
            InitializeComponent();
        }

        private void buttonAccept_Click(object sender, EventArgs e)
        {
            var identification = new IdentificationJSON
            {
                Slin = inputSlin.Text,
                ProjectCode = inputProject.Text,
                IdTestValidation = inputIdTestValidation.Text,
                InspectionLot = inputInspectionLot.Text,
                StardardId = inputStandardId.Text,
                StandardCode = inputStCode.Text,
                StandardEdition = inputStEdition.Text,
                TestCode = inputTestCode.Text,
                ProcedureCode = inputPrCode.Text,
                ProcedureEdition = inputPrEdition.Text,
                IdCertificate = inputCertificate.Text,
                CertificateName = inputCertName.Text,
                CertificateEdition = inputCertEdition.Text,
                Other = inputOther.Text
            };

            identificationJSON = JsonConvert.SerializeObject(identification);
            DialogResult = DialogResult.Cancel;
            Close();
        }

        private void buttonCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }
}
