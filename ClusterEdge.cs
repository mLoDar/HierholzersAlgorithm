using System.Numerics;

namespace HierholzersAlgorithm
{
    internal class ClusterEdge : Control
    {
        private int _edgeId;

        internal readonly ClusterPoint _startPoint;
        internal readonly ClusterPoint _EndPoint;
        private Point _startLocation;
        private Point _endLocation;



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



        internal ClusterEdge(ClusterPoint startPoint, ClusterPoint endPoint, Point startLocation, Point endLocation)
        {
            _startPoint = startPoint;
            _EndPoint = endPoint;
            _startLocation = startLocation;
            _endLocation = endLocation;
        }

        internal void Draw(Graphics g)
        {
            using Pen pen = new(Color.Black, 4);

            g.DrawLine(pen, _startLocation, _endLocation);
        }

        internal bool ClickedOnEdge(Point clickLocation, float tolerance = 5f)
        {
            // Algorithm created by ChatGPT
            Vector2 edgeStartPoint = new(this._startLocation.X, this._startLocation.Y);
            Vector2 edgeEndPoint = new(this._endLocation.X, this._endLocation.Y);

            float edgeLength = Vector2.Distance(edgeStartPoint, edgeEndPoint);

            if (edgeLength == 0)
            {
                return clickLocation == this._startLocation;
            }

            float deltaX = this._endLocation.X - this._startLocation.X;
            float deltaY = this._endLocation.Y - this._startLocation.Y;

            float constantTerm = this._endLocation.X * this._startLocation.Y - this._endLocation.Y * this._startLocation.X;

            float numerator = Math.Abs(deltaY * clickLocation.X - deltaX * clickLocation.Y + constantTerm);

            return numerator / edgeLength <= tolerance;
        }
    }
}