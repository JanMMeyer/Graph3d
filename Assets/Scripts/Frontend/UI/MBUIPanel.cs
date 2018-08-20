using UnityEngine;
using G3D.Core.EventSystem;

namespace G3D.Frontend.UI
{
	public class MBUIPanel : MonoBehaviour
	{
		public void SetActive(bool active)
		{
			if (active)
			{
				EventPublisher.Publish(new EICloseOtherPanels<GameObject>(gameObject));
			}
			gameObject.SetActive(active);
		}

		void Start()
		{
			EventPublisher.RegisterListener<EICloseOtherPanels<GameObject>>(onCloseOtherPanelsEI);
		}

		void onCloseOtherPanelsEI(EICloseOtherPanels<GameObject> ei)
		{
			if ((GameObject)ei.GetCaller() != gameObject)
			{
				gameObject.SetActive(false);
			}
		}

	}
}
