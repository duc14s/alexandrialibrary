using System;
using System.Collections.Generic;

namespace Telesophy.Alexandria.Media
{
	public interface IRelease
	{
		string Title { get; set; }
		DateTime DateReleased { get; set; }
		ILocation Location { get; set; }
		IList<IWork> Works { get; }
	}
}
