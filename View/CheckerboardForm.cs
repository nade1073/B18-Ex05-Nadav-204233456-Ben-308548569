namespace View
{
	using System;
    using System.Drawing;
    using System.Threading.Tasks;
    using System.Windows.Forms;
    using Controller;

    public class CheckerBoardForm : Form
    {
        private const int k_SizeOfSquareInBoard = 50;
        private const string k_SoliderPicName = "S";
        private const string k_SquarePicName = "Q";
        private const string k_LabelNameOfFirstPlayer = "FirstPlayerLabel";
        private const string k_LabelNameOfSecondPlayer = "SecondPlayerLabel";
        private SquareMove m_CurrentMove = new SquareMove();
        private bool m_IsChooseSolider = false;
        private bool m_IsSoliderIsMovingRightNow = false;

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

            //Checkerboard + Soliders
            generateBoardSquaresAndSoliders(true);

            // Labels
            generateLabelsOfPlayersName();

            //Labels location of checkererboard
            generateLocationLablesOfCheckerboard();

            //SomeOtherProporties  
            this.Click += CheckerBoardForm_Click;
            this.AutoScaleMode = AutoScaleMode.Font;
            this.AutoSizeMode = AutoSizeMode.GrowAndShrink;
            this.BackgroundImage = Properties.Resources.wooden_background_3217987_1920;
            this.BackgroundImageLayout = ImageLayout.Stretch;
            this.Cursor = Cursors.Arrow;
            this.FormBorderStyle = FormBorderStyle.None;
            this.Name = "WindowCheckerBoard";
            this.StartPosition = FormStartPosition.CenterScreen;
            this.ResumeLayout(false);
        }

        private void CheckerBoardForm_Click(object sender, EventArgs e)
        {
            if (m_IsChooseSolider)
            {
                removeBorderFromSoliderThatHaveBeenChosen();
                m_IsChooseSolider = false;
            }
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
            closeButton.Size = new Size(39, 32);
            closeButton.SizeMode = PictureBoxSizeMode.StretchImage;
            closeButton.Click += this.closeButton_Click;
            ToolTip toolTip1 = new ToolTip();
            toolTip1.AutoPopDelay = 5000;
            toolTip1.InitialDelay = 100;
            toolTip1.ReshowDelay = 100;
            toolTip1.ShowAlways = true;
            toolTip1.SetToolTip(closeButton, "Exit");
            this.Controls.Add(closeButton);
        }

        private void generateLabelsOfPlayersName()
        {
            PictureBoxWithText firstLabelPlayer = new PictureBoxWithText(Properties.Resources.WoodenForLabel, String.Format("{0} - {1}", CheckerboardController.Instance.CurrentPlayer.PlayerName, CheckerboardController.Instance.CurrentPlayer.Score));
            PictureBoxWithText secondLaberlPlayer = new PictureBoxWithText(Properties.Resources.WoodenForLabel, String.Format("{0} - {1}", CheckerboardController.Instance.OtherPlayer.PlayerName, CheckerboardController.Instance.OtherPlayer.Score));
            firstLabelPlayer.Location = new Point(70, 0);
            firstLabelPlayer.Name = k_LabelNameOfFirstPlayer;
            secondLaberlPlayer.Location = new Point(ClientSize.Width - 250, 0);
            secondLaberlPlayer.Name = k_LabelNameOfSecondPlayer;
            this.Controls.Add(firstLabelPlayer);
            this.Controls.Add(secondLaberlPlayer);
        }

        private void generateBoardSquaresAndSoliders(bool i_IsNeedToDrawSquare)
        {
            int sizeOfBoard = (int)CheckerboardController.Instance.SizeBoard;
            int indexToDrawTheSolider = 1;
            int startingPointX = 150;
            int startingPointY = 70;
            eNumberOfPlayer numberOfPlayer = eNumberOfPlayer.First;
            Point pointToDraw = new Point(startingPointX, startingPointY);
            Bitmap imageToLoad = Properties.Resources.WhiteSquare;
            imageToLoad.Tag = new TagName("White");
            Image SoliderToDraw = null;
            bool isDrawSolider = false;
            for (int i = 0; i < sizeOfBoard; i++)
            {
                swapIndexToDrawTheSolider(ref indexToDrawTheSolider, i);
                pointToDraw.X = startingPointX;
                pointToDraw.Y += k_SizeOfSquareInBoard;
                if ((i < (sizeOfBoard / 2) - 1))
                {
                    SoliderToDraw = Properties.Resources.BlackSolider;
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
					if (i_IsNeedToDrawSquare == true)
					{
						applySquareBoardToView(imageToLoad, pointToDraw, i, j);
					}
                    if (isDrawSolider)
                    {
                        if (j == indexToDrawTheSolider)
                        {
                            applySoliderToFrontOfView(SoliderToDraw, pointToDraw, i, j, numberOfPlayer);
                            indexToDrawTheSolider += 2;
                        }
                    }
                }
                isDrawSolider = false;
            }
        }

        private void applySoliderToFrontOfView(Image i_SoliderToDraw, Point i_PointToDraw, int i_Row, int i_Col, eNumberOfPlayer i_NumberOfPlayer)
        {
            OvalPictureBox solider = new OvalPictureBox(i_SoliderToDraw);
            solider.Location = new Point(i_PointToDraw.X + 2, i_PointToDraw.Y + 2);
            string stringToSetToTagName = String.Format("{0}{1}", (char)(MovementOptions.k_StartCol + i_Col), (char)(MovementOptions.k_StartRow + i_Row));
            solider.Name = string.Format("{0}{1}", stringToSetToTagName, k_SoliderPicName);
            solider.Tag = new TagSolider(stringToSetToTagName, i_NumberOfPlayer);
            TagSolider tempTag = solider.Tag as TagSolider;
            if ((i_NumberOfPlayer == eNumberOfPlayer.Second && CheckerboardController.Instance.OtherPlayer.TypeOfPlayer != eTypeOfPlayer.Computer) || i_NumberOfPlayer == eNumberOfPlayer.First)
            {
                solider.MouseClick += solider_MouseClick;
            }

			solider.PictureOfSoliderStoppedToMove += solider_PictureOfSoliderStoppedToMove;
            this.Controls.Add(solider);
            solider.BringToFront();
        }

        private void swapIndexToDrawTheSolider(ref int i_Index, int i)
        {
            if (i % 2 == 0)
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
            squareBoard.Size = new Size(k_SizeOfSquareInBoard, k_SizeOfSquareInBoard);
            squareBoard.TabStop = false;
            squareBoard.MouseClick += squareBoard_MouseClick;
            string stringToSetToTagName = String.Format("{0}{1}", (char)(MovementOptions.k_StartCol + i_Col), (char)(MovementOptions.k_StartRow + i_Row));
            squareBoard.Name = string.Format("{0}{1}", stringToSetToTagName, k_SquarePicName);
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
            int sizeOfBoard = (int)CheckerboardController.Instance.SizeBoard;
            Label labelsTop;
            Label labelsDown;
            Label labelsLeftSide;
            Label labelsRightSide;
            Point pointForLabelsUp = new Point(158, 90);
            Point pointForLabelsDown = new Point(158, 90);
            Point pointForLabelsLeftSide = new Point(120, 130);
            Point pointForLabelsRightSide = new Point(115, 130);

            char textToAddUp = MovementOptions.k_StartCol;
            char textToAddInTheSides = MovementOptions.k_StartRow;

            for (int i = 0; i < sizeOfBoard; i++)
            {
                pointForLabelsDown.Y += k_SizeOfSquareInBoard;
                pointForLabelsRightSide.X += k_SizeOfSquareInBoard;
            }
            pointForLabelsDown.Y += 40;
            pointForLabelsRightSide.X += 40;

            for (int i = 0; i < sizeOfBoard; i++)
            {
                labelsTop = new Label();
                labelsDown = new Label();
                labelsLeftSide = new Label();
                labelsRightSide = new Label();

                labelsTop.Text = textToAddUp.ToString();
                labelsTop.BackColor = Color.Transparent;
                labelsTop.Font = new Font("Segoe Script", 14, FontStyle.Bold);
                labelsTop.AutoSize = true;
                labelsTop.Location = pointForLabelsUp;

                labelsDown.Text = textToAddUp.ToString();
                labelsDown.BackColor = Color.Transparent;
                labelsDown.Font = new Font("Segoe Script", 14, FontStyle.Bold);
                labelsDown.AutoSize = true;
                labelsDown.Location = pointForLabelsDown;

                labelsLeftSide.Text = textToAddInTheSides.ToString();
                labelsLeftSide.BackColor = Color.Transparent;
                labelsLeftSide.Font = new Font("Segoe Script", 14, FontStyle.Bold);
                labelsLeftSide.AutoSize = true;
                labelsLeftSide.Location = pointForLabelsLeftSide;

                labelsRightSide.Text = textToAddInTheSides.ToString();
                labelsRightSide.BackColor = Color.Transparent;
                labelsRightSide.Font = new Font("Segoe Script", 14, FontStyle.Bold);
                labelsRightSide.AutoSize = true;
                labelsRightSide.Location = pointForLabelsRightSide;

                this.Controls.Add(labelsTop);
                this.Controls.Add(labelsDown);
                this.Controls.Add(labelsLeftSide);
                this.Controls.Add(labelsRightSide);

                textToAddUp = (char)(textToAddUp + 1);
                textToAddInTheSides = (char)(textToAddInTheSides + 1);

                pointForLabelsUp.X += k_SizeOfSquareInBoard;
                pointForLabelsDown.X += k_SizeOfSquareInBoard;
                pointForLabelsLeftSide.Y += k_SizeOfSquareInBoard;
                pointForLabelsRightSide.Y += k_SizeOfSquareInBoard;
            }

        }

        private void initializeEventHandlers()
        {
            initializeEventForPlayer(CheckerboardController.Instance.CurrentPlayer);
            initializeEventForPlayer(CheckerboardController.Instance.OtherPlayer);
        }
      
        private void initializeEventForPlayer(Player i_Player)
        {
            foreach (Soldier currentSoldier in i_Player.Soldiers)
            {
				currentSoldier.StartAnimationOfSoliderMovingAfterChangePlaceOnBoard += this.solider_StartAnimationOfSoliderMovingAfterChangePlaceOnBoard;
				currentSoldier.ChangePictureOfSoliderAfterChangedType += this.solider_ChangePictureOfSoliderAfterChangedType;
				currentSoldier.RemoveSoliderFromBoard += this.solider_RemoveSoliderFromBoard;
            }
        }

        private void removeBorderFromSoliderThatHaveBeenChosen()
        {
            Control[] soliderToMove = this.Controls.Find(String.Format("{0}{1}", m_CurrentMove.FromSquare.ToString(), k_SoliderPicName), false);
            soliderToMove[0].Invalidate();
        }

		private void gameStatusChangeMessage(eGameStatus i_CurrentGameStatus)
        {
            m_IsChooseSolider = true;
            string message = "";
            const string caption = "Form Closing";
            switch (i_CurrentGameStatus)
            {
                case eGameStatus.FirstPlayerWon:
                    message = "player 1 Won!\nAnother Round?";
                    break;
                case eGameStatus.SecondPlayerWon:
                    message = "player 2 Won!\nAnother Round?";
                    break;
                case eGameStatus.Tie:
                    message = "Tie!\nAnother Round?";
                    break;
            }
            var messageBoxResult = MessageBox.Show(message, caption, MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (messageBoxResult == DialogResult.Yes)
            {
                CheckerboardController.Instance.InitializeCheckerGame();
                removeAllSolidersFromBord();
                updateScoreInsideLabels();
                generateBoardSquaresAndSoliders(false);
                m_IsChooseSolider = false;
                m_IsSoliderIsMovingRightNow = false;
                CheckerboardController.Instance.GameStatus = eGameStatus.ContinueGame;
            }
            else
            {
                this.Close();
                //OrDispose;
            }
        }

        private void removeAllSolidersFromBord()
        {
            foreach (Control c in this.Controls)
            {
                OvalPictureBox currentSolider = c as OvalPictureBox;
                if (currentSolider != null)
                {
                    this.Controls.Remove(c);
                }
            }
        }

        private void updateScoreInsideLabels()
        {
            Control[] firstPlayerLabel, secondPlayerLabel;
            firstPlayerLabel = this.Controls.Find(k_LabelNameOfFirstPlayer, false);
            secondPlayerLabel = this.Controls.Find(k_LabelNameOfSecondPlayer, false);
            PictureBoxWithText firstLabel = firstPlayerLabel[0] as PictureBoxWithText;
            PictureBoxWithText secondLabel = secondPlayerLabel[0] as PictureBoxWithText;
            firstLabel.setNewTextInsidePicture(String.Format("{0} - {1}", CheckerboardController.Instance.CurrentPlayer.PlayerName, CheckerboardController.Instance.CurrentPlayer.Score));
            secondLabel.setNewTextInsidePicture(String.Format("{0} - {1}", CheckerboardController.Instance.OtherPlayer.PlayerName, CheckerboardController.Instance.OtherPlayer.Score));
        }

        //Listeners
        private void closeButton_Click(object i_Sender, EventArgs i_Events)
        {
            this.Dispose();
        }

		private void solider_MouseClick(object i_Sender, MouseEventArgs i_Events)
        {
			if (!m_IsSoliderIsMovingRightNow)
			{
				OvalPictureBox currentSolider = i_Sender as OvalPictureBox;
				if (m_IsChooseSolider == true)
				{
					removeBorderFromSoliderThatHaveBeenChosen();
					Control[] soliderToMove = this.Controls.Find(String.Format("{0}{1}", m_CurrentMove.FromSquare.ToString(), k_SoliderPicName), false);
					soliderToMove[0].Refresh();
				}

				TagSolider currentTagSolider = currentSolider.Tag as TagSolider;
				if (currentTagSolider.NumberOfPlayer == CheckerboardController.Instance.CurrentPlayer.NumberOfPlayer)
				{
					currentSolider.MakeBorder(currentSolider.CreateGraphics());
					this.m_CurrentMove.FromSquare = new Square(currentTagSolider.Name[1], currentTagSolider.Name[0]);
					this.m_IsChooseSolider = true;
				}
				else
				{
					this.m_IsChooseSolider = false;
				}
			}
        }

		private async void squareBoard_MouseClick(object i_Sender, MouseEventArgs i_Events)
        {
			if (this.m_IsChooseSolider == true)
			{
				removeBorderFromSoliderThatHaveBeenChosen();
				PictureBox currentSquare = i_Sender as PictureBox;            
				TagName currentPositionOfCurrentSolider = currentSquare.Tag as TagName;
				this.m_CurrentMove.ToSquare = new Square(currentPositionOfCurrentSolider.Name[1], currentPositionOfCurrentSolider.Name[0]);
				CheckerboardController.Instance.nextTurn(m_CurrentMove);
				if (CheckerboardController.Instance.GameStatus != eGameStatus.ContinueGame)
				{
					await Task.Delay(3000);
					gameStatusChangeMessage(CheckerboardController.Instance.GameStatus);
				}
				else
				{
					while (CheckerboardController.Instance.CurrentPlayer.TypeOfPlayer == eTypeOfPlayer.Computer && CheckerboardController.Instance.GameStatus == eGameStatus.ContinueGame)
					{
						await Task.Delay(3000);
						CheckerboardController.Instance.nextTurn(null);
						if (CheckerboardController.Instance.GameStatus != eGameStatus.ContinueGame)
						{
							await Task.Delay(3000);
							gameStatusChangeMessage(CheckerboardController.Instance.GameStatus);
							break;
						}

					}
				} 

                this.m_IsChooseSolider = false;
            }
        }

		private void solider_ChangePictureOfSoliderAfterChangedType(Soldier i_Soldier)
        {
            Control[] soliderToMove = this.Controls.Find(String.Format("{0}{1}", i_Soldier.PlaceOnBoard.ToString(), k_SoliderPicName), false);
            if (i_Soldier.CharRepresent == Soldier.k_FirstPlayerKing)
                soliderToMove[0].BackgroundImage = Properties.Resources.BlackKing;
            else
            {
                soliderToMove[0].BackgroundImage = Properties.Resources.WhiteKing;
            }
        }

		private void solider_StartAnimationOfSoliderMovingAfterChangePlaceOnBoard(Square i_OldSquare, Square i_NewSquare)
		{         
			Control[] soliderToMove = this.Controls.Find(String.Format("{0}{1}", i_OldSquare.ToString(), k_SoliderPicName), false);
			Control[] squareToMoveTheSolider = this.Controls.Find(String.Format("{0}{1}", i_NewSquare.ToString(), k_SquarePicName), false);
			Point currentLocationOfSquare = squareToMoveTheSolider[0].Location;
			OvalPictureBox currentSolider = soliderToMove[0] as OvalPictureBox;
			Point newLocation = new Point(currentLocationOfSquare.X + 2, currentLocationOfSquare.Y + 2);
			m_IsSoliderIsMovingRightNow = true;
			currentSolider.BringToFront();
			currentSolider.startAnimationOfMovingSolider(newLocation);
			TagSolider tagOfCurrentSolider = soliderToMove[0].Tag as TagSolider;
			tagOfCurrentSolider.Name = i_NewSquare.ToString();
			soliderToMove[0].Name = String.Format("{0}{1}", i_NewSquare.ToString(), k_SoliderPicName);
		}

		private void solider_RemoveSoliderFromBoard(Soldier i_SoldierToRemove)
        {
            Control[] soliderToRemove = this.Controls.Find(String.Format("{0}{1}", i_SoldierToRemove.PlaceOnBoard.ToString(), k_SoliderPicName), false);
            OvalPictureBox currentSolider = soliderToRemove[0] as OvalPictureBox;
            Timer tempTimer = new Timer();
            tempTimer.Interval = 1100;
            tempTimer.Tick += (sender, e) =>
            {
                this.Controls.Remove(soliderToRemove[0]);
                tempTimer.Stop();
            };
            tempTimer.Start();
        }

		private void solider_PictureOfSoliderStoppedToMove(bool i_IsStopToMove)
        {
            m_IsSoliderIsMovingRightNow = i_IsStopToMove;

        }      
    }
}
