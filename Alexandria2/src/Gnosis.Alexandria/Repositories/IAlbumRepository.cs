﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gnosis.Alexandria.Repositories
{
	public interface IAlbumRepository
		: IRepository<IAlbum>
	{
		IList<IAlbum> GetByArtist(IArtist artist);
	}
}
