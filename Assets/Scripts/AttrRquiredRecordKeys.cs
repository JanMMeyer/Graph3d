using System;

namespace G3D
{
	[AttributeUsage(AttributeTargets.Class)]
	public class AttrRequiredRecordKeys : Attribute {
		public readonly string[] Keys;
		public AttrRequiredRecordKeys(string[] requiredKeys)
		{
			this.Keys = requiredKeys;
		}
	}
}
