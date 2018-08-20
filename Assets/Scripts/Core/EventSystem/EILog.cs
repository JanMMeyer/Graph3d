namespace G3D.Core.EventSystem
{
	public class EILog : AEventInfo
	{
		string logMessage;

		public EILog(string message)
		{
			this.logMessage = message;
		}
					
		public string GetLogMessage()
		{
			return this.logMessage;
		}
	}
}