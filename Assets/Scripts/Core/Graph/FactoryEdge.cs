using System.Collections.Generic;

namespace G3D.Core.Graph
{
	public class FactoryEdge : IFactoryGraphElement<Edge>
	{
		IGraph graph;
		public FactoryEdge(IGraph graph)
		{
			this.graph = graph;
		}

		public Edge[] make(IRecord[] edgeRecords)
		{
			List<Edge> edges = new List<Edge>();
			Edge edge;
			INode sourceNode;
			INode targetNode;
			string id;
			string sourceId;
			string targetId;
			string label;
			string type;
			foreach (IRecord edgeRecord in edgeRecords)
			{

				if (edgeRecord.TryGet("id", out id)
					&& edgeRecord.TryGet("source", out sourceId)
					&& edgeRecord.TryGet("target", out targetId))
				{

					if (this.graph.TryGetNode(sourceId, out sourceNode)
						&& this.graph.TryGetNode(targetId, out targetNode))
					{

						edge = new Edge(id, sourceNode, targetNode);

						if (edgeRecord.TryGet("label", out label))
						{
							edge.SetLabel(label);
						}
						if (edgeRecord.TryGet("type", out type))
						{
							edge.SetEdgeType(type);
						}
						edges.Add(edge);

					}
					else
					{
						G3DLogger.Log("EdgeFactory can't find source or target node in Graph for Edge  {0} ", id);
					}

				}
				else
				{
					G3DLogger.Log("EdgeFactory misses id, sourceId, targetId in edgeRecord");
				}
			}
			return edges.ToArray();
		}
	}
}
