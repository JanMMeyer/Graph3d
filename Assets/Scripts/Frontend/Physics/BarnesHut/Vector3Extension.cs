using System;
using UnityEngine;

namespace G3D.Frontend.Physics
{
	public static class Vector3Extensions
	{
		public static bool hasNegativeComponent(this Vector3 vector)
		{
			for (int i = 0; i < 3; i++)
			{
				if (vector[i] < 0)
					return true;
			}
			return false;
		}

		public static bool hasZeroComponent(this Vector3 vector)
		{
			for (int i = 0; i < 3; i++)
			{
				if (vector[i] == 0)
					return true;
			}
			return false;
		}

		public static float GetAbsMaxComponent(this Vector3 vector)
		{
			float absMax = 0;
			for (int i = 0; i < 3; i++)
			{
				float absComp = Math.Abs(vector[i]);
				absMax = Math.Max(absMax, absComp);
			}
			return absMax;
		}

		public static Vector3 rotateToOctant(this Vector3 vector, int index)
		{
			float x = vector.x * (float)Math.Pow(-1, index);
			float y = vector.y * (float)Math.Pow(-1, index / 2);
			float z = vector.z * (float)Math.Pow(-1, index / 4);
			return new Vector3(x, y, z);
		}

	}
}