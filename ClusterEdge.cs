using System.Numerics;





namespace HierholzersAlgorithm
{
    internal class ClusterEdge : Control
    {
        private int _edgeId;

        internal ClusterPoint startPoint;
        internal ClusterPoint endPoint;
        internal Point startLocation;
        internal Point endLocation;



        internal int EdgeId
        {
            get
            {
                return _edgeId;
            }
            set
            {
                _edgeId = value;
                Invalidate();
            }
        }



        internal ClusterEdge(ClusterPoint startPoint, ClusterPoint endPoint)
        {
            this.startPoint = startPoint;
            this.endPoint = endPoint;
        }

        internal void Draw(Graphics g)
        {
            using Pen pen = new(Color.Black, 4);

            startLocation = new(startPoint.Location.X + startPoint.Width / 2, startPoint.Location.Y + startPoint.Height / 2);
            endLocation = new(endPoint.Location.X + endPoint.Width / 2, endPoint.Location.Y + endPoint.Height / 2);

            g.DrawLine(pen, startLocation, endLocation);
        }

        internal bool ClickedOnEdge(Point clickLocation, float tolerance = 5f)
        {
            // Algorithm created by ChatGPT
            Vector2 edgeStartPoint = new(startLocation.X, startLocation.Y);
            Vector2 edgeEndPoint = new(endLocation.X, endLocation.Y);

            float edgeLength = Vector2.Distance(edgeStartPoint, edgeEndPoint);

            if (edgeLength == 0)
            {
                return clickLocation == this.startLocation;
            }

            float deltaX = endLocation.X - startLocation.X;
            float deltaY = endLocation.Y - startLocation.Y;

            float constantTerm = endLocation.X * startLocation.Y - endLocation.Y * startLocation.X;

            float numerator = Math.Abs(deltaY * clickLocation.X - deltaX * clickLocation.Y + constantTerm);

            return numerator / edgeLength <= tolerance;
        }
    }
}