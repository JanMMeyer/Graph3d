using UnityEngine;
using G3D.Core.EventSystem;

namespace G3D.Frontend
{
	public class HighlighterBinary : IHighliter
	{
		bool highlighted = false;
		GameObject gameObject;
		IHighlightableBinary highlitableB;
		EventPublisher.EventListener onObjectClickedListener;

		public HighlighterBinary(IHighlightableBinary hB, GameObject gOToWatch)
		{
			this.highlitableB = hB;
			this.gameObject = gOToWatch;
			this.onObjectClickedListener = EventPublisher.RegisterListener<EIObjectClicked<GameObject>>(onObjectClicked);
		}

		public void SelfDestruct()
		{
			EventPublisher.UnregisterListener<EIObjectClicked<GameObject>>(onObjectClickedListener);
		}

		void onObjectClicked(EIObjectClicked<GameObject> ei)
		{
			if (ei.GetClickedObject() == this.gameObject)
			{
				this.highlighted = !this.highlighted;
				this.highlitableB.SetHighlighted(this.highlighted);
			}
		}
	}
}