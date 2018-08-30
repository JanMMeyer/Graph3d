namespace G3D.Frontend.Avatars
{
	public class EdgeAvatarDirected : AEdgeAvatarDecorator
	{
		
		public EdgeAvatarDirected(IEdgeAvatar edgeAvatar, IAdjustableLineWidth adjustableLW) : base(edgeAvatar)
		{
			adjustableLW.SetSourceLineWidth(4.5f);
			adjustableLW.SetTargetLineWidth(0.5f);
		}

	}	
}