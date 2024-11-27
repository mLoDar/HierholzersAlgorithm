using System.Drawing.Drawing2D;
using System.Windows.Forms;





namespace HierholzersAlgorithm
{
    internal class ClusterPoint : Button
    {
        private int _pointId = 0;
        private int _cornerRadius = 0;



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



        protected override void OnPaint(PaintEventArgs paintEventArgs)
        {
            base.OnPaint(paintEventArgs);

            GraphicsPath graphicsPath = new();

            graphicsPath.AddArc(0, 0, _cornerRadius, _cornerRadius, 180, 90);
            graphicsPath.AddArc(Width - _cornerRadius - 1, 0, _cornerRadius, _cornerRadius, 270, 90);
            graphicsPath.AddArc(Width - _cornerRadius - 1, Height - _cornerRadius - 1, _cornerRadius, _cornerRadius, 0, 90);
            graphicsPath.AddArc(0, Height - _cornerRadius - 1, _cornerRadius, _cornerRadius, 90, 90);
            graphicsPath.CloseFigure();

            this.Region = new Region(graphicsPath);

            using (SolidBrush solidBrush = new(this.BackColor))
            {
                paintEventArgs.Graphics.FillPath(solidBrush, graphicsPath);
            }

            using (Pen pen = new(Color.Black, 4))
            {
                paintEventArgs.Graphics.DrawPath(pen, graphicsPath);
            }

            TextRenderer.DrawText(paintEventArgs.Graphics, Text, Font, ClientRectangle, ForeColor, TextFormatFlags.HorizontalCenter | TextFormatFlags.VerticalCenter);
        }

        protected override void OnMouseDown(MouseEventArgs mouseEventArgs)
        {
            base.OnMouseDown(mouseEventArgs);

            MainForm.ClusterPoint_Click(this, mouseEventArgs);
        }
    }
}