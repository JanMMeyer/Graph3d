using UnityEngine;
using UnityEngine.UI;
using G3D.Core.EventSystem;

namespace G3D.Frontend.UI
{
	public class MBSliderInterNodeForce : MonoBehaviour
	{

		private void Start()
		{
			float initialValue = gameObject.GetComponent<Slider>().value;
			EventPublisher.Publish(new EISliderInterNodeFChanged(initialValue));
		}
		
		public void onValueChanged(float value)
		{
			EventPublisher.Publish(new EISliderInterNodeFChanged(value));
		}

	}
}