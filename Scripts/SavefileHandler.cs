using HierholzersAlgorithm.ClusterElements;

using Newtonsoft.Json;
using Newtonsoft.Json.Linq;



#pragma warning disable CS1690 // Accessing a member on a field of a marshal-by-reference class may cause a runtime exception





namespace HierholzersAlgorithm.Scripts
{
    class SavefileHandler
    {
        private static readonly ColorConverter _colorConvertor = new();

        private static readonly string _folderAppData = Environment.GetFolderPath(Environment.SpecialFolder.ApplicationData);
        private static readonly string _folderApplication = Path.Combine(_folderAppData, "HierholzersAlgorithm");



        internal string SaveCluster(List<ClusterPoint> clusterPoints, List<ClusterEdge> clusterEdges)
        {
            long currentUnixTimestamp = DateTimeOffset.UtcNow.ToUnixTimeSeconds();

            try
            {
                if (Directory.Exists(_folderApplication) == false)
                {
                    Directory.CreateDirectory(_folderApplication);
                }
            }
            catch
            {
                return "Failed to create a folder for the save files!\r\nPlease restart the application as administrator and try again.";
            }



            JObject clusterStructure = new()
            {
                ["fileCreationUnixSeconds"] = currentUnixTimestamp
            };

            JArray jsonClusterPoints = [];
            JArray jsonClusterEdges = [];



            foreach (ClusterPoint clusterPoint in clusterPoints)
            {
                JObject jsonClusterPoint = new()
                {
                    ["pointId"] = clusterPoint.PointId,
                    ["pointName"] = clusterPoint.Name,
                    ["pointText"] = clusterPoint.Text,
                    ["pointColorInHex"] = _colorConvertor.ColorToHex(clusterPoint.BackColor),
                    ["pointLocationX"] = clusterPoint.Location.X,
                    ["pointLocationY"] = clusterPoint.Location.Y,
                };

                jsonClusterPoints.Add(jsonClusterPoint);
            }

            foreach (ClusterEdge clusterEdge in clusterEdges)
            {
                JObject jsonClusterEdge = new()
                {
                    ["edgeId"] = clusterEdge.EdgeId,
                    ["edgeStartPointId"] = clusterEdge.startPoint.PointId,
                    ["edgeEndPointId"] = clusterEdge.endPoint.PointId,
                    ["edgeStartLocationX"] = clusterEdge.startLocation.X,
                    ["edgeStartLocationY"] = clusterEdge.startLocation.Y,
                    ["edgeEndLocationX"] = clusterEdge.endLocation.X,
                    ["edgeEndLocationY"] = clusterEdge.endLocation.Y,
                };

                jsonClusterEdges.Add(jsonClusterEdge);
            }



            clusterStructure["clusterPoints"] = jsonClusterPoints;
            clusterStructure["clusterEdges"] = jsonClusterEdges;

            string saveFileName = $"clusterStructure-{currentUnixTimestamp}.json";
            string pathForSaveFile = Path.Combine(_folderApplication, saveFileName);



            try
            {
                File.WriteAllText(pathForSaveFile, clusterStructure.ToString(Formatting.Indented));
            }
            catch
            {
                return "Failed to write data to save file!\r\nPlease restart the application as administrator and try again.";
            }

            return string.Empty;
        }

        internal (List<ClusterPoint>, List<ClusterEdge>, string) LoadCluster()
        {
            List<ClusterPoint> clusterPoints = [];
            List<ClusterEdge> clusterEdges = [];

            

            OpenFileDialog openFileDialog = new()
            {
                InitialDirectory = _folderAppData,
                Filter = "JSON Files (*.json)|*.json"
            };

            if (openFileDialog.ShowDialog() != DialogResult.OK)
            {
                string error = "The file selection was cancelled.";
                return (clusterPoints, clusterEdges, error);
            }

            string selectedFilePath = openFileDialog.FileName;
            string jsonClusterStructure = File.ReadAllText(selectedFilePath);



            JObject clusterStructure = [];

            try
            {
                clusterStructure = JObject.Parse(jsonClusterStructure);
            }
            catch
            {
                string error = "Failed to parse the selected file.\r\nPlease ensure that the formatting within the save file is correct.";
                return (clusterPoints, clusterEdges, error);
            }
            
            JArray jsonClusterPoints = clusterStructure["clusterPoints"] as JArray ?? [];
            JArray jsonClusterEdges = clusterStructure["clusterEdges"] as JArray ?? [];



            for (int i = 0; i < jsonClusterPoints.Count; i++)
            {
                ClusterPoint clusterPoint = new()
                {
                    AutoSize = true,
                    Padding = new Padding(5),
                    PointId = (int)jsonClusterPoints[i].SelectToken("pointId"),
                    Name = (string)jsonClusterPoints[i].SelectToken("pointName"),
                    Text = (string)jsonClusterPoints[i].SelectToken("pointText"),
                    BackColor = _colorConvertor.HexToColor((string)jsonClusterPoints[i].SelectToken("pointColorInHex")),
                    Location = new Point((int)jsonClusterPoints[i].SelectToken("pointLocationX"), (int)jsonClusterPoints[i].SelectToken("pointLocationY")),
                };

                clusterPoints.Add(clusterPoint);
            }
            
            for (int i = 0; i < jsonClusterEdges.Count; i++)
            {
                ClusterPoint edgeStart = new();
                ClusterPoint edgeEnd = new();

                int edgeStartId = (int)jsonClusterEdges[i].SelectToken("edgeStartPointId");
                int edgeEndId = (int)jsonClusterEdges[i].SelectToken("edgeEndPointId");

                for (int j = 0; j < clusterPoints.Count; j++)
                {
                    if (clusterPoints[j].PointId == edgeStartId)
                    {
                        edgeStart = clusterPoints[j];
                        continue;
                    }

                    if (clusterPoints[j].PointId == edgeEndId)
                    {
                        edgeEnd = clusterPoints[j];
                        continue;
                    }
                }

                ClusterEdge clusterEdge = new(edgeStart, edgeEnd)
                {
                    EdgeId = (int)jsonClusterEdges[i].SelectToken("edgeId"),
                    startLocation = new((int)jsonClusterEdges[i].SelectToken("edgeStartLocationX"), (int)jsonClusterEdges[i].SelectToken("edgeStartLocationY")),
                    endLocation = new((int)jsonClusterEdges[i].SelectToken("edgeEndLocationX"), (int)jsonClusterEdges[i].SelectToken("edgeEndLocationY"))
                };

                clusterEdges.Add(clusterEdge);
            }

            return (clusterPoints, clusterEdges, string.Empty);
        }
    }
}