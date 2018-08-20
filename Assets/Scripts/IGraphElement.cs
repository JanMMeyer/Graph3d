namespace G3D
{
	public interface IGraphElement
	{
		string GetId();
		void SelfDestruct();
		void SetAvatar(IAvatar avatar);
		void SetLabel(string label);
		bool TryGetAvatar(out IAvatar avatar);
		bool TryGetLabel(out string label);
	}
}