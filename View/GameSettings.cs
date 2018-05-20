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
            bool isFirstPlayerHasValidName = Player.isPlayerNameValid(PlayerOneTextBox.Text);
            CheckState eCheckStateOfCheckBox = CheckBoxOfPlayerTwo.CheckState;
            bool isSecondPlayerHasValidName = true;
            if (CheckState.Checked== eCheckStateOfCheckBox)
            {
                isSecondPlayerHasValidName = Player.isPlayerNameValid(PlayerTwoTextBox.Text);
            }
            if(isSecondPlayerHasValidName && isSecondPlayerHasValidName)
            {

            }
            else
            {
               
            }
        }
    }
}
