namespace HierholzersAlgorithm
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            ButtonLoadStructure = new Button();
            ButtonSaveStructure = new Button();
            ButtonRenamePoint = new Button();
            ButtonRecolorPoint = new Button();
            LabelHeaderBackup = new Label();
            LabelHeaderEdit = new Label();
            LabelHeaderInformation = new Label();
            ButtonHelp = new Button();
            SuspendLayout();
            // 
            // ButtonLoadStructure
            // 
            ButtonLoadStructure.Font = new Font("Microsoft Sans Serif", 8.25F);
            ButtonLoadStructure.Location = new Point(30, 107);
            ButtonLoadStructure.Name = "ButtonLoadStructure";
            ButtonLoadStructure.Size = new Size(150, 40);
            ButtonLoadStructure.TabIndex = 2;
            ButtonLoadStructure.Text = "Load structure";
            ButtonLoadStructure.UseVisualStyleBackColor = true;
            // 
            // ButtonSaveStructure
            // 
            ButtonSaveStructure.Font = new Font("Microsoft Sans Serif", 8.25F);
            ButtonSaveStructure.Location = new Point(30, 60);
            ButtonSaveStructure.Name = "ButtonSaveStructure";
            ButtonSaveStructure.Size = new Size(150, 40);
            ButtonSaveStructure.TabIndex = 1;
            ButtonSaveStructure.Text = "Save structure";
            ButtonSaveStructure.UseVisualStyleBackColor = true;
            // 
            // ButtonRenamePoint
            // 
            ButtonRenamePoint.Font = new Font("Microsoft Sans Serif", 8.25F);
            ButtonRenamePoint.Location = new Point(30, 244);
            ButtonRenamePoint.Name = "ButtonRenamePoint";
            ButtonRenamePoint.Size = new Size(150, 40);
            ButtonRenamePoint.TabIndex = 5;
            ButtonRenamePoint.Text = "Rename point";
            ButtonRenamePoint.UseVisualStyleBackColor = true;
            // 
            // ButtonRecolorPoint
            // 
            ButtonRecolorPoint.Font = new Font("Microsoft Sans Serif", 8.25F);
            ButtonRecolorPoint.Location = new Point(30, 197);
            ButtonRecolorPoint.Name = "ButtonRecolorPoint";
            ButtonRecolorPoint.Size = new Size(150, 40);
            ButtonRecolorPoint.TabIndex = 4;
            ButtonRecolorPoint.Text = "Recolor point";
            ButtonRecolorPoint.UseVisualStyleBackColor = true;
            // 
            // LabelHeaderBackup
            // 
            LabelHeaderBackup.AutoSize = true;
            LabelHeaderBackup.Font = new Font("Microsoft Sans Serif", 12F);
            LabelHeaderBackup.Location = new Point(30, 33);
            LabelHeaderBackup.Name = "LabelHeaderBackup";
            LabelHeaderBackup.Size = new Size(84, 25);
            LabelHeaderBackup.TabIndex = 0;
            LabelHeaderBackup.Text = "Backup:";
            // 
            // LabelHeaderEdit
            // 
            LabelHeaderEdit.AutoSize = true;
            LabelHeaderEdit.Font = new Font("Microsoft Sans Serif", 12F);
            LabelHeaderEdit.Location = new Point(30, 171);
            LabelHeaderEdit.Name = "LabelHeaderEdit";
            LabelHeaderEdit.Size = new Size(131, 25);
            LabelHeaderEdit.TabIndex = 3;
            LabelHeaderEdit.Text = "Edit structure:";
            // 
            // LabelHeaderInformation
            // 
            LabelHeaderInformation.AutoSize = true;
            LabelHeaderInformation.Font = new Font("Microsoft Sans Serif", 12F);
            LabelHeaderInformation.Location = new Point(30, 309);
            LabelHeaderInformation.Name = "LabelHeaderInformation";
            LabelHeaderInformation.Size = new Size(114, 25);
            LabelHeaderInformation.TabIndex = 7;
            LabelHeaderInformation.Text = "Information:";
            // 
            // ButtonHelp
            // 
            ButtonHelp.Font = new Font("Microsoft Sans Serif", 8.25F);
            ButtonHelp.Location = new Point(30, 337);
            ButtonHelp.Name = "ButtonHelp";
            ButtonHelp.Size = new Size(150, 40);
            ButtonHelp.TabIndex = 8;
            ButtonHelp.Text = "Help";
            ButtonHelp.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(782, 413);
            Controls.Add(ButtonHelp);
            Controls.Add(LabelHeaderInformation);
            Controls.Add(LabelHeaderEdit);
            Controls.Add(LabelHeaderBackup);
            Controls.Add(ButtonRecolorPoint);
            Controls.Add(ButtonRenamePoint);
            Controls.Add(ButtonSaveStructure);
            Controls.Add(ButtonLoadStructure);
            Name = "MainForm";
            ShowIcon = false;
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Hierholzer's Algorithm";
            Click += MainForm_Click;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Button ButtonSaveStructure;
        private Button ButtonLoadStructure;
        private Button ButtonRecolorPoint;
        private Button ButtonRenamePoint;
        private Button ButtonHelp;
        private Label LabelHeaderBackup;
        private Label LabelHeaderEdit;
        private Label LabelHeaderInformation;
    }
}
