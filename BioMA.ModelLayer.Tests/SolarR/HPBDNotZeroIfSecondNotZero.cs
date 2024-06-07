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
	/// Strategy to calculate PAR daily and hourly,
	/// Beam and Diffuse daily and hourly components of PAR.
	/// agronomy@isci.it, June 2005.
	/// </summary>
	/// <remarks>Supit, I., and E. van der Goot. 2003.
	/// Updated system description of the Wofost crop growth simulation model as implemented
	/// in the crop growth monitoring system applied by the European Commission.
	/// Treemail, Heelsum, The Netherlands.</remarks>
	public class HPBDNotZeroIfSecondNotZero : IRadDataStrategy
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
        public HPBDNotZeroIfSecondNotZero()
        {
            //60 for hourly, 1440 for daily; multiple Add statements for strategies with multiple time steps
           _MinutesTimeSteps.Add(1440);
           _MinutesTimeSteps.Add(60);
            ModellingOptions mo0_0 = new ModellingOptions();

            //Parameters
            List<VarInfo> _parameters0_0 = new List<VarInfo>();

            VarInfo _SupitVanDerGrootFractionGSRadVarInfo = new VarInfo();
            _SupitVanDerGrootFractionGSRadVarInfo.Description = "Conversion factor GSRad to PAR";
            _SupitVanDerGrootFractionGSRadVarInfo.Name = "SupitVanDerGrootFractionGSRad";
            _SupitVanDerGrootFractionGSRadVarInfo.Units = "Unitless";
            _SupitVanDerGrootFractionGSRadVarInfo.Size = 1;
            _SupitVanDerGrootFractionGSRadVarInfo.DefaultValue = 0.5;
            _SupitVanDerGrootFractionGSRadVarInfo.MaxValue = 0.50;
            _SupitVanDerGrootFractionGSRadVarInfo.MinValue = 0.45;
            _SupitVanDerGrootFractionGSRadVarInfo.VarType = CRA.ModelLayer.Core.VarInfo.Type.PARAMETER;
            _SupitVanDerGrootFractionGSRadVarInfo.ValueType = VarInfoValueTypes.GetInstanceForName("Double");
            _parameters0_0.Add(_SupitVanDerGrootFractionGSRadVarInfo);

            mo0_0.Parameters = _parameters0_0;

            //Inputs
            List<PropertyDescription> _inputs0_0 = new List<PropertyDescription>();
            PropertyDescription pd1 = new PropertyDescription();
            pd1.DomainClassType = typeof(RadData);
            pd1.PropertyName = "GlobalSolarRadiation";
            pd1.PropertyType = ((RadDataVarInfo.GlobalSolarRadiation)).ValueType.TypeForCurrentValue;
            pd1.PropertyVarInfo = (RadDataVarInfo.GlobalSolarRadiation);
            _inputs0_0.Add(pd1);

            PropertyDescription pd2 = new PropertyDescription();
            pd2.DomainClassType = typeof(RadData);
            pd2.PropertyName = "RadiationDiffuseSky";
            pd2.PropertyType = ((RadDataVarInfo.RadiationDiffuseSky)).ValueType.TypeForCurrentValue;
            pd2.PropertyVarInfo = (RadDataVarInfo.RadiationDiffuseSky);
            _inputs0_0.Add(pd2);

            PropertyDescription pd3 = new PropertyDescription();
            pd3.DomainClassType = typeof(RadData);
            pd3.PropertyName = "SolarElevationHourly";
            pd3.PropertyType = ((RadDataVarInfo.SolarElevationHourly)).ValueType.TypeForCurrentValue;
            pd3.PropertyVarInfo = (RadDataVarInfo.SolarElevationHourly);
            _inputs0_0.Add(pd3);

            mo0_0.Inputs = _inputs0_0;

            //Outputs
            List<PropertyDescription> _outputs0_0 = new List<PropertyDescription>();
            PropertyDescription pd11 = new PropertyDescription();
            pd11.DomainClassType = typeof(RadData);
            pd11.PropertyName = "PhotosynteticallyActiveRadiation";
            pd11.PropertyType = ((RadDataVarInfo.PhotosynteticallyActiveRadiation)).ValueType.TypeForCurrentValue;
            pd11.PropertyVarInfo = (RadDataVarInfo.PhotosynteticallyActiveRadiation);
            _outputs0_0.Add(pd11);

            PropertyDescription pd12 = new PropertyDescription();
            pd12.DomainClassType = typeof(RadData);
            pd12.PropertyName = "ParBeam";
            pd12.PropertyType = ((RadDataVarInfo.ParBeam)).ValueType.TypeForCurrentValue;
            pd12.PropertyVarInfo = (RadDataVarInfo.ParBeam);
            _outputs0_0.Add(pd12);

            PropertyDescription pd13 = new PropertyDescription();
            pd13.DomainClassType = typeof(RadData);
            pd13.PropertyName = "ParDiffuse";
            pd13.PropertyType = ((RadDataVarInfo.ParDiffuse)).ValueType.TypeForCurrentValue;
            pd13.PropertyVarInfo = (RadDataVarInfo.ParDiffuse);
            _outputs0_0.Add(pd13);

            PropertyDescription pd14 = new PropertyDescription();
            pd14.DomainClassType = typeof(RadData);
            pd14.PropertyName = "PhotosynteticallyActiveRadiationHourly";
            pd14.PropertyType = ((RadDataVarInfo.PhotosynteticallyActiveRadiationHourly)).ValueType.TypeForCurrentValue;
            pd14.PropertyVarInfo = (RadDataVarInfo.PhotosynteticallyActiveRadiationHourly);
            _outputs0_0.Add(pd14);

            PropertyDescription pd15 = new PropertyDescription();
            pd15.DomainClassType = typeof(RadData);
            pd15.PropertyName = "ParBeamHourly";
            pd15.PropertyType = ((RadDataVarInfo.ParBeamHourly)).ValueType.TypeForCurrentValue;
            pd15.PropertyVarInfo = (RadDataVarInfo.ParBeamHourly);
            _outputs0_0.Add(pd15);

            PropertyDescription pd16 = new PropertyDescription();
            pd16.DomainClassType = typeof(RadData);
            pd16.PropertyName = "ParDiffuseHourly";
            pd16.PropertyType = ((RadDataVarInfo.ParDiffuseHourly)).ValueType.TypeForCurrentValue;
            pd16.PropertyVarInfo = (RadDataVarInfo.ParDiffuseHourly);
            _outputs0_0.Add(pd16);

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
            SupitVanDerGrootFractionGSRadVarInfo.Description = "Conversion factor GSRad to PAR";
            SupitVanDerGrootFractionGSRadVarInfo.Name = "SupitVanDerGrootFractionGSRad";
            SupitVanDerGrootFractionGSRadVarInfo.Units = "Unitless";
            SupitVanDerGrootFractionGSRadVarInfo.DefaultValue = 0.5;
            SupitVanDerGrootFractionGSRadVarInfo.MaxValue = 0.50;
            SupitVanDerGrootFractionGSRadVarInfo.MinValue = 0.45;
            SupitVanDerGrootFractionGSRadVarInfo.ValueType = VarInfoValueTypes.GetInstanceForName("Double");
        }

        #endregion

        #region Fields

        private readonly string _strategyName = "HPBDNotZeroIfSecondNotZero";

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
			_SupitVanDerGrootFractionGSRad = _SupitVanDerGrootFractionGSRadVarInfo.DefaultValue;
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

		#region Parameters
		//value
		private double _SupitVanDerGrootFractionGSRad;

        /// <summary>Parameter of the HPBDNotZeroIfSecondNotZero model</summary>
        public double SupitVanDerGrootFractionGSRad
		{
			get	{ return _SupitVanDerGrootFractionGSRad; }
			set	{ _SupitVanDerGrootFractionGSRad = value;	}
		}

		//description
		private static VarInfo _SupitVanDerGrootFractionGSRadVarInfo = new VarInfo();

        /// <summary>VarInfo of parameter of the HPBDNotZeroIfSecondNotZero model</summary>
        public static VarInfo SupitVanDerGrootFractionGSRadVarInfo
		{
			get	{ return _SupitVanDerGrootFractionGSRadVarInfo; }
		}
		#endregion

		#region Model
		private void ModelEstimate( RadData rd)
		{
			int h;
			double sum = 0;
			double distribution; 
				
			for (h=0;h<24;h++)
			{
                sum = sum + Math.Sin(rd.SolarElevationHourly[h] * (1 + 0.4 * Math.Sin(rd.SolarElevationHourly[h]))); 
			}
			for (h=0;h<24;h++)
			{
				distribution = _SupitVanDerGrootFractionGSRad
                               * Math.Sin(rd.SolarElevationHourly[h] *
                               (1 + 0.4 * Math.Sin(rd.SolarElevationHourly[h]))) / sum;
				rd.PhotosynteticallyActiveRadiationHourly[h] = rd.GlobalSolarRadiation *
					                                           distribution;
				rd.ParDiffuseHourly[h] = rd.RadiationDiffuseSky * distribution;
				rd.ParBeamHourly[h] = rd.PhotosynteticallyActiveRadiationHourly[h]
					                  - rd.ParDiffuseHourly[h];
				rd.PhotosynteticallyActiveRadiation += rd.PhotosynteticallyActiveRadiationHourly[h];
				rd.ParDiffuse += rd.ParDiffuseHourly[h];
				rd.ParBeam += rd.ParBeamHourly[h];
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
            //prc.RangeBased.Add(RadDataVarInfo.GlobalSolarRadiation);
            //prc.RangeBased.Add(RadDataVarInfo.SolarElevationHourly);
			//prc.RangeBased.Add(RadDataVarInfo.RadiationDiffuseSky);
            //prc.RangeBased.Add(_SupitVanDerGrootFractionGSRadVarInfo);

            //RangeBasedCondition r = new RangeBasedCondition(RadDataVarInfo.GlobalSolarRadiation);
            //if (r.ApplicableVarInfoValueTypes.Contains(RadDataVarInfo.GlobalSolarRadiation.ValueType)) { prc.AddCondition(r); }
            //r = new RangeBasedCondition(RadDataVarInfo.SolarElevationHourly);
            //if (r.ApplicableVarInfoValueTypes.Contains(RadDataVarInfo.SolarElevationHourly.ValueType)) { prc.AddCondition(r); }
            //r = new RangeBasedCondition(RadDataVarInfo.RadiationDiffuseSky);
            //if (r.ApplicableVarInfoValueTypes.Contains(RadDataVarInfo.RadiationDiffuseSky.ValueType)) { prc.AddCondition(r); }



            //cannot be smaller than 
            //prc.GreaterThan.Add(RadDataVarInfo.GlobalSolarRadiation, RadDataVarInfo.RadiationDiffuseSky);
            NotZeroIfSecondNotZeroCondition g = new NotZeroIfSecondNotZeroCondition(RadDataVarInfo.GlobalSolarRadiation, RadDataVarInfo.RadiationDiffuseSky);
            if (g.ApplicableVarInfoValueTypes.Contains(RadDataVarInfo.GlobalSolarRadiation.ValueType)) { prc.AddCondition(g); }

            //at least one must be different from 0
            //prc.AtLeastOne.Add(RadDataVarInfo.SolarElevationHourly);
            //RadDataVarInfo.ExtraterrestrialRadiationHourly.CurrentValue = rd.ExtraterrestrialRadiationHourly;
            //AtLeastOneDifferentFromZeroCondition a = new AtLeastOneDifferentFromZeroCondition(RadDataVarInfo.SolarElevationHourly);           
            //if (a.ApplicableVarInfoValueTypes.Contains(RadDataVarInfo.SolarElevationHourly.ValueType)) { prc.AddCondition(a); }

            //get the evaluation of preconditions
            //return  pre.VerifyPreconditions( prc, callID);
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
            //prc.RangeBased.Add(RadDataVarInfo.PhotosynteticallyActiveRadiationHourly);
			//prc.RangeBased.Add(RadDataVarInfo.ParBeamHourly);
			//prc.RangeBased.Add(RadDataVarInfo.ParDiffuseHourly);
			//prc.RangeBased.Add(RadDataVarInfo.PhotosynteticallyActiveRadiation);
			//prc.RangeBased.Add(RadDataVarInfo.ParBeam);
			//prc.RangeBased.Add(RadDataVarInfo.ParDiffuse);

            RangeBasedCondition r = new RangeBasedCondition(RadDataVarInfo.PhotosynteticallyActiveRadiationHourly);
            if (r.ApplicableVarInfoValueTypes.Contains(RadDataVarInfo.PhotosynteticallyActiveRadiationHourly.ValueType)) { prc.AddCondition(r); }
            r = new RangeBasedCondition(RadDataVarInfo.ParBeamHourly);
            if (r.ApplicableVarInfoValueTypes.Contains(RadDataVarInfo.ParBeamHourly.ValueType)) { prc.AddCondition(r); }
            r = new RangeBasedCondition(RadDataVarInfo.ParDiffuseHourly);
            if (r.ApplicableVarInfoValueTypes.Contains(RadDataVarInfo.ParDiffuseHourly.ValueType)) { prc.AddCondition(r); }
            r = new RangeBasedCondition(RadDataVarInfo.PhotosynteticallyActiveRadiation);
            if (r.ApplicableVarInfoValueTypes.Contains(RadDataVarInfo.PhotosynteticallyActiveRadiation.ValueType)) { prc.AddCondition(r); }
            r = new RangeBasedCondition(RadDataVarInfo.ParBeam);
            if (r.ApplicableVarInfoValueTypes.Contains(RadDataVarInfo.ParBeam.ValueType)) { prc.AddCondition(r); }
            r = new RangeBasedCondition(RadDataVarInfo.ParDiffuse);
            if (r.ApplicableVarInfoValueTypes.Contains(RadDataVarInfo.ParDiffuse.ValueType)) { prc.AddCondition(r); }

            //at least one different from 0
            //prc.AtLeastOne.Add(RadDataVarInfo.PhotosynteticallyActiveRadiationHourly);
            //prc.AtLeastOne.Add(RadDataVarInfo.ParBeamHourly);
            //prc.AtLeastOne.Add(RadDataVarInfo.ParDiffuseHourly);

            AtLeastOneDifferentFromZeroCondition a = new AtLeastOneDifferentFromZeroCondition(RadDataVarInfo.PhotosynteticallyActiveRadiationHourly);
            if (a.ApplicableVarInfoValueTypes.Contains(RadDataVarInfo.PhotosynteticallyActiveRadiationHourly.ValueType)) { prc.AddCondition(a); }
            a = new AtLeastOneDifferentFromZeroCondition(RadDataVarInfo.ParBeamHourly);
            if (a.ApplicableVarInfoValueTypes.Contains(RadDataVarInfo.ParBeamHourly.ValueType)) { prc.AddCondition(a); }
            a = new AtLeastOneDifferentFromZeroCondition(RadDataVarInfo.ParDiffuseHourly);
            if (a.ApplicableVarInfoValueTypes.Contains(RadDataVarInfo.ParDiffuseHourly.ValueType)) { prc.AddCondition(a); }

            // cannot be smaller than 
            //prc.GreaterThan.Add(RadDataVarInfo.PhotosynteticallyActiveRadiation, RadDataVarInfo.ParBeam);

            GreaterThanCondition g = new GreaterThanCondition(RadDataVarInfo.PhotosynteticallyActiveRadiation, RadDataVarInfo.ParBeam);
            if (g.ApplicableVarInfoValueTypes.Contains(RadDataVarInfo.PhotosynteticallyActiveRadiation.ValueType)) { prc.AddCondition(g); }

            // VarInfo created to avoid duplication in the dictionary structure of GreaterThan
            VarInfo v = new VarInfo();
		    v.MaxValue = RadDataVarInfo.PhotosynteticallyActiveRadiation.MaxValue;
            v.MinValue = RadDataVarInfo.PhotosynteticallyActiveRadiation.MinValue;
            v.Description = RadDataVarInfo.PhotosynteticallyActiveRadiation.Description;
		    v.CurrentValue = RadDataVarInfo.PhotosynteticallyActiveRadiation.CurrentValue;
            v.Name = RadDataVarInfo.PhotosynteticallyActiveRadiation.Name;

            //prc.GreaterThan.Add(v, RadDataVarInfo.ParDiffuse);
            g = new GreaterThanCondition(v, RadDataVarInfo.ParDiffuse);
            if (g.ApplicableVarInfoValueTypes.Contains(v.ValueType)) { prc.AddCondition(g); }

            //get the evaluation of postconditions
            //return  pre.VerifyPostconditions( prc, callID);
            return preconditions.VerifyPostconditions(prc, callID);
        }		
		private void ResetOut( RadData rd)
		{
			int i;
			for(i=0; i<24; i++)
			{
				rd.PhotosynteticallyActiveRadiationHourly[i] = double.NaN;
				rd.ParBeamHourly[i] = double.NaN;
				rd.ParDiffuseHourly[i] = double.NaN;
			}
			rd.PhotosynteticallyActiveRadiation = double.NaN;
			rd.ParBeam = double.NaN;
			rd.ParDiffuse = double.NaN;
		}
		#endregion

		#region Set inputs and parameters current values
		private void SetParametersInputsCurrentValue( RadData rd)
		{
			//set currentValue of description for pre-conditions tests
			_SupitVanDerGrootFractionGSRadVarInfo.CurrentValue = _SupitVanDerGrootFractionGSRad;
			RadDataVarInfo.GlobalSolarRadiation.CurrentValue = rd.GlobalSolarRadiation;
			RadDataVarInfo.RadiationDiffuseSky.CurrentValue = rd.RadiationDiffuseSky;
            RadDataVarInfo.SolarElevationHourly.CurrentValue = rd.SolarElevationHourly;
		}
		private void SetOutputsCurrentValue( RadData rd)
		{
			//set currentValue of description for post-conditions test
			RadDataVarInfo.PhotosynteticallyActiveRadiation.CurrentValue = rd.PhotosynteticallyActiveRadiation;
			RadDataVarInfo.PhotosynteticallyActiveRadiationHourly.CurrentValue = rd.PhotosynteticallyActiveRadiationHourly;
			RadDataVarInfo.ParBeam.CurrentValue = rd.ParBeam;
			RadDataVarInfo.ParBeamHourly.CurrentValue = rd.ParBeamHourly;
			RadDataVarInfo.ParDiffuse.CurrentValue = rd.ParDiffuse;
			RadDataVarInfo.ParDiffuseHourly.CurrentValue = rd.ParDiffuseHourly;
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
        /// Strategy to calculate PAR daily and hourly, Beam and Diffuse daily and hourly components of PAR.
        /// </summary>
        public string Description
        {
            get
            {
                return "Strategy to calculate PAR daily and hourly, Beam and Diffuse daily and hourly components "+
                    "of PAR. Supit, I., and E. van der Goot. 2003. Updated system description of the Wofost crop "+
                    "growth simulation model as implemented in the crop growth monitoring system applied by the "+
                    "European Commission. Treemail, Heelsum, The Netherlands.";
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
