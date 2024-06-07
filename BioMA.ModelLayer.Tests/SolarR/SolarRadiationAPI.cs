using System;
//using CRA.Clima.AirT.Interfaces;
using CRA.Clima.SolarR.Interfaces;
using CRA.ModelLayer.Core;

namespace CRA.Clima.SolarR.Interfaces
{
	/// <summary>
	/// SolarRadiation is the access class for the component.
    /// This is a deprecated class destined to be phased out in favor of SolarRadiationAPI 
	/// </summary>
	/// <remarks>agronomy@isci.it, January 2007</remarks>
    public class SolarRadiationAPI
	{
		private	string preconditionsResult;
		private string postconditionsResult;

        Preconditions prc = new Preconditions();
        /// <summary>
		/// The estimate method is used to access all models in the component
		/// The overload with 4 Parameters checks for pre- post-conditions
		/// If the test of pre or post conditions fails, the model output is reset to NaN
		/// </summary>
		/// <param name="d">instance of RadData</param> 
		/// <param name="s">instance of a model class</param> 
		/// <param name="saveLog">used by preconditions: false=on screen, true=on file</param> 
		/// <param name="callID">an identifier from the client of the component</param> 
		public void Estimate(RadData d, IRadDataStrategy s, bool saveLog, string callID)
        {
            preconditionsResult = String.Empty;
            postconditionsResult = String.Empty;
            preconditionsResult = s.TestPreConditions( d, callID);
			s.Estimate(d);
			postconditionsResult = s.TestPostConditions( d, callID);
			if (preconditionsResult != String.Empty || postconditionsResult != String.Empty)
			{
				prc.TestsOut(preconditionsResult + postconditionsResult, saveLog, "SolarRadiation component, class " + s.ToString());
				s.ResetOutputs(d);
			}
		}
		/// <summary>
		/// The estimate method is used to access all models in the component
		/// The overload with 2 Parameters checks for pre-conditions only if a unhandled exception occurs
		/// </summary>
		/// <param name="d">instance of RadData</param>
		/// <param name="s">instance of a model class</param>		
		public void Estimate(RadData d, IRadDataStrategy s)
        
        {
			s.Estimate(d);
		}
		/// <summary>
		/// Display form with info on the SolarR component and two buttons to access
		/// the help file and the code documentation
		/// </summary>
		public void Info()
		{
            //FormAbout Ab = new FormAbout();
            //Ab.ShowDialog();
		}


	}
}




