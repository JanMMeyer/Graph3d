using UnityEngine;
using G3D.Core;

namespace G3D.Frontend.Avatars
{
	public class NodeAvatar : INodeAvatar
	{
		
		protected GameObject gameObject;

		public NodeAvatar(GameObject nodeAvatarPrefab)
		{
			this.gameObject = MonoBehaviour.Instantiate(nodeAvatarPrefab, UnityEngine.Random.onUnitSphere * 7f, Quaternion.identity);
		}

		public Vector3 GetPosition()
		{
			return gameObject.transform.position;
		}

		public GameObject GetGameObject()
		{
			return this.gameObject;
		}

		public void AddForce(Vector3 force)
		{
			this.gameObject.GetComponent<Rigidbody>().AddForce(force);
		}

		public void SelfDestruct()
		{
			MonoBehaviour.Destroy(gameObject);
		}
	}	
}