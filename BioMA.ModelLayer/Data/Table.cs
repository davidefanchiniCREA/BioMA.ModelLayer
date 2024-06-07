using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

namespace CRA.ModelLayer.Data
{
    /// <summary>
    /// Lightweight version of the <see cref="DataTable">DataTable</see>, to be used with <see cref="DataCollection">DataCollection</see>.
    /// </summary>
    /// <remarks>
    /// Like in the version of the Microsoft framework, it is possible to add columns and data rows, but no verification of primary key nor
    /// relationships is performed (in fact none of these can be enforced in this lightweight version). This in order to keep overhead
    /// in using this class to a minumum.<br/>
    /// A <see cref="DataTable">DataTable</see> version of a Table can be built by invoking the property
    /// <see cref="Table.DataTable">Table.DataTable</see>, but again on the obtained object
    /// no primary key nor relationship constraint is enforced.<br/>
    /// Each row in the Table consists of an array of objects (object[]). This array must have the same number of elements as the
    /// number of columns added to the Table.
    /// While adding a row, by default no type check of the elements of the array is performed against the types
    /// with which each column has been added to the Table, unless the programmer explicitly asks for this by using a boolean
    /// flag "checkType". This, again, to keep overhead in using this class to a minimum.
    /// </remarks>
    public class Table
    {
        private Dictionary<string, ColumnDescriptor> _ColumnDescriptors = new Dictionary<string, ColumnDescriptor>();
        private List<string> _ColumnNames = new List<string>();
        private List<object[]> _Data = new List<object[]>();
        internal DataCollection _ContainingRunValue;
        private string _Name;

        internal Table(string name, DataCollection runValue)
        {
            if (name == null || name.Trim().Equals(""))
                throw new DataCollectionException("invalid table name");
            _Name = name;
            _ContainingRunValue = runValue;
        }

        /// <summary>
        /// Constructor that builds a new Table not belonging to a <see cref="DataCollection">DataCollection</see>.
        /// </summary>
        /// <param name="name">The name of the new Table</param>
        /// <remarks>
        /// If a Table belonging to a <see cref="DataCollection">DataCollection</see> is needed, use the method
        /// <see cref="DataCollection.AddTable(string)">DataCollection.AddTable(string)</see> to create one, instead
        /// of calling directly this Constructor.
        /// </remarks>
        public Table(string name)
        {
            if (name == null || name.Trim().Equals(""))
                throw new DataCollectionException("invalid table name");
            _Name = name;
        }

        internal void AddColumn(ColumnDescriptor descriptor)
        {
            if (_ColumnDescriptors.ContainsKey(descriptor.ColumnName))
                throw new DataCollectionException("the table already contains a column named '" + descriptor.ColumnName + "'");
            /* DFa - allow for adding a column with non-empty table (as per DFu request) 25/07/2011 - begin */
            /* old - begin */
            //if (_Data.Count > 0)
            //    throw new DataCollectionException("cannot add a new column in a non-empty table");
            /* old - end */
            if (_Data.Count > 0)
            {
                //Table newTable = new Table(this._Name);
                var _newColumnNames = _ColumnNames.ToList();
                var _newColumnDescriptors = _ColumnDescriptors.ToDictionary(a => a.Key, a => a.Value);
                var _newData = new List<object[]>();

                _newColumnNames.Add(descriptor.ColumnName);
                _newColumnDescriptors.Add(descriptor.ColumnName, descriptor);

                int numberOfColumns = this._ColumnDescriptors.Count +1;

                foreach (object[] oldValues in _Data)
                {
                    object[] newValues = new object[numberOfColumns];
                    Array.Copy(oldValues, newValues, numberOfColumns - 1);
                    _newData.Add(newValues);
                }

                // S Y N C H R O N I Z E   H E R E   ! ! !
                _ColumnDescriptors = _newColumnDescriptors;
                _ColumnNames = _newColumnNames;
                _Data = _newData;
                
                return;
            }
            /* DFa - allow for adding a column with non-empty table (as per DFu request) 25/07/2011 - end */
            _ColumnNames.Add(descriptor.ColumnName);
            _ColumnDescriptors.Add(descriptor.ColumnName, descriptor);
        }

        /// <summary>
        /// Returns an enumeration of all the columns added to this Table
        /// </summary>
        public IEnumerable<string> ColumnNames
        {
            get
            {
                foreach (var item in _ColumnNames)
                {
                    yield return item;
                }
            }
        }

        /// <summary>
        /// Returns the ColumnDescriptor for the column having the name passed as parameter.
        /// </summary>
        /// <param name="columnName">The name of the Column whose ColumnDescriptor is needed.</param>
        /// <returns>The ColumnDescriptor for the column having the name passed as parameter.</returns>
        public ColumnDescriptor GetColumnDescriptor(string columnName)
        {
            return _ColumnDescriptors[columnName];
        }

        /// <summary>
        /// Adds a new column to this Table, having the name and type passed has parameters.
        /// </summary>
        /// <param name="name">The name of the new column.</param>
        /// <param name="type">The type of the new column.</param>
        /// <exception cref="DataCollectionException">If this Table already contains a column with the name passed as parameter.</exception>
        public void AddColumn(string name, Type type)
        {
            AddColumn(new ColumnDescriptor(name, type, this));
        }

        /// <summary>
        /// Sets, in the row passed as the parameter 'row', the value 'newValue' in the column having the name 'columnName'.
        /// The method throws <see cref="DataCollectionException">DataCollectionException</see> if the Table
        /// does not contain a column named 'columnName', or if, in the case checkType is true, the type of newValue is not
        /// compatible with the column type. This last check is not performed if checkType is false.
        /// </summary>
        /// <param name="row">The row in which the value has to be modified.</param>
        /// <param name="columnName">The column for which the value has to be modified.</param>
        /// <param name="newValue">The new value to set.</param>
        /// <param name="checkType">If true, a type check is performed on the value to verify its compliancy
        /// with the column's type. If the type is not compliant a <see cref="DataCollectionException">DataCollectionException
        /// </see>is thrown. If this parameter is false, the type check is not performed.</param>
        /// <exception cref="DataCollectionException">If this table does not contain a column with the name specified
        /// as parameter, or if, in the case checkType is true, the type of newValue is not compatible with the column type.</exception>
        public void ModifyCell(object[] row, string columnName, object newValue, bool checkType)
        {
            int indexOfColumn = _ColumnNames.IndexOf(columnName);
            if (indexOfColumn < 0) throw new DataCollectionException("No column '" + columnName + "' for table '" + _Name + "'");
            if (checkType && newValue != null)
            {
                Type typeOfCell = _ColumnDescriptors[columnName].ColumnType;
                if (!typeOfCell.IsAssignableFrom(newValue.GetType()))
                {
                    throw new DataCollectionException("Invalid type");
                }              
            }

            row[indexOfColumn] = newValue;
        }

        /// <summary>
        /// Calls <see cref="ModifyCell(object[], string, object)">ModifyCell(object[] string, object, bool)</see> with
        /// checkType set to false.
        /// </summary>
        /// <param name="row">The row in which the value has to be modified.</param>
        /// <param name="columnName">The column for which the value has to be modified.</param>
        /// <param name="newValue">The new value to set.</param>
        public void ModifyCell(object[] row, string columnName, object newValue)
        {
            ModifyCell(row, columnName, newValue, false);
        }

        /// <summary>
        /// Adds a new row to this Table.
        /// </summary>
        /// <param name="row">The row to add to this Table</param>
        public void AddRow(object[] row)
        {
            AddRow(row, false);
        }

        /// <summary>
        /// Adds a new row to this Table.
        /// </summary>
        /// <param name="row">The row to add to this Table</param>
        /// <param name="checkType"></param>
        /// <exception cref="ArgumentNullException">If row is <c>null</c></exception>
        /// <exception cref="DataCollectionException">If the row size is not consistent with the number of columns of this Table,
        /// or  if one one the values in the row has a type not compatible with the corresponding column type.</exception>
        public void AddRow(object[] row, bool checkType)
        {
            if (row == null) throw new ArgumentNullException("row");
            if (checkType)
            {
                _CheckRowConsistency(row);
            }
            _Data.Add(row);
        }

        /// <summary>
        /// Returns the name with which this Table has been instantiated.
        /// </summary>
        public string Name
        {
            get { return _Name; }
        }

        /// <summary>
        /// Returns an enumeration of all the rows inserted in this Table, in insertion order.
        /// </summary>
        public IEnumerable<object[]> Rows
        {
            get
            {
                return _Data.Select(a => a);
            }
        }

        /// <summary>
        /// Returns the value, contained in the row passed as parameter, corresponding to the
        /// column with the name passed as parameter.
        /// </summary>
        /// <param name="row">The row whose values must be assessed.</param>
        /// <param name="columnName">The name of the field whose value must be assessed</param>
        /// <returns>The value, contained in the row passed as parameter, corresponding to the
        /// column with the name passed as parameter</returns>
        /// <exception cref="DataCollectionException">If no column named as the 'columnName' passed as parameter
        /// is present in this Table.</exception>
        public object GetColumnValue(object[] row, string columnName)
        {
            int indexOfColumn = _ColumnNames.IndexOf(columnName);
            if (indexOfColumn < 0)
                throw new DataCollectionException("no column named '" + columnName + "'");
            return row[indexOfColumn];
        }

        /// <summary>
        /// Returns a classic <see cref="DataTable">DataTable</see> representation
        /// of this Table. No verification of primary key nor
        /// relationships is performed (in fact none of these can be enforced in this lightweight version).
        /// Each <c>null</c> value contained in the rows is converted to a <see cref="DBNull.Value">DBNull.Value</see>
        /// </summary>
        public DataTable DataTable
        {
            get
            {
                DataTable dataTable = new DataTable(_Name);
                foreach (string columnName in _ColumnNames)
                {
                    dataTable.Columns.Add(_ColumnDescriptors[columnName].DataColumn);
                }
                foreach (object[] row in _Data)
                {
                    DataRow dataRow = dataTable.Rows.Add(row.Select(el => el == null ? DBNull.Value : el).ToArray());
                }
                return dataTable;
            }
        }

        private void _CheckRowConsistency(object[] row)
        {
            if (row == null)
                throw new DataCollectionException("error: null row");
            if (row.Length != _ColumnDescriptors.Count)
                throw new DataCollectionException("inconsistent row size");
            for (int i = 0; i < row.Length; i++)
            {
                if (row[i] == null) continue;
                Type columnType = _ColumnDescriptors[_ColumnNames[i]].ColumnType;
                if (!columnType.IsAssignableFrom(row[i].GetType()))
                    throw new DataCollectionException("error: inconsistent type for column '" + _ColumnNames[i] + "'");
            }
        }
    }
}