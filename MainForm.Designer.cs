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
            ButtonLoadStructure.Font = new Font("Book Antiqua", 7.8F, FontStyle.Bold);
            ButtonLoadStructure.Location = new Point(30, 106);
            ButtonLoadStructure.Name = "ButtonLoadStructure";
            ButtonLoadStructure.Size = new Size(150, 40);
            ButtonLoadStructure.TabIndex = 2;
            ButtonLoadStructure.Text = "Load structure";
            ButtonLoadStructure.UseVisualStyleBackColor = true;
            // 
            // ButtonSaveStructure
            // 
            ButtonSaveStructure.Font = new Font("Book Antiqua", 7.8F, FontStyle.Bold);
            ButtonSaveStructure.Location = new Point(30, 60);
            ButtonSaveStructure.Name = "ButtonSaveStructure";
            ButtonSaveStructure.Size = new Size(150, 40);
            ButtonSaveStructure.TabIndex = 1;
            ButtonSaveStructure.Text = "Save structure";
            ButtonSaveStructure.UseVisualStyleBackColor = true;
            // 
            // ButtonRenamePoint
            // 
            ButtonRenamePoint.Font = new Font("Book Antiqua", 7.8F, FontStyle.Bold);
            ButtonRenamePoint.Location = new Point(30, 244);
            ButtonRenamePoint.Name = "ButtonRenamePoint";
            ButtonRenamePoint.Size = new Size(150, 40);
            ButtonRenamePoint.TabIndex = 5;
            ButtonRenamePoint.Text = "Rename point";
            ButtonRenamePoint.UseVisualStyleBackColor = true;
            // 
            // ButtonRecolorPoint
            // 
            ButtonRecolorPoint.Font = new Font("Book Antiqua", 7.8F, FontStyle.Bold);
            ButtonRecolorPoint.Location = new Point(30, 198);
            ButtonRecolorPoint.Name = "ButtonRecolorPoint";
            ButtonRecolorPoint.Size = new Size(150, 40);
            ButtonRecolorPoint.TabIndex = 4;
            ButtonRecolorPoint.Text = "Recolor point";
            ButtonRecolorPoint.UseVisualStyleBackColor = true;
            // 
            // ButtonDeleteObject
            // 
            ButtonDeleteObject.Font = new Font("Book Antiqua", 7.8F, FontStyle.Bold);
            ButtonDeleteObject.Location = new Point(30, 291);
            ButtonDeleteObject.Name = "ButtonDeleteObject";
            ButtonDeleteObject.Size = new Size(150, 40);
            ButtonDeleteObject.TabIndex = 6;
            ButtonDeleteObject.Text = "Delete object";
            ButtonDeleteObject.UseVisualStyleBackColor = true;
            // 
            // LabelHeaderBackup
            // 
            LabelHeaderBackup.AutoSize = true;
            LabelHeaderBackup.Font = new Font("Book Antiqua", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            LabelHeaderBackup.Location = new Point(30, 33);
            LabelHeaderBackup.Name = "LabelHeaderBackup";
            LabelHeaderBackup.Size = new Size(83, 24);
            LabelHeaderBackup.TabIndex = 0;
            LabelHeaderBackup.Text = "Backup:";
            // 
            // LabelHeaderEdit
            // 
            LabelHeaderEdit.AutoSize = true;
            LabelHeaderEdit.Font = new Font("Book Antiqua", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            LabelHeaderEdit.Location = new Point(30, 171);
            LabelHeaderEdit.Name = "LabelHeaderEdit";
            LabelHeaderEdit.Size = new Size(140, 24);
            LabelHeaderEdit.TabIndex = 3;
            LabelHeaderEdit.Text = "Edit structure:";
            // 
            // LabelHeaderInformation
            // 
            LabelHeaderInformation.AutoSize = true;
            LabelHeaderInformation.Font = new Font("Book Antiqua", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            LabelHeaderInformation.Location = new Point(30, 358);
            LabelHeaderInformation.Name = "LabelHeaderInformation";
            LabelHeaderInformation.Size = new Size(127, 24);
            LabelHeaderInformation.TabIndex = 7;
            LabelHeaderInformation.Text = "Information:";
            // 
            // ButtonHelp
            // 
            ButtonHelp.Font = new Font("Book Antiqua", 7.8F, FontStyle.Bold);
            ButtonHelp.Location = new Point(30, 385);
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
            ClientSize = new Size(782, 463);
            Controls.Add(ButtonHelp);
            Controls.Add(LabelHeaderInformation);
            Controls.Add(LabelHeaderEdit);
            Controls.Add(LabelHeaderBackup);
            Controls.Add(ButtonDeleteObject);
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
        private Button ButtonDeleteObject;
        private Button ButtonHelp;
        private Label LabelHeaderBackup;
        private Label LabelHeaderEdit;
        private Label LabelHeaderInformation;
    }
}
