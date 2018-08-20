namespace G3D.Core.EventSystem
{
	public class EICloseOtherPanels<TCaller> : AEventInfo
	{
		TCaller caller;
		
		public EICloseOtherPanels(TCaller caller)
		{
			this.caller = caller;
		}

		public TCaller GetCaller()
		{
			return caller;
		}
	}

}