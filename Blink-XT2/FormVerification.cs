using System;
using System.Windows.Forms;
using Blink.Classes;

namespace Blink
{
    public partial class FormVerification : Form
    {
        private BaseData _BaseData;

        public FormVerification(BaseData baseData)
        {
            InitializeComponent();
            this._BaseData = baseData;
        }

        private void FormVerification_Shown(object sender, EventArgs e)
        {
            btn_Ok.Enabled = false;

            lbl_Explanation.Text =
                "Attention!\r\n" +
                "\r\n" +
                "Blink (not me!) will send you a verification email to\r\n" +
                $"{this._BaseData.Email}\r\n" + 
                "\r\n" +
                "This email will contain a numeric six-digit verification pin.\r\n" +
                "This verification pin must be entered ASAP below.\r\n" +
                "\r\n" +
                "Consider also to check your spam folder!\r\n" +
                "\r\n" +
                "Or, in case you do not get an email within max.\r\n" +
                "two minutes, enter the verification pin from the\r\n" + 
                "last Blink email!";
            txt_VerificationPin.Focus();
        }

        private void btn_Cancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        private void btn_Ok_Click(object sender, EventArgs e)
        {
            this._BaseData.VerificationPin = txt_VerificationPin.Text;

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void txt_VerificationPin_TextChanged(object sender, EventArgs e)
        {
            btn_Ok.Enabled = false;
            if (string.IsNullOrEmpty(txt_VerificationPin.Text))
            { 
                return;
            }
            if (txt_VerificationPin.Text.Length != 6)
            { 
                return;
            }

            if (!int.TryParse(txt_VerificationPin.Text, out int value))
            {
                MessageBox.Show(
                    $"Please provide the\r\n" +
                    "numeric\r\n" + 
                    "six-digit long Verification PIN.",
                    Config.TitleErrorAppNameAndVersion,
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error
                );
                txt_VerificationPin.Clear();
                txt_VerificationPin.Focus();
                return;
            }
            btn_Ok.Enabled = true;
        }
    }
}
