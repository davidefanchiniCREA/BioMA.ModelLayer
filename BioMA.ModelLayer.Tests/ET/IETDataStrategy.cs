using CRA.ModelLayer.Strategy;
using System;
using System.Collections.Generic;

namespace CRA.Clima.ET.Interfaces
{
	/// <summary>
	/// IETDataStrategy is the interface for strategies
	/// using the ETData domain class
	/// </summary>
	/// <remarks>June 2005</remarks>
	public interface IETDataStrategy : IStrategy
	{
		/// <summary>
		/// Make estimate via the model in the strategy
		/// </summary>
		/// <param name="d">instance of ETData</param>
		void Estimate(ETData d);

		/// <summary>
		/// Test of pre-conditions
		/// </summary>
		/// <param name="d">instance of ETData</param>
		/// <param name="callID">identifier from the client to be saved with each preconditions tests</param>
		/// <returns>string with pre-conditions violated</returns>
		string TestPreConditions(ETData d, string callID);

		/// <summary>
		/// Test of post-conditions
		/// </summary>
		/// <param name="d">instance of ETData</param>
		/// <param name="callID">identifier from the client to be saved with each preconditions tests</param>
		/// <returns>string with post-conditions violated</returns>		
		string TestPostConditions(ETData d, string callID); 

		/// <summary>
		/// Reset strategy output to NaN
		/// </summary>
		/// <param name="d">instance of ETData</param>		
		void ResetOutputs(ETData d);

        /// <summary>
        /// Assign VarInfo.DefaultValue to each Parameter
        /// </summary>
        void SetParametersDefaultValue();
	}
}
