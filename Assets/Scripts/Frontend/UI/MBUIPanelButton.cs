using UnityEngine;
using UnityEngine.UI;
using G3D.Core.EventSystem;

namespace G3D.Frontend.UI
{
	public class MBUIPanelButton : MonoBehaviour
	{
		public GameObject panel;
		MBUIPanel panelBhvr;

		void Start()
		{
			panelBhvr = panel.GetComponent<MBUIPanel>();
		}

		public void onClick()
		{
			panelBhvr.SetActive(!panel.activeSelf);
		}
	}
}