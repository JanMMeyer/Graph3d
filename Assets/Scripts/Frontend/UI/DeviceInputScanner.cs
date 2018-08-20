using System;
using System.Collections.Generic;
using G3D.Core.EventSystem;

namespace G3D.Frontend.UI
{ 
	public class DeviceInputScanner : IDeviceInputScanner
	{
		Dictionary<int, List<Type>> inputEvents = new Dictionary<int, List<Type>>();
		delegate bool InputConditional(int keyCode);
		InputConditional inputConditional;
		public DeviceInputScanner(Func<int, bool> inputConditional)
		{
			this.inputConditional = (keyCode) => { 
				return inputConditional(keyCode);
			};
		}

		public void addEvent<TEvent>(int KeyCode) where TEvent : AEventInfo
		{
			if (!this.inputEvents.ContainsKey(KeyCode))
			{
				this.inputEvents.Add(KeyCode, new List<Type>());
			}
			this.inputEvents[KeyCode].Add(typeof(TEvent));
		}

		public void Update()
		{
			foreach (KeyValuePair<int, List<Type>> item in inputEvents)
			{
				if (this.inputConditional(item.Key))
				{
					foreach (Type type in item.Value)
					{
						AEventInfo inputEvent = (AEventInfo)Activator.CreateInstance(type);
						EventPublisher.Publish(inputEvent);
					}
				}
			}
		}

	}
}