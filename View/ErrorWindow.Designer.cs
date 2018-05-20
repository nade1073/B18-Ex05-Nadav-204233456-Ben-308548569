namespace View
{
    partial class ErrorWindow
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ErrorWindow));
            this.ErrorImage = new System.Windows.Forms.PictureBox();
            this.label1 = new System.Windows.Forms.Label();
            this.button1 = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.ErrorImage)).BeginInit();
            this.SuspendLayout();
            // 
            // ErrorImage
            // 
            this.ErrorImage.Image = Properties.Resources.SignError;
            this.ErrorImage.Location = new System.Drawing.Point(34, 28);
            this.ErrorImage.Name = "ErrorImage";
            this.ErrorImage.Size = new System.Drawing.Size(30, 32);
            this.ErrorImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.ErrorImage.TabIndex = 0;
            this.ErrorImage.TabStop = false;
            // 
            // label1
            // 
            this.label1.Location = new System.Drawing.Point(83, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(99, 42);
            this.label1.TabIndex = 1;
            this.label1.Text = "Invalid properties Please try again";
            this.label1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(75, 78);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(63, 20);
            this.button1.TabIndex = 2;
            this.button1.Text = "Ok";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // ErrorWindow
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.AutoValidate = System.Windows.Forms.AutoValidate.Disable;
            this.ClientSize = new System.Drawing.Size(222, 110);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.ErrorImage);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "ErrorWindow";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Error";
            ((System.ComponentModel.ISupportInitialize)(this.ErrorImage)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox ErrorImage;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button button1;
    }
}