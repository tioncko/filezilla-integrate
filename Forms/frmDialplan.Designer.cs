namespace filezilla_integrate
{
    partial class frmDialplan
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
            txtDialplan = new TextBox();
            btnSave = new Button();
            btnBack = new Button();
            txtDialField01 = new TextBox();
            txtDialField02 = new TextBox();
            txtDialField03 = new TextBox();
            txtDialField04 = new TextBox();
            txtDialField05 = new TextBox();
            txtDialField06 = new TextBox();
            txtDialField07 = new TextBox();
            SuspendLayout();
            // 
            // txtDialplan
            // 
            txtDialplan.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Left | AnchorStyles.Right;
            txtDialplan.AutoCompleteMode = AutoCompleteMode.Append;
            txtDialplan.Font = new Font("Segoe UI", 10F, FontStyle.Regular, GraphicsUnit.Point);
            txtDialplan.Location = new Point(12, 12);
            txtDialplan.Multiline = true;
            txtDialplan.Name = "txtDialplan";
            txtDialplan.ScrollBars = ScrollBars.Vertical;
            txtDialplan.Size = new Size(593, 426);
            txtDialplan.TabIndex = 18;
            // 
            // btnSave
            // 
            btnSave.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            btnSave.Location = new Point(1037, 13);
            btnSave.Name = "btnSave";
            btnSave.Size = new Size(103, 23);
            btnSave.TabIndex = 20;
            btnSave.Text = "Save";
            btnSave.UseVisualStyleBackColor = true;
            btnSave.Click += btnSave_Click;
            // 
            // btnBack
            // 
            btnBack.Anchor = AnchorStyles.Top | AnchorStyles.Bottom | AnchorStyles.Right;
            btnBack.Location = new Point(1037, 415);
            btnBack.Name = "btnBack";
            btnBack.Size = new Size(103, 23);
            btnBack.TabIndex = 21;
            btnBack.Text = "Back";
            btnBack.UseVisualStyleBackColor = true;
            btnBack.Click += btnBack_Click;
            // 
            // txtDialField01
            // 
            txtDialField01.Location = new Point(718, 89);
            txtDialField01.Name = "txtDialField01";
            txtDialField01.Size = new Size(242, 23);
            txtDialField01.TabIndex = 22;
            // 
            // txtDialField02
            // 
            txtDialField02.Location = new Point(718, 118);
            txtDialField02.Name = "txtDialField02";
            txtDialField02.Size = new Size(242, 23);
            txtDialField02.TabIndex = 23;
            // 
            // txtDialField03
            // 
            txtDialField03.Location = new Point(718, 147);
            txtDialField03.Name = "txtDialField03";
            txtDialField03.Size = new Size(242, 23);
            txtDialField03.TabIndex = 24;
            // 
            // txtDialField04
            // 
            txtDialField04.Location = new Point(718, 176);
            txtDialField04.Name = "txtDialField04";
            txtDialField04.Size = new Size(242, 23);
            txtDialField04.TabIndex = 25;
            // 
            // txtDialField05
            // 
            txtDialField05.Location = new Point(718, 205);
            txtDialField05.Name = "txtDialField05";
            txtDialField05.Size = new Size(242, 23);
            txtDialField05.TabIndex = 26;
            // 
            // txtDialField06
            // 
            txtDialField06.Location = new Point(718, 234);
            txtDialField06.Name = "txtDialField06";
            txtDialField06.Size = new Size(242, 23);
            txtDialField06.TabIndex = 27;
            // 
            // txtDialField07
            // 
            txtDialField07.Location = new Point(718, 263);
            txtDialField07.Name = "txtDialField07";
            txtDialField07.Size = new Size(242, 23);
            txtDialField07.TabIndex = 28;
            // 
            // frmDialplan
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1152, 450);
            Controls.Add(txtDialField07);
            Controls.Add(txtDialField06);
            Controls.Add(txtDialField05);
            Controls.Add(txtDialField04);
            Controls.Add(txtDialField03);
            Controls.Add(txtDialField02);
            Controls.Add(txtDialField01);
            Controls.Add(btnBack);
            Controls.Add(btnSave);
            Controls.Add(txtDialplan);
            FormBorderStyle = FormBorderStyle.None;
            Name = "frmDialplan";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "frmDialplan";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtDialplan;
        private Button btnSave;
        private Button btnBack;
        private TextBox txtDialField01;
        private TextBox txtDialField02;
        private TextBox txtDialField03;
        private TextBox txtDialField04;
        private TextBox txtDialField05;
        private TextBox txtDialField06;
        private TextBox txtDialField07;
    }
}