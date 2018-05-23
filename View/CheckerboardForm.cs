using System;
using System.Drawing;
using System.Windows.Forms;
using Controller;
using System.Collections.Generic;

namespace View
{
	public class CheckerBoardForm : Form
	{

        //** Need to implement Handle ResultOfGame
		private const int k_SizeOfSquareInBoard = 50;
		private SquareMove m_CurrentMove;
		private bool m_IsChooseSolider = false;

		public CheckerBoardForm()
		{
			initializeComponent();
			initializeEventHandlers();
            
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
			generateLabelsOfPlayersName();

			//
			generateLocationLablesOfCheckerboard();

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
			int centerSizeOfBoard = k_SizeOfSquareInBoard * (int)CheckerboardController.Instance.SizeBoard;
			int width = 150 * 2 + centerSizeOfBoard;
			int height = 100 * 2 + centerSizeOfBoard;
			this.ClientSize = new Size(width, height);
		}

		private void generateCloseButton()
		{
			PictureBox closeButton = new PictureBox();
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

		private void generateLabelsOfPlayersName()
		{
			PictureBoxWithText firstLabelPlayer = new PictureBoxWithText(Properties.Resources.WoodenForLabel, String.Format("Player 1: {0}", CheckerboardController.Instance.CurrentPlayer.PlayerName));
			PictureBoxWithText secondLaberlPlayer = new PictureBoxWithText(Properties.Resources.WoodenForLabel, String.Format("Player 2: {0}", CheckerboardController.Instance.OtherPlayer.PlayerName));
			firstLabelPlayer.Location = new Point(70, 20);
			secondLaberlPlayer.Location = new Point(ClientSize.Width - 250, 20);
			this.Controls.Add(firstLabelPlayer);
			this.Controls.Add(secondLaberlPlayer);
		}

		private void generateBoardSquaresAndSoliders()
		{
			int sizeOfBoard = (int)CheckerboardController.Instance.SizeBoard;
			int indexToDrawTheSolider = 1;
            //int startingPointX = 150;
            //int startingPointY = 120;
            int startingPointX = 100;
            int startingPointY = 70;
            eNumberOfPlayer numberOfPlayer = eNumberOfPlayer.First;
			Point pointToDraw = new Point(startingPointX, startingPointY);
			Bitmap imageToLoad = Properties.Resources.WhiteSquare;
			imageToLoad.Tag = new TagName("White");
			Image SoliderToDraw = null;
			bool isDrawSolider = false;
			for (int i = 0; i < sizeOfBoard; i++)
			{
                swapIndexToDrawTheSolider(ref indexToDrawTheSolider,i);
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
					numberOfPlayer = eNumberOfPlayer.Second;
				}
				for (int j = 0; j < sizeOfBoard; j++)
				{
					if (j != 0)
					{
                        pointToDraw.X += k_SizeOfSquareInBoard;
                        swapImages(ref imageToLoad);
					}
					applySquareBoardToView(imageToLoad, pointToDraw, i, j);
					if (isDrawSolider)
					{
						if (j == indexToDrawTheSolider)
						{
							applySoliderToFrontOfView(SoliderToDraw, pointToDraw, i, j,numberOfPlayer);
							indexToDrawTheSolider += 2;
						}
					}
                }
                isDrawSolider = false;
                
			}
        }




//              for (int i = 0; i<size;i++)
//            {
//                if(i%2==0)
//                {
//                    ImageToLoad = Properties.Resources.WhiteSquare;
//                    ImageToLoad.Tag = new TagName("White");
//        indexToDrawTheSolider = 1;
//                }
//                else
//                {
//                    ImageToLoad = Properties.Resources.BrownSquare;
//                    ImageToLoad.Tag = new TagName("Brown");
//    indexToDrawTheSolider = 0;
//                }
//pointToDraw.X = X;
//                if (i != 0)
//                {
//                    pointToDraw.Y += sizeOfSquareInBoard;
//                }

//                if ((i< (size / 2) - 1))
//                {
//                    SoliderToDraw = Properties.Resources.BrownSolider;
//                    isDrawSolider = true;
//                }
//                else if (i >= (size / 2) + 1)
//                {
//                    SoliderToDraw = Properties.Resources.WhiteSolider;
//                    isDrawSolider = true;
//                }
//                for (int j = 0; j<size;j++)
//                {                   
//                    PictureBox squareBoard = new PictureBox();
//                    if(j!=0)
//                    {
                        
//                        swapImages(ref ImageToLoad);
//                    }
//                    squareBoard.BackgroundImage = ImageToLoad;
//                    squareBoard.SendToBack();
//                    squareBoard.BackgroundImageLayout =ImageLayout.Stretch;
//                    squareBoard.Location = pointToDraw;
//                    squareBoard.Name = string.Format("{0}{1}", X, Y);
//squareBoard.Size = new Size(sizeOfSquareInBoard, sizeOfSquareInBoard);
//squareBoard.TabStop = false;
//                    if (isDrawSolider)
//                    {
//                        if (j == indexToDrawTheSolider)
//                        {

//                            OvalPictureBox solider = new OvalPictureBox(SoliderToDraw);
//solider.Location = new Point(pointToDraw.X + 2, pointToDraw.Y + 2);
//                            this.Controls.Add(solider);
//solider.BringToFront();
//indexToDrawTheSolider += 2;
//}
                       
//                    }
//                    this.Controls.Add(squareBoard);
//}
//isDrawSolider = false;
//            } 
//        }



















		private void applySoliderToFrontOfView(Image i_SoliderToDraw, Point i_PointToDraw, int i_Row, int i_Col,eNumberOfPlayer i_NumberOfPlayer)
		{
			OvalPictureBox solider = new OvalPictureBox(i_SoliderToDraw);
			solider.Location = new Point(i_PointToDraw.X + 2, i_PointToDraw.Y + 2);
			string stringToSetToTagName = String.Format("{0}{1}", MovementOptions.k_StartCol + i_Col, MovementOptions.k_StartRow + i_Row);
			solider.Tag = new TagSolider(stringToSetToTagName,i_NumberOfPlayer);
			solider.MouseClick += Solider_MouseClick;
			this.Controls.Add(solider);
			solider.BringToFront();

		}

		private void swapIndexToDrawTheSolider(ref int i_Index,int i)
		{
            if(i%2==0)
            {
                i_Index = 1;
            }
            else
            {
                i_Index = 0;
            }
		}

		private void applySquareBoardToView(Bitmap i_ImageToLoad, Point i_PointToDraw, int i_Row, int i_Col)
		{
			PictureBox squareBoard = new PictureBox();
			squareBoard.BackgroundImage = i_ImageToLoad;
			squareBoard.BackgroundImageLayout = ImageLayout.Stretch;
			squareBoard.Location = i_PointToDraw;
			squareBoard.Name = string.Format("{0}{1}", i_PointToDraw.X, i_PointToDraw.Y);
			squareBoard.Size = new Size(k_SizeOfSquareInBoard, k_SizeOfSquareInBoard);
			squareBoard.TabStop = false;
			squareBoard.MouseClick += SquareBoard_MouseClick;
			string stringToSetToTagName = String.Format("{0}{1}", MovementOptions.k_StartCol + i_Col, MovementOptions.k_StartRow + i_Row);
			squareBoard.Tag = new TagName(stringToSetToTagName);
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
		private void generateLocationLablesOfCheckerboard()
		{
			//NeedToImplement
		}

		//Listeners
		private void closeButton_Click(object sender, EventArgs e)
		{
			this.Dispose();
		}

		private void Solider_MouseClick(object sender, MouseEventArgs e)
		{
			OvalPictureBox currentSolider = sender as OvalPictureBox;
			if (currentSolider != null)
			{
				TagSolider currentTagSolider = currentSolider.Tag as TagSolider; 
				if(currentTagSolider.NumberOfPlayer==CheckerboardController.Instance.CurrentPlayer.NumberOfPlayer)
				{
					//Brush(Border) the current solideer with whiteColor--https://stackoverflow.com/questions/4446478/how-do-i-create-a-colored-border-on-a-picturebox-control
                    TagName currentPositionOfCurrentSolider = currentSolider.Tag as TagName;
                    this.m_CurrentMove.FromSquare.Col = currentPositionOfCurrentSolider.Name[0];
                    this.m_CurrentMove.FromSquare.Row = currentPositionOfCurrentSolider.Name[1];
                    this.m_IsChooseSolider = true;	
				}

			}
		}

		private void SquareBoard_MouseClick(object sender, MouseEventArgs e)
		{
			if (this.m_IsChooseSolider == true)
			{
				PictureBox currentSquare = sender as PictureBox;
				if (currentSquare != null)
				{
					TagName currentPositionOfCurrentSolider = currentSquare.Tag as TagName;
					this.m_CurrentMove.ToSquare.Col = currentPositionOfCurrentSolider.Name[0];
					this.m_CurrentMove.ToSquare.Row = currentPositionOfCurrentSolider.Name[1];
					CheckerboardController.Instance.nextTurn(m_CurrentMove);
				}
				this.m_IsChooseSolider = false;
			}
		}

		private void initializeEventHandlers()
		{
			initializeEvenetForAllPlayers();
		}

		private void initializeEvenetForAllPlayers()
		{
			List<Soldier> allSolidersInBoard = CheckerboardController.Instance.CurrentPlayer.Soldiers;
			allSolidersInBoard.AddRange(CheckerboardController.Instance.OtherPlayer.Soldiers);
			foreach(Soldier currentSoldier in allSolidersInBoard)
			{
				currentSoldier.ChangePlaceOnBoardEventHandler += this.solider_ChangePlaceOnBoard;
				currentSoldier.ChangeTypeOfSolider += this.solider_ChangeType;
				currentSoldier.RemoveSolider += this.solider_RemoveFromBoard;
			}
		}
        
		private void solider_ChangeType(Soldier i_Soldier)
		{
			//Need  To Implement to King change on view!!!
		}
        private void solider_ChangePlaceOnBoard(Square i_OldSquare,Square i_NewSquare)
		{
			//NEED TO IMPLEMENT!! change the place of solider
		}

		private void solider_RemoveFromBoard(Soldier i_SoldierToRemove)
		{
			//Need to Implement to remove the player from board
		}

		//classes
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

		private class TagSolider : TagName
		{
			private eNumberOfPlayer m_NumberOfPlayer;

			public TagSolider(String i_setName,eNumberOfPlayer i_NumberOfPlayer) : base(i_setName)
			{
				m_NumberOfPlayer = i_NumberOfPlayer;
			}

			public eNumberOfPlayer NumberOfPlayer
			{
				get
				{
					return m_NumberOfPlayer;
				}
			}
		}

    }
}
