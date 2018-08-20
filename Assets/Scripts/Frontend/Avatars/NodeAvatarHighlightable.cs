using UnityEngine;

namespace G3D.Frontend.Avatars
{
	public class NodeAvatarHighlightable : ANodeAvatarDecorator
	{
		IHighliter highlighter;

		public NodeAvatarHighlightable(INodeAvatar nodeAvatar, IHighlightableBinary highlightableB) : base(nodeAvatar)
		{
			GameObject gameObject = this.nodeAvatar.GetGameObject();
			this.highlighter = new HighlighterBinary(highlightableB, gameObject);
		}

		public override void SelfDestruct()
		{
			highlighter.SelfDestruct();
			base.SelfDestruct();
		}
	}
}