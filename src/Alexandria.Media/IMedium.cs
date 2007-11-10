using System;
using System.Collections.Generic;

namespace Telesophy.Alexandria.Media
{
	public interface IMedium
	{
		string Name { get; set; }
		string Type { get; set; }
		string Description { get; set; }
		bool IsDigital { get; set; }
	}
}
