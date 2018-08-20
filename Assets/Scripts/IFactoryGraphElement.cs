namespace G3D
{
	public interface IFactoryGraphElement<TElement> where TElement :IGraphElement
	{
		TElement[] make(IRecord[] records);
	}
}
