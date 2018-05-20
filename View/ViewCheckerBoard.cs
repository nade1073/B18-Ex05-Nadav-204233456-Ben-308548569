using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Windows.Forms;
using Controller;

namespace View
{
    public partial class ViewCheckerBoard : Form
    {
        private CheckerBoard m_Board;

        public ViewCheckerBoard(CheckerBoard i_CheckerBoard)
        {
            m_Board = i_CheckerBoard;
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            this.Dispose();
        }

    }
}
