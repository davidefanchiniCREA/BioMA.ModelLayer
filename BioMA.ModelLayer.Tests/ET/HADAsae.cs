using System;
using System.Collections.Generic;
using System.Linq;
using CRA.Clima;
using CRA.Clima.ET.Interfaces;
using CRA.ModelLayer.Core;
using CRA.ModelLayer.MetadataTypes;
using CRA.ModelLayer.Strategy;

namespace CRA.Clima.ET.Strategies
{
	/// <summary>
	/// Strategy to estimate atmospheric density with hourly step (Asae method).  agronomy@isci.it
	/// June, 2005
	/// </summary>
	/// <remarks>
	/// ASAE Standards. 1998. EP406.2: heating, cooling, and ventilating greenhouses. 
	/// St. Joseph, MI, USA.
	/// </remarks>
	public class HADAsae: IETDataStrategy
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
		/// Strategy to estimate atmospheric density.
		/// Constructor
        /// </summary>
        public HADAsae()
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
            pd1.DomainClassType = typeof(ETData);
            pd1.PropertyName = "AirTemperatureHourly";
            pd1.PropertyType = ((ETDataVarInfo.AirTemperatureHourly)).ValueType.TypeForCurrentValue;
            pd1.PropertyVarInfo = (ETDataVarInfo.AirTemperatureHourly);
            _inputs0_0.Add(pd1);

            //Outputs
            List<PropertyDescription> _outputs0_0 = new List<PropertyDescription>();
            PropertyDescription pd2 = new PropertyDescription();
            pd2.DomainClassType = typeof(ETData);
            pd2.PropertyName = "AtmosphericDensityHourly";
            pd2.PropertyType = ((ETDataVarInfo.AtmosphericDensityHourly)).ValueType.TypeForCurrentValue;
            pd2.PropertyVarInfo = (ETDataVarInfo.AtmosphericDensityHourly);
            _outputs0_0.Add(pd2);
            mo0_0.Outputs = _outputs0_0;
            //Associated strategies
            List<string> lAssStrat0_0 = new List<string>();
            mo0_0.AssociatedStrategies = lAssStrat0_0;
            //Adding the modeling options to the modeling options manager
            _modellingOptionsManager = new ModellingOptionsManager(mo0_0);

            SetStaticParametersVarInfoDefinitions();
            SetPublisherData();
        }

        private static void SetStaticParametersVarInfoDefinitions()
        {
        }

        #endregion

        #region Fields

        private readonly string _strategyName = "HADAsae";

        private readonly List<int> _MinutesTimeSteps = new List<int>();

        private readonly bool _IsContext = false;

        #endregion

        #region IETDataStrategy members

        /// <summary>
        /// The estimate method is used to access all models in the component.
        /// The overload with 2 Parameters checks for pre-conditions only if a unhandled exception occurs.
        /// </summary>
        /// <param Name="d">instance of ETData</param>
        public void Estimate(ETData d)
        {
            try
            {
                ModelEstimate(d);
                d.StrategyUsed.Add(_strategyName);
                TraceStrategies.TraceEvent(System.Diagnostics.TraceEventType.Verbose, 1011,
                    "Strategy: " + _strategyName + " - Run successful");
            }
            catch (Exception e)
            {
                TraceStrategies.TraceEvent(System.Diagnostics.TraceEventType.Error, 1001,
                    "Strategy: " + _strategyName + " - Unhandled exception due to violated pre-conditions");
                string msg = "Component EvapoTranspiration, " + _strategyName + ": Pre-conditions violated. ";
                msg = msg + TestPreConditions(d, "");
                throw new Exception(msg, e);
            }
        }
        /// <summary>
        /// Reset strategy output to NaN
        /// </summary>
        /// <param Name="d">instance of ETData</param>
        public void ResetOutputs(ETData d)
        {
            try
            {
                ResetOut(d);
                TraceStrategies.TraceEvent(System.Diagnostics.TraceEventType.Verbose, 1012,
                    "Strategy: " + _strategyName + " - Output reset to NaN (Not a Number)");
            }
            catch (Exception e)
            {
                TraceStrategies.TraceEvent(System.Diagnostics.TraceEventType.Error, 1002,
                    "Strategy: " + _strategyName + " - Unhandled exception running output reset");
                string msg = "Component EvapoTranspiration, " + _strategyName + ": Unhandled exception running Outputs reset. ";
                throw new Exception(msg, e);
            }
        }

        /// <summary>
        /// This method allows testing post-conditions.
        /// </summary>
        /// <param Name="d">instance of ETData</param>
        /// <param Name="callID">identification of method call from client</param>
        /// <returns>a string with post-condition tests failed</returns>
        public string TestPostConditions(ETData d, string callID)
        {
            try
            {
                string _result = PostConditions(d, callID);
                TraceStrategies.TraceEvent(System.Diagnostics.TraceEventType.Verbose, 1014,
                    "Strategy: " + _strategyName + " - Post-conditions tests done, ID: " + callID);
                return _result;
            }
            catch (Exception e)
            {
                TraceStrategies.TraceEvent(System.Diagnostics.TraceEventType.Error, 1004,
                    "Strategy: " + _strategyName + " - Unhandled exception running post-conditions tests");
                string msg = "Component EvapoTranspiration, " + _strategyName + ": Unhandled exception running post-condition test. ";
                throw new Exception(msg, e);
            }
        }
        /// <summary>
        /// This method allows testing pre-conditions.
        /// </summary>
        /// <param Name="d">instance of ETData</param>
        /// <param Name="callID">identification of method call from client</param>
        /// <returns>a string with pre-condition tests failed</returns>
        public string TestPreConditions(ETData d, string callID)
        {
            try
            {
                string _result = PreConditions(d, callID);
                TraceStrategies.TraceEvent(System.Diagnostics.TraceEventType.Verbose, 1013,
                    "Strategy: " + _strategyName + " - Pre-conditions tests done, ID: " + callID);
                return _result;
            }
            catch (Exception e)
            {
                TraceStrategies.TraceEvent(System.Diagnostics.TraceEventType.Error, 1003,
                    "Strategy: " + _strategyName + " - Unhandled exception running pre-conditions tests");
                string msg = "Component EvapoTranspiration, " + _strategyName + ": Unhandled exception running pre-condition test. ";
                throw new Exception(msg, e);
            }
        }
        /// <summary>
        /// Assign VarInfo.DefaultValue to each parameter
        /// </summary>
        public void SetParametersDefaults()
        {
            //
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
		private void ModelEstimate(ETData etd)
		{
			int h;
			double R;
			double[] hourlyT = new double[24];
						
			R = 287;     // gas constant (J kg-1 K-1)
						
			for (h=0; h<24; h++)
			{
				hourlyT[h] = etd.AirTemperatureHourly[h];
				etd.AtmosphericDensityHourly[h] = 100000 /(R * (hourlyT[h] + 273.16 ));			
			}
		}
		#endregion

		#region Pre- post- conditions
		private string PreConditions(ETData etd, string callID)
		{
			SetParametersInputsCurrentValue(etd);
            //CRA.Core.Preconditions.PreconditionsData prc = new CRA.Core.Preconditions.PreconditionsData();
            //CRA.Core.Preconditions.Preconditions pre = new CRA.Core.Preconditions.Preconditions();

            //Create the collection of the conditions to test
            ConditionsCollection prc = new ConditionsCollection();
            Preconditions pre = new Preconditions();

            //add range based (current value must be in the range minValue-maxValue)
            //prc.RangeBased.Add(CRA.Clima.ET.Interfaces.ETDataVarInfo.AirTemperatureHourly);

            RangeBasedCondition r1 = new RangeBasedCondition(ETDataVarInfo.AirTemperatureHourly);
            if (r1.ApplicableVarInfoValueTypes.Contains(ETDataVarInfo.AirTemperatureHourly.ValueType)) { prc.AddCondition(r1); }

            //	TODO
            //get the evaluation of preconditions
            return  pre.VerifyPreconditions(prc, callID); 
		}
		private string PostConditions(ETData etd, string callID)
		{
			SetOutputsCurrentValue(etd);
            //CRA.Core.Preconditions.PreconditionsData prc = new CRA.Core.Preconditions.PreconditionsData();
            //CRA.Core.Preconditions.Preconditions pre = new CRA.Core.Preconditions.Preconditions();

            //Create the collection of the conditions to test
            ConditionsCollection prc = new ConditionsCollection();
            Preconditions pre = new Preconditions();

            //add range based (current value must be in the range minValue-maxValue)
            // prc.RangeBased.Add(CRA.Clima.ET.Interfaces.ETDataVarInfo.AtmosphericDensityHourly);
            RangeBasedCondition r1 = new RangeBasedCondition(ETDataVarInfo.AtmosphericDensityHourly);
            if (r1.ApplicableVarInfoValueTypes.Contains(ETDataVarInfo.AtmosphericDensityHourly.ValueType)) { prc.AddCondition(r1); }
            //get the evaluation of preconditions
            return  pre.VerifyPostconditions(prc, callID); 
		}
		private void ResetOut(ETData d)
		{
			int h;
			for (h=0; h<24; h++)
			{
				d.AtmosphericDensityHourly[h] = double.NaN;
			}
		}
		#endregion

		#region Set inputs and parameters current values
		private void SetParametersInputsCurrentValue(ETData etd)		
		{
			//set CurrentValue of description for pre-conditions tests
			CRA.Clima.ET.Interfaces.ETDataVarInfo.AirTemperatureHourly.CurrentValue = etd.AirTemperatureHourly;
		}
		private void SetOutputsCurrentValue(ETData etd)
		{
			//set CurrentValue of description for post-conditions test
			CRA.Clima.ET.Interfaces.ETDataVarInfo.AtmosphericDensityHourly.CurrentValue = etd.AtmosphericDensityHourly;
		}
		#endregion


        #region IStrategy Members
        /// <summary>
        /// Strategy to estimate atmospheric density with hourly step (Asae method).
        /// </summary>
        public string Description
        {
            get
            {
                return "Strategy to estimate atmospheric density with hourly step (Asae method). ASAE Standards. 1998. "+
                    "EP406.2: heating, cooling, and ventilating greenhouses. St. Joseph, MI, USA.";
            }
        }
        /// <summary>
        /// URL where a description of the model is stored.
        /// </summary>
        public string URL
        {
            get { return "http://ontology.seamless-ip.org"; }
        }

        #endregion

        /// <summary>
        /// Time step of the models (if any)
        /// </summary>
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
            return new List<Type>() { typeof(ETData) };
        }
    }
}

