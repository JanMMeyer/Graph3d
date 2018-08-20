using System;
using System.Linq;

namespace G3D.Core.Graph
{
	[AttrRequiredRecordKeys(new string[] {"id", "source", "target"})]
	public class Edge : AGraphElement, IEdge
	{
		// u = undirected, d = directed, h = hierarchical (parent -> child)
		static char[] supportedEdgeCategories = new char[] { 'u', 'd', 'h' };
		
		INode source;
		INode target;

		char edgeCategory = 'u';

		public Edge(string edgeId, INode source, INode target) : base(edgeId)
		{
			source.AddEdge(this);
			target.AddEdge(this);
			this.source = source;
			this.target = target;
		}

		public void SetCategory(string edgeCategory)
		{
			if (edgeCategory.Length == 1)
			{
				this.SetCategory((char)edgeCategory[0]);
			}
			else
			{
				//TODO: log error with edge ID
			}
		}

		public void SetCategory(char edgeCategory)
		{
			if (supportedEdgeCategories.Contains(edgeCategory))
			{
				this.edgeCategory = edgeCategory;
			}
			else
			{
				//TODO: LOG defaulting with edge ID
			}
		}

		public char GetEdgeCategory()
		{
			return this.edgeCategory;
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