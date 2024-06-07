using System;
using CRA.Clima.ET.Interfaces;
using CRA.ModelLayer.Core;

namespace CRA.Clima.ET.Interfaces
{
    /// <summary>
    /// EvapotranspirationAPI is the application programming interface.
    /// </summary>
    /// <remarks></remarks>
    public class EvapotranspirationAPI
    {
        private string preconditionsResult;
        private string postconditionsResult;

        Preconditions prc = new Preconditions();

        /// <summary>
        /// Overloaded. The estimate method is used to access all models in the component
        /// The overload with 2 Parameters checks for pre- post-conditions
        /// only if an unhandled exception occurs, and the model output is reset to default.
        /// </summary>
        public void Estimate(ETData d, IETDataStrategy s, bool saveLog, string callID)
        {
            preconditionsResult = String.Empty;
            postconditionsResult = String.Empty;
            preconditionsResult = s.TestPreConditions(d, callID);
            s.Estimate(d);
            postconditionsResult = s.TestPostConditions(d, callID);
            if (preconditionsResult != String.Empty || postconditionsResult != String.Empty)
            {
                prc.TestsOut(preconditionsResult + postconditionsResult, saveLog, "ET component, class " + s.ToString());
                s.ResetOutputs(d);
            }
        }
        /// <summary>
        /// Overloaded. The estimate method is used to access all models in the component
        /// The overload with 4 Parameters checks for pre- post-conditions.
        /// If the test of pre or post conditions fails, the model output is reset to default. 
        /// </summary>
        public void Estimate(ETData d, IETDataStrategy s)
        {
            s.Estimate(d);
        }
        /// <summary>
        /// Display form with info on the ET component and two buttons to access
        /// the help file and the code documentation.
        /// </summary>
        public void Info()
        {
            //FormAbout Ab = new FormAbout();
            //Ab.ShowDialog();
        }

    }
}

