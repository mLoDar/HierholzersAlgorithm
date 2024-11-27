namespace HierholzersAlgorithm
{
    public partial class MainForm : Form
    {
        private static readonly Point _restrictedArea = new(220, 440);

        private static readonly int pointDiameter = 50;
        internal static readonly List<ClusterPoint> _clusterPoints = [];



        public MainForm()
        {
            InitializeComponent();

            this.DoubleBuffered = true;
        }

        private void MainForm_Click(object sender, EventArgs e)
        {
            MouseEventArgs mouseEventArgs = (MouseEventArgs)e;

            Point clickLocation = mouseEventArgs.Location;
            MouseButtons clickButton = mouseEventArgs.Button;

            if (ClickedOutsideRestrictedArea(clickLocation))
            {
                return;
            }



            if (clickButton == MouseButtons.Left)
            {
                string processResult = AddNewPoint(this, clickLocation);

                if (processResult.Equals(string.Empty) == false)
                {
                    string text = processResult;
                    string caption = "Failed to add a new point!";

                    MessageBox.Show(text, caption, MessageBoxButtons.OK, MessageBoxIcon.Warning);

                    return;
                }
            }
        }

        private void ClusterPoint_Click(object sender, EventArgs e)
        {
            ClusterPoint clickedClusterPoint = (ClusterPoint)sender;
            MouseEventArgs mouseEventArgs = (MouseEventArgs)e;

            if (mouseEventArgs.Button == MouseButtons.Right)
            {
                _clusterPoints.Remove(clickedClusterPoint);
                this.Controls.Remove(clickedClusterPoint);
                clickedClusterPoint.Dispose();
            }
        }


        private bool ClickedOutsideRestrictedArea(Point clickLocation)
        {
            if (clickLocation.X < _restrictedArea.X && clickLocation.Y < _restrictedArea.Y)
            {
                return true;
            }

            return false;
        }

        private string AddNewPoint(MainForm mainForm, Point clickLocation)
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

                mainForm.Controls.Add(clusterPoint);
                _clusterPoints.Add(clusterPoint);
            }
            catch (Exception exception)
            {
                return exception.Message;
            }

            return string.Empty;
        }

        private int GetHighestClusterPointId()
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
    }
}