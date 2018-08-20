using UnityEngine;

namespace G3D.Frontend.Avatars
{
	
	public class EdgeAvatar : IEdgeAvatar
	{
		GameObject gameObject;
		INodeAvatar sourceNodeAvatar;
		INodeAvatar targetNodeAvatar;

		public EdgeAvatar(GameObject nodeAvatarPrefab, IEdge edge)
		{
			this.gameObject = MonoBehaviour.Instantiate(nodeAvatarPrefab, Vector3.zero, Quaternion.identity);

			MBEdgeAvatar mbEdegAvatar = this.gameObject.GetComponent<MBEdgeAvatar>();
			INode source = edge.GetSourceNode();
			INode target = edge.GetTargetNode();
			IAvatar sourceAvatar;
			IAvatar targetAvatar;
			
			if (source.TryGetAvatar(out sourceAvatar) && target.TryGetAvatar(out targetAvatar) && mbEdegAvatar != null)
			{
				this.sourceNodeAvatar = (INodeAvatar)sourceAvatar;
				this.targetNodeAvatar = (INodeAvatar)targetAvatar;

				mbEdegAvatar.SetSourceNodeAvatar(this.sourceNodeAvatar);
				mbEdegAvatar.SetTargetNodeAvatar(this.targetNodeAvatar);
			}
			else
			{
				G3DLogger.Log("Missing component in edge {0}, avatar constructor failed.", edge.GetId());
				this.SelfDestruct();
			}
		}

		public GameObject GetGameObject()
		{
			return this.gameObject;
		}

		public GameObject GetSourceGameObject()
		{
			return this.sourceNodeAvatar.GetGameObject();
		}
		public GameObject GetTargetGameObject()
		{
			return this.targetNodeAvatar.GetGameObject();
		}

		public Vector3 GetSourcePosition()
		{
			return this.sourceNodeAvatar.GetPosition();
		}
		public Vector3 GetTargetPosition()
		{
			return this.targetNodeAvatar.GetPosition(); ;
		}

		public void AddForceToSource(Vector3 force)
		{
			this.sourceNodeAvatar.AddForce(force);
		}
		public void AddForceToTarget(Vector3 force)
		{
			this.targetNodeAvatar.AddForce(force);
		}

		public void SelfDestruct()
		{
			MonoBehaviour.Destroy(this.gameObject);
		}
	}	
}