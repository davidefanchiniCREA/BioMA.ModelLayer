using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace CRA.ModelLayer.Data
{
    /// <summary>
    /// Provides information on each column contained in a <see cref="Table">Table</see>.
    /// </summary>
    public class ColumnDescriptor
    {
        private Type _ColumnType;
        private string _ColumnName;
        private Table _ContainingTable;

        internal ColumnDescriptor(string name, Type type, Table table)
        {
            if (name == null || name.Trim().Equals(""))
                throw new DataCollectionException("invalid name for a column");
            if (type == null)
                throw new DataCollectionException("invalid type for a column");
            _ColumnName = name;
            _ColumnType = type;
            _ContainingTable = table;
        }

        /// <summary>
        /// Returns a classic <see cref="DataColumn">DataColumn</see> representation.
        /// </summary>
        public DataColumn DataColumn
        {
            get
            {
                DataColumn dataColumn = new DataColumn(_ColumnName, _ColumnType);
                return dataColumn;
            }
        }

        /// <summary>
        /// The type of the column represented by this descriptor.
        /// </summary>
        public Type ColumnType
        {
            get { return _ColumnType; }
        }

        /// <summary>
        /// The name of the column represented by this descriptor.
        /// </summary>
        public string ColumnName
        {
            get { return _ColumnName; }
        }

        /// <summary>
        /// The <see cref="Table">Table</see> to which the column represented by this descriptor belongs.
        /// </summary>
        public Table Table
        {
            get { return _ContainingTable; }
        }
    }
}