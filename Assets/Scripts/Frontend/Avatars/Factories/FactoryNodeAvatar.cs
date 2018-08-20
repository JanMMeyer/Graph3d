using UnityEngine;

namespace G3D.Frontend.Avatars
{
	public class FactoryNodeAvatar : AFactoryAvatar<INode>
	{
		GameObject labelAvatarPrefab;
		public FactoryNodeAvatar(GameObject nodeAvatarPrefab, GameObject labelAvatarPrefab ) : base(nodeAvatarPrefab)
		{
			this.labelAvatarPrefab = labelAvatarPrefab;
		}
		protected override void SpawnAvatar(INode node)
		{
			INodeAvatar nodeAvatar = new NodeAvatar(this.avatarPrefab);
			
			IHighlightableBinary highlightableB = nodeAvatar.GetGameObject().GetComponent<MBNodeAvatar>();
			if (highlightableB != null)
			{
				nodeAvatar = new NodeAvatarHighlightable(nodeAvatar, highlightableB);
			}

			string labelText;
			if (node.TryGetLabel(out labelText)){
				nodeAvatar = new NodeAvatarLabeled(nodeAvatar, labelAvatarPrefab, labelText);
			}
			
			node.SetAvatar(nodeAvatar);
		}

	}
}