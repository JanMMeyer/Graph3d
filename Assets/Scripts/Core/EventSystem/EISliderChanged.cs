namespace G3D.Core.EventSystem
{
	public abstract class AEISliderChanged : AEventInfo
	{
		protected float value;
		protected AEISliderChanged(float value)
		{
			this.value = value;
		}
		public float GetNewValue()
		{
			return this.value;
		}
	}

	public class EISliderCentralFChanged :  AEISliderChanged
	{
		public EISliderCentralFChanged(float value) : base(value)
		{
		}
	}

	public class EISliderInterNodeFChanged : AEISliderChanged
	{
		public EISliderInterNodeFChanged(float value) : base(value)
		{
		}
	}

	public class EISliderEdgeFChanged : AEISliderChanged
	{
		public EISliderEdgeFChanged(float value) : base(value)
		{
		}
	}
}