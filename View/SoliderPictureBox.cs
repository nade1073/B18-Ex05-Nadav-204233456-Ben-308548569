using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace View
{
    class OvalPictureBox : PictureBox
    {
        public OvalPictureBox(Image i_ImageToSet)
        {
            this.BackColor = Color.DarkGray;
            this.BackgroundImage = i_ImageToSet;
            this.BackgroundImageLayout = ImageLayout.Stretch;
            this.Size = new Size(45, 45);

        }
        protected override void OnResize(EventArgs e)
        {
            base.OnResize(e);
            using (var gp = new GraphicsPath())
            {
                gp.AddEllipse(new Rectangle(0, 0, this.Width - 1, this.Height - 1));
                this.Region = new Region(gp);
            }
        }
    }
}
