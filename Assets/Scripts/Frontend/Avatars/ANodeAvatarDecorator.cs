using UnityEngine;

namespace G3D.Frontend.Avatars
{
	public abstract class ANodeAvatarDecorator : INodeAvatar
	{
		protected INodeAvatar nodeAvatar;

		public ANodeAvatarDecorator(INodeAvatar nodeAvatar)
		{
			this.nodeAvatar = nodeAvatar;
		}

		public Vector3 GetPosition()
		{
			return this.nodeAvatar.GetPosition();
		}

		public GameObject GetGameObject()
		{
			return this.nodeAvatar.GetGameObject();
		}

		public void AddForce(Vector3 force)
		{
			this.nodeAvatar.AddForce(force);
		}

		public virtual void SelfDestruct()
		{
			this.nodeAvatar.SelfDestruct();
		}
	}
}