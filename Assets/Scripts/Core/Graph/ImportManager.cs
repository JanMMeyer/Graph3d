using G3D.Core.EventSystem;

namespace G3D.Core.Graph
{
	public class ImportManager : IObserver
	{
		IGraph graph;
		IRecordsImporter importer;
		IFactoryGraphElement<Node> nodeFactory;
		IFactoryGraphElement<Edge> edgeFactory;

		public ImportManager(IGraph graph, IRecordsImporter importer, IFactoryGraphElement<Node> nodeFactory, IFactoryGraphElement<Edge> edgeFactory)
		{
			this.graph = graph;
			this.importer = importer;
			EventPublisher.RegisterListener<EIImport>(onImport);
			this.nodeFactory = nodeFactory;
			this.edgeFactory = edgeFactory;
		}

		void onImport(EIImport ei)
		{
			ElementRecords elementRecords;
			if (importer.TryGetElementRecords(ei.getDataFolderPath(), ei.getFileFormat(), out elementRecords))
			{
				this.graph.Empty();

				Node[] nodes = this.nodeFactory.make(elementRecords.GetNodeRecords());
				this.graph.AddNodes(nodes);

				Edge[] edges = this.edgeFactory.make(elementRecords.GetEdgeRecords());
				this.graph.AddEdges(edges);
			}
		}
	}
}
