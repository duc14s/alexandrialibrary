#region License
/*
Copyright (c) 2007 Dan Poage

Permission is hereby granted, free of charge, to any person
obtaining a copy of this software and associated documentation
files (the "Software"), to deal in the Software without
restriction, including without limitation the rights to use,
copy, modify, merge, publish, distribute, sublicense, and/or sell
copies of the Software, and to permit persons to whom the
Software is furnished to do so, subject to the following
conditions:

The above copyright notice and this permission notice shall be
included in all copies or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND,
EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES
OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND
NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT
HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY,
WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING
FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR
OTHER DEALINGS IN THE SOFTWARE.
*/
#endregion

using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SQLite;
using System.IO;
using System.Reflection;
using System.Text;
using Alexandria;
using Alexandria.Data;

namespace Alexandria.SQLite
{
	public class SQLiteDataProvider : IDataStore
	{			
		#region Constructors
		public SQLiteDataProvider(string databasePath)
		{		
			this.databasePath = databasePath;
		}
		#endregion
		
		#region Private Constants
		private const string SCHEMA_TABLES = "Tables";
		private const string SCHEMA_TABLE_NAME = "TABLE_NAME";
		#endregion
		
		#region Private Fields
		string databasePath;
		#endregion
		
		#region Private Methods
		
		#region GetConnectionString
		private string GetConnectionString()
		{
			bool databaseIsNew = false;
			databaseIsNew = (!File.Exists(databasePath));
			return string.Format("Data Source={0};New={1};UTF8Encoding=True;Version=3", databasePath, databaseIsNew);		
		}
		#endregion
		
		#region GetSQLiteConnection
		private SQLiteConnection GetSQLiteConnection(string connectionString)
		{
			return new SQLiteConnection(connectionString);
		}
		#endregion

		#region TableExists
		private bool TableExists(string tableName)
		{
			SQLiteConnection connection = GetSQLiteConnection(GetConnectionString());
			DataTable tables = connection.GetSchema(SCHEMA_TABLES);
			foreach (DataRow tableInfo in tables.Rows)
			{
				if (string.Compare(tableInfo[SCHEMA_TABLE_NAME].ToString(), tableName, true) == 0)
					return true;
			}
			return false;
		}

		private bool TableExists<T>(T table) where T : IMetadata
		{
			if (table != null)
			{
				string tableName = table.GetType().Name;
				return TableExists(tableName);
			}
			else throw new ArgumentNullException("table");
		}
		#endregion
		
		#region IsValueType
		/// <summary>
		/// Get a value indicating whether or not the given type is a value type
		/// </summary>
		/// <param name="type">The type in question</param>
		/// <returns>True if the type is a value type, false otherwise</returns>
		/// <remarks>Note - technically string is not a value type it is a primitive type but this is an expedient</remarks>
		private bool IsValueType(Type type)
		{
			bool isValueType = false;

			if (type == typeof(char) ||
				type == typeof(decimal) ||
				type == typeof(float) ||
				type == typeof(double) ||
				type == typeof(bool) ||
				type == typeof(byte) ||
				type == typeof(sbyte) ||
				type == typeof(ushort) ||
				type == typeof(short) ||
				type == typeof(uint) ||
				type == typeof(int) ||
				type == typeof(ulong) ||
				type == typeof(long) ||
				type == typeof(DateTime) ||
				type == typeof(TimeSpan))
			isValueType = true;
			
			return isValueType;
		}
		#endregion
		
		#region IsCollection
		private bool IsCollection(Type type)
		{
			//if (type.GetInterface("System.Collections.ICollection") != null)
				//return true;
			//else
			if (type.GetInterface("System.Collections.Generic.ICollection<T>") != null)
				return true;
			else
				return false;
		}
		#endregion
		
		#region InstantiateType
		private void InstantiateType(Type type)
		{
			ConstructorInfo ctor = null;
			
			foreach(ConstructorInfo constructor in type.GetConstructors(BindingFlags.NonPublic|BindingFlags.Public))
			{
				foreach (PersistanceConstructorAttribute attribute in constructor.GetCustomAttributes(typeof(PersistanceConstructorAttribute), false))
				{
					ctor = constructor;					
					break;					
				}
				
				if (ctor != null)
					break;
			}
		}
		#endregion
		
		#region DetermineTablesFromType
		private void DetermineTablesFromType(IList<DataTable> tables, Type type)
		{
			PersistanceClassAttribute classAttribute = null;			
						
			foreach(PersistanceClassAttribute attribute in type.GetCustomAttributes(typeof(PersistanceClassAttribute), false))
			{
				classAttribute = attribute;
				break;
			}

			if (classAttribute != null)
			{
				string tableName = classAttribute.TableName;

				if (!string.IsNullOrEmpty(tableName))
				{
					DataTable table = new DataTable(tableName);
					IDictionary<int, DataColumn> columns = new Dictionary<int, DataColumn>();				
					int i = 1; int ordinal;
					
					foreach(PropertyInfo property in type.GetProperties(BindingFlags.GetProperty|BindingFlags.Public|BindingFlags.Instance))
					{
						foreach (PersistancePropertyAttribute attribute in property.GetCustomAttributes(typeof(PersistancePropertyAttribute), false))
						{
							if (attribute.FieldType == PersistanceFieldType.Basic)
							{
								ordinal = (attribute.Ordinal > 0) ? attribute.Ordinal : i;
								DataColumn column = new DataColumn(property.Name, property.PropertyType);
								column.Unique = attribute.IsUnique;
								column.AllowDBNull = !attribute.IsRequired;
								column.DefaultValue = attribute.DefaultValue;
								if (attribute.MaxLength > 0)																
									column.MaxLength = attribute.MaxLength;
								
								columns.Add(ordinal, column);
								i++;
							}
							else
							{
								if (attribute.FieldType == PersistanceFieldType.OneToOneChild)
								{
								}
								else if (attribute.FieldType == PersistanceFieldType.OneToManyChildren)
								{
									if (attribute.ChildType != null)
										DetermineTablesFromType(tables, attribute.ChildType);
								}							
							}
						}
					}
					
					if (columns.Count > 0)
					{
						for(int j=1;j<=columns.Count;j++)
							table.Columns.Add(columns[j]);
						
						tables.Add(table);
					}
					else throw new ApplicationException("Could not find any columns for type: " + type.Name);
				}
				else throw new ApplicationException("Could not determine the table name for type: " + type.Name);
			}
		}
		#endregion
		
		#region CreateTable
		private bool CreateTable(DataTable table)
		{
			bool tableCreated = false;
		
			if (table != null)
			{
				StringBuilder sql = new StringBuilder();
				sql.AppendFormat("CREATE TABLE IF NOT EXISTS {0} (", table.TableName);
				
				int count = 0;
				foreach(DataColumn column in table.Columns)
				{
					string delimiter = string.Empty;
					if (count > 0) delimiter = ", ";
					
					string columnType = "TEXT";
					string columnConstraint = string.Empty;
					
					if (column.Unique)					
						columnConstraint += " UNIQUE";
					 
					 if (!column.AllowDBNull)
						columnConstraint += " NOT NULL";
					 
					if (column.DataType == typeof(decimal) ||
						column.DataType == typeof(string) ||
						column.DataType == typeof(Guid))
					{
						columnType = "TEXT";
					}
					else 
					if (column.DataType == typeof(float) ||
						column.DataType == typeof(double))
					{
						columnType = "REAL";
					}
					else
					if (column.DataType == typeof(bool) ||
						column.DataType == typeof(byte) ||
						column.DataType == typeof(sbyte) ||
						column.DataType == typeof(ushort) ||
						column.DataType == typeof(short) ||
						column.DataType == typeof(uint) ||
						column.DataType == typeof(int) ||
						column.DataType == typeof(ulong) ||
						column.DataType == typeof(long) ||
						column.DataType == typeof(DateTime) ||
						column.DataType == typeof(TimeSpan))
					{
						columnType = "INTEGER";						
					}
					
					sql.AppendFormat("{0}{1} {2}{3}", delimiter, column.ColumnName, columnType, columnConstraint);
					
					count++;
				}
				sql.Append(")");
				
				SQLiteConnection connection = GetSQLiteConnection(GetConnectionString());
				connection.Open();
				IDbCommand command = new SQLiteCommand(sql.ToString(), connection);
				tableCreated = (command.ExecuteNonQuery() == 0);
			}
			else throw new ArgumentNullException("table");
			
			return tableCreated;
		}
		#endregion
		
		#region GetChildCollectionByParentId
		private IList<IPersistant> GetChildCollectionByParentId(Guid id)
		{
			return new List<IPersistant>();
		}
		#endregion
		
		#region GetRecordById
		private T GetRecordById<T>(Guid id) where T: class, IPersistant
		{
			try
			{
				IList<DataTable> tables = new List<DataTable>();
				DetermineTablesFromType(tables, typeof(T)); 
				foreach(DataTable table in tables)
					CreateTable(table);
			}
			catch (Exception ex)
			{
				throw new ApplicationException("Lookup error", ex);
			}
			
			return null;
		}
		#endregion
		
		#endregion
	
		#region Public Methods

		#region GetConnection
		public IDbConnection GetConnection()
		{
			return GetSQLiteConnection(GetConnectionString());
		}
		#endregion
		
		#region Test
		public string Test()
		{
			try
			{
				using (SQLiteConnection connection = GetSQLiteConnection(GetConnectionString()))
				{
					//connection.Open();
					//SQLiteCommand createCommand = new SQLiteCommand("CREATE TABLE AudioTrack (Id TEXT PRIMARY KEY, Location TEXT, Name TEXT, Album TEXT, Artist TEXT, Duration INT, ReleaseDate INT, TrackNumber INT, Format TEXT)", connection);
					//SQLiteCommand createCommand = new SQLiteCommand("CREATE TABLE MetadataId (Id TEXT PRIMARY KEY, ParentId TEXT, IdValue TEXT, IdType TEXT, IdVersion TEXT)", connection);
					//return createCommand.ExecuteNonQuery().ToString();
				}
			}
			catch (Exception ex)
			{
				throw new ApplicationException("SQLite error", ex);
			}
			
			return string.Empty;
		}
		#endregion
		
		/*
		#region Lookup
		public T Lookup<T>(IIdentifier id) where T: IMetadata
		{
			IList<DataTable> tables = new List<DataTable>();
			DetermineTablesFromType(tables, typeof(T));
			//if (TableExists)...
		
			return default(T);
		}
		
		public T Lookup<T>(Guid alexandriaId) where T: IMetadata
		{
			Type type = typeof(T);
		
			return default(T);
		}
		#endregion
		
		#region Save
		public bool Save<T>(T row) where T: IMetadata
		{
			bool saved = false;
			
			return saved;
		}
		#endregion
		
		#region Delete
		public bool Delete<T>(T row) where T: IMetadata
		{
			bool deleted = false;
			
			return deleted;
		}
		#endregion
		*/
		#endregion

		#region IDataStore Members
		public void Initialize(Type type)
		{
			IList<DataTable> tables = new List<DataTable>();
			DetermineTablesFromType(tables, type);
			foreach(DataTable table in tables)
				CreateTable(table);
		}
		
		public T Lookup<T>(Guid id) where T : class,IPersistant
		{
			T record = GetRecordById<T>(id);
			if (record != null)
				record.DataStore = this;
			
			return record;
		}

		public void Save(IPersistant record)
		{
		}

		public void Delete(IPersistant record)
		{
		}
		#endregion
	}
}
