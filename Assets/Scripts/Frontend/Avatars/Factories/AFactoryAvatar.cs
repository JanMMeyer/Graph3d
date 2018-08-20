using UnityEngine;
using G3D.Core.EventSystem;

namespace G3D.Frontend.Avatars
{
	public abstract class AFactoryAvatar<TGraphElement> : IFactoryAvatar where TGraphElement : IGraphElement
	{
		protected GameObject avatarPrefab;

		public AFactoryAvatar(GameObject prefab)
		{
			avatarPrefab = prefab;
			EventPublisher.RegisterListener<EIGraphElementAdded<TGraphElement>>(onGraphElementAdded);
		}

		void onGraphElementAdded(EIGraphElementAdded<TGraphElement> eventInfo)
		{
			SpawnAvatar(eventInfo.GetAddedElement());
		}

		protected abstract void SpawnAvatar(TGraphElement graphElement);

	}
}