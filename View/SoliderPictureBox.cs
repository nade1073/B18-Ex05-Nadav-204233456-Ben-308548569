using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace View
{
    class OvalPictureBox : PictureBox
    {
        private Timer m_TimerOfMovingPic;
        private Point m_NewLocation;
        public event Action<bool> StopSoliderMoveEventHandler;

        public OvalPictureBox(Image i_ImageToSet)
        {
            this.BackColor = Color.DarkGray;
            this.BackgroundImage = i_ImageToSet;
            this.BackgroundImageLayout = ImageLayout.Stretch;
            this.Size = new Size(45, 45);
            this.m_TimerOfMovingPic = new Timer();
            this.m_TimerOfMovingPic.Interval = 10;
            this.m_TimerOfMovingPic.Tick += TimerOfMovingPic_Tick;
        }

        private void TimerOfMovingPic_Tick(object sender, EventArgs e)
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
                if(this.Location.X > m_NewLocation.X)
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
            OnStopSoliderMove();
        }

        private void OnStopSoliderMove()
        {
            if(StopSoliderMoveEventHandler!=null)
            {
                StopSoliderMoveEventHandler.Invoke(false);
            }
        }

        public void MakeBorder(Graphics e)
        {
            float penWidth = 6F;
            Pen myPen = new Pen(Color.FromArgb(255, 255, 255), penWidth);
            e.DrawEllipse(myPen, new RectangleF(new PointF(0, 0), new SizeF((float)(this.Width - 1), this.Height - 1)));
            myPen.Dispose();
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
