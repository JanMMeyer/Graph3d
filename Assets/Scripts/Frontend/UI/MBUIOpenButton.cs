using UnityEngine;
using G3D.Core.EventSystem;
using Crosstales.FB;

namespace G3D.Frontend.UI
{
	public class MBUIOpenButton : MonoBehaviour
	{

		public void onClick()
		{
			EventPublisher.Publish(new EICloseOtherPanels<GameObject>(gameObject));
			string dataFolderPath = FileBrowser.OpenSingleFolder("Open folder containing Noides.csv and Edges.csv")+"/";
			EIImport importEI = new EIImport(dataFolderPath, "csv");
			EventPublisher.Publish(importEI);
		}

	}
}
