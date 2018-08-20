using System.Collections.Generic;

namespace G3D.Core.Graph
{
	[AttrRequiredRecordKeys(new string[] { "id" })]
	public class Node : AGraphElement, INode
	{
		bool selected;
		List<IEdge> connectedEdges = new List<IEdge>();

		public Node(string nodeId) : base(nodeId)
		{
		}
	
		public void AddEdge(IEdge edge)
		{
			connectedEdges.Add(edge);
		}

		public IEdge[] GetConnectedEdges()
		{
			return connectedEdges.ToArray();
		}	
	}
}