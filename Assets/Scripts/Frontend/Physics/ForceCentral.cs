using UnityEngine;

namespace G3D.Frontend.Physics
{
	// Force pointing to the origin, which defaults to(0,0,0). Magnitude scales linear with distance (spring force).
	public class ForceCentral : IForce
	{
		float forceFactor = 0.5f;
		Vector3 origin = Vector3.zero;
		IRegistryNodeAvatar nodeAvatarRegistry;


		public ForceCentral(IRegistryNodeAvatar nodeAvatarRegistry)
		{
			this.nodeAvatarRegistry = nodeAvatarRegistry;
		}
		public ForceCentral(IRegistryNodeAvatar nodeAvatarRegistry, Vector3 origin) : this(nodeAvatarRegistry)
		{
			this.origin = origin;
		}

		public void SetForceFactor(float value)
		{
			this.forceFactor = value;
		}

		public void Update()
		{
			foreach (INodeAvatar nodeAvatar in nodeAvatarRegistry.GetAvatars())
			{
				nodeAvatar.AddForce(this.calculateForce(nodeAvatar.GetPosition()));
			}
		}

		Vector3 calculateForce(Vector3 position)
		{
			return -(position - origin)* forceFactor;
		}
	}
}