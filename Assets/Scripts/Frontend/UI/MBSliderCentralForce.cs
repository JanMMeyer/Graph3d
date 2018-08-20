using UnityEngine;
using UnityEngine.UI;
using G3D.Core.EventSystem;

namespace G3D.Frontend.UI
{
	public class MBSliderCentralForce : MonoBehaviour
	{

		private void Start()
		{
			float initialValue = gameObject.GetComponent<Slider>().value;
			EventPublisher.Publish(new EISliderCentralFChanged(initialValue));
		}

		public void onValueChanged(float value)
		{
			EventPublisher.Publish(new EISliderCentralFChanged(value));
		}

	}
}