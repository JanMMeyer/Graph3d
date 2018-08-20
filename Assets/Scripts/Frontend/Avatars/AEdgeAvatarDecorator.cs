using UnityEngine;

namespace G3D.Frontend.Avatars
{
	public abstract class AEdgeAvatarDecorator : IEdgeAvatar
	{
		protected IEdgeAvatar edgeAvatar;

		public AEdgeAvatarDecorator(IEdgeAvatar edgeAvatar)
		{
			this.edgeAvatar = edgeAvatar;
		}

		public void AddForceToSource(Vector3 force)
		{
			this.edgeAvatar.AddForceToSource(force);
		}

		public void AddForceToTarget(Vector3 force)
		{
			this.edgeAvatar.AddForceToTarget(force);
		}

		public GameObject GetGameObject()
		{
			return edgeAvatar.GetGameObject();
		}

		public GameObject GetSourceGameObject()
		{
			return edgeAvatar.GetSourceGameObject();
		}

		public Vector3 GetSourcePosition()
		{
			return this.edgeAvatar.GetSourcePosition();
		}

		public GameObject GetTargetGameObject()
		{
			return edgeAvatar.GetTargetGameObject();
		}

		public Vector3 GetTargetPosition()
		{
			return this.edgeAvatar.GetTargetPosition();
		}

		public virtual void SelfDestruct()
		{
			this.edgeAvatar.SelfDestruct();
		}
	}
}