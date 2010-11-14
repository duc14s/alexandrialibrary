﻿using System.Linq;
using Gnosis.Alexandria.Models.Interfaces;

namespace Gnosis.Alexandria.Models.Mappers
{
    public class PersistMapper<T> : IPersistMapper<T>
        where T : IModel
    {
        public PersistMapper(ISchema<T> schema, IFactory<IInsertBuilder> insertFactory, IFactory<IUpdateBuilder> updateFactory, IFactory<IDeleteBuilder> deleteFactory)
        {
            Schema = schema;
            InsertFactory = insertFactory;
            UpdateFactory = updateFactory;
            DeleteFactory = deleteFactory;
        }

        #region Protected Members

        protected readonly ISchema<T> Schema;
        protected readonly IFactory<IInsertBuilder> InsertFactory;
        protected readonly IFactory<IUpdateBuilder> UpdateFactory;
        protected readonly IFactory<IDeleteBuilder> DeleteFactory;

        protected virtual ICommand GetInsertCommand(T model)
        {
            return InsertFactory.Create()
                .Insert
                .OrFail
                .Into(Schema.Name)
                .ColumnsToValues<T>(Schema.NonPrimaryFields.Select(x => x.Getter), model)
                .SetCallback<T>((x, y) => x.Initialize(y), model)
                .ToCommand();
        }

        protected virtual ICommand GetUpdateCommand(T model)
        {
            return UpdateFactory.Create()
                .Update
                .OrFail
                .Table(Schema.Name)
                .ColumnsToValues(Schema.NonPrimaryFields.Select(x => x.Getter), model)
                .Where<T>(x => x.Id).IsEqualTo<T>(x => x.Id, model.Id)
                .ToCommand();
        }

        protected virtual ICommand GetDeleteCommand(T model)
        {
            return DeleteFactory.Create()
                .Delete
                .OrFail
                .From(Schema.Name)
                    .Where<T>(x => x.Id)
                    .IsEqualTo<T>(x => x.Id, model.Id)
                .ToCommand();
        }

        #endregion

        public ICommand GetPersistCommand(T model)
        {
            if (model.IsDeleted)
                return GetDeleteCommand(model);
            
            return (model.IsNew) ?
                GetInsertCommand(model) :
                GetUpdateCommand(model);
        }
    }
}