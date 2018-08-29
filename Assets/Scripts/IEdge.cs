namespace G3D
{
	public interface IEdge : IGraphElement
	{
		char GetEdgeType();
		INode GetSourceNode();
		INode GetTargetNode();
		void SetEdgeType(string edgeCategory);
		void SetEdgeType(char edgeCategory);
	}
}