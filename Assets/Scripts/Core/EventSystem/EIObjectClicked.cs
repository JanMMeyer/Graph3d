namespace G3D.Core.EventSystem
{
	public class EIObjectClicked<TClickedObject> : AEventInfo 
	{
		TClickedObject clickedObject;
		public EIObjectClicked(TClickedObject element)
		{
			this.clickedObject = element;
		}
		public TClickedObject GetClickedObject()
		{
			return this.clickedObject;
		}
	}
}