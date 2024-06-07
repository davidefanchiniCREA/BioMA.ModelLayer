#region -- Copyright --
//-----------------------------------------------------------------------------
// Copyright (C) 2006 Informatica Ambientale Srl.
// All rights reserved.
//
// This source code is intended for internal use only as part of the
// "ParameterEditor" Development Project and/or Documentation.
//
// THIS CODE AND INFORMATION IS PROVIDED "AS IS" WITHOUT WARRANTY OF ANY KIND,
// EITHER EXPRESSED OR IMPLIED, INCLUDING, BUT NOT LIMITED TO, THE IMPLIED
// WARRANTIES OF TITLE, MERCHANTABILITY, AGAINST INFRINGEMENT AND/OR FITNESS
// FOR A PARTICULAR PURPOSE.
//-----------------------------------------------------------------------------

//----------------------------------------------------------------
// Author: Marco Botta
// Created: 06/05/2007
//
// Last Modified: 06/05/2007 (Marco Botta)
//----------------------------------------------------------------
#endregion

using System;
using System.IO;
using System.Xml;

namespace CRA.ModelLayer.ParametersManagement
{
    /// <summary>
    /// Xml parameter <see cref="IValuesReader">reader</see>/<see cref="IValuesWriter">writer</see>. The xml is compliant to the MPE xml format (xml schema:'ValuesXmlSchema.xsd', targetNamespace="http://CRA.ParameterEditor.org/ValuesXmlSchema.xsd")
    /// Xml files containing parameters can be edited by the application MPE (Model Parameter Editor), which uses, as definition, the DCC Xml file used to generate the parameters class.
    /// </summary>
    public class XmlRW : AXmlRW
    {
        protected override StreamReader GetSchemaStreamReader()
        {
            string schemaPath = Path.GetDirectoryName(
                    System.Reflection.Assembly.GetExecutingAssembly().Location) +
                Path.DirectorySeparatorChar + SCHEMA_FOLDER +
                Path.DirectorySeparatorChar + "ValuesXmlSchema.xsd";
            if (!File.Exists(schemaPath))
            {
                schemaPath = Path.GetDirectoryName(
                    System.Reflection.Assembly.GetExecutingAssembly().Location) +
                Path.DirectorySeparatorChar + "ValuesXmlSchema.xsd";

                if (!File.Exists(schemaPath))
                {
                    throw new IOException("Could not find ValuesXmlSchema.xsd");
                }
            }
            return new StreamReader(schemaPath);
        }

        protected override StreamReader GetFileFileStreamReader()
        {
            // Check source existence
            if ((FilePath == null) || (!File.Exists(FilePath)))
            {
                throw new InvalidOperationException(
                    "Xml file missing or not specified");
            }
            return new StreamReader(FilePath);
        }

        protected override XmlTextWriter GetXmlTextWriter(IParametersSet e)
        {
            XmlTextWriter xwriter = null;
            if (Directory.Exists(FilePath))
            {
                xwriter = new XmlTextWriter(FilePath + Path.DirectorySeparatorChar +
                    e.Descriptor.Component + "_" + e.Descriptor.Model + ".xml",
                    System.Text.Encoding.UTF8);
            }
            else if (File.Exists(FilePath))
            {
                if (File.Exists(FilePath))
                {
                    xwriter = new XmlTextWriter(FilePath,
                       System.Text.Encoding.UTF8);
                }
            }
            else
            {
                xwriter = new XmlTextWriter(FilePath, System.Text.Encoding.UTF8);
            }
            return xwriter;
        }

        private string filepathVar;

        /// <summary>
        /// Full path of the file to be read or written.
        /// </summary>
        public string FilePath
        {
            get
            {
                return filepathVar;
            }
            set
            {
                filepathVar = value;
            }
        }

        /// <summary>
        ///  Creates a new instance of XmlRW setting also the file path
        /// </summary>
        /// <param name="path">Path of the file to be read or written</param>
        public XmlRW(String path)
        {
            filepathVar = path;
        }

        /// <summary>
        /// Creates a new instance of XmlRW. File path is null and must be set after the constructor call.
        /// </summary>
        public XmlRW()
        {

        }
    }
}