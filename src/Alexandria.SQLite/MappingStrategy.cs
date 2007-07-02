using System;
using System.Collections.Generic;
using System.Text;
using Alexandria.Persistence;

namespace Alexandria.SQLite
{
	internal class MappingStrategy : IMappingStrategy
	{
		#region Constructor
		internal MappingStrategy(SQLiteDataProvider provider, MappingFunction function) : this(provider, function, (IPersistent)null)
		{
		}

		internal MappingStrategy(SQLiteDataProvider provider, MappingFunction function, IPersistent record)
		{
			this.provider = provider;
			this.function = function;
			this.type = MappingType.Singleton;
			this.record = record;
		}

		internal MappingStrategy(SQLiteDataProvider provider, MappingFunction function, IList<IPersistent> records)
		{
			this.provider = provider;
			this.function = function;
			this.type = MappingType.Collection;
			this.records = records;
		}
		#endregion
	
		#region Private Fields
		private SQLiteDataProvider provider;
		private MappingFunction function;
		private MappingType type;
		private IPersistent record;
		private IList<IPersistent> records;		
		#endregion
	
		#region IMappingStrategy Members
		public SQLiteDataProvider Provider
		{
			get { return provider; }
		}

		public MappingFunction Function
		{
			get { return function; }
		}
		
		public MappingType Type
		{
			get { return type; }
		}
		
		public IPersistent Record
		{
			get { return record; }
			set { record = value; }
		}
		
		public IList<IPersistent> Records
		{
			get { return records; }
			set { records = value; }
		}
		#endregion
	}
}