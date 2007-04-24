using System;
using System.Collections.Generic;
using System.Net.Mime;
using System.Text;

namespace Alexandria
{
	public interface IMediaFormat
	{
		string Name { get; }
		IList<ContentType> ContentTypes { get; }
		IList<string> FileExtensions { get; }
	}
}