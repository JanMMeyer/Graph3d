using System;
using System.IO;

namespace G3D.Backend
{
	public abstract class StreamAdapter
	{
		static readonly string STREAMREADER_EXCPTN = "StreamReader Excepion: {0}";
		static readonly string STREAMREADER_SUCCESS = "File {0} opened.";

		protected string filePath;
		protected StreamReader streamReader;

		public StreamAdapter(string filePath)
		{
			this.filePath = filePath;
		}
		public virtual bool IsReady()
		{
			try
			{
				streamReader = new StreamReader(filePath);
				G3DLogger.Log(STREAMREADER_SUCCESS, filePath);
				return true;
			}
			catch (Exception e)
			{
				G3DLogger.Log(STREAMREADER_EXCPTN, e.Message);
			}
			return false;
		}
	}
}
