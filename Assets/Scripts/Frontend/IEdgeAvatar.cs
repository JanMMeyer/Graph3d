using UnityEngine;

namespace G3D.Frontend
{
	public interface IEdgeAvatar : IAvatar
	{
		GameObject GetGameObject();

		GameObject GetSourceGameObject();
		GameObject GetTargetGameObject();

		Vector3 GetSourcePosition();
		Vector3 GetTargetPosition();

		void AddForceToSource(Vector3 force);
		void AddForceToTarget(Vector3 force);
	}
}
