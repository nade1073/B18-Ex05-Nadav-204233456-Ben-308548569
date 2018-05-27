namespace View
{
	using System.Windows.Forms;
    using Controller;
	using System;

	public partial class GameSettings : Form
    {
		private const string k_ComputerName="[Computer]";
        public GameSettings()
        {
            InitializeComponent();
        }

        private void checkBox1_CheckedChanged(object i_Sender, EventArgs i_Events)
        {
			CheckBox checkBoxOfPlayerTwo = i_Sender as CheckBox;
			if(checkBoxOfPlayerTwo.Checked==true)
            {
                this.PlayerTwoTextBox.Enabled = true;
                this.PlayerTwoTextBox.Text = string.Empty;
            }
            else
            {
                this.PlayerTwoTextBox.Enabled = false;
				this.PlayerTwoTextBox.Text = k_ComputerName;
            }  
        }

		private void DoneButton_Click(object i_Sender, EventArgs i_Events)
        {
            string firstName = PlayerOneTextBox.Text;
            string secondName = null;   
            bool isFirstPlayerHasValidName = Player.isPlayerNameValid(firstName);
            CheckState eCheckStateOfCheckBox = CheckBoxOfPlayerTwo.CheckState;
            bool isSecondPlayerHasValidName = true;
            if (CheckState.Checked== eCheckStateOfCheckBox)
            {
                secondName = PlayerTwoTextBox.Text;
                isSecondPlayerHasValidName = Player.isPlayerNameValid(secondName);
            }
            if(isFirstPlayerHasValidName && isSecondPlayerHasValidName)
            {
                eSizeBoard sizeOfBoard;
                if(this.SixSize.Checked)
                {
                    sizeOfBoard = eSizeBoard.Six;
                }
                else if(this.EightSize.Checked)
                {
                    sizeOfBoard = eSizeBoard.Eight;
                }
                else
                {
                    sizeOfBoard = eSizeBoard.Ten;
                }

                this.Hide();
                CheckerboardController.Instance.initializeCheckerBoard(firstName, secondName, sizeOfBoard);
                CheckerBoardForm viewBoard = new CheckerBoardForm();
                viewBoard.ShowDialog();
                this.Close();         
            }
            else
            {
                ErrorWindow errorForm = new ErrorWindow();
                errorForm.ShowDialog();
            }
        }
    }
}
