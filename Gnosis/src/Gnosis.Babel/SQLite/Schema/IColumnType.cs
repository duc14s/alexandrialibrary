﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Gnosis.Babel.SQLite.Schema
{
    public interface IColumnType : IStatement, IColumnConstrained
    {
    }

    public interface IColumnType<T> : IStatement, IColumnConstrained<T>
    {
    }
}
