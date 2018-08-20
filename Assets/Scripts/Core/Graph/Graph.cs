using System.Collections.Generic;
using System.Linq;
using G3D.Core.EventSystem;

namespace G3D.Core.Graph
{
	public class Graph : IGraph
	{	

		Dictionary<string,INode> nodesDict = new Dictionary<string, INode>();
		Dictionary<string,IEdge> edgesDict = new Dictionary<string, IEdge>();

		public bool TryGetNode(string nodeId, out INode node)
		{
			return nodesDict.TryGetValue(nodeId, out node);
		}

		public INode[] GetNodes()
		{
			return nodesDict.Values.ToArray();
		}

		public void AddNodes(INode[] nodes)
		{
			foreach (INode node in nodes)
			{
				this.addNode(node);
			}
		}

		public IEdge[] GetEdges()
		{
			return edgesDict.Values.ToArray();
		}

		public void AddEdges(IEdge[] edges)
		{
			foreach(IEdge edge in edges)
			{
				this.addEdge(edge);
			}
		}

		public void Empty()
		{
			this.cleanNodesDict();
			this.cleanEdgesDict();
		}


		void addNode(INode node)
		{
			nodesDict.Add(node.GetId(), node);
			EventPublisher.Publish(new EIGraphElementAdded<INode>(node));
		}

		void addEdge(IEdge edge)
		{
			edgesDict.Add(edge.GetId(), edge);
			EventPublisher.Publish(new EIGraphElementAdded<IEdge>(edge));
		}

		void removeNode(string id)
		{
			INode nodeToRemove;
			if (nodesDict.TryGetValue(id, out nodeToRemove))
			{
				nodeToRemove.SelfDestruct();
				nodesDict.Remove(id);
			}
			
		}

		void removeEdge(string id)
		{
			IEdge edgeToRemove;
			if (edgesDict.TryGetValue(id, out edgeToRemove))
			{
				edgeToRemove.SelfDestruct();
				edgesDict.Remove(id);
			}
		}

		void cleanNodesDict()
		{
			string[] keys = nodesDict.Keys.ToArray();
			foreach (string id in keys)
			{
				this.removeNode(id);
			}
		}

		void cleanEdgesDict()
		{
			string[] keys = edgesDict.Keys.ToArray();
			foreach (string id in keys)
			{
				this.removeEdge(id);
			}
		}

	}
}