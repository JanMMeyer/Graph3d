using UnityEngine;

namespace G3D.Frontend.Avatars
{
	public class EdgeAvatarLabeled : AEdgeAvatarDecorator
	{
		
		public EdgeAvatarLabeled(IEdgeAvatar edgeAvatar, GameObject labelPrefab, string labelText) : base(edgeAvatar)
		{
			GameObject edgeAvatarGO = this.edgeAvatar.GetGameObject();
			GameObject labelPivot = MonoBehaviour.Instantiate(labelPrefab, edgeAvatarGO.transform);
			GameObject labelGO = labelPivot.transform.GetChild(0).gameObject;
			labelGO.GetComponent<TextMesh>().text = labelText;
		}

	}	
}