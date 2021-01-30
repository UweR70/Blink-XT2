
namespace Blink
{
    partial class FormVerification
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.btn_Ok = new System.Windows.Forms.Button();
            this.btn_Cancel = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_VerificationPin = new System.Windows.Forms.TextBox();
            this.lbl_Explanation = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // btn_Ok
            // 
            this.btn_Ok.Location = new System.Drawing.Point(98, 308);
            this.btn_Ok.Name = "btn_Ok";
            this.btn_Ok.Size = new System.Drawing.Size(75, 23);
            this.btn_Ok.TabIndex = 0;
            this.btn_Ok.Text = "Ok";
            this.btn_Ok.UseVisualStyleBackColor = true;
            this.btn_Ok.Click += new System.EventHandler(this.btn_Ok_Click);
            // 
            // btn_Cancel
            // 
            this.btn_Cancel.Location = new System.Drawing.Point(12, 308);
            this.btn_Cancel.Name = "btn_Cancel";
            this.btn_Cancel.Size = new System.Drawing.Size(75, 23);
            this.btn_Cancel.TabIndex = 1;
            this.btn_Cancel.Text = "Cancel";
            this.btn_Cancel.UseVisualStyleBackColor = true;
            this.btn_Cancel.Click += new System.EventHandler(this.btn_Cancel_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 285);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(80, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Verification PIN";
            // 
            // txt_VerificationPin
            // 
            this.txt_VerificationPin.Location = new System.Drawing.Point(98, 282);
            this.txt_VerificationPin.MaxLength = 6;
            this.txt_VerificationPin.Name = "txt_VerificationPin";
            this.txt_VerificationPin.Size = new System.Drawing.Size(80, 20);
            this.txt_VerificationPin.TabIndex = 3;
            this.txt_VerificationPin.TextChanged += new System.EventHandler(this.txt_VerificationPin_TextChanged);
            // 
            // lbl_Explanation
            // 
            this.lbl_Explanation.AutoSize = true;
            this.lbl_Explanation.BackColor = System.Drawing.Color.Maroon;
            this.lbl_Explanation.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold);
            this.lbl_Explanation.ForeColor = System.Drawing.Color.White;
            this.lbl_Explanation.Location = new System.Drawing.Point(12, 9);
            this.lbl_Explanation.Name = "lbl_Explanation";
            this.lbl_Explanation.Size = new System.Drawing.Size(158, 260);
            this.lbl_Explanation.TabIndex = 4;
            this.lbl_Explanation.Text = "1 filled_at_runtime\r\n2 dummy\r\n3 dummy\r\n4 dummy\r\n5 dummy\r\n6 dummy\r\n7 dummy\r\n8 dumm" +
    "y\r\n9 dummy\r\n10 dummy\r\n11 dummy\r\n12 dummy\r\n13 dummy";
            // 
            // FormVerification
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(516, 345);
            this.ControlBox = false;
            this.Controls.Add(this.lbl_Explanation);
            this.Controls.Add(this.txt_VerificationPin);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btn_Cancel);
            this.Controls.Add(this.btn_Ok);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "FormVerification";
            this.Text = "Verification";
            this.Shown += new System.EventHandler(this.FormVerification_Shown);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btn_Ok;
        private System.Windows.Forms.Button btn_Cancel;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_VerificationPin;
        private System.Windows.Forms.Label lbl_Explanation;
    }
}