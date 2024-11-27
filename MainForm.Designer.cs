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
            ButtonDeleteObject = new Button();
            LabelHeaderBackup = new Label();
            LabelHeaderEdit = new Label();
            LabelHeaderInformation = new Label();
            ButtonHelp = new Button();
            SuspendLayout();
            // 
            // ButtonLoadStructure
            // 
            ButtonLoadStructure.Font = new Font("Microsoft Sans Serif", 8.25F);
            ButtonLoadStructure.Location = new Point(26, 80);
            ButtonLoadStructure.Margin = new Padding(3, 2, 3, 2);
            ButtonLoadStructure.Name = "ButtonLoadStructure";
            ButtonLoadStructure.Size = new Size(131, 30);
            ButtonLoadStructure.TabIndex = 2;
            ButtonLoadStructure.Text = "Load structure";
            ButtonLoadStructure.UseVisualStyleBackColor = true;
            // 
            // ButtonSaveStructure
            // 
            ButtonSaveStructure.Font = new Font("Microsoft Sans Serif", 8.25F);
            ButtonSaveStructure.Location = new Point(26, 45);
            ButtonSaveStructure.Margin = new Padding(3, 2, 3, 2);
            ButtonSaveStructure.Name = "ButtonSaveStructure";
            ButtonSaveStructure.Size = new Size(131, 30);
            ButtonSaveStructure.TabIndex = 1;
            ButtonSaveStructure.Text = "Save structure";
            ButtonSaveStructure.UseVisualStyleBackColor = true;
            // 
            // ButtonRenamePoint
            // 
            ButtonRenamePoint.Font = new Font("Microsoft Sans Serif", 8.25F);
            ButtonRenamePoint.Location = new Point(26, 183);
            ButtonRenamePoint.Margin = new Padding(3, 2, 3, 2);
            ButtonRenamePoint.Name = "ButtonRenamePoint";
            ButtonRenamePoint.Size = new Size(131, 30);
            ButtonRenamePoint.TabIndex = 5;
            ButtonRenamePoint.Text = "Rename point";
            ButtonRenamePoint.UseVisualStyleBackColor = true;
            // 
            // ButtonRecolorPoint
            // 
            ButtonRecolorPoint.Font = new Font("Microsoft Sans Serif", 8.25F);
            ButtonRecolorPoint.Location = new Point(26, 148);
            ButtonRecolorPoint.Margin = new Padding(3, 2, 3, 2);
            ButtonRecolorPoint.Name = "ButtonRecolorPoint";
            ButtonRecolorPoint.Size = new Size(131, 30);
            ButtonRecolorPoint.TabIndex = 4;
            ButtonRecolorPoint.Text = "Recolor point";
            ButtonRecolorPoint.UseVisualStyleBackColor = true;
            // 
            // ButtonDeleteObject
            // 
            ButtonDeleteObject.Font = new Font("Microsoft Sans Serif", 8.25F);
            ButtonDeleteObject.Location = new Point(26, 218);
            ButtonDeleteObject.Margin = new Padding(3, 2, 3, 2);
            ButtonDeleteObject.Name = "ButtonDeleteObject";
            ButtonDeleteObject.Size = new Size(131, 30);
            ButtonDeleteObject.TabIndex = 6;
            ButtonDeleteObject.Text = "Delete object";
            ButtonDeleteObject.UseVisualStyleBackColor = true;
            // 
            // LabelHeaderBackup
            // 
            LabelHeaderBackup.AutoSize = true;
            LabelHeaderBackup.Font = new Font("Microsoft Sans Serif", 12F);
            LabelHeaderBackup.Location = new Point(26, 25);
            LabelHeaderBackup.Name = "LabelHeaderBackup";
            LabelHeaderBackup.Size = new Size(67, 20);
            LabelHeaderBackup.TabIndex = 0;
            LabelHeaderBackup.Text = "Backup:";
            // 
            // LabelHeaderEdit
            // 
            LabelHeaderEdit.AutoSize = true;
            LabelHeaderEdit.Font = new Font("Microsoft Sans Serif", 12F);
            LabelHeaderEdit.Location = new Point(26, 128);
            LabelHeaderEdit.Name = "LabelHeaderEdit";
            LabelHeaderEdit.Size = new Size(108, 20);
            LabelHeaderEdit.TabIndex = 3;
            LabelHeaderEdit.Text = "Edit structure:";
            // 
            // LabelHeaderInformation
            // 
            LabelHeaderInformation.AutoSize = true;
            LabelHeaderInformation.Font = new Font("Microsoft Sans Serif", 12F);
            LabelHeaderInformation.Location = new Point(26, 268);
            LabelHeaderInformation.Name = "LabelHeaderInformation";
            LabelHeaderInformation.Size = new Size(94, 20);
            LabelHeaderInformation.TabIndex = 7;
            LabelHeaderInformation.Text = "Information:";
            // 
            // ButtonHelp
            // 
            ButtonHelp.Font = new Font("Microsoft Sans Serif", 8.25F);
            ButtonHelp.Location = new Point(26, 289);
            ButtonHelp.Margin = new Padding(3, 2, 3, 2);
            ButtonHelp.Name = "ButtonHelp";
            ButtonHelp.Size = new Size(131, 30);
            ButtonHelp.TabIndex = 8;
            ButtonHelp.Text = "Help";
            ButtonHelp.UseVisualStyleBackColor = true;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(684, 347);
            Controls.Add(ButtonHelp);
            Controls.Add(LabelHeaderInformation);
            Controls.Add(LabelHeaderEdit);
            Controls.Add(LabelHeaderBackup);
            Controls.Add(ButtonDeleteObject);
            Controls.Add(ButtonRecolorPoint);
            Controls.Add(ButtonRenamePoint);
            Controls.Add(ButtonSaveStructure);
            Controls.Add(ButtonLoadStructure);
            Margin = new Padding(3, 2, 3, 2);
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
        private Button ButtonDeleteObject;
        private Button ButtonHelp;
        private Label LabelHeaderBackup;
        private Label LabelHeaderEdit;
        private Label LabelHeaderInformation;
    }
}
