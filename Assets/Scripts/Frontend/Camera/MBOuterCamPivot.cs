using UnityEngine;
using G3D.Core.EventSystem;

namespace G3D.Frontend.CameraControl
{
	public class MBOuterCamPivot : MonoBehaviour
	{
		public float translationSpeed = 1f;
		public float rotationSpeed = 1f;
		float xRotation;

		delegate void PivotDynamic();
		PivotDynamic pivotRotationDelegate;

		void Start()
		{
			EventPublisher.RegisterListener<EIStartCamRot>(onStartCamPivotRotation);
			EventPublisher.RegisterListener<EIEndCamRot>(onEndCamPivotRotation);
		}
		void LateUpdate()
		{
			if (pivotRotationDelegate != null)
			{
				pivotRotationDelegate();
			}
			translatePivot();
		}
		void onStartCamPivotRotation(EIStartCamRot startCPREI)
		{
			pivotRotationDelegate = rotatePivot;
		}
		void onEndCamPivotRotation(EIEndCamRot endCPREI)
		{
			pivotRotationDelegate = null;
		}

		void rotatePivot()
		{
			xRotation = transform.localEulerAngles.y + Input.GetAxis("Mouse X") * rotationSpeed;
			transform.localEulerAngles = new Vector3(0, xRotation, 0);
		}
		void translatePivot()
		{
			transform.Translate(Input.GetAxis("Horizontal") * translationSpeed, Input.GetAxis("Vertical") * translationSpeed, Input.GetAxis("Longitudinal") * translationSpeed);
		}
	}
}