using UnityEngine;

namespace G3D.Frontend.Avatars
{
	public class MBEdgeAvatar : MonoBehaviour, IHighlightableTernary, IAdjustableLineWidth
	{
		static float normalWidth = 0.03f;
		static float highlightedWidth = 0.05f;

		public Material NormalMaterial;
		public Material HighlitedMaterial;
		public Material HighlitedMaterial2;

		INodeAvatar sourceNodeAvatar;
		INodeAvatar targetNodeAvatar;
		LineRenderer ownlineRenderer;

		public void SetSourceNodeAvatar(INodeAvatar avatar)
		{
			this.sourceNodeAvatar = avatar;
		}

		public void SetTargetNodeAvatar(INodeAvatar avatar)
		{
			this.targetNodeAvatar = avatar;
		}

		public void SetSourceLineWidth(float value)
		{
			if (this.ownlineRenderer == null)
			{
				this.ownlineRenderer = GetComponent<LineRenderer>();
			}
			this.ownlineRenderer.startWidth = value;

		}
		public void SetTargetLineWidth(float value)
		{
			if (this.ownlineRenderer == null)
			{
				this.ownlineRenderer = GetComponent<LineRenderer>();
			}
			this.ownlineRenderer.endWidth = value;
		}

		void Start()
		{
			this.ownlineRenderer = GetComponent<LineRenderer>();
			this.ownlineRenderer.material = NormalMaterial;
			this.ownlineRenderer.widthMultiplier = normalWidth;
			this.setPosition(sourceNodeAvatar.GetPosition(), targetNodeAvatar.GetPosition());
		}

		void Update()
		{
			Vector3 sourcePos = this.sourceNodeAvatar.GetPosition();
			Vector3 targetPos = this.targetNodeAvatar.GetPosition();
			this.ownlineRenderer.SetPosition(0, sourcePos);
			this.ownlineRenderer.SetPosition(1, targetPos);
			this.setPosition(sourcePos, targetPos);
		}


		public void SetHighlighted(int state)
		{
			switch (state)
			{
				case 0:
					this.ownlineRenderer.material = this.NormalMaterial;
					this.ownlineRenderer.widthMultiplier = normalWidth;
					break;
				case 1:
					this.ownlineRenderer.material = this.HighlitedMaterial;
					this.ownlineRenderer.widthMultiplier = highlightedWidth;
					break;
				case 2:
					this.ownlineRenderer.material = this.HighlitedMaterial2;
					this.ownlineRenderer.widthMultiplier = highlightedWidth * 2;
					break;
				default:
					G3DLogger.Log("HighlightableTernary got invalid state argument {1} in 'SetHighlighted(int state)', state must be 0, 1 or 2!", state);
					break;
			}
		}

		void setPosition(Vector3 sourcePos, Vector3 targetPos)
		{
			this.transform.position = (sourcePos + targetPos) / 2f;
		}
	}
}