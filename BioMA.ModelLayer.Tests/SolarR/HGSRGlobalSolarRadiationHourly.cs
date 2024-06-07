using System;
using System.Collections.Generic;
using System.Linq;
using CRA.Clima.SolarR;
using CRA.Clima.SolarR.Interfaces;
using CRA.ModelLayer.Core;
using CRA.ModelLayer.MetadataTypes;
using CRA.ModelLayer.Strategy;

namespace CRA.Clima.SolarR.Strategies
{
	/// <summary>
	/// Strategy to calculate hourly global radiation.
	/// agronomy@isci.it, June 2005.
	/// </summary>
	/// <remarks>Chen, J.M., Liu, J., Cihlar, J., and M.L. Goulden. 1999.
	/// Daily canopy photosynthesis model through temporal and spatial scaling
	/// for remote sensing applications. Ecol. Model., 124:99-119.</remarks>
	public class HGSRGlobalSolarRadiationHourly: IRadDataStrategy
    {
        public string TestPreconditionsOnParameters(string callID)
        {
            return "";
        }

        private ITestsOutput _preconditionsWriter;

		public ITestsOutput PreconditionsWriter
        {
			get
            {
				return _preconditionsWriter;
            }

			set
            {
				_preconditionsWriter = value;
				foreach (IStrategy strategy in this.GetAssociatedStrategies())
                {
					strategy.PreconditionsWriter = _preconditionsWriter;
                }
            }
        }

        #region Constructors
	/// <summary>
        /// Constructor
        /// </summary>
        public HGSRGlobalSolarRadiationHourly()
        {
            //60 for hourly, 1440 for daily; multiple Add statements for strategies with multiple time steps
            _MinutesTimeSteps.Add(60);
            ModellingOptions mo0_0 = new ModellingOptions();

            //Parameters
            List<VarInfo> _parameters0_0 = new List<VarInfo>();
            mo0_0.Parameters = _parameters0_0;

            //Inputs
            List<PropertyDescription> _inputs0_0 = new List<PropertyDescription>();
            PropertyDescription pd1 = new PropertyDescription();
            pd1.DomainClassType = typeof(RadData);
            pd1.PropertyName = "ExtraterrestrialRadiationHourly";
            pd1.PropertyType = ((RadDataVarInfo.ExtraterrestrialRadiationHourly)).ValueType.TypeForCurrentValue;
            pd1.PropertyVarInfo = (RadDataVarInfo.ExtraterrestrialRadiationHourly);
            _inputs0_0.Add(pd1);

            PropertyDescription pd2 = new PropertyDescription();
            pd2.DomainClassType = typeof(RadData);
            pd2.PropertyName = "GlobalSolarRadiation";
            pd2.PropertyType = ((RadDataVarInfo.GlobalSolarRadiation)).ValueType.TypeForCurrentValue;
            pd2.PropertyVarInfo = (RadDataVarInfo.GlobalSolarRadiation);
            _inputs0_0.Add(pd2);


            mo0_0.Inputs = _inputs0_0;

            //Outputs
            List<PropertyDescription> _outputs0_0 = new List<PropertyDescription>();
            PropertyDescription pd11 = new PropertyDescription();
            pd11.DomainClassType = typeof(RadData);
            pd11.PropertyName = "GlobalSolarRadiationHourly";
            pd11.PropertyType = ((RadDataVarInfo.GlobalSolarRadiationHourly)).ValueType.TypeForCurrentValue;
            pd11.PropertyVarInfo = (RadDataVarInfo.GlobalSolarRadiationHourly);
            _outputs0_0.Add(pd11);

            mo0_0.Outputs = _outputs0_0;

            //Associated strategies
            List<string> lAssStrat0_0 = new List<string>();
            mo0_0.AssociatedStrategies = lAssStrat0_0;

            //Adding the modeling options to the modeling options manager
            _modellingOptionsManager = new ModellingOptionsManager(mo0_0);

            //SetStaticParametersVarInfoDefinitions();
            SetPublisherData();

        }

        #endregion

        #region Fields

        private readonly string _strategyName = "HGSRGlobalSolarRadiationHourly";

        private readonly List<int> _MinutesTimeSteps = new List<int>();

        private readonly bool _IsContext = false;

        #endregion

        #region Lists: Inputs, Outputs, Parameters, Associated Strategies
        private static readonly List<string> _Inputs = new List<string>();
        /// <summary>List of inputs within RadData</summary>
        public static List<string> Inputs
        {
            get { return _Inputs; }
        }
        private static readonly List<string> _Outputs = new List<string>();
        /// <summary>List of outputs within RadData</summary>
        public static List<string> Outputs
        {
            get { return _Outputs; }
        }
        private static readonly List<string> _Parameters = new List<string>();
        /// <summary>List of Parameters (static properties of this class)</summary>
        public static List<string> Parameters
        {
            get { return _Parameters; }
        }
        private static readonly List<string> _AssociatedStrategies = new List<string>();
        /// <summary>List of associated stategies</summary>
        public static List<string> AssociatedStrategies
        {
            get { return _AssociatedStrategies; }
        }

        #endregion

        #region IRadDataStrategy Members
        /// <summary>
        /// The estimate method is used to access all models in the component.
        /// The overload with 2 Parameters checks for pre-conditions only if an unhandled exception occurs.
        /// </summary>
        /// <param Name="d">instance of RadData</param>
        public void Estimate(RadData d)
        {
            try
            {
                ModelEstimate(d);
                d.StrategyUsed.Add(_strategyName);
                TraceStrategies.TraceEvent(System.Diagnostics.TraceEventType.Verbose, 1001,
                                     "Strategy: " + _strategyName + " - Run successful");
            }
            catch (Exception e)
            {
                TraceStrategies.TraceEvent(System.Diagnostics.TraceEventType.Error, 1002,
                                     "Strategy: " + _strategyName + " - Unhandled exception due to violated pre-conditions");
                string msg = "Component SolarRadiation, " + _strategyName + ": Pre-conditions violated. ";
                msg = msg + TestPreConditions(d, "");
                throw new Exception(msg, e);
            }
        }
        /// <summary>
        /// Reset strategy output to NaN
        /// </summary>
        /// <param Name="d">instance of RadData</param>
        public void ResetOutputs(RadData d)
        {
            try
            {
                ResetOut(d);
                TraceStrategies.TraceEvent(System.Diagnostics.TraceEventType.Verbose, 1003,
                                     "Strategy: " + _strategyName + " - Output reset to NaN (Not a Number)");
            }
            catch (Exception e)
            {
                TraceStrategies.TraceEvent(System.Diagnostics.TraceEventType.Error, 1004,
                                     "Strategy: " + _strategyName + " - Unhandled exception running output reset");
                string msg = "Component SolarRadiation, " + _strategyName + ": Unhandled exception running outputs reset. ";
                throw new Exception(msg, e);
            }
        }

        /// <summary>
        /// This method allows testing post-conditions.
        /// </summary>
        /// <param Name="d">instance of RadData</param>
        /// <param Name="callID">identification of method call from client</param>
        /// <returns>a string with post-condition tests failed</returns>
        public string TestPostConditions(RadData d, string callID)
        {
            try
            {
                string _result = PostConditions(d, callID);
                TraceStrategies.TraceEvent(System.Diagnostics.TraceEventType.Verbose, 1005,
                                     "Strategy: " + _strategyName + " - Post-conditions tests done, ID: " + callID);
                return _result;
            }
            catch (Exception e)
            {
                TraceStrategies.TraceEvent(System.Diagnostics.TraceEventType.Error, 1006,
                                     "Strategy: " + _strategyName + " - Unhandled exception running post-conditions tests");
                string msg = "Component SolarRadiation, " + _strategyName + ": Unhandled exception running post-condition test. ";
                throw new Exception(msg, e);
            }
        }
        /// <summary>
        /// This method allows testing pre-conditions.
        /// </summary>
        /// <param Name="d">instance of RadData</param>
        /// <param Name="callID">identification of method call from client</param>
        /// <returns>a string with pre-condition tests failed</returns>
        public string TestPreConditions(RadData d, string callID)
        {
            try
            {
                string _result = PreConditions(d, callID);
                TraceStrategies.TraceEvent(System.Diagnostics.TraceEventType.Verbose, 1007,
                                     "Strategy: " + _strategyName + " - Pre-conditions tests done, ID: " + callID);
                return _result;
            }
            //catch (PreconditionErrorException)
            //{
            //    throw;
            //}
            catch (Exception e)
            {
                TraceStrategies.TraceEvent(System.Diagnostics.TraceEventType.Error, 1008,
                                     "Strategy: " + _strategyName + " - Unhandled exception running pre-conditions tests");
                string msg = "Component SolarRadiation, " + _strategyName + ": Unhandled exception running pre-condition test. ";
                throw new Exception(msg, e);
            }
        }
		/// <summary>
		/// Assign VarInfo.DefaultValue to each parameter
		/// </summary>
		public void SetParametersDefaults()
		{
		}
        /// <summary>
        /// Time step of the models (if any)
        /// </summary>
        public List<int> MinutesTimeSteps
        {
            get { return _MinutesTimeSteps; }
        }

        /// <summary>
        /// Context strategy info
        /// </summary>
        public bool IsContext
        {
            get { return _IsContext; }
        }

		#endregion

		#region Model
		private void ModelEstimate(RadData rd)
		{
			double[] Distribution = new double[24];
			int h;
			double sumExtraterrestrialRadiationHourly = 0;

			for (h=0;h<24;h++)
			{
				sumExtraterrestrialRadiationHourly += rd.ExtraterrestrialRadiationHourly[h];
			}
			
			for (h=0;h<24;h++)
			{
				Distribution[h] = rd.ExtraterrestrialRadiationHourly[h]
					/ sumExtraterrestrialRadiationHourly;
				rd.GlobalSolarRadiationHourly[h] = Distribution[h] * rd.GlobalSolarRadiation;
			}
		}
		#endregion

		#region Pre- post- conditions
		private string PreConditions( RadData rd, string callID)
		{
			SetParametersInputsCurrentValue( rd);
            //CRA.Core.Preconditions.PreconditionsData prc = new CRA.Core.Preconditions.PreconditionsData();
            //CRA.Core.Preconditions.Preconditions pre = new CRA.Core.Preconditions.Preconditions();
            ConditionsCollection prc = new ConditionsCollection();
            Preconditions preconditions = new Preconditions();

            //add range based (current value must be in the range minValue-maxValue)
            //prc.RangeBased.Add(RadDataVarInfo.ExtraterrestrialRadiationHourly);
            //prc.RangeBased.Add(RadDataVarInfo.ExtraterrestrialRadiation);
            //prc.RangeBased.Add(RadDataVarInfo.GlobalSolarRadiation);

            AtLeastOneDifferentFromZeroCondition a = new AtLeastOneDifferentFromZeroCondition(RadDataVarInfo.ExtraterrestrialRadiationHourly);
            //RadDataVarInfo.ExtraterrestrialRadiationHourly.CurrentValue = rd.ExtraterrestrialRadiationHourly;
            if (a.ApplicableVarInfoValueTypes.Contains(RadDataVarInfo.ExtraterrestrialRadiationHourly.ValueType)) { prc.AddCondition(a); }

            RangeBasedCondition r = new RangeBasedCondition(RadDataVarInfo.ExtraterrestrialRadiationHourly);
            if (r.ApplicableVarInfoValueTypes.Contains(RadDataVarInfo.ExtraterrestrialRadiationHourly.ValueType)) { prc.AddCondition(r); }
             r = new RangeBasedCondition(RadDataVarInfo.GlobalSolarRadiation);
            if (r.ApplicableVarInfoValueTypes.Contains(RadDataVarInfo.GlobalSolarRadiation.ValueType)) { prc.AddCondition(r); }

            //add at least one value different from 0 (vectors or bi-dimensional matrices)
            //prc.AtLeastOne.Add(RadDataVarInfo.ExtraterrestrialRadiationHourly);

            //get the evaluation of preconditions
            //return pre.VerifyPreconditions( prc, callID);
            return preconditions.VerifyPreconditions(prc, callID);
        }
		private string PostConditions( RadData rd, string callID)
		{
			SetOutputsCurrentValue( rd);
            //CRA.Core.Preconditions.PreconditionsData prc = new CRA.Core.Preconditions.PreconditionsData();
            //CRA.Core.Preconditions.Preconditions pre = new CRA.Core.Preconditions.Preconditions();
            ConditionsCollection prc = new ConditionsCollection();
            Preconditions preconditions = new Preconditions();

            //add range based (current value must be in the range minValue-maxValue)
            //prc.RangeBased.Add(RadDataVarInfo.GlobalSolarRadiationHourly);

            RangeBasedCondition r = new RangeBasedCondition(RadDataVarInfo.GlobalSolarRadiationHourly);
            if (r.ApplicableVarInfoValueTypes.Contains(RadDataVarInfo.GlobalSolarRadiationHourly.ValueType)) { prc.AddCondition(r); }

            //get the evaluation of postconditions
            //return pre.VerifyPostconditions( prc, callID);
            return preconditions.VerifyPostconditions(prc, callID);
        }		
		private void ResetOut( RadData rd)
		{
			int h=0;
			for(h=0; h<24; h++)
			{
				rd.GlobalSolarRadiationHourly[h] = double.NaN;
			}
		}
		#endregion

		#region Set inputs and parameters current values
		private void SetParametersInputsCurrentValue( RadData rd)
		{
			//set currentValue of description for pre-conditions tests
			RadDataVarInfo.ExtraterrestrialRadiationHourly.CurrentValue = rd.ExtraterrestrialRadiationHourly;
			RadDataVarInfo.GlobalSolarRadiation.CurrentValue = rd.GlobalSolarRadiation;
		}
		private void SetOutputsCurrentValue( RadData rd)
		{
			//set currentValue of description for post-conditions test
			RadDataVarInfo.GlobalSolarRadiationHourly.CurrentValue = rd.GlobalSolarRadiationHourly;
		}
        #endregion

        #region Constructor methods

        public void SetParametersDefaultValue()
        {
            _modellingOptionsManager.SetParametersDefaultValue();


            //GENERATED CODE END - PLACE YOUR CUSTOM CODE BELOW - Section5
            //Code written below will not be overwritten by a future code generation

            //Custom initialization of the parameter. E.g. initialization of the array dimensions of array parameters

            //End of custom code. Do not place your custom code below. It will be overwritten by a future code generation.
            //PLACE YOUR CUSTOM CODE ABOVE - GENERATED CODE START - Section5
        }

        public IEnumerable<Type> GetStrategyDomainClassesTypes()
        {
            return new List<Type>() { typeof(RadData) };
        }
        #endregion

        #region IStrategy Members

        /// <summary>
        ///Strategy to calculate hourly global radiation.
        /// </summary>
        public string Description
        {
            get
            {
                return "Strategy to calculate hourly global radiation. Chen, J.M., Liu, J., Cihlar, J., and M.L. "+
                    "Goulden. 1999. Daily canopy photosynthesis model through temporal and spatial scaling "+
                    "for remote sensing applications. Ecol. Model., 124:99-119.";
            }
        }

        /// <summary>
 		/// URL where a description of the model is stored.
		/// </summary>
		public string URL
        {
            get { return "http://www.isci.it/tools"; }
        }

        public IList<int> TimeStep
        {
            get { return _MinutesTimeSteps; }
        }

        public string ModelType { get { return "Weather"; } }

        public string Domain { get { return "Weather"; } }

        #region Publisher Data

        private PublisherData _pd;
        private void SetPublisherData()
        {
            // Set publishers' data

            _pd = new PublisherData();
            _pd.Add("Creator", "marcello.donatelli@crea.gov.it");
            _pd.Add("Date", "7/14/2020");
            _pd.Add("Publisher", "CREA");
        }

        public PublisherData PublisherData
        {
            get { return _pd; }
        }

        #endregion

        #region ModellingOptionsManager

        private ModellingOptionsManager _modellingOptionsManager;

        public ModellingOptionsManager ModellingOptionsManager
        {
            get { return _modellingOptionsManager; }
        }
        #endregion
        #endregion	} 
    }
}
