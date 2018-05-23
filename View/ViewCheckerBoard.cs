using System;
using System.Drawing;
using System.Windows.Forms;
using Controller;

namespace View
{
    public class ViewCheckerBoard : Form
    {
        private CheckerBoard m_Board;
		private const int k_SizeOfSquareInBoard = 50;

              
        public ViewCheckerBoard(CheckerBoard i_CheckerBoard)
        {
            m_Board = i_CheckerBoard;
            initializeComponent();
        }

		private void initializeComponent()
        {
			//Client Size
            generateClientSize();

			//CloseButton
			generateCloseButton();

            //Check what is this?
            this.SuspendLayout();

            //Checkerboard + Soliders
            generateBoardSquaresAndSoliders();

			// Labels
			generateLabels();

            //SomeOtherProporties         
            this.AutoScaleMode = AutoScaleMode.Font;
            this.AutoSizeMode = AutoSizeMode.GrowAndShrink;         
            //this.BackColor = System.Drawing.Color.White;
            this.BackgroundImage = Properties.Resources.wooden_background_3217987_1920;
            this.BackgroundImageLayout = ImageLayout.Stretch;
            this.Cursor = Cursors.Arrow;
            this.FormBorderStyle = FormBorderStyle.None;
            this.Name = "WindowCheckerBoard";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.ResumeLayout(false);         
        }

		private void generateClientSize()
        {
            int centerSizeOfBoard = k_SizeOfSquareInBoard * (int)m_Board.SizeBoard;
            int width = 150 * 2 + centerSizeOfBoard;
            int height = 100 * 2 + centerSizeOfBoard;   
            this.ClientSize = new Size(width, height);
        }
              
        private void generateCloseButton()
		{
			PictureBox closeButton=new PictureBox();
			closeButton.BackColor = Color.Transparent;
			closeButton.BackgroundImage = Properties.Resources.CloseWoodenButton;
			closeButton.BackgroundImageLayout = ImageLayout.Zoom;
			closeButton.Cursor = Cursors.Hand;
            closeButton.Location = new Point(ClientSize.Width - 40, 0);
            closeButton.Size = new System.Drawing.Size(39, 32);
            closeButton.SizeMode = PictureBoxSizeMode.StretchImage;
			closeButton.Click += this.closeButton_Click;	
			this.Controls.Add(closeButton);
		}

        private void generateLabels()
		{
			PictureBoxWithText firstLabelPlayer = new PictureBoxWithText(Properties.Resources.WoodenForLabel, String.Format("Player 1: {0}", m_Board.CurrentPlayer.PlayerName));
            PictureBoxWithText secondLaberlPlayer = new PictureBoxWithText(Properties.Resources.WoodenForLabel, String.Format("Player 2: {0}", m_Board.OtherPlayer.PlayerName));
			firstLabelPlayer.Location = new Point(70, 20);
			secondLaberlPlayer.Location = new Point(ClientSize.Width - 250, 20);
			this.Controls.Add(firstLabelPlayer);
			this.Controls.Add(secondLaberlPlayer);
		}

		private void generateBoardSquaresAndSoliders()
        {
            int sizeOfBoard = (int)m_Board.SizeBoard;
            int indexToDrawTheSolider=1;
            //int startingPointX = 150;
            //int startingPointY = 120;
			int startingPointX = 100;
            int startingPointY = 70;
			Point pointToDraw = new Point(startingPointX, startingPointY);
			Bitmap imageToLoad=Properties.Resources.WhiteSquare;
			imageToLoad.Tag = new TagName("White");
            Image SoliderToDraw=null;
            bool isDrawSolider = false;
			for (int i=0;i<sizeOfBoard;i++)
            {
				pointToDraw.X = startingPointX;
				pointToDraw.Y += k_SizeOfSquareInBoard;            
				if ((i < (sizeOfBoard / 2) - 1))
                {
                    SoliderToDraw = Properties.Resources.BrownSolider;
                    isDrawSolider = true;
                }
				else if (i >= (sizeOfBoard / 2) + 1)
                {
                    SoliderToDraw = Properties.Resources.WhiteSolider;
                    isDrawSolider = true;
                }
				for (int j=0;j<sizeOfBoard;j++)
                {                                     
                    if(j!=0)
                    {
						swapImages(ref imageToLoad);
                    }
					applySquareBoardToView(imageToLoad,pointToDraw);
                    if (isDrawSolider)
                    {
                        if (j == indexToDrawTheSolider)
                        {
							applySoliderToFrontOfView(SoliderToDraw,pointToDraw);
                            indexToDrawTheSolider += 2;
                        }
                    }
                }
                isDrawSolider = false;
				swapImages(ref imageToLoad);
				swapIndexToDrawTheSolider(ref indexToDrawTheSolider);
            } 
        }

        private void applySoliderToFrontOfView(Image i_SoliderToDraw,Point i_PointToDraw)
		{
			OvalPictureBox solider = new OvalPictureBox(i_SoliderToDraw);
			solider.Location = new Point(i_PointToDraw.X + 2, i_PointToDraw.Y + 2);
            this.Controls.Add(solider);
            solider.BringToFront();
		}

        private void swapIndexToDrawTheSolider(ref int i_Index)
		{
			if(i_Index==0)
			{
				i_Index = 1;
			}
			else
			{
				i_Index = 0;
			}
		}

		private void applySquareBoardToView(Bitmap i_ImageToLoad,Point i_PointToDraw)
		{
			PictureBox squareBoard = new PictureBox();
			squareBoard.BackgroundImage = i_ImageToLoad;
			squareBoard.BackgroundImageLayout = ImageLayout.Stretch;
			squareBoard.Location = i_PointToDraw;
			squareBoard.Name = string.Format("{0}{1}", i_PointToDraw.X, i_PointToDraw.Y);
			squareBoard.Size = new Size(k_SizeOfSquareInBoard, k_SizeOfSquareInBoard);
			squareBoard.TabStop = false;
			this.Controls.Add(squareBoard);
			squareBoard.SendToBack();
		}

		private void swapImages(ref Bitmap i_CurrentImage)
        {

            TagName tempTag = i_CurrentImage.Tag as TagName;
            if (tempTag != null)
            {
                if (tempTag.Name == "Brown")
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

        //Listeners
		private void closeButton_Click(object sender, EventArgs e)
        {
            this.Dispose();
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
