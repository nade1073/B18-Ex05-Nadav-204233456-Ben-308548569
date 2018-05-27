using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace View
{
    public class OvalPictureBox : PictureBox
    {
        private Timer m_TimerOfMovingPic;
        private Point m_NewLocation;
		private const int k_SizeOfPic = 45;
		private const int k_TimeInterval = 10;

        public event Action<bool> PictureOfSoliderStoppedToMove;

        public OvalPictureBox(Image i_ImageToSet)
        {
            this.BackgroundImage = i_ImageToSet;
            this.BackColor = Color.Transparent;
            this.BackgroundImageLayout = ImageLayout.Stretch;
			this.Size = new Size(k_SizeOfPic, k_SizeOfPic);
            this.m_TimerOfMovingPic = new Timer();
			this.m_TimerOfMovingPic.Interval = k_TimeInterval;
            this.m_TimerOfMovingPic.Tick += TimerOfMovingPic_Tick;
        }

        private void TimerOfMovingPic_Tick(object i_Sender, EventArgs i_Events)
        {
            if (this.Location == m_NewLocation)
            {
                doWhenReachToThePlace();
            }
            else
            {
                if (this.Location.Y > m_NewLocation.Y)
                {
                    this.Top -= 1;                  
                }
                else
                {
                    this.Top += 1;                  
                }

                if (this.Location.X > m_NewLocation.X)
                {
                    this.Left -= 1;
                }
                else
                {
                    this.Left += 1;
                }
            }
        }

        public void startAnimationOfMovingSolider(Point i_NewLocation)
        {
            m_NewLocation = i_NewLocation;
            m_TimerOfMovingPic.Start();
        }

        private void doWhenReachToThePlace()
        {
            m_TimerOfMovingPic.Stop();
			OnPictureOfSoliderStoppedToMove();
        }

		private void OnPictureOfSoliderStoppedToMove()
        {
			if (PictureOfSoliderStoppedToMove != null)
            {
				PictureOfSoliderStoppedToMove.Invoke(false);
            }         
        }

        public void MakeBorder(Graphics i_Events)
        {
            float penWidth = 4F;
            Pen myPen = new Pen(Color.FromArgb(255, 255, 255), penWidth);
			i_Events.DrawEllipse(myPen, new RectangleF(new PointF(3, 3), new SizeF((float)(this.Width - 7), this.Height - 7)));
            myPen.Dispose();
        }

		protected override void OnResize(EventArgs i_Events)
        {
			base.OnResize(i_Events);
            using (var gp = new GraphicsPath())
            {
                gp.AddEllipse(new Rectangle(3, 3, this.Width - 7, this.Height - 7));
                this.Region = new Region(gp);
            }
        }     
    }
}
