namespace G3D
{
	public interface IEdge : IGraphElement
	{
		char GetEdgeCategory();
		INode GetSourceNode();
		INode GetTargetNode();
		void SetCategory(string edgeCategory);
		void SetCategory(char edgeCategory);
	}
}