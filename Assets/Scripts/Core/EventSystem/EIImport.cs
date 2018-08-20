namespace G3D.Core.EventSystem
{
	public class EIImport : AEventInfo
	{
		string dataFolderPath;
		string fileFormat;
		public EIImport(string dataFolderPath, string fileFormat)
		{
			this.dataFolderPath = dataFolderPath;
			this.fileFormat = fileFormat;
		}
		public string getDataFolderPath()
		{
			return dataFolderPath;
		}
		public string getFileFormat()
		{
			return fileFormat;
		}
	}
}