using System.Collections.Generic;

namespace G3D.Frontend
{
	public class RegistryEdgeAvatar : IRegistryEdgeAvatar
	{
		IGraph graph;
		IEdge[] edges;
		List<IEdgeAvatar> avatars;
		
		public RegistryEdgeAvatar(IGraph graph)
		{
			this.graph = graph;
		}

		public IEdgeAvatar[] GetAvatars()
		{
			avatars = new List<IEdgeAvatar>();
			edges = this.graph.GetEdges();
			IAvatar edgeAvatar;
			foreach (IEdge edge in edges)
			{
				if (edge.TryGetAvatar(out edgeAvatar))
				{
					avatars.Add((IEdgeAvatar)edgeAvatar);
				}

			}
			return avatars.ToArray();
		}
	}
}
