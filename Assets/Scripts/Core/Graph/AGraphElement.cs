namespace G3D.Core.Graph
{
	public abstract class AGraphElement : IGraphElement
	{

		protected string id;
		protected IAvatar avatar;

		protected string label;

		protected AGraphElement(string elementId)
		{
			id = elementId;
		}

		public string GetId()
		{
			return id;
		}

		public void SetLabel(string label)
		{
			this.label = label;
		}

		public bool TryGetLabel(out string label)
		{
			label = this.label;
			if (label == null)
			{
				return false;
			}
			return true;
		}

		public void SetAvatar(IAvatar avatar)
		{
			this.avatar = avatar;
		}

		public bool TryGetAvatar(out IAvatar avatar)
		{
			avatar = this.avatar;
			if (avatar == null)
			{
				return false;
			}
			return true;
		}

		public void SelfDestruct()
		{
			if (this.avatar != null)
			{
				avatar.SelfDestruct();
			}
		}

	}
}