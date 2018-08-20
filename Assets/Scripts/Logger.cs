using System;
using G3D.Core.EventSystem;

namespace G3D
{
	public class G3DLogger
	{
		public static void Log(string message)
		{
			EventPublisher.Publish(new EILog(message));
		}

		public static void Log(string message, object arg)
		{
			EventPublisher.Publish(new EILog(String.Format(message, arg)));
		}

		public static void Log(string message, object[] args)
		{
			EventPublisher.Publish(new EILog(String.Format(message, args))); 
		}
	}
}
