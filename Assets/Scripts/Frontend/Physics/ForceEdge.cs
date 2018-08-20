using UnityEngine;

namespace G3D.Frontend.Physics
{
	// Force pointing to the world origing (0,0,0), linear scaling with distance (spring force)
	public class ForceEdge : IForce
	{
		static float forceFactor = 0.5f;
		IRegistryEdgeAvatar edgeAvatarRegistry;

		public ForceEdge(IRegistryEdgeAvatar edgeAvatarRegistry)
		{
			this.edgeAvatarRegistry = edgeAvatarRegistry;
		}

		public void SetForceFactor(float value)
		{
			forceFactor = value;
		}

		public void Update()
		{
			Vector3 sAvPos;
			Vector3 tAvPos;
			foreach (IEdgeAvatar edgeAvatar in edgeAvatarRegistry.GetAvatars())
			{
				sAvPos = edgeAvatar.GetSourcePosition();
				tAvPos = edgeAvatar.GetTargetPosition();
				edgeAvatar.AddForceToSource(this.calculateForce(sAvPos, tAvPos));
				edgeAvatar.AddForceToTarget(this.calculateForce(tAvPos, sAvPos));
			}
		}

		Vector3 calculateForce(Vector3 thisPosition, Vector3 thatPosition)
		{
			return (thatPosition - thisPosition) * forceFactor;
		}
	}
}