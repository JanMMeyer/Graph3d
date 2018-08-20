using G3D.Core.EventSystem;

namespace G3D
{
	public interface IDeviceInputScanner : IUpdatable
	{
		void addEvent<TEvent>(int keyCode) where TEvent : AEventInfo;
	}
}
