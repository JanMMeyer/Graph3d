using UnityEngine;

namespace G3D.Frontend
{
	public interface INodeAvatar : IAvatar
	{
		Vector3 GetPosition();

		GameObject GetGameObject();

		void AddForce(Vector3 force);
	}
}
