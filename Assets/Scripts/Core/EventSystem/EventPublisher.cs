using System.Collections.Generic;

namespace G3D.Core.EventSystem
{
	public static class EventPublisher
	{
		static readonly object eventLock = new object();
		public delegate void EventListener(AEventInfo eventInfo);
		static Dictionary<System.Type, List<EventListener>> eventDict = new Dictionary<System.Type, List<EventListener>>();

		public static EventListener RegisterListener<T>(System.Action<T> listener) where T : AEventInfo
		{
			System.Type eventInfoType = typeof(T);
			//Debug.Log("registered: "+eventInfoType.Name);
			lock (eventLock)
			{
				if (eventDict.ContainsKey(eventInfoType) == false)
				{
					eventDict[eventInfoType] = new List<EventListener>();
				}
				//Lambda expression creates an anonymous wrapper function, that is typecast to the delegate type on assignment.
				EventListener wrapper = (ei) => { listener((T)ei); };
				eventDict[eventInfoType].Add(wrapper);
				return wrapper;
			}
		}

		public static void UnregisterListener<T>(EventListener listener) where T : AEventInfo
		{
			lock (eventLock)
			{
				System.Type eventInfoType = typeof(T);
				if (eventDict.ContainsKey(eventInfoType))
				{
					eventDict[eventInfoType].Remove(listener);
				}
			}
		}

		public static void Publish(AEventInfo eventInfo)
		{
			System.Type eventInfoType = eventInfo.GetType();
			List<EventListener> eventListeners;
			if (eventDict.TryGetValue(eventInfoType, out eventListeners))
			{
				EventListener[] eventListenerArr = eventListeners.ToArray();
				foreach (EventListener eventListener in eventListenerArr)
				{
					eventListener(eventInfo);
				}
			}
		}
	}
}