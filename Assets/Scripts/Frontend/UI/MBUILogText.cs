using UnityEngine;
using UnityEngine.UI;
using G3D.Core.EventSystem;

namespace G3D.Frontend.UI
{
	public class MBUILogText : MonoBehaviour
	{
		public GameObject LogTextGO;
		Text textComponent;

		const int maxLines = 20;
		string loggedMessages;
		string newMessage;

		int firstLineEnd;
		int safetybreak;

		void Start()
		{
			textComponent = LogTextGO.GetComponent<Text>();
			EventPublisher.RegisterListener<EILog>(onLog);
		}

		void onLog(EILog logEI)
		{
			newMessage = logEI.GetLogMessage();
			Debug.Log(newMessage);
			loggedMessages = textComponent.text;
			if (loggedMessages.Length == 0)
			{
				textComponent.text = newMessage;
			}
			else
			{
				safetybreak = 0;
				while (loggedMessages.Split('\n').Length >= maxLines && safetybreak < 100)
				{
					firstLineEnd = loggedMessages.IndexOf('\n');
					loggedMessages = loggedMessages.Remove(0, firstLineEnd + 1);
					safetybreak++;
				}
				textComponent.text = loggedMessages + '\n' + newMessage;
			}
		}

	}
}

