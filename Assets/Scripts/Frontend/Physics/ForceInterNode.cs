using System;
using UnityEngine;

namespace G3D.Frontend.Physics
{
	class ForceInterNode : IForce
	{
	
		INodeAvatar[] nodeAvatars;
		OctNode OctTree;
		IRegistryNodeAvatar nodeAvatarRegistry;

		public ForceInterNode(IRegistryNodeAvatar nodeAvatarRegistry)
		{
			this.nodeAvatarRegistry = nodeAvatarRegistry;
		}

		public void SetTheta(float theta)
		{
			// distance threshold for octant-avatar interaction 
			OctNode.SetTheta(theta);
		}

		public void SetForceFactor(float value)
		{
			OctNode.SetForceFactor(value);
		}

		public void Update()
		{
			this.nodeAvatars = this.nodeAvatarRegistry.GetAvatars();
			OctTree = new OctNode(Vector3.zero, this.getInitialInnerRadius());
			this.addAvatars();
			this.interactAvatars();
		}

		void addAvatars()
		{
			foreach (INodeAvatar nodeAvatar in this.nodeAvatars)
			{
				// recursively adds avatar in an empty octant or splits any occupied octant untils each avatar has it's own
				OctTree.Add(nodeAvatar, nodeAvatar.GetPosition());
			}
		}

		void interactAvatars()
		{
			foreach (INodeAvatar nodeAvatar in this.nodeAvatars)
			{
				// interaction between single avatars and center of charges of octants.
				OctTree.interact(nodeAvatar, nodeAvatar.GetPosition());
			}
		}

		// gets size of first octant
		float getInitialInnerRadius()
		{
			float innerRadius = 0;
			Vector3 nodeAvatarPos;
			foreach (INodeAvatar nodeAvatar in nodeAvatars)
			{
				nodeAvatarPos = nodeAvatar.GetPosition();
				// GetAbsMaxComponent return the absolute maximum component of ther vector, ie the longest distance from the center in one dimension
				innerRadius = Math.Max(innerRadius, nodeAvatarPos.GetAbsMaxComponent());
			}

			return innerRadius+0.5f;
		}
	}
}
