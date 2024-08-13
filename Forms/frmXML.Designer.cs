namespace filezilla_integrate
{
    partial class frmXML
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
            txtLoadXML = new TextBox();
            txtReturnXML = new TextBox();
            btnDesSer = new Button();
            SuspendLayout();
            // 
            // txtLoadXML
            // 
            txtLoadXML.Location = new Point(12, 12);
            txtLoadXML.Multiline = true;
            txtLoadXML.Name = "txtLoadXML";
            txtLoadXML.Size = new Size(560, 308);
            txtLoadXML.TabIndex = 0;
            // 
            // txtReturnXML
            // 
            txtReturnXML.Location = new Point(578, 12);
            txtReturnXML.Multiline = true;
            txtReturnXML.Name = "txtReturnXML";
            txtReturnXML.Size = new Size(502, 308);
            txtReturnXML.TabIndex = 1;
            // 
            // btnDesSer
            // 
            btnDesSer.Location = new Point(915, 326);
            btnDesSer.Name = "btnDesSer";
            btnDesSer.Size = new Size(165, 47);
            btnDesSer.TabIndex = 3;
            btnDesSer.Text = "button2";
            btnDesSer.UseVisualStyleBackColor = true;
            btnDesSer.Click += button2_Click;
            // 
            // frmXML
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1092, 390);
            Controls.Add(btnDesSer);
            Controls.Add(txtReturnXML);
            Controls.Add(txtLoadXML);
            Name = "frmXML";
            Text = "frmXML";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtLoadXML;
        private TextBox txtReturnXML;
        private Button btnDesSer;
    }
}