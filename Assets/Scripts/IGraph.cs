namespace G3D
{
	public interface IGraph
	{
		void AddEdges(IEdge[] edges);
		void AddNodes(INode[] nodes);
		void Empty();
		IEdge[] GetEdges();
		INode[] GetNodes();
		bool TryGetNode(string nodeId, out INode node);
	}
}