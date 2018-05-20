namespace View
{
    partial class GameSettings
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
            this.BoardSize = new System.Windows.Forms.Label();
            this.EightSize = new System.Windows.Forms.RadioButton();
            this.TenSize = new System.Windows.Forms.RadioButton();
            this.SixSize = new System.Windows.Forms.RadioButton();
            this.Players = new System.Windows.Forms.Label();
            this.PlayerOne = new System.Windows.Forms.Label();
            this.PlayerOneTextBox = new System.Windows.Forms.TextBox();
            this.PlayerTwoTextBox = new System.Windows.Forms.TextBox();
            this.CheckBoxOfPlayerTwo = new System.Windows.Forms.CheckBox();
            this.DoneButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // BoardSize
            // 
            this.BoardSize.AutoSize = true;
            this.BoardSize.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.BoardSize.Location = new System.Drawing.Point(29, 12);
            this.BoardSize.Name = "BoardSize";
            this.BoardSize.Size = new System.Drawing.Size(61, 13);
            this.BoardSize.TabIndex = 0;
            this.BoardSize.Text = "Board Size:";
            // 
            // EightSize
            // 
            this.EightSize.AutoSize = true;
            this.EightSize.BackColor = System.Drawing.SystemColors.Control;
            this.EightSize.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.EightSize.Cursor = System.Windows.Forms.Cursors.Hand;
            this.EightSize.Location = new System.Drawing.Point(123, 35);
            this.EightSize.Name = "EightSize";
            this.EightSize.Size = new System.Drawing.Size(48, 17);
            this.EightSize.TabIndex = 2;
            this.EightSize.Text = "8 x 8";
            this.EightSize.UseVisualStyleBackColor = false;
            // 
            // TenSize
            // 
            this.TenSize.AutoSize = true;
            this.TenSize.BackColor = System.Drawing.SystemColors.Control;
            this.TenSize.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.TenSize.Cursor = System.Windows.Forms.Cursors.Hand;
            this.TenSize.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(177)));
            this.TenSize.Location = new System.Drawing.Point(188, 35);
            this.TenSize.Name = "TenSize";
            this.TenSize.Size = new System.Drawing.Size(60, 17);
            this.TenSize.TabIndex = 3;
            this.TenSize.Text = "10 x 10";
            this.TenSize.UseVisualStyleBackColor = false;
            // 
            // SixSize
            // 
            this.SixSize.AutoSize = true;
            this.SixSize.BackColor = System.Drawing.SystemColors.Control;
            this.SixSize.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Center;
            this.SixSize.Checked = true;
            this.SixSize.Cursor = System.Windows.Forms.Cursors.Hand;
            this.SixSize.Location = new System.Drawing.Point(54, 35);
            this.SixSize.Name = "SixSize";
            this.SixSize.Size = new System.Drawing.Size(48, 17);
            this.SixSize.TabIndex = 4;
            this.SixSize.TabStop = true;
            this.SixSize.Text = "6 x 6";
            this.SixSize.UseVisualStyleBackColor = false;
            // 
            // Players
            // 
            this.Players.AutoSize = true;
            this.Players.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.Players.Location = new System.Drawing.Point(31, 66);
            this.Players.Name = "Players";
            this.Players.Size = new System.Drawing.Size(44, 13);
            this.Players.TabIndex = 5;
            this.Players.Text = "Players:";
            // 
            // PlayerOne
            // 
            this.PlayerOne.AutoSize = true;
            this.PlayerOne.ImageAlign = System.Drawing.ContentAlignment.TopCenter;
            this.PlayerOne.Location = new System.Drawing.Point(48, 91);
            this.PlayerOne.Name = "PlayerOne";
            this.PlayerOne.Size = new System.Drawing.Size(48, 13);
            this.PlayerOne.TabIndex = 6;
            this.PlayerOne.Text = "Player 1:";
            // 
            // PlayerOneTextBox
            // 
            this.PlayerOneTextBox.Location = new System.Drawing.Point(123, 89);
            this.PlayerOneTextBox.Name = "PlayerOneTextBox";
            this.PlayerOneTextBox.Size = new System.Drawing.Size(100, 20);
            this.PlayerOneTextBox.TabIndex = 7;
            // 
            // PlayerTwoTextBox
            // 
            this.PlayerTwoTextBox.Enabled = false;
            this.PlayerTwoTextBox.Location = new System.Drawing.Point(123, 117);
            this.PlayerTwoTextBox.Name = "PlayerTwoTextBox";
            this.PlayerTwoTextBox.Size = new System.Drawing.Size(100, 20);
            this.PlayerTwoTextBox.TabIndex = 8;
            this.PlayerTwoTextBox.Text = "[Computer]";
            // 
            // CheckBoxOfPlayerTwo
            // 
            this.CheckBoxOfPlayerTwo.AutoSize = true;
            this.CheckBoxOfPlayerTwo.Location = new System.Drawing.Point(50, 118);
            this.CheckBoxOfPlayerTwo.Name = "CheckBoxOfPlayerTwo";
            this.CheckBoxOfPlayerTwo.Size = new System.Drawing.Size(67, 17);
            this.CheckBoxOfPlayerTwo.TabIndex = 10;
            this.CheckBoxOfPlayerTwo.Text = "Player 2:";
            this.CheckBoxOfPlayerTwo.UseVisualStyleBackColor = true;
            this.CheckBoxOfPlayerTwo.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // DoneButton
            // 
            this.DoneButton.Location = new System.Drawing.Point(84, 154);
            this.DoneButton.Name = "DoneButton";
            this.DoneButton.Size = new System.Drawing.Size(75, 23);
            this.DoneButton.TabIndex = 11;
            this.DoneButton.Text = "Done";
            this.DoneButton.UseVisualStyleBackColor = true;
            this.DoneButton.Click += new System.EventHandler(this.DoneButton_Click);
            // 
            // GameSettings
            // 
            this.AllowDrop = true;
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.ClientSize = new System.Drawing.Size(262, 199);
            this.Controls.Add(this.DoneButton);
            this.Controls.Add(this.CheckBoxOfPlayerTwo);
            this.Controls.Add(this.PlayerTwoTextBox);
            this.Controls.Add(this.PlayerOneTextBox);
            this.Controls.Add(this.PlayerOne);
            this.Controls.Add(this.Players);
            this.Controls.Add(this.SixSize);
            this.Controls.Add(this.TenSize);
            this.Controls.Add(this.EightSize);
            this.Controls.Add(this.BoardSize);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Name = "GameSettings";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Game Settings";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label BoardSize;
        private System.Windows.Forms.RadioButton EightSize;
        private System.Windows.Forms.RadioButton TenSize;
        private System.Windows.Forms.RadioButton SixSize;
        private System.Windows.Forms.Label Players;
        private System.Windows.Forms.Label PlayerOne;
        private System.Windows.Forms.TextBox PlayerOneTextBox;
        private System.Windows.Forms.TextBox PlayerTwoTextBox;
        private System.Windows.Forms.CheckBox CheckBoxOfPlayerTwo;
        private System.Windows.Forms.Button DoneButton;
    }
}

