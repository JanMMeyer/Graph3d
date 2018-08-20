using UnityEngine;
using G3D.Core;
namespace G3D.Frontend.Physics
{
	public class OctNode : Octant
	{
		static float theta = 0.5f;
		static float forceFactor = 10f;

		INodeAvatar containedAvatar;
		Vector3 containedAvatarPos;
		Vector3 centerOfCharge;
		float chargeSum = 0;
		OctNode[] children;

		// distence threshold for subsummation of nodes, theta = 0 is euqivalent to brute force individual node interaction. higher values -> lower precision. 
		public static void SetTheta(float value)
		{
			theta = value;
		}
		// force pointing away from 'thisPostion' with magnitude of 1/distance (coulomb)
		static Vector3 interNodeForce(Vector3 thisPosition, Vector3 otherPosition, float otherCharge = 1)
		{
			Vector3 deltaPosition = thisPosition - otherPosition;
			float squaredDistance = deltaPosition.sqrMagnitude;
			return deltaPosition * (otherCharge / squaredDistance) * forceFactor;
		}

		public static void SetForceFactor(float value)
		{
			forceFactor = value;
		}

		public OctNode(Vector3 center, float innerRadius) : base(center, innerRadius)
		{
		}

		public void Add(INodeAvatar nodeAvatar, Vector3 avatarPos)
		{
			// if this is internal
			if (children != null)
			{
				this.update(nodeAvatar, avatarPos);
				this.moveToChild(nodeAvatar, avatarPos);
			}
			// if this is empty external
			else if (containedAvatar == null)
			{
				this.containedAvatar = nodeAvatar;
				this.containedAvatarPos = avatarPos;
				this.update(nodeAvatar, avatarPos);
			}
			// if this is non empty external 
			else
			{
				this.initChildren();
				this.update(nodeAvatar, avatarPos);
				this.moveToChild(nodeAvatar, avatarPos);
				this.moveToChild(this.containedAvatar, this.containedAvatarPos);
				containedAvatar = null;
			}
		}

		public void interact(INodeAvatar nodeAvatar, Vector3 nodeAvatarPos)
		{
			// if emtpy external or external with self
			if (this.chargeSum == 0 || this.containedAvatar == nodeAvatar)
			{
				return;
			}
			// if internal not fulfilling theta criterium
			if (containedAvatar == null && this.chargeSum / Vector3.Distance(nodeAvatarPos, centerOfCharge) > theta)
			{
				for (int i = 0; i < 8; i++)
				{
					this.children[i].interact(nodeAvatar, nodeAvatarPos);
				}
			}
			// if non empty external or internal fulfilling theta criterium 
			else
			{
				Vector3 force = interNodeForce(nodeAvatarPos, this.centerOfCharge, this.chargeSum);
				nodeAvatar.AddForce(force);
			}
		}

		void moveToChild(INodeAvatar nodeAvatar, Vector3 nodeAvatarPos)
		{
			foreach (OctNode child in children)
			{
				if (child.Contains(nodeAvatarPos))
				{
					child.Add(nodeAvatar, nodeAvatarPos);
					break;
				}
			}
		}

		void update(INodeAvatar nodeAvatar, Vector3 nodeAvatarPos)
		{
			this.centerOfCharge = (this.centerOfCharge * this.chargeSum + nodeAvatarPos) / (chargeSum + 1);
			this.chargeSum++;
		}

		void initChildren()
		{
			children = new OctNode[8];
			float childInnerRadius = this.innerRadius / 2f;
			Vector3 initialChildInnerRadiusVector = Vector3.one * childInnerRadius;
			Vector3 childCenter;
			for (int i = 0; i < 8; i++)
			{
				childCenter = this.center + initialChildInnerRadiusVector.rotateToOctant(i);
				children[i] = new OctNode(childCenter, childInnerRadius);
			}
		}
	}
}