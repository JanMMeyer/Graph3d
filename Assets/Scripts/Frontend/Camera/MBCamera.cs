using UnityEngine;
using G3D.Core.EventSystem;

namespace G3D.Frontend.CameraControl
{
	public class MBCamera : MonoBehaviour
	{
		public float camZSpeed = 7f;
		public float maxCamZPosition = -3;
		public float minCamZPosition = -15;

		float distanceToPivot;
		
		delegate void PivotDynamic();
		PivotDynamic camRotationDelegate;

		void Start()
		{
			distanceToPivot = transform.position.z;
			EventPublisher.RegisterListener<EIStartCamRot>(onStartCamPivotRotation);
			EventPublisher.RegisterListener<EIEndCamRot>(onEndCamPivotRotation);
			EventPublisher.RegisterListener<EILClick>(onLClick);
		}

		void LateUpdate()
		{
			if (camRotationDelegate != null)
			{
				camRotationDelegate();
			}
		}

		void onStartCamPivotRotation(EIStartCamRot startCPREI)
		{
			camRotationDelegate = changeCamZPostion;
		}

		void onEndCamPivotRotation(EIEndCamRot endCPREI)
		{
			camRotationDelegate = null;
		}

		void changeCamZPostion()
		{
			distanceToPivot += Input.GetAxis("Mouse ScrollWheel") * camZSpeed;
			distanceToPivot = Mathf.Clamp(distanceToPivot, minCamZPosition, maxCamZPosition);
			transform.localPosition = new Vector3(0, 0, distanceToPivot);
		}

		void onLClick(EILClick ei)
		{
			RaycastHit hit;
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			if (UnityEngine.Physics.Raycast(ray, out hit, 300f, ~0, QueryTriggerInteraction.Ignore))
			{
				GameObject hitObject = hit.collider.gameObject;
				EventPublisher.Publish(new EIObjectClicked<GameObject>(hitObject));
				
			}
		}

	}
}
