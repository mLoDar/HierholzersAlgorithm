using System.Drawing.Drawing2D;





namespace HierholzersAlgorithm.ClusterElements
{
    internal class ClusterPoint : Button
    {
        private int _pointId = 0;
        private int _cornerRadius = 50;

        private bool _draggingPoint = false;
        private Point _locationOffset;
        internal Point locationOnMouseDown;



        internal int PointId
        {
            get
            {
                return _pointId;
            }
            set
            {
                _pointId = value;
                Invalidate();
            }
        }

        internal int CornerRadius
        {
            get
            {
                return _cornerRadius;
            }
            set
            {
                _cornerRadius = value;
                Invalidate();
            }
        }



        internal ClusterPoint()
        {
            MouseDown += ClusterPoint_MouseDown;
            MouseMove += ClusterPoint_MouseMove;
            MouseUp += ClusterPoint_MouseUp;
        }

        protected override void OnPaint(PaintEventArgs paintEventArgs)
        {
            base.OnPaint(paintEventArgs);

            GraphicsPath graphicsPath = new();

            graphicsPath.AddArc(0, 0, _cornerRadius, _cornerRadius, 180, 90);
            graphicsPath.AddArc(Width - _cornerRadius - 1, 0, _cornerRadius, _cornerRadius, 270, 90);
            graphicsPath.AddArc(Width - _cornerRadius - 1, Height - _cornerRadius - 1, _cornerRadius, _cornerRadius, 0, 90);
            graphicsPath.AddArc(0, Height - _cornerRadius - 1, _cornerRadius, _cornerRadius, 90, 90);
            graphicsPath.CloseFigure();

            Region = new Region(graphicsPath);

            using (SolidBrush solidBrush = new(BackColor))
            {
                paintEventArgs.Graphics.FillPath(solidBrush, graphicsPath);
            }

            using (Pen pen = new(Color.Black, 4))
            {
                paintEventArgs.Graphics.DrawPath(pen, graphicsPath);
            }

            TextRenderer.DrawText(paintEventArgs.Graphics, Text, Font, ClientRectangle, ForeColor, TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
        }

        private void ClusterPoint_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                _draggingPoint = true;
                _locationOffset = new Point(e.X, e.Y);
            }
        }

        private void ClusterPoint_MouseMove(object sender, MouseEventArgs e)
        {
            if (_draggingPoint)
            {
                int newX = Left + (e.X - _locationOffset.X);
                int newY = Top + (e.Y - _locationOffset.Y);

                Location = new Point(newX, newY);
            }
        }

        private void ClusterPoint_MouseUp(object sender, MouseEventArgs e)
        {
            _draggingPoint = false;
        }
    }
}