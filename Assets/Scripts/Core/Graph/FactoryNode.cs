using System.Collections.Generic;

namespace G3D.Core.Graph
{
	public class FactoryNode : IFactoryGraphElement<Node>
	{
		public  Node[] make(IRecord[] nodeRecords)
		{
			List<Node> nodes = new List<Node>();
			Node node;
			string id;
			string label;
			foreach (IRecord nodeRecord in nodeRecords)
			{
				if (nodeRecord.TryGet("id", out id))
				{
					node = new Node(id);
					if (nodeRecord.TryGet("label", out label))
					{
						node.SetLabel(label);
					}
					nodes.Add(node);
				}
				else
				{
					G3DLogger.Log("NodeFactory misses id in NodeRecord, skipping.");
				}
			}
			return nodes.ToArray();
		}
	}
}
