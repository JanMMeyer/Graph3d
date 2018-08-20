namespace G3D
{
	public interface IRecordsImporter
	{
		bool TryGetElementRecords(string dataFolderPath, string fileFormat, out ElementRecords elementRecords);
	}
}
