using UnityEngine;
using G3D.Core.EventSystem;

namespace G3D.Frontend.CameraControl
{
	public class MBInnerCamPivot : MonoBehaviour
	{
		public float rotationSpeed = 1.5f;
		public float lookUpLimit = 60.0f;
		public float lookDownLimit = -60.0f;

		float yRotation;
		float xRotation;

		delegate void PivotDynamic();
		PivotDynamic camRotationDelegate;

		void Start()
		{
			EventPublisher.RegisterListener<EIStartCamRot>(onStartCamPivotRotation);
			EventPublisher.RegisterListener<EIEndCamRot>(onEndCamPivotRotation);

			yRotation = -transform.localEulerAngles.x;
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
			camRotationDelegate = rotateCamera;
		}

		void onEndCamPivotRotation(EIEndCamRot endCPREI)
		{
			camRotationDelegate = null;
		}

		void rotateCamera()
		{
			yRotation += Input.GetAxis("Mouse Y") * rotationSpeed;
			yRotation = Mathf.Clamp(yRotation, lookDownLimit, lookUpLimit);
			transform.localEulerAngles = new Vector3(-yRotation, 0, 0);
		}
	}
}
