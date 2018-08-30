using UnityEngine;

namespace G3D.Frontend.Avatars
{
	public class FactoryEdgeAvatar : AFactoryAvatar<IEdge>
	{
		GameObject labelAvatarPrefab;
		public FactoryEdgeAvatar(GameObject prefab, GameObject labelAvatarPrefab) : base(prefab)
		{
			this.labelAvatarPrefab = labelAvatarPrefab;
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
			string labelText;
			if (edge.TryGetLabel(out labelText))
			{
				edgeAvatar = new EdgeAvatarLabeled(edgeAvatar, labelAvatarPrefab, labelText);
			}
			edge.SetAvatar(edgeAvatar);
		}
	}
}