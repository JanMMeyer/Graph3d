using System.Collections.Generic;
using G3D.Core;

namespace G3D.Frontend
{
	public class RegistryNodeAvatar : IRegistryNodeAvatar
	{
		IGraph graph;
		INode[] nodes;
		List<INodeAvatar> avatars;
		public RegistryNodeAvatar(IGraph graph)
		{
			this.graph = graph;
		}
		public INodeAvatar[] GetAvatars()
		{
			avatars = new List<INodeAvatar>();
			nodes = this.graph.GetNodes();
			IAvatar nodeAvatar;
			foreach (INode node in nodes)
			{
				if (node.TryGetAvatar(out nodeAvatar))
				{
					avatars.Add((INodeAvatar)nodeAvatar);
				}

			}
			return avatars.ToArray();
		}
	}
}
