using System;
using System.Collections.Generic;

namespace G3D.Backend
{
	public class CSVAdapter<ElementType>: StreamAdapter
	{
		static readonly string NODATA_ERR = "File {0} contains no Data.";
		static readonly string MISSINGKEYS_ERR = "File {0} is missing at least one of the following required keys: {1}";
		static readonly string FIELDNUMBER_ERR = "In FIle {3}, Number of Fields ({0}) does not match number of Keys ({1}). Skipping line {2}.";

		char lineEnding;
		char delimiter;
		string[] lines;
		string[] columnNames;
		string[] requiredRecordKeys = new string[] { };

		public CSVAdapter(string csvPath, char delimiter = ';', char lineEnding = '\n') : base(csvPath)
		{
			this.delimiter = delimiter;
			this.lineEnding = lineEnding;
			AttrRequiredRecordKeys requiredRecordKeysAttr = (AttrRequiredRecordKeys)Attribute.GetCustomAttribute(typeof(ElementType), typeof(AttrRequiredRecordKeys));
			if (requiredRecordKeysAttr != null)
			{
				requiredRecordKeys = requiredRecordKeysAttr.Keys;
			}

		}

		public override bool IsReady()
		{
			if (!base.IsReady())
			{
				return false;
			}
			lines = streamReader.ReadToEnd().Split(lineEnding);
			if (lines.Length < 2)
			{
				G3DLogger.Log(NODATA_ERR, this.filePath);
				return false;
			}
			for (int i = 0; i < lines.Length; i++)
			{
				string line = lines[i];
				lines[i] = line.Replace("\n", String.Empty).Replace("\r", String.Empty).Trim();
			}
			columnNames = lines[0].Split(delimiter);
			if (!new HashSet<string>(requiredRecordKeys).IsSubsetOf(new HashSet<string>(columnNames)))
			{
				string missingKeys = string.Join(", ", requiredRecordKeys);
				G3DLogger.Log(MISSINGKEYS_ERR,new object[] {this.filePath ,missingKeys});
				return false;
			}
			return true;
		}

		public CSVRecord[] GetRecords()
		{
			int numKeys = columnNames.Length;
			List<CSVRecord> recordList = new List<CSVRecord>();
			string[] values;
			for (int i = 1; i < lines.Length; i++)
			{
				values = lines[i].Split(delimiter);
				if (values.Length > 0) {
					try
					{
						recordList.Add(new CSVRecord(columnNames, values));
					}
					catch (IndexOutOfRangeException e)
					{
						G3DLogger.Log(FIELDNUMBER_ERR, new object[] { values.Length, numKeys, i, this.filePath });
					}
				}
			}
				
			return recordList.ToArray();
		}
	}
}