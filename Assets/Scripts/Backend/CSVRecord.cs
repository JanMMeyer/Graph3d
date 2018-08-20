using System.Collections.Generic;

namespace G3D.Backend
{
	public class CSVRecord : IRecord
	{
		Dictionary<string, string> record = new Dictionary<string, string>();

		public CSVRecord(string[] keys, string[] values)
		{
			int arrayLength = keys.Length;
			for (int i = 0; i < arrayLength; i++)
			{
				record.Add(keys[i], values[i]);
			}
		}
		public bool TryGet(string key, out string value)
		{
			return record.TryGetValue(key, out value);
		}
	}

}