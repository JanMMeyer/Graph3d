using UnityEngine;

namespace G3D.Frontend.Physics
{
	public class Octant
	{

		protected readonly Vector3 center;
		protected readonly float innerRadius;

		Vector3 upperLimit;
		Vector3 lowerLimit;

		public Octant(Vector3 center, float innerRadius)
		{
			this.center = center;
			this.innerRadius = innerRadius;
			Vector3 innerRadiusVec = Vector3.one * innerRadius;
			this.upperLimit = center + innerRadiusVec;
			this.lowerLimit = center - innerRadiusVec;
			
		}
		
		protected bool Contains(Vector3 testVector)
		{
			Vector3 upperResult = this.upperLimit - testVector;
			Vector3 lowerResult = testVector - this.lowerLimit;
			//inclusive upperLimit, exclusive lower Limit
			return !upperResult.hasNegativeComponent()
					&& !lowerResult.hasNegativeComponent()
					&& !lowerResult.hasZeroComponent();
		}

	}
}