namespace G3D.Backend
{
	public class RecordsImporter<NodeType, EdgeType> : IRecordsImporter
	{
		public bool TryGetElementRecords(string dataFolderPath, string fileFormat, out ElementRecords elementRecords)
		{
			switch (fileFormat)
			{
				case "csv":
					return importCSV(dataFolderPath, out elementRecords);
				default:
					G3DLogger.Log("Unsupported file format: {0}", fileFormat);
					elementRecords = null;
					return false;
			}
		}

		bool importCSV(string dataFolderPath, out ElementRecords elementRecords)
		{
			CSVAdapter<NodeType> nodeAdapter = new CSVAdapter<NodeType>(dataFolderPath + "Nodes.csv");
			CSVAdapter<EdgeType> edgeAdapter = new CSVAdapter<EdgeType>(dataFolderPath + "Edges.csv");
			if (!nodeAdapter.IsReady() || !edgeAdapter.IsReady())
			{
				elementRecords = null;
				return false;
			}
			CSVRecord[] nodeRecords = nodeAdapter.GetRecords();
			CSVRecord[] edgeRecrods = edgeAdapter.GetRecords();
			elementRecords = new ElementRecords(nodeRecords, edgeRecrods);
			return true;
		}
	}
}