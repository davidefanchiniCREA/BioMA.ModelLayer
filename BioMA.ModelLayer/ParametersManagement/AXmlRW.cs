using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Xml.Schema;
using System.Xml;
using CRA.ModelLayer.Core;

namespace CRA.ModelLayer.ParametersManagement
{
    /// <summary>
    /// Xml parameter <see cref="IValuesReader">reader</see>/<see cref="IValuesWriter">writer</see>. The xml is compliant to the MPE xml format (xml schema:'ValuesXmlSchema.xsd', targetNamespace="http://CRA.ParameterEditor.org/ValuesXmlSchema.xsd")
    /// Xml files containing parameters can be edited by the application MPE (Model Parameter Editor), which uses, as definition, the DCC Xml file used to generate the parameters class.
	/// </summary>
	public abstract class AXmlRW :
        IValuesReader, IValuesWriter
    {
        protected abstract StreamReader GetSchemaStreamReader();

        protected abstract StreamReader GetFileFileStreamReader();

        protected abstract XmlTextWriter GetXmlTextWriter(IParametersSet e);

        #region IValuesReader Members

        /// <summary>
        /// Reads the values of parameter set from the xml file.
        /// </summary>
        /// <returns>parameters set</returns>
        /// <exception cref="InvalidOperationException">Xml path has not been
        /// defined.</exception>
        /// <exception cref="InvalidDataException">The data have not the correct
        /// format.</exception>
        /// <exception cref="IOException">An I/O error is occured.</exception>
        //public IParametersSet ReadValues()
        protected override IParametersSet InternalReadValues()
        {
            // Read the stream

            IParametersSet ps;
            ISetDescriptor sd;
            string descriptorComponent = null;
            string descriptorModel = null;
            string descriptorKeyType = null;
            string descriptorURL = null;
            string descriptorDescription = null;
            List<VarInfo> tmpViList = new List<VarInfo>();
            Dictionary<IKeyValue, Dictionary<VarInfo, List<string>>> temporaryValues = new Dictionary<IKeyValue, Dictionary<VarInfo, List<string>>>();

            // Create the parser
            // -----------------

            // Create the XmlSchemaSet class
            XmlSchemaSet sc = new XmlSchemaSet();

            sc.Add("http://CRA.ParameterEditor.org/ValuesXmlSchema.xsd", XmlReader.Create(GetSchemaStreamReader()));

            // Set the validation settings
            XmlReaderSettings settings = new XmlReaderSettings();
            settings.ValidationType = ValidationType.Schema;
            settings.Schemas = sc;

            // Create the XmlReader and XmlDocument objects
            XmlReader reader = XmlReader.Create(GetFileFileStreamReader(), settings);
            XmlDocument doc = new XmlDocument();

            try
            {
                // Map
                // Parameter name - parameter
                Dictionary<string, VarInfo> nameParameterMap =
                    new Dictionary<string, VarInfo>();


                // Read the template
                doc.Load(reader);

                // Fill data structure
                foreach (XmlNode elem in doc.DocumentElement.ChildNodes)
                {
                    if (elem.NodeType != XmlNodeType.Element)
                    {
                        continue;
                    }

                    switch (elem.Name)
                    {
                        // Description element
                        case E_DESCRIPTION:
                            {
                                foreach (XmlNode descChild in elem.ChildNodes)
                                {
                                    if (descChild.NodeType != XmlNodeType.Element)
                                    {
                                        continue;
                                    }

                                    switch (descChild.Name)
                                    {
                                        case E_DESC_E_NAMESPACE:
                                            descriptorComponent = descChild.InnerText;
                                            break;
                                        case E_DESC_E_TYPENAME:
                                            descriptorModel = descChild.InnerText;
                                            break;
                                        case E_DESC_E_PARAMETER_KEY:
                                            descriptorKeyType = descChild.InnerText;
                                            break;
                                        case E_DESC_E_URL:
                                            descriptorURL = descChild.InnerText;
                                            break;
                                        case E_DESC_E_DESCRIPTION:
                                            descriptorDescription = descChild.InnerText;
                                            break;
                                    }
                                }
                            }
                            break;

                        // Definitions element
                        case E_VARINFO_ATTRIBUTES:
                            {
                                // Temporary variables
                                VarInfo tmpVi = null;
                                int index = 0;

                                foreach (XmlNode viAttChild in elem.ChildNodes)
                                {
                                    if (viAttChild.NodeType != XmlNodeType.Element)
                                    {
                                        continue;
                                    }

                                    switch (viAttChild.Name)
                                    {
                                        case E_VIATT_E_VARINFO:
                                            {
                                                tmpVi = new VarInfo();
                                                tmpVi.Id = index++;
                                                tmpVi.Name = viAttChild.Attributes[
                                                    E_VIATT_E_VARINFO_A_NAME].Value;

                                                foreach (XmlNode vInfoChild in viAttChild.ChildNodes)
                                                {
                                                    if (vInfoChild.NodeType != XmlNodeType.Element)
                                                    {
                                                        continue;
                                                    }

                                                    switch (vInfoChild.Name)
                                                    {
                                                        case E_VIATT_E_DESCRIPTION:
                                                            tmpVi.Description = vInfoChild.InnerText;
                                                            break;
                                                        case E_VIATT_E_MAXVALUE:
                                                            tmpVi.MaxValue = double.Parse(vInfoChild.InnerText,
                                                                NumberFormatInfo.InvariantInfo);
                                                            break;
                                                        case E_VIATT_E_MINVALUE:
                                                            tmpVi.MinValue = double.Parse(vInfoChild.InnerText,
                                                                NumberFormatInfo.InvariantInfo);
                                                            break;
                                                        case E_VIATT_E_DEFAULTVALUE:
                                                            tmpVi.DefaultValue = double.Parse(vInfoChild.InnerText,
                                                                NumberFormatInfo.InvariantInfo);
                                                            break;
                                                        case E_VIATT_E_TYPE:
                                                            VarInfo.ParseValueType(vInfoChild.InnerText, tmpVi);
                                                            break;
                                                        case E_VIATT_E_UNITS:
                                                            tmpVi.Units = vInfoChild.InnerText;
                                                            break;
                                                        case E_VIATT_E_URL:
                                                            tmpVi.URL = vInfoChild.InnerText;
                                                            break;
                                                    }
                                                }

                                                tmpViList.Add(tmpVi);
                                                nameParameterMap.Add(tmpVi.Name, tmpVi);
                                            }
                                            break;
                                    }
                                }
                            }
                            break;

                        // Values element
                        case E_VALUES:
                            {
                                // Temporary variables
                                Dictionary<VarInfo, List<string>> tmpVals = null;
                                IKeyValue tmpKv = null;
                                VarInfo tmpParam = null;
                                List<string> tmpValuesList = null;
                                int index = 0;

                                foreach (XmlNode valsChild in elem.ChildNodes)
                                {
                                    if (valsChild.NodeType != XmlNodeType.Element)
                                    {
                                        continue;
                                    }

                                    switch (valsChild.Name)
                                    {
                                        case E_VALS_E_KEYVALUE:
                                            {
                                                if (tmpKv != null)
                                                {
                                                    tmpKv = DataTypeFactory.NewKeyValue(index++, valsChild.Attributes[E_VALS_E_KEYVALUE_A_NAME].Value, tmpKv.Description);
                                                }
                                                else
                                                {
                                                    tmpKv = DataTypeFactory.NewKeyValue(index++, valsChild.Attributes[E_VALS_E_KEYVALUE_A_NAME].Value, null);
                                                }

                                                tmpVals = new Dictionary<VarInfo, List<string>>();

                                                foreach (XmlNode keyChild in valsChild.ChildNodes)
                                                {
                                                    if (keyChild.NodeType != XmlNodeType.Element)
                                                    {
                                                        continue;
                                                    }

                                                    switch (keyChild.Name)
                                                    {
                                                        case E_VALS_E_KV_E_DESCRIPTION:
                                                            if (tmpKv != null)
                                                            {
                                                                tmpKv = DataTypeFactory.NewKeyValue(tmpKv.Id, tmpKv.Name, keyChild.InnerText);
                                                            }
                                                            else
                                                            {
                                                                tmpKv = DataTypeFactory.NewKeyValue(0, null, keyChild.InnerText);
                                                            }
                                                            break;
                                                        case E_VALS_E_KV_E_PARAMETER:
                                                            {
                                                                tmpValuesList = new List<string>();
                                                                try
                                                                {
                                                                    tmpParam = nameParameterMap[keyChild.Attributes[E_VALS_E_KV_E_PARAM_A_NAME].Value];
                                                                }
                                                                catch (Exception)
                                                                {
                                                                    throw new Exception("Parameter not found:'" + keyChild.Attributes[E_VALS_E_KV_E_PARAM_A_NAME].Value + "'");
                                                                }
                                                                foreach (XmlNode paramChild in keyChild.ChildNodes)
                                                                {
                                                                    if (paramChild.NodeType != XmlNodeType.Element)
                                                                    {
                                                                        continue;
                                                                    }

                                                                    switch (paramChild.Name)
                                                                    {
                                                                        case E_VALS_E_KV_E_VALUE:
                                                                            {
                                                                                string s = paramChild.InnerText;
                                                                                if (paramChild.Attributes.GetNamedItem(E_VALS_E_KV_E_KEY) != null)
                                                                                {
                                                                                    //  s = s + EditorEngine.E_VALS_E_KV_E_KEY_SEPARATOR + paramChild.Attributes.GetNamedItem(E_VALS_E_KV_E_KEY).Value;
                                                                                    s =
                                                                                        VarInfoValueTypes.
                                                                                            ConcatenateKeyAndValue(
                                                                                            paramChild.Attributes.
                                                                                                GetNamedItem(
                                                                                                E_VALS_E_KV_E_KEY).Value,
                                                                                            s);
                                                                                }
                                                                                tmpValuesList.Add(s);
                                                                                break;
                                                                            }
                                                                    }
                                                                }

                                                                tmpVals.Add(tmpParam, tmpValuesList);
                                                            }
                                                            break;
                                                    }
                                                }
                                                temporaryValues.Add(tmpKv, tmpVals);
                                            }
                                            break;
                                    }
                                }
                            }
                            break;
                    }
                }


                sd = DataTypeFactory.NewSetDescriptor(descriptorComponent, descriptorModel, descriptorKeyType, descriptorURL, descriptorDescription);
                ps = DataTypeFactory.NewParametersSet(sd, tmpViList.ToArray(), temporaryValues);

                return ps;
            }
            catch (Exception ex)
            {
                throw new InvalidDataException(ex.Message, ex);
            }
            finally
            {
                if (reader != null)
                {
                    reader.Close();
                }
            }



        }

        #endregion

        #region IValuesWriter Members

        /// <summary>
        /// Writes the parameters values to the xml file.
        /// </summary>
        /// <param name="e">set to write</param>
        /// <exception cref="ArgumentNullException">The argument is null.</exception>
        /// <exception cref="InvalidOperationException">Data path has not been
        /// defined.</exception>
        /// <exception cref="IOException">An I/O error is occured.</exception>
        public void WriteValues(IParametersSet e)
        {
            // Check arguments
            if (e == null)
            {
                throw new ArgumentNullException();
            }

            WriteValues(e, (new List<IKeyValue>(e.Values.Keys)).ToArray());
        }

        /// <summary>
        /// Writes the parameters values only for specified key values to the xml file.
        /// </summary>
        /// <param name="e">set to write</param>
        /// <param name="keyValues">key values to write</param>
        /// <exception cref="ArgumentNullException">The argument is null.
        /// </exception>
        /// <exception cref="InvalidOperationException">Data path has not been
        /// defined.</exception>
        /// <exception cref="IOException">An I/O error is occured.</exception>
        public void WriteValues(IParametersSet e, IKeyValue[] keyValues)
        {
            // Check arguments
            if ((e == null) || (keyValues == null))
            {
                throw new ArgumentNullException();
            }

            // If there is no key value to write, return
            if (keyValues.Length == 0)
            {
                return;
            }

            XmlTextWriter xwriter = null;

            try
            {
                // Write Xml document
                xwriter = GetXmlTextWriter(e);

                xwriter.Formatting = Formatting.Indented;
                xwriter.WriteStartDocument(true);

                // Write start element
                xwriter.WriteStartElement(DOCUMENT_NAME);

                // Write the description
                xwriter.WriteStartElement(E_DESCRIPTION);

                xwriter.WriteElementString(E_DESC_E_NAMESPACE, e.Descriptor.Component);
                xwriter.WriteElementString(E_DESC_E_TYPENAME, e.Descriptor.Model);
                xwriter.WriteElementString(E_DESC_E_URL, e.Descriptor.URL);
                xwriter.WriteElementString(E_DESC_E_PARAMETER_KEY, e.Descriptor.KeyType);
                xwriter.WriteElementString(E_DESC_E_DESCRIPTION, e.Descriptor.Description);

                xwriter.WriteEndElement();


                // Write parameters
                xwriter.WriteStartElement(E_VARINFO_ATTRIBUTES);

                foreach (VarInfo vInfo in e.Parameters)
                {
                    xwriter.WriteStartElement(E_VIATT_E_VARINFO);

                    xwriter.WriteAttributeString(E_VIATT_E_VARINFO_A_NAME, vInfo.Name);
                    xwriter.WriteElementString(E_VIATT_E_DESCRIPTION, vInfo.Description);
                    xwriter.WriteElementString(E_VIATT_E_MAXVALUE,
                        vInfo.MaxValue.ToString(NumberFormatInfo.InvariantInfo));
                    xwriter.WriteElementString(E_VIATT_E_MINVALUE,
                        vInfo.MinValue.ToString(NumberFormatInfo.InvariantInfo));
                    xwriter.WriteElementString(E_VIATT_E_DEFAULTVALUE,
                        vInfo.DefaultValue.ToString(NumberFormatInfo.InvariantInfo));

                    xwriter.WriteElementString(E_VIATT_E_TYPE, vInfo.ValueType.Converter.GetTypeNameRepresentation(vInfo.Size));

                    xwriter.WriteElementString(E_VIATT_E_UNITS, vInfo.Units);
                    xwriter.WriteElementString(E_VIATT_E_URL, vInfo.URL);

                    xwriter.WriteEndElement();
                }

                xwriter.WriteEndElement();


                // Write values
                xwriter.WriteStartElement(E_VALUES);

                foreach (IKeyValue kv in keyValues)
                {
                    xwriter.WriteStartElement(E_VALS_E_KEYVALUE);
                    xwriter.WriteAttributeString(E_VALS_E_KEYVALUE_A_NAME, kv.Name);

                    xwriter.WriteElementString(E_VALS_E_KV_E_DESCRIPTION, kv.Description);

                    foreach (VarInfo param in e.Values[kv].Keys)
                    {
                        IVarInfoConverter converter = param.ValueType.Converter;
                        xwriter.WriteRaw(converter.ParseValue(converter.GetParsedValueFromMPE(e.Values[kv][param]), param.Name).ToString());
                    }

                    xwriter.WriteEndElement();
                }

                xwriter.WriteEndElement();


                xwriter.WriteEndElement();
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException(ex.Message, ex);
            }
            finally
            {
                // Closes writer
                xwriter.Close();
            }
        }

        #endregion

        #region - Xml constants -

        private const string DOCUMENT_NAME = "ParametersValues";

        private const string E_DESCRIPTION = "Description";
        private const string E_DESC_E_NAMESPACE = "NameSpace";
        private const string E_DESC_E_TYPENAME = "TypeName";
        private const string E_DESC_E_URL = "URL";
        private const string E_DESC_E_DESCRIPTION = "Description";
        private const string E_DESC_E_PARAMETER_KEY = "ParameterKey";

        private const string E_VARINFO_ATTRIBUTES = "VarInfoAttributes";
        private const string E_VIATT_E_VARINFO = "VarInfo";
        private const string E_VIATT_E_VARINFO_A_NAME = "name";
        private const string E_VIATT_E_DESCRIPTION = "Description";
        private const string E_VIATT_E_MAXVALUE = "MaxValue";
        private const string E_VIATT_E_MINVALUE = "MinValue";
        private const string E_VIATT_E_DEFAULTVALUE = "DeafaultValue";
        private const string E_VIATT_E_TYPE = "Type";
        private const string E_VIATT_E_UNITS = "Units";
        private const string E_VIATT_E_URL = "URL";

        private const string E_VALUES = "Values";
        private const string E_VALS_E_KEYVALUE = "KeyValue";
        private const string E_VALS_E_KEYVALUE_A_NAME = "name";
        private const string E_VALS_E_KV_E_DESCRIPTION = "Description";
        private const string E_VALS_E_KV_E_PARAMETER = "Parameter";
        private const string E_VALS_E_KV_E_PARAM_A_NAME = "name";
        private const string E_VALS_E_KV_E_VALUE = "Value";
        private const string E_VALS_E_KV_E_KEY = "Key";



        protected const string SCHEMA_FOLDER = "xmlSchema";

        #endregion
    }
}