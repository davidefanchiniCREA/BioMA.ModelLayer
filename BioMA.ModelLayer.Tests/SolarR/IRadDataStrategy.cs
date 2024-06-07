using CRA.ModelLayer.Strategy;
using System;
using System.Collections.Generic;


namespace CRA.Clima.SolarR.Interfaces
{
    /// <summary>
    /// IRadDataStrategy is the interface for strategies
    /// using the RadData domain class
    /// </summary>
    /// <remarks>June 2005</remarks>
    public interface IRadDataStrategy : IStrategy
    {
        /// <summary>
        /// Make estimate via the model in the strategy
        /// </summary>
        /// <param name="d">instance of RadData</param>
        void Estimate(RadData d);
        /// <summary>
        /// Test of pre-conditions
        /// </summary>
        /// <param name="d">instance of RadData</param>
        /// <param name="callID">identifier from the client to be saved with each preconditions tests</param>
        /// <returns>a string with pre-conditions violated</returns>
        string TestPreConditions(RadData d, string callID);
        /// <summary>
        /// Test of post-conditions
        /// </summary>
        /// <param name="d">instance of RadData</param>
        /// <param name="callID">identifier from the client to be saved with each preconditions tests</param>
        /// <returns>a string with post-conditions violated</returns>		
        string TestPostConditions(RadData d, string callID); 
        /// <summary>
        /// Reset strategy output to NaN
        /// </summary>
        /// <param name="d">instance of RadData</param>
        void ResetOutputs(RadData d);
        /// <summary>
        /// Assign VarInfo.defaultValue to each Parameter
        /// </summary>
        void SetParametersDefaultValue();
        /// <summary>
        /// Array of timesteps allowed for the class (often one)
        /// </summary>
    }
}