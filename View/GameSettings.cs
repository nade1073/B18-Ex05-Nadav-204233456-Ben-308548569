using System.Windows.Forms;
using Controller;
namespace View
{
    public partial class GameSettings : Form
    {
        public GameSettings()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, System.EventArgs e)
        {

        }

        private void checkBox1_CheckedChanged(object sender, System.EventArgs e)
        {
            CheckBox CheckBoxOfPlayerTwo = sender as CheckBox;
            if(CheckBoxOfPlayerTwo.Checked==true)
            {
                this.PlayerTwoTextBox.Enabled = true;
                this.PlayerTwoTextBox.Text = string.Empty;
            }
            else
            {
                this.PlayerTwoTextBox.Enabled = false;
                this.PlayerTwoTextBox.Text = "[Computer]";
            }
            
        }

        private void DoneButton_Click(object sender, System.EventArgs e)
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
          //  if(isFirstPlayerHasValidName && isSecondPlayerHasValidName)
           // {
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
                CheckerBoard board = new CheckerBoard();
                board.initializeCheckerBoard("Nadav", "Shalev", sizeOfBoard);
                ViewCheckerBoard viewBoard = new ViewCheckerBoard(board);
                viewBoard.ShowDialog();
                this.Close();         
            //}
            //else
            //{
            //    ErrorWindow errorForm = new ErrorWindow();
            //    errorForm.ShowDialog();
            //}
        }
    }
}
