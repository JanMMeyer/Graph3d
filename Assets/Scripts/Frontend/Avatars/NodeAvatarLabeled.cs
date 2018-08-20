using UnityEngine;

namespace G3D.Frontend.Avatars
{
	public class NodeAvatarLabeled : ANodeAvatarDecorator
	{
		public NodeAvatarLabeled(INodeAvatar nodeAvatar, GameObject labelPrefab, string labelText) : base(nodeAvatar)
		{
			GameObject nodeAvatarGO = this.nodeAvatar.GetGameObject();
			GameObject labelPivot = MonoBehaviour.Instantiate(labelPrefab, nodeAvatarGO.transform);
			GameObject labelGO = labelPivot.transform.GetChild(0).gameObject;
			labelGO.GetComponent<TextMesh>().text = labelText;
		}
	}
}