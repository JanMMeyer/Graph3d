using UnityEngine;

namespace G3D.Frontend.Avatars
{
	public class FactoryEdgeAvatar : AFactoryAvatar<IEdge>
	{

		public FactoryEdgeAvatar(GameObject prefab) : base(prefab)
		{
		}

		protected override void SpawnAvatar(IEdge edge)
		{
			IEdgeAvatar edgeAvatar = new EdgeAvatar(this.avatarPrefab, edge);
			MBEdgeAvatar mbEdgeAvatar = edgeAvatar.GetGameObject().GetComponent<MBEdgeAvatar>();
			if (mbEdgeAvatar != null)
			{
				edgeAvatar = new EdgeAvatarHighlightable(edgeAvatar, mbEdgeAvatar);
				if (edge.GetEdgeType() == 'd')
				{
					edgeAvatar = new EdgeAvatarDirected(edgeAvatar, mbEdgeAvatar);
				}
				
			}
			edge.SetAvatar(edgeAvatar);
		}
	}
}