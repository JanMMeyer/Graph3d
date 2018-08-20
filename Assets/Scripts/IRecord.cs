namespace G3D
{
	// data transport object backend to core
	public interface IRecord
	{
		bool TryGet(string key, out string value);
	}
}
