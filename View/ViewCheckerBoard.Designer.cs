using System;
using System.Drawing;
using System.Windows.Forms;

namespace View
{
    partial class ViewCheckerBoard
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;
        private const int sizeOfSquareInBoard = 50;
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
            generateClientSize();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ViewCheckerBoard));
            this.CloseButton = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.testPic = new System.Windows.Forms.PictureBox();
            this.SuspendLayout();
            generateBoardSquares();
            // 
            // CloseButton
            // 
            this.CloseButton.BackColor = Color.Transparent;
            this.CloseButton.BackgroundImage = Properties.Resources.CloseWoodenButton;
            this.CloseButton.BackgroundImageLayout = ImageLayout.Zoom;
            this.CloseButton.BorderStyle = BorderStyle.FixedSingle;
            this.CloseButton.Cursor = System.Windows.Forms.Cursors.Hand;   
            this.CloseButton.Location = new Point(ClientSize.Width-40,0);
            this.CloseButton.Name = "CloseButton";
            this.CloseButton.Size = new System.Drawing.Size(39, 32);
            this.CloseButton.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage;
            this.CloseButton.TabIndex = 0;
            this.CloseButton.TabStop = false;
            this.CloseButton.Click += new System.EventHandler(this.pictureBox1_Click);
            //
            //Labels
            //
            PictureBox FirstPlayerPictureLabel = new PictureBox();
            FirstPlayerPictureLabel.BackgroundImage = Properties.Resources.WoodenLabel;
            FirstPlayerPictureLabel.Location=new Point(0, 0);
            FirstPlayerPictureLabel.Size = new Size(40, 40);
            
            this.Controls.Add(FirstPlayerPictureLabel);
            



            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink;
            this.BackColor = System.Drawing.Color.White;
            this.BackgroundImage = Properties.Resources.wooden_background_3217987_1920;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;   


            this.Controls.Add(this.CloseButton);
            this.Cursor = System.Windows.Forms.Cursors.Arrow;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "ViewCheckerBoard";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "CheckerBoard";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.PictureBox CloseButton;
        private System.Windows.Forms.PictureBox pictureBox1;
        private PictureBox testPic;

        private void generateBoardSquares()
        {
            int size = (int)m_Board.SizeBoard;
           
            int X = 150;
            int Y = 100+20;
            Point pointToDraw = new Point(X, Y);
            Bitmap ImageToLoad;
            for (int i=0;i<size;i++)
            {
                if(i%2==0)
                {
                    ImageToLoad = Properties.Resources.WhiteSquare;
                    ImageToLoad.Tag = new TagName("White");
                }
                else
                {
                    ImageToLoad = Properties.Resources.BrownSquare;
                    ImageToLoad.Tag = new TagName("Brown");
                }
                pointToDraw.X = X;
                if (i != 0)
                {
                    pointToDraw.Y += sizeOfSquareInBoard;
                }
                for(int j=0;j<size;j++)
                {
                   
                    
                    PictureBox squareBoard = new PictureBox();
                    if(j!=0)
                    {
                        pointToDraw.X += sizeOfSquareInBoard;
                        swapImages(ref ImageToLoad);
                    }
                    squareBoard.BackgroundImage = ImageToLoad;
                    squareBoard.BackgroundImageLayout =ImageLayout.Stretch;
                    squareBoard.Location = pointToDraw;
                    squareBoard.Name = string.Format("{0}{1}",X,Y);
                    squareBoard.Size = new Size(sizeOfSquareInBoard, sizeOfSquareInBoard);
                    squareBoard.TabStop = false;
                    this.Controls.Add(squareBoard);
                }
            }
        }
        private void generateClientSize()
        {
            int centerSizeOfBoard = sizeOfSquareInBoard * (int)m_Board.SizeBoard;
            int width =  150*2+ centerSizeOfBoard;
            int height =  100*2 + centerSizeOfBoard;
        
            this.ClientSize = new Size(width, height);
        }
        private void swapImages(ref Bitmap i_CurrentImage)
        {

            TagName tempTag = i_CurrentImage.Tag as TagName;
            if(tempTag!=null)
            {
                if(tempTag.Name=="Brown")
                {
                    i_CurrentImage = Properties.Resources.WhiteSquare;
                    i_CurrentImage.Tag = new TagName("White");
                }
                else
                {
                    i_CurrentImage = Properties.Resources.BrownSquare;
                    i_CurrentImage.Tag = new TagName("Brown");
                }
            }
        }
        private class TagName
        {
            public String m_String;
            public TagName(String i_setName)
            {
                Name = i_setName;
            }
            public String Name
            {
                get
                {
                    return m_String;
                }
                set
                {
                    m_String = value;
                }
            }

        }
    }
}