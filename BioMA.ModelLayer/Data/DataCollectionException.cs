using System;
using System.Runtime.Serialization;

namespace CRA.ModelLayer.Data
{
    /// <summary>
    /// The general error in <see cref="DataCollection">DataCollection</see>.
    /// </summary>
    [Serializable]
    public class DataCollectionException : ApplicationException
    {
        /// <summary>
        /// See <see cref="ApplicationException()">ApplicationException.ApplicationException()</see>
        /// </summary>
        public DataCollectionException() { }

        /// <summary>
        /// See <see cref="ApplicationException(string)">ApplicationException.ApplicationException(string)</see>
        /// </summary>
        public DataCollectionException(string message) :
            base(message) { }

        /// <summary>
        /// See <see cref="ApplicationException(string, Exception)">ApplicationException.ApplicationException(string, Exception)</see>
        /// </summary>
        public DataCollectionException(string message, Exception inner) :
            base(message, inner) { }
    }
}