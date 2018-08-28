using System;
using G3D.Core.EventSystem;

namespace G3D.Frontend
{
	public class ForceCooler : IUpdatable
	{
		static float decrementOnUpdate = 0.0015f;
		static float resetValue = 1;
		static ForceCooler instance;

		float forceCoolFactor = 0;

		static ForceCooler()
		{
			instance = new ForceCooler();
		}

		public static ForceCooler GetInstance()
		{
			return instance;
		}

		private ForceCooler()
		{
			EventPublisher.RegisterListener<EILClick>(onResetEvent);
			EventPublisher.RegisterListener<EIImport>(onResetEvent);
		}

		public void Update()
		{
			this.forceCoolFactor = Math.Max(this.forceCoolFactor - decrementOnUpdate, 0);
		}

		public void Reset()
		{
			this.forceCoolFactor = resetValue;
		}

		public float getForceCoolFactor()
		{
			return this.forceCoolFactor;
		}

		void onResetEvent(AEventInfo ei)
		{
			this.Reset();
		}
	}
}
