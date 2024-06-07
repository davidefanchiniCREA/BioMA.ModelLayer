using CRA.Clima.ET.Interfaces;
using CRA.Clima.ET.Strategies;
using CRA.ModelLayer.Core;
using CRA.ModelLayer.Data;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BioMA.ModelLayer.NetFramework.Tests
{
    [TestClass]
    public class Test
    {
        [TestMethod]
        public void ChangeDataCollectionForTable()
        {
            var dataCollection = new DataCollection();

            Table table = GetTable(dataCollection);

            var newDataCollection = new DataCollection();
            newDataCollection.AddTable(table);
            

            Table readTable = newDataCollection.GetTable("table");

            Assert.IsNotNull(readTable);
            CollectionAssert.AreEqual(new List<string>() { "ID1", "Date1", "Double" }, readTable.ColumnNames.ToList());
            var readRows = readTable.Rows.ToList();
            Assert.AreEqual(9, readRows.Count);
        }

        private Table GetTable(DataCollection dataCollection)
        {            
            dataCollection.AddTable("table");
            Table table = dataCollection.GetTable("table");
            table.AddColumn("ID1", typeof(int));
            table.AddColumn("Date1", typeof(DateTime));
            table.AddColumn("Double", typeof(double));

            table.AddRow(new object[] { 1, new DateTime(1970, 6, 4), 1.0 });
            table.AddRow(new object[] { 1, new DateTime(1970, 6, 5), 2.0 });
            table.AddRow(new object[] { 1, new DateTime(1970, 6, 6), 3.0 });
            table.AddRow(new object[] { 2, new DateTime(1970, 6, 4), 4.0 });
            table.AddRow(new object[] { 2, new DateTime(1970, 6, 5), 5.0 });
            table.AddRow(new object[] { 2, new DateTime(1970, 6, 6), 6.0 });
            table.AddRow(new object[] { 3, new DateTime(1970, 6, 4), 7.0 });
            table.AddRow(new object[] { 3, new DateTime(1970, 6, 5), 8.0 });
            table.AddRow(new object[] { 3, new DateTime(1970, 6, 6), 9.0 });

            return table;
        }

        //[Test]
        public void VarInfoInitializationStrings()
        {
            string dllLocation = System.Reflection.Assembly.GetExecutingAssembly().Location;
            string[] lines = File.ReadAllLines(Path.GetDirectoryName(dllLocation) + Path.DirectorySeparatorChar + "Files" + Path.DirectorySeparatorChar + "VarInfo.txt");
            var splitLines = lines.Select(l => l.Split(new char[] { ';' })).ToList();

            var stringsForTypes = new Dictionary<string, List<string>>();

            foreach (var row in splitLines)
            {
                stringsForTypes.Add(row[0], row.ToList());
            }

            string[] variablesLine = File.ReadAllLines(Path.GetDirectoryName(dllLocation) + Path.DirectorySeparatorChar + "Files" + Path.DirectorySeparatorChar + "Variables.txt");
            var splitVariables = variablesLine.Select(l => l.Split(new char[] { ';' })).ToList();

            StringBuilder sbVarInfoValues = new StringBuilder();

            StringBuilder sbInitializations = new StringBuilder();

            foreach (var variableLine in splitVariables)
            {
                try
                {
                    string typeName = stringsForTypes[variableLine[1]][1];
                    string variableName = variableLine[2];
                    sbVarInfoValues.Append(variableName)
                        .Append(".ValueType = VarInfoValueTypes.GetInstanceForName(\"")
                        .Append(typeName)
                        .AppendLine("\");");

                    VarInfoValueTypes varInfoValueTypes = VarInfoValueTypes.GetInstanceForName(stringsForTypes[variableLine[1]][1]);
                    int size = 0;
                    if (varInfoValueTypes.RequiresSizeInTypeDefinition)
                    {
                        size = int.Parse(variableLine[6]);
                    }
                    string initialization = varInfoValueTypes.Converter.GetConstructingString(size);
                    if (initialization == null)
                    {
                        initialization = "default(" + stringsForTypes[variableLine[1]][0] + ")";
                    }
                    sbInitializations.Append(variableName)
                        .Append(" = ")
                        .Append(initialization)
                        .AppendLine(";");
                }
                catch (KeyNotFoundException)
                {
                    continue;
                }
            }
        }
    }
}
