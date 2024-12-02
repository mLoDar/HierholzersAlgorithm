namespace HierholzersAlgorithm
{
    public partial class MainForm : Form
    {
        private static readonly Point _restrictedArea = new(220, 440);

        private static readonly int pointDiameter = 50;
        private static readonly List<ClusterPoint> _clusterPoints = [];
        private static readonly List<ClusterEdge> _clusterEdges = [];

        private static ClusterPoint _selectedEdgeStartPoint;
        private static Color _selectedEdgeStartPointOriginalColor;



        public MainForm()
        {
            InitializeComponent();

            this.DoubleBuffered = true;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            foreach (ClusterEdge clusterEdge in _clusterEdges)
            {
                clusterEdge.Draw(e.Graphics);
            }
        }



        private void MainForm_Click(object sender, EventArgs e)
        {
            MouseEventArgs mouseEventArgs = (MouseEventArgs)e;

            Point clickLocation = mouseEventArgs.Location;
            MouseButtons clickButton = mouseEventArgs.Button;

            ClusterEdge clickedEdge = null;

            if (ClickedOutsideRestrictedArea(clickLocation))
            {
                return;
            }


            foreach (ClusterEdge clusterEdge in _clusterEdges)
            {
                if (clusterEdge.ClickedOnEdge(clickLocation))
                {
                    clickedEdge = clusterEdge;
                    break;
                }
            }

            this.Invalidate();



            if (clickButton == MouseButtons.Left)
            {
                string processResult = AddNewPoint(clickLocation);

                this.Invalidate();

                if (processResult.Equals(string.Empty) == false)
                {
                    string text = processResult;
                    string caption = "Failed to add a new point!";

                    MessageBox.Show(text, caption, MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    return;
                }
            }

            if (clickButton == MouseButtons.Right)
            {
                if (clickedEdge != null)
                {
                    _clusterEdges.Remove(clickedEdge);
                    this.Controls.Remove(clickedEdge);

                    this.Invalidate();
                }
            }
        }

        private void ClusterPoint_Click(object sender, EventArgs e)
        {
            ClusterPoint clickedClusterPoint = (ClusterPoint)sender;
            MouseEventArgs mouseEventArgs = (MouseEventArgs)e;

            if (mouseEventArgs.Button == MouseButtons.Right)
            {
                RemoveExisitingPoint(clickedClusterPoint);
                this.Invalidate();

                return;
            }

            if (mouseEventArgs.Button == MouseButtons.Left)
            {
                if (_selectedEdgeStartPoint == clickedClusterPoint)
                {
                    _selectedEdgeStartPoint = null;
                    clickedClusterPoint.BackColor = _selectedEdgeStartPointOriginalColor;

                    this.Invalidate();

                    return;
                }

                if (_selectedEdgeStartPoint == null)
                {
                    _selectedEdgeStartPointOriginalColor = clickedClusterPoint.BackColor;
                    _selectedEdgeStartPoint = clickedClusterPoint;

                    Color currentPointColor = clickedClusterPoint.BackColor;

                    if (currentPointColor.R > 200 || currentPointColor.G > 200 && currentPointColor.B > 200)
                    {
                        int r = Math.Max(currentPointColor.R - 50, 0);
                        int g = Math.Max(currentPointColor.G - 50, 0);
                        int b = Math.Max(currentPointColor.B - 50, 0);

                        clickedClusterPoint.BackColor = Color.FromArgb(r, g, b);
                    }
                    else
                    {
                        int r = Math.Min(currentPointColor.R + 50, 0);
                        int g = Math.Min(currentPointColor.G + 50, 0);
                        int b = Math.Min(currentPointColor.B + 50, 0);

                        clickedClusterPoint.BackColor = Color.FromArgb(r, g, b);
                    }

                    this.Invalidate();

                    return;
                }

                if (this.Controls.Contains(_selectedEdgeStartPoint) == false)
                {
                    _selectedEdgeStartPoint = null;
                    return;
                }

                if (EdgeAlreadyExists(_selectedEdgeStartPoint, clickedClusterPoint))
                {
                    return;
                }



                string processResult = AddNewEdge(_selectedEdgeStartPoint, clickedClusterPoint);

                this.Invalidate();

                if (processResult.Equals(string.Empty) == false)
                {
                    string text = processResult;
                    string caption = "Failed to add a new edge!";

                    MessageBox.Show(text, caption, MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    return;
                }

                _selectedEdgeStartPoint.BackColor = _selectedEdgeStartPointOriginalColor;
                _selectedEdgeStartPoint = null;

                this.Invalidate();
            }
        }

        private void ButtonRecolorPoint_Click(object sender, EventArgs e)
        {
            if (_selectedEdgeStartPoint == null)
            {
                string text = "You need to select a valid cluster point first.";
                string caption = "Failed to recolor a point!";

                MessageBox.Show(text, caption, MessageBoxButtons.OK, MessageBoxIcon.Warning);

                return;
            }

            using ColorDialog colorDialog = new();

            if (colorDialog.ShowDialog() == DialogResult.OK)
            {
                _selectedEdgeStartPoint.BackColor = colorDialog.Color;
                _selectedEdgeStartPointOriginalColor = colorDialog.Color;

                _selectedEdgeStartPoint = null;
            }
        }



        private static bool ClickedOutsideRestrictedArea(Point clickLocation)
        {
            if (clickLocation.X < _restrictedArea.X && clickLocation.Y < _restrictedArea.Y)
            {
                return true;
            }

            return false;
        }

        private string AddNewPoint(Point clickLocation)
        {
            try
            {
                int newId = GetHighestClusterPointId() + 1;

                ClusterPoint clusterPoint = new()
                {
                    PointId = newId,
                    Name = newId.ToString(),
                    Text = newId.ToString(),
                    BackColor = Color.Cyan,
                    CornerRadius = pointDiameter,
                    Size = new Size(pointDiameter, pointDiameter),
                    Location = new Point(clickLocation.X - pointDiameter / 2, clickLocation.Y - pointDiameter / 2)
                };

                clusterPoint.MouseDown += ClusterPoint_Click;

                this.Controls.Add(clusterPoint);
                _clusterPoints.Add(clusterPoint);
            }
            catch (Exception exception)
            {
                return exception.Message;
            }

            return string.Empty;
        }

        private string AddNewEdge(ClusterPoint startPoint, ClusterPoint endPoint)
        {
            try
            {
                Point startLocation = new(startPoint.Location.X + startPoint.Width / 2, startPoint.Location.Y + startPoint.Height / 2);
                Point endLocation = new(endPoint.Location.X + endPoint.Width / 2, endPoint.Location.Y + endPoint.Height / 2);

                int newId = GetHighestClusterEdgeId() + 1;

                ClusterEdge clusterEdge = new(startPoint, endPoint, startLocation, endLocation)
                {
                    EdgeId = newId,
                    Name = newId.ToString(),
                    BackColor = Color.Black,
                    ForeColor = Color.Black,
                };

                this.Controls.Add(clusterEdge);
                _clusterEdges.Add(clusterEdge);
            }
            catch (Exception exception)
            {
                return exception.Message;
            }

            return string.Empty;
        }

        private static int GetHighestClusterPointId()
        {
            int highestId = 0;

            foreach (ClusterPoint clusterPoint in _clusterPoints)
            {
                if (clusterPoint.PointId > highestId)
                {
                    highestId = clusterPoint.PointId;
                }
            }

            return highestId;
        }

        private static int GetHighestClusterEdgeId()
        {
            int highestId = 0;

            foreach (ClusterEdge clusterEdge in _clusterEdges)
            {
                if (clusterEdge.EdgeId > highestId)
                {
                    highestId = clusterEdge.EdgeId;
                }
            }

            return highestId;
        }

        private void RemoveExisitingPoint(ClusterPoint clickedClusterPoint)
        {
            List<ClusterEdge> edgesToRemove = [];

            foreach (ClusterEdge clusterEdge in _clusterEdges)
            {
                if (clusterEdge._startPoint.PointId == clickedClusterPoint.PointId)
                {
                    edgesToRemove.Add(clusterEdge);
                }

                if (clusterEdge._EndPoint.PointId == clickedClusterPoint.PointId)
                {
                    edgesToRemove.Add(clusterEdge);
                }
            }

            foreach (ClusterEdge clusterEdge in edgesToRemove)
            {
                _clusterEdges.Remove(clusterEdge);
                this.Controls.Remove(clusterEdge);
                clusterEdge.Dispose();
            }



            _clusterPoints.Remove(clickedClusterPoint);
            this.Controls.Remove(clickedClusterPoint);
            clickedClusterPoint.Dispose();
        }

        private static bool EdgeAlreadyExists(ClusterPoint startPoint, ClusterPoint endPoint)
        {
            foreach (ClusterEdge clusterEdge in _clusterEdges)
            {
                if (clusterEdge._startPoint.PointId == startPoint.PointId && clusterEdge._EndPoint.PointId == endPoint.PointId)
                {
                    return true;
                }

                if (clusterEdge._startPoint.PointId == endPoint.PointId && clusterEdge._EndPoint.PointId == startPoint.PointId)
                {
                    return true;
                }
            }

            return false;
        }
    }
}