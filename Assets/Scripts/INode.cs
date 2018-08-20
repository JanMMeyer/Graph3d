namespace G3D
{
	public interface INode : IGraphElement
	{
		void AddEdge(IEdge edge);
		IEdge[] GetConnectedEdges();
	}
}