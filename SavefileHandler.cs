using Newtonsoft.Json;
using Newtonsoft.Json.Linq;



#pragma warning disable CS1690 // Accessing a member on a field of a marshal-by-reference class may cause a runtime exception





namespace HierholzersAlgorithm
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
    }
}