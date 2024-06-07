using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data;

/*! 
    \namespace EC.JRC.MARS.ModelLayer.Data Data management of the Bioma Model Layer
 * 
 * The EC.JRC.MARS.ModelLayer.Data namespace contains the classes of the Bioma Model Layer for managing the model output in terms of output tables. 
    
*/


namespace CRA.ModelLayer.Data
{
    /// <summary>
    /// Lightweight version of the <see cref="DataSet">DataSet</see>.
    /// </summary>
    /// <remarks>
    /// Like in the version of the Microsoft framework, it is possible to add Tables counterparts, but no verification of primary key nor
    /// relationships is performed (in fact none of these can be enforced in this lightweight version). This in order to keep overhead
    /// in using this class to a minimum.
    /// A <see cref="DataSet">DataSet</see> version of a DataCollection can be built by invoking the property
    /// <see cref="DataCollection.DataSet">DataCollection.DataSet</see>, but again on the obtained object
    /// no primary key nor relationship constraint is enforced.
    /// </remarks>
    public class DataCollection
    {
        /* DFa - allow for adding a column with non-empty table (as per DFu request) 25/07/2011 - begin */
        /* old - begin */
        //private Dictionary<string, Table> _Tables = new Dictionary<string, Table>();
        /* old - end */
        internal Dictionary<string, Table> _Tables = new Dictionary<string, Table>();
        /* DFa - allow for adding a column with non-empty table (as per DFu request) 25/07/2011 - end */

        public void AddTable(Table table)
        {

            if (_Tables.ContainsKey(table.Name))
                throw new DataCollectionException("RunValue already contains table '" + table.Name + "'");
            _Tables.Add(table.Name, table);
            table._ContainingRunValue = this;
        }

        /// <summary>
        /// Adds a new empty <see cref="Table">Table</see> with the name passed as parameter.
        /// </summary>
        /// <param name="name">The name of the <see cref="Table">Table</see> to add. </param>
        public void AddTable(string name)
        {
            AddTable(new Table(name, this));
        }

        /// <summary>
        /// Returns an enumeration of the <see cref="Table">Table</see>s in this DataCollection.
        /// </summary>
        public IEnumerable<Table> Tables
        {
            get
            {
                foreach (var item in _Tables)
                {
                    yield return item.Value;
                }
            }
        }

        /// <summary>
        /// Returns the <see cref="Table">Table</see> in this DataCollection having the name passed as parameter.
        /// </summary>
        /// <param name="name">The name of the <see cref="Table">Table</see> to retrieve.</param>
        /// <returns>The <see cref="Table">Table</see> with the name passed as parameter.</returns>
        public Table GetTable(string name)
        {
            return _Tables[name];
        }

        /// <summary>
        /// Builds and returns a <see cref="DataSet">DataSet</see> representation of this DataCollection.
        /// </summary>
        public DataSet DataSet
        {
            get
            {
                DataSet dataSet = new DataSet();
                foreach (var tab in _Tables)
                {
                    DataTable dataTable = tab.Value.DataTable;
                    dataSet.Tables.Add(dataTable);
                }
                return dataSet;
            }
        }
       
    }

    /// <summary>
    /// Adds an extension method to the <see cref="DataSet">DataSet</see> class to transform the DataSet into a <see cref="DataCollection">DataCollection</see> object. 
    /// </summary>
    public static class DataSetToDataCollectionExthensionMethod
    {
        /// <summary>
        /// Transforms the <see cref="DataSet">DataSet</see> object into a <see cref="DataCollection">DataCollection</see> object. 
        /// Each <see cref="DataTable">DataTable</see> of the DataSet is copied to a <see cref="Table">Table</see> of the DataCollection. 
        /// Data are copied as well. 
        /// </summary>
        /// <param name="ds">The DataSet to transform</param>
        /// <returns>The DataCollection as result of the transformation from the DataSet</returns>
        public static DataCollection ToDataCollection(this DataSet ds)
        {
            DataCollection dc = new DataCollection();
            foreach (DataTable table in ds.Tables)
            {
                dc.AddTable(table.TableName);

                foreach (DataColumn column in table.Columns)
                {
                    dc.GetTable(table.TableName).AddColumn(column.ColumnName, column.DataType);
                }
                foreach (DataRow row in table.Rows)
                {
                    if (row.RowState != DataRowState.Deleted)
                        dc.GetTable(table.TableName).AddRow(row.ItemArray);
                }
            }
            return dc;
        }

    }
}