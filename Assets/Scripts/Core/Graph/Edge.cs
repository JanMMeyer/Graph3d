using System;
using System.Linq;
using G3D;

namespace G3D.Core.Graph
{
	[AttrRequiredRecordKeys(new string[] {"id", "source", "target"})]
	public class Edge : AGraphElement, IEdge
	{
		// u = undirected, d = directed, h = hierarchical (parent -> child)
		static char[] supportedEdgeTypes = new char[] { 'u', 'd', 'h' };
		
		INode source;
		INode target;

		char edgeType = 'u';

		public Edge(string edgeId, INode source, INode target) : base(edgeId)
		{
			source.AddEdge(this);
			target.AddEdge(this);
			this.source = source;
			this.target = target;
		}

		public void SetEdgeType(string edgeType)
		{
			if (edgeType.Length == 1)
			{
				this.SetEdgeType((char)edgeType[0]);
			}
			else
			{
				G3DLogger.Log("Unknown edge-type '{0}' for edge id {1}", new object[]{edgeType, this.GetId()});
			}
		}

		public void SetEdgeType(char edgeType)
		{
			if (supportedEdgeTypes.Contains(edgeType))
			{
				this.edgeType = edgeType;
			}
			else
			{
				//TODO: LOG defaulting with edge ID
			}
		}

		public char GetEdgeType()
		{
			return this.edgeType;
		}

		public INode GetSourceNode()
		{
			return source;
		}
		public INode GetTargetNode()
		{
			return target;
		}
	}
}