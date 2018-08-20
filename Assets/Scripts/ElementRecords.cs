namespace G3D
{
	public class ElementRecords {
		
		IRecord[] nodeRecords;
		IRecord[] edgeRecords;

		public ElementRecords(IRecord[] nodeRecords, IRecord[] edgeRecords)
		{
			this.nodeRecords = nodeRecords;
			this.edgeRecords = edgeRecords;
		}

		public IRecord[] GetNodeRecords()
		{
			return this.nodeRecords;
		}
		public IRecord[] GetEdgeRecords()
		{
			return this.edgeRecords;
		}
	}
}
