namespace VicompBioApiNetDemo
{
    partial class FormMain
    {
        /// <summary>
        /// Wymagana zmienna projektanta.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Wyczyść wszystkie używane zasoby.
        /// </summary>
        /// <param name="disposing">prawda, jeżeli zarządzane zasoby powinny zostać zlikwidowane; Fałsz w przeciwnym wypadku.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Kod generowany przez Projektanta formularzy systemu Windows

        /// <summary>
        /// Metoda wymagana do obsługi projektanta — nie należy modyfikować
        /// jej zawartości w edytorze kodu.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(FormMain));
            this.buttonTest = new System.Windows.Forms.Button();
            this.labelMessage = new System.Windows.Forms.Label();
            this.pictureBox = new System.Windows.Forms.PictureBox();
            this.radioButtonSync = new System.Windows.Forms.RadioButton();
            this.radioButtonAsync = new System.Windows.Forms.RadioButton();
            this.progressBar = new System.Windows.Forms.ProgressBar();
            this.pictureBoxRight = new System.Windows.Forms.PictureBox();
            this.pictureBoxLeft = new System.Windows.Forms.PictureBox();
            this.pictureBoxUp = new System.Windows.Forms.PictureBox();
            this.pictureBoxDown = new System.Windows.Forms.PictureBox();
            this.labelSubMessage = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxRight)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLeft)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxUp)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxDown)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonTest
            // 
            this.buttonTest.Font = new System.Drawing.Font("Microsoft Sans Serif", 15.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.buttonTest.Location = new System.Drawing.Point(305, 441);
            this.buttonTest.Name = "buttonTest";
            this.buttonTest.Size = new System.Drawing.Size(175, 49);
            this.buttonTest.TabIndex = 0;
            this.buttonTest.Text = "Test";
            this.buttonTest.UseVisualStyleBackColor = true;
            this.buttonTest.Click += new System.EventHandler(this.buttonTest_Click);
            // 
            // labelMessage
            // 
            this.labelMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelMessage.Location = new System.Drawing.Point(51, 373);
            this.labelMessage.Name = "labelMessage";
            this.labelMessage.Size = new System.Drawing.Size(682, 60);
            this.labelMessage.TabIndex = 1;
            this.labelMessage.Text = "Kliknij \"Test\" aby sprawdzić skanowanie palca.";
            this.labelMessage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBox
            // 
            this.pictureBox.Location = new System.Drawing.Point(305, 79);
            this.pictureBox.Name = "pictureBox";
            this.pictureBox.Size = new System.Drawing.Size(175, 226);
            this.pictureBox.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.pictureBox.TabIndex = 2;
            this.pictureBox.TabStop = false;
            // 
            // radioButtonSync
            // 
            this.radioButtonSync.AutoSize = true;
            this.radioButtonSync.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.radioButtonSync.Location = new System.Drawing.Point(297, 498);
            this.radioButtonSync.Name = "radioButtonSync";
            this.radioButtonSync.Size = new System.Drawing.Size(62, 24);
            this.radioButtonSync.TabIndex = 3;
            this.radioButtonSync.Text = "Sync";
            this.radioButtonSync.UseVisualStyleBackColor = true;
            // 
            // radioButtonAsync
            // 
            this.radioButtonAsync.AutoSize = true;
            this.radioButtonAsync.CheckAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.radioButtonAsync.Checked = true;
            this.radioButtonAsync.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.radioButtonAsync.Location = new System.Drawing.Point(417, 498);
            this.radioButtonAsync.Name = "radioButtonAsync";
            this.radioButtonAsync.Size = new System.Drawing.Size(70, 24);
            this.radioButtonAsync.TabIndex = 4;
            this.radioButtonAsync.TabStop = true;
            this.radioButtonAsync.Text = "Async";
            this.radioButtonAsync.UseVisualStyleBackColor = true;
            // 
            // progressBar
            // 
            this.progressBar.Location = new System.Drawing.Point(22, 539);
            this.progressBar.Maximum = 30;
            this.progressBar.Name = "progressBar";
            this.progressBar.Size = new System.Drawing.Size(741, 10);
            this.progressBar.Style = System.Windows.Forms.ProgressBarStyle.Continuous;
            this.progressBar.TabIndex = 5;
            this.progressBar.Visible = false;
            // 
            // pictureBoxRight
            // 
            this.pictureBoxRight.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxRight.Image")));
            this.pictureBoxRight.InitialImage = ((System.Drawing.Image)(resources.GetObject("pictureBoxRight.InitialImage")));
            this.pictureBoxRight.Location = new System.Drawing.Point(485, 158);
            this.pictureBoxRight.Name = "pictureBoxRight";
            this.pictureBoxRight.Size = new System.Drawing.Size(60, 79);
            this.pictureBoxRight.TabIndex = 7;
            this.pictureBoxRight.TabStop = false;
            this.pictureBoxRight.Visible = false;
            // 
            // pictureBoxLeft
            // 
            this.pictureBoxLeft.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxLeft.Image")));
            this.pictureBoxLeft.InitialImage = ((System.Drawing.Image)(resources.GetObject("pictureBoxLeft.InitialImage")));
            this.pictureBoxLeft.Location = new System.Drawing.Point(239, 158);
            this.pictureBoxLeft.Name = "pictureBoxLeft";
            this.pictureBoxLeft.Size = new System.Drawing.Size(60, 79);
            this.pictureBoxLeft.TabIndex = 8;
            this.pictureBoxLeft.TabStop = false;
            this.pictureBoxLeft.Visible = false;
            // 
            // pictureBoxUp
            // 
            this.pictureBoxUp.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxUp.Image")));
            this.pictureBoxUp.InitialImage = ((System.Drawing.Image)(resources.GetObject("pictureBoxUp.InitialImage")));
            this.pictureBoxUp.Location = new System.Drawing.Point(353, 12);
            this.pictureBoxUp.Name = "pictureBoxUp";
            this.pictureBoxUp.Size = new System.Drawing.Size(79, 60);
            this.pictureBoxUp.TabIndex = 9;
            this.pictureBoxUp.TabStop = false;
            this.pictureBoxUp.Visible = false;
            // 
            // pictureBoxDown
            // 
            this.pictureBoxDown.Image = ((System.Drawing.Image)(resources.GetObject("pictureBoxDown.Image")));
            this.pictureBoxDown.InitialImage = ((System.Drawing.Image)(resources.GetObject("pictureBoxDown.InitialImage")));
            this.pictureBoxDown.Location = new System.Drawing.Point(353, 311);
            this.pictureBoxDown.Name = "pictureBoxDown";
            this.pictureBoxDown.Size = new System.Drawing.Size(79, 60);
            this.pictureBoxDown.TabIndex = 10;
            this.pictureBoxDown.TabStop = false;
            this.pictureBoxDown.Visible = false;
            // 
            // labelSubMessage
            // 
            this.labelSubMessage.Font = new System.Drawing.Font("Microsoft Sans Serif", 9.75F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(238)));
            this.labelSubMessage.Location = new System.Drawing.Point(438, 14);
            this.labelSubMessage.Name = "labelSubMessage";
            this.labelSubMessage.Size = new System.Drawing.Size(343, 23);
            this.labelSubMessage.TabIndex = 11;
            this.labelSubMessage.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // FormMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(784, 561);
            this.Controls.Add(this.labelSubMessage);
            this.Controls.Add(this.pictureBoxDown);
            this.Controls.Add(this.pictureBoxUp);
            this.Controls.Add(this.pictureBoxLeft);
            this.Controls.Add(this.pictureBoxRight);
            this.Controls.Add(this.progressBar);
            this.Controls.Add(this.radioButtonAsync);
            this.Controls.Add(this.radioButtonSync);
            this.Controls.Add(this.pictureBox);
            this.Controls.Add(this.labelMessage);
            this.Controls.Add(this.buttonTest);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.MaximizeBox = false;
            this.Name = "FormMain";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "VicompBioApiNet Demo     Build 17.11.8.0     Copyright © 2017 Vicomp Ltd     (Vis" +
    "ual Studio 2017 C#/.NET)";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxRight)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxLeft)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxUp)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxDown)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button buttonTest;
        private System.Windows.Forms.Label labelMessage;
        private System.Windows.Forms.PictureBox pictureBox;
        private System.Windows.Forms.RadioButton radioButtonSync;
        private System.Windows.Forms.RadioButton radioButtonAsync;
        private System.Windows.Forms.ProgressBar progressBar;
        private System.Windows.Forms.PictureBox pictureBoxRight;
        private System.Windows.Forms.PictureBox pictureBoxLeft;
        private System.Windows.Forms.PictureBox pictureBoxUp;
        private System.Windows.Forms.PictureBox pictureBoxDown;
        private System.Windows.Forms.Label labelSubMessage;
    }
}

