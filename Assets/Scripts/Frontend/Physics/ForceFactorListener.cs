using G3D.Core.EventSystem;

namespace G3D.Frontend.Physics
{
	public class ForceFactorListener<TEvent> : IObserver where TEvent : AEISliderChanged
	{
		IForce force;

		public ForceFactorListener(IForce force)
		{
			this.force = force;
			EventPublisher.RegisterListener<TEvent>(onValueChanged);
		}

		void onValueChanged(TEvent ei)
		{
			force.SetForceFactor(ei.GetNewValue());
		}
	}
}