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
			IHighlightableTernary highlightableT = edgeAvatar.GetGameObject().GetComponent<MBEdgeAvatar>();
			if (highlightableT != null)
			{
				edgeAvatar = new EdgeAvatarHighlightable(edgeAvatar, highlightableT);
			}
			edge.SetAvatar(edgeAvatar);
		}
	}
}