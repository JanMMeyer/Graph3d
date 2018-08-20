using UnityEngine;

namespace G3D.Frontend
{
	//ternary = is either highlighted (1), very highlighted (2) or not (0)
	public interface IHighlightableTernary
	{
		void SetHighlighted(int state);
	}
}
