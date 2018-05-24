using System;
using System.Drawing;
using System.Windows.Forms;

namespace View
{
    public class PictureBoxWithText : Control
    {
        private PictureBox m_Picture;
        private String m_Text;
        private Image m_Image;

        public PictureBoxWithText(Image i_ImageToSet, String i_Text)
        {
            SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            m_Image = i_ImageToSet;
            m_Text = i_Text;
            InitializeComponent();
           
            this.Controls.Add(m_Picture);
        }
        public void setNewTextInsidePicture(string i_Text)
        {
            m_Text = i_Text;
            this.Invalidate();
        }
        
        private void InitializeComponent()
        {
            m_Picture = new PictureBox();
            m_Picture.BackgroundImage = m_Image;
            m_Picture.SendToBack();
            m_Picture.BackColor = Color.Transparent;
            m_Picture.BackgroundImageLayout = ImageLayout.Stretch;
            m_Picture.SizeMode = PictureBoxSizeMode.StretchImage;
            m_Picture.Paint += OnDrawText;
            m_Picture.Size = new Size(200,80);
            m_Picture.Location = new Point(0, 0);
            this.Location = new Point(0, 0);
            this.Size = new Size(200, 80);
            this.BackColor = Color.Transparent;
        }

        private void OnDrawText(object sender,PaintEventArgs e)
        {
            e.Graphics.TextRenderingHint = System.Drawing.Text.TextRenderingHint.ClearTypeGridFit;
            string text = m_Text;
            SizeF textSize = e.Graphics.MeasureString(text, Font);
            PointF locationToDraw = new PointF();
            locationToDraw.X = (m_Picture.Width / 2) - (textSize.Width / 2) - 20;
            locationToDraw.Y = (m_Picture.Height / 2) - (textSize.Height / 2);
            e.Graphics.DrawString(text, new Font("Segoe Script", 10, FontStyle.Bold), Brushes.Black, locationToDraw);
        }


    }
}
