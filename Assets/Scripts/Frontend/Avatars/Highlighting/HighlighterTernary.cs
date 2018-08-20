using UnityEngine;
using G3D.Core.EventSystem;

namespace G3D.Frontend
{
	public class HighlighterTernary : IHighliter
	{
		bool firstHighlighted = false;
		bool secondHighlighted = false;
		bool changed = false;
		GameObject firstGameObject;
		GameObject secondGameObject;
		IHighlightableTernary highlitableT;
		EventPublisher.EventListener onObjectClickedListener;

		public HighlighterTernary(IHighlightableTernary highlightalbeT, GameObject gOToWatch1, GameObject gOToWatch2)
		{
			this.highlitableT = highlightalbeT;
			this.firstGameObject = gOToWatch1;
			this.secondGameObject = gOToWatch2;
			this.onObjectClickedListener = EventPublisher.RegisterListener<EIObjectClicked<GameObject>>(onObjectClicked);
		}

		public void SelfDestruct()
		{
			EventPublisher.UnregisterListener<EIObjectClicked<GameObject>>(onObjectClickedListener);
		}

		void onObjectClicked(EIObjectClicked<GameObject> ei)
		{
			this.changed = false;
			GameObject clickedGObject = ei.GetClickedObject();
			if (clickedGObject == this.firstGameObject)
			{
				this.firstHighlighted = !this.firstHighlighted;
				this.changed = true;
			}
			else if (clickedGObject == this.secondGameObject)
			{
				this.secondHighlighted = !this.secondHighlighted;
				this.changed = true;
			}
			if (changed)
			{
				int state = 0;
				if (this.firstHighlighted)
				{
					state++;
				}
				if (this.secondHighlighted)
				{
					state++;
				}
				this.highlitableT.SetHighlighted(state);
			}
		}

	}
}