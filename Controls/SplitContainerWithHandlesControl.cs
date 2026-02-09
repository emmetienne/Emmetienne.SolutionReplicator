using System.Drawing;
using System.Windows.Forms;

namespace Emmetienne.SolutionReplicator.Controls
{
    internal class SplitContainerWithHandlesControl : SplitContainer
    {
        public SplitContainerWithHandlesControl()
        {
            this.SetStyle(ControlStyles.UserPaint, true);
            this.MouseDown += OnMouseDown;
            this.MouseMove += OnMouseMove;
            this.MouseUp += OnMouseUp;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            // Calcola il rettangolo dello splitter
            Rectangle gripRect;
            if (Orientation == Orientation.Vertical)
            {
                gripRect = new Rectangle(
                    SplitterDistance,
                    0,
                    SplitterWidth,
                    Height
                );
            }
            else
            {
                gripRect = new Rectangle(
                    0,
                    SplitterDistance,
                    Width,
                    SplitterWidth
                );
            }

            var brush = new SolidBrush(Color.Gray);

            // Disegna solo 3 puntini centrati
            if (Orientation == Orientation.Vertical)
            {
                int centerX = gripRect.X + gripRect.Width / 2;
                int centerY = gripRect.Y + gripRect.Height / 2;

                // Spaziatura verticale
                int spacing = 10;

                for (int i = -1; i <= 1; i++)
                {
                    int y = centerY + (i * spacing);
                    e.Graphics.FillEllipse(brush, centerX - 2, y - 2, 4, 4);
                }
            }
            else
            {
                int centerY = gripRect.Y + gripRect.Height / 2;
                int centerX = gripRect.X + gripRect.Width / 2;

                // Spaziatura orizzontale
                int spacing = 10;

                for (int i = -1; i <= 1; i++)
                {
                    int x = centerX + (i * spacing);
                    e.Graphics.FillEllipse(brush, x - 2, centerY - 2, 4, 4);
                }
            }

        }

        private void OnMouseDown(object sender, MouseEventArgs e)
        {
            // This disables the normal move behavior
            ((SplitContainer)sender).IsSplitterFixed = true;
        }

        private void OnMouseUp(object sender, MouseEventArgs e)
        {
            // This allows the splitter to be moved normally again
            ((SplitContainer)sender).IsSplitterFixed = false;
        }

        //assign this to the SplitContainer's MouseMove event
        private void OnMouseMove(object sender, MouseEventArgs e)
        {

            if (!((SplitContainer)sender).IsSplitterFixed)
                return;

            if (!e.Button.Equals(MouseButtons.Left))
            {
                ((SplitContainer)sender).IsSplitterFixed = false;
                return;
            }
            if (((SplitContainer)sender).Orientation.Equals(Orientation.Vertical))
            {

                if (e.X > 0 && e.X < ((SplitContainer)sender).Width)
                {
                    ((SplitContainer)sender).SplitterDistance = e.X;
                    ((SplitContainer)sender).Refresh();
                }
            }
            else
            {
                if (e.Y > 0 && e.Y < ((SplitContainer)sender).Height)
                {
                    ((SplitContainer)sender).SplitterDistance = e.Y;
                    ((SplitContainer)sender).Refresh();
                }
            }
        }
    }
}
