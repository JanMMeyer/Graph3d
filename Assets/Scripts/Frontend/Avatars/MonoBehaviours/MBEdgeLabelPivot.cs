using UnityEngine;

namespace G3D.Frontend.Avatars
{
	public class MBEdgeLabelPivot : MonoBehaviour
	{
		static Transform mainCameraTransform;
	
		void Start()
		{
			if (mainCameraTransform == null)
			{
				mainCameraTransform = Camera.main.transform;
			}
		}

		void Update()
		{
			transform.LookAt(mainCameraTransform);
		}
	}
}

