namespace G3D.Core.EventSystem
{
	public class EIGraphElementAdded<ElementType> : AEventInfo 
	{
		ElementType addedElement;
		public EIGraphElementAdded(ElementType element)
		{
			this.addedElement = element;
		}
		public ElementType GetAddedElement()
		{
			return this.addedElement;
		}
	}
}