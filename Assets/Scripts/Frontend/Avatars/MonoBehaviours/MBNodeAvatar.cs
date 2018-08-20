using UnityEngine;

namespace G3D.Frontend.Avatars
{
	public class MBNodeAvatar : MonoBehaviour, IHighlightableBinary
	{
		static float highlightForceFactor = 30f;
		static float triggerColliderRadius = 10f;

		public	Material NormalMaterial;
		public  Material HighlitedMaterial;
		
		MeshRenderer ownMeshRenderer;
		SphereCollider triggerCollider;

		public void SetHighlighted(bool state)
		{
			this.triggerCollider.enabled = state;
			if (state)
			{
				this.ownMeshRenderer.material = this.HighlitedMaterial;
			}
			else
			{
				this.ownMeshRenderer.material = this.NormalMaterial;
			}
		}

		void Start()
		{
			this.ownMeshRenderer = gameObject.GetComponent<MeshRenderer>();
			this.ownMeshRenderer.material = NormalMaterial;
			this.triggerCollider = gameObject.GetComponents<SphereCollider>()[1];
			this.triggerCollider.radius = triggerColliderRadius;
		}

		void OnTriggerStay(Collider other)
		{
			if (other.attachedRigidbody)
			{
				Vector3 force = this.getHighlightForce(other.transform.position);
				other.attachedRigidbody.AddForce(force);
			}
		}

		Vector3 getHighlightForce(Vector3 otherPosition)
		{
			Vector3 deltaPosition = otherPosition - transform.position;
			Vector3 direction = deltaPosition.normalized;
			float distance = deltaPosition.magnitude;
			return direction * (1 / distance - 1 / triggerColliderRadius) * highlightForceFactor;
		}

	}
}

