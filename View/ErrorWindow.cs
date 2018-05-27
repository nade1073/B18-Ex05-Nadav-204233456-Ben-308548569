using System;
using System.Windows.Forms;

namespace View
{
    public partial class ErrorWindow : Form
    {
        public ErrorWindow()
        {
            InitializeComponent();
        }
        
        private void button1_Click(object i_Sender, EventArgs i_Events)
        {
            this.Dispose();
        }
    }
}
