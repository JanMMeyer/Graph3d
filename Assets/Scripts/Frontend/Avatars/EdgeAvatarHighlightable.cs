using UnityEngine;

namespace G3D.Frontend.Avatars
{
	public class EdgeAvatarHighlightable : AEdgeAvatarDecorator
	{
		IHighliter highlighter;

		public EdgeAvatarHighlightable(IEdgeAvatar edgeAvatar, IHighlightableTernary highlightableT) : base(edgeAvatar)
		{
				GameObject sourceGO = this.edgeAvatar.GetSourceGameObject();
				GameObject targetGO = this.edgeAvatar.GetTargetGameObject(); ;
				this.highlighter = new HighlighterTernary(highlightableT, sourceGO, targetGO);
		}

		public override void SelfDestruct()
		{
			this.highlighter.SelfDestruct();
			base.SelfDestruct();
		}
	}	
}