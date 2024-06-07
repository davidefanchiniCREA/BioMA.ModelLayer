using CRA.ModelLayer.Core;
using CRA.ModelLayer.ParametersManagement;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace CRA.Clima.ET.Interfaces
{
    /// <summary>
    /// ETData is  the domain class used to estimate reference evapotranspiration
    /// at a site.
    /// Each attribute is described using the VarInfo data-type in the
    /// ETDataVarInfo class.
    /// </summary>
    /// <remarks>June 2005</remarks>
    [Serializable()]
    public class ETData : IDomainClass, ICloneable
    {
        #region Private field for properties
        private ParametersIO _parametersIO;
        #endregion

        #region Constructor
        /// <summary>No parameters constructor</summary>
        public ETData()
        {
            _parametersIO = new ParametersIO(this);
        }
        #endregion

        #region Clone
        /// <summary>Implement ICloneable.Clone()</summary>
        public virtual Object Clone()
        {
            // Shallow copy by default
            IDomainClass myclass = (IDomainClass)this.MemberwiseClone();
            _parametersIO.PopulateClonedCopy(myclass);
            return myclass;
        }
        #endregion

        private double[] _ActualVapourPressureHourly = new double[24];
		private double[] _AerodynamicResistanceHourly = new double[24];
		private double[] _DewPointTemperatureHourly = new double[24];
		private double[] _AirTemperatureHourly = new double[24];
		private double[] _AmbientTemperatureHourly = new double[24];
		private double[] _AtmosphericDensityHourly = new double[24];
		private double[] _ExtraterrestrialRadiationHourly = new double[24];
		private double[] _GlobalSolarRadiationHourly = new double[24];
		private double[] _LatentHeatOfVaporizationHourly = new double[24];
		private double[] _LeafTemperatureHourly = new double[24];
		private double[] _LongWaveNetRadiationHourly = new double[24];
		private double[] _NetRadiationHourly = new double[24];
		private double[] _PsychrometricConstantHourly = new double[24];
		private double[] _RadiativeResistanceHourly = new double[24];
		private double[] _ReferenceEvapotranspirationHourly = new double[24];
		private double[] _RelativeAirHumidityHourly = new double[24];
        private double[] _SaturationVapourPressureHourly = new double[24];
		private double[] _ShortWaveNetRadiationHourly = new double[24];
		private double[] _SlopeVapourPressureHourly = new double[24];
		private double[] _SoilHeatFluxHourly = new double[24];
		private double[] _VapourPressureDeficitHourly = new double[24];
		private double[] _WindSpeedHourly = new double[24];
		private double[] _LeafAreaIndexHourly = new double[24];
        private double[] _PotentialEvaporationHourly = new double[24];
		private double _ActualVapourPressure;
		private double _AerodynamicResistance;
		private double _DewPointTemperature;
        private double _DiurnalAirTemperatureRange;
		private double _AirHumidityFactor;
		private double _AirTemperatureMax;
		private double _AirTemperatureMin;
		private double _Albedo;
		private double _AtmosphericDensity;
		private double _ClearSkyTransmissivity;
		private double _CloudinessFactor;
        private double _DaytimeTemperature;
		private double _Elevation;
		private double _ExtraterrestrialRadiation;
		private double _GlobalSolarRadiation;
		private double _LatentHeatOfVaporization;
		private double _LongWaveNetRadiation;
		private double _MaximumVapourPressureDeficit;
		private double _NetRadiation;
	    private double _NormalizedDifferenceVegetationIndex;
		private double _PriestleyTaylorCoefficient;
		private double _PsychrometricConstant;
		private double _ReferenceEvapotranspiration;
        private double _GlobalEvapotranspiration;
	    private double _PanCoefficient;
	    private double _PanEvaporationClassA;
	    private double _FetchDistance;
		private double _RelativeAirHumidityMax;
		private double _RelativeAirHumidityMin;
	    private double _RelativeAirHumidity;
	    private double _RickAllenConstant;
		private double _SaturationVapourPressure;
		private double _ShortWaveNetRadiation;
		private double _SlopeVapourPressure;
		private double _SoilHeatFlux;
		private double _VapourPressureDeficit;
		private double _WindSpeed;
		private double _WindMeasurementHeight;
        private List<string> _StrategyUsed = new List<string>();

        #region IDomainClass members
        /// <summary>Domain Class Description</summary>
        public virtual string Description
        {
            get
            {
                return "Variables to estimate reference evapotranspiration at a site.";
            }
        }

        /// <summary>Reference to the ontology</summary>
        public virtual string URL
        {
            get
            {
                return "http://ontology.seamless-ip.org";
            }
        }
        #endregion

        #region IETData Members

        /// <summary>
        /// Strategy used (may be different in context classes)
        /// </summary>
        public List<string> StrategyUsed
        {
            get { return _StrategyUsed; }
            set { _StrategyUsed = value; }
        }
		
		/// <summary>Hourly actual vapour pressure </summary> 
		public double[] ActualVapourPressureHourly
		{
			get {return _ActualVapourPressureHourly;}
			set {this._ActualVapourPressureHourly = value;}
		}
		/// <summary>Hourly aerodynamic resistance </summary> 
		public double[] AerodynamicResistanceHourly
		{
			get {return _AerodynamicResistanceHourly;}
			set {this._AerodynamicResistanceHourly = value;}
		}
		/// <summary>Hourly dew point temperature </summary> 
		public double[] DewPointTemperatureHourly
		{
			get {return _DewPointTemperatureHourly;}
			set {this._DewPointTemperatureHourly = value;}
		}
		/// <summary>Hourly air temperature </summary> 
		public double[] AirTemperatureHourly
		{
			get {return _AirTemperatureHourly;}
			set {this._AirTemperatureHourly = value;}
		}
		/// <summary>Ambient hourly air temperature </summary> 
		public double[] AmbientTemperatureHourly
		{
			get {return _AmbientTemperatureHourly;}
			set {this._AmbientTemperatureHourly = value;}
		}
		/// <summary>Hourly atmospheric density </summary> 
		public double[] AtmosphericDensityHourly
		{
			get {return _AtmosphericDensityHourly;}
			set {this._AtmosphericDensityHourly = value;}
		}
		/// <summary>Hourly extraterrestrial radiation </summary> 
		public double[] ExtraterrestrialRadiationHourly
		{
			get {return _ExtraterrestrialRadiationHourly;}
			set {this._ExtraterrestrialRadiationHourly = value;}
		}
		/// <summary>Hourly global solar radiation outside earth atmosphere </summary> 
		public double[] GlobalSolarRadiationHourly
		{
			get {return _GlobalSolarRadiationHourly;}
			set {this._GlobalSolarRadiationHourly = value;}
		}
		/// <summary>Hourly latent heat of vaporization </summary> 
		public double[] LatentHeatOfVaporizationHourly
		{
			get {return _LatentHeatOfVaporizationHourly;}
			set {this._LatentHeatOfVaporizationHourly = value;}
		}
		/// <summary>Leaf area index</summary> 
		public double[] LeafAreaIndexHourly
		{
			get {return _LeafAreaIndexHourly;}
			set {this._LeafAreaIndexHourly = value;}
		}
		/// <summary>Hourly leaf temperature </summary> 
		public double[] LeafTemperatureHourly
		{
			get {return _LeafTemperatureHourly;}
			set {this._LeafTemperatureHourly = value;}
		}
		/// <summary>Hourly long wave net radiation </summary> 
		public double[] LongWaveNetRadiationHourly
		{
			get {return _LongWaveNetRadiationHourly;}
			set {this._LongWaveNetRadiationHourly = value;}
		}
		/// <summary>Hourly net radiation </summary> 
		public double[] NetRadiationHourly
		{
			get {return _NetRadiationHourly;}
			set {this._NetRadiationHourly = value;}
		}
        /// <summary>Normalized difference vegetation index</summary> 
        public double NormalizedDifferenceVegetationIndex
        {
            get { return _NormalizedDifferenceVegetationIndex; }
            set { this._NormalizedDifferenceVegetationIndex = value; }
        }
        /// <summary>Diurnal air temperature range</summary> 
        public double DiurnalAirTemperatureRange
        {
            get { return _DiurnalAirTemperatureRange; }
            set { this._DiurnalAirTemperatureRange = value; }
        }	
        /// <summary>Psychrometric constant hourly</summary> 
		public double[] PsychrometricConstantHourly
		{
			get {return _PsychrometricConstantHourly;}
			set {this._PsychrometricConstantHourly = value;}
		}
		/// <summary>Radiative resistance </summary> 
		public double[] RadiativeResistanceHourly
		{
			get {return _RadiativeResistanceHourly;}
			set {this._RadiativeResistanceHourly = value;}
		}
		/// <summary>Hourly reference evapotranspiration </summary> 
		public double[] ReferenceEvapotranspirationHourly
		{
			get {return _ReferenceEvapotranspirationHourly;}
			set {this._ReferenceEvapotranspirationHourly = value;}
		}
		/// <summary>Hourly relative air humidity </summary> 
		public double[] RelativeAirHumidityHourly
		{
			get {return _RelativeAirHumidityHourly;}
			set {this._RelativeAirHumidityHourly = value;}
		}
        /// <summary>Hourly saturation vapour pressure </summary> 
		public double[] SaturationVapourPressureHourly
		{
			get {return _SaturationVapourPressureHourly;}
			set {this._SaturationVapourPressureHourly = value;}
		}
		/// <summary>Hourly short wave net radiation </summary> 
		public double[] ShortWaveNetRadiationHourly
		{
			get {return _ShortWaveNetRadiationHourly;}
			set {this._ShortWaveNetRadiationHourly = value;}
		}
		/// <summary>Hourly slope VapourPressureDeficit </summary> 
		public double[] SlopeVapourPressureHourly
		{
			get {return _SlopeVapourPressureHourly;}
			set {this._SlopeVapourPressureHourly = value;}
		}
		/// <summary>Hourly slope vapour pressure deficit </summary> 
		public double[] SoilHeatFluxHourly
		{
			get {return _SoilHeatFluxHourly;}
			set {this._SoilHeatFluxHourly = value;}
		}
		/// <summary>Hourly vapour pressure deficit </summary> 
		public double[] VapourPressureDeficitHourly
		{
			get {return _VapourPressureDeficitHourly;}
			set {this._VapourPressureDeficitHourly = value;}
		}
		/// <summary>Hourly wind speed </summary> 
		public double[] WindSpeedHourly
		{
			get {return _WindSpeedHourly;}
			set {this._WindSpeedHourly = value;}
		}
        /// <summary>Hourly potential evaporation </summary> 
        public double[] PotentialEvaporationHourly
        {
            get { return _PotentialEvaporationHourly; }
            set { this._PotentialEvaporationHourly = value; }
        }
        /// <summary>Actual vapour pressure </summary> 
		public double ActualVapourPressure
		{
			get {return _ActualVapourPressure;}
			set {this._ActualVapourPressure = value;}
		}
		/// <summary>Canopy aerodynamic resistance </summary> 
		public double AerodynamicResistance
		{
			get {return _AerodynamicResistance;}
			set {this._AerodynamicResistance = value;}
		}
		/// <summary>Air dew point temperature </summary> 
		public double DewPointTemperature
		{
			get {return _DewPointTemperature;}
			set {this._DewPointTemperature = value;}
		}
		/// <summary>Air humidity factor </summary> 
		public double AirHumidityFactor
		{
			get {return _AirHumidityFactor;}
			set {this._AirHumidityFactor = value;}
		}
		/// <summary>Daily maximum air temperature </summary> 
		public double AirTemperatureMax
		{
			get {return _AirTemperatureMax;}
			set {this._AirTemperatureMax = value;}
		}
        /// <summary>Daily minimum air temperature </summary> 
		public double AirTemperatureMin
		{
			get {return _AirTemperatureMin;}
			set {this._AirTemperatureMin = value;}
		}
		/// <summary>Albedo </summary> 
		public double Albedo
		{
			get {return _Albedo;}
			set {this._Albedo = value;}
		}
		/// <summary>Atmospheric density </summary> 
		public double AtmosphericDensity
		{
			get {return _AtmosphericDensity;}
			set {this._AtmosphericDensity = value;}
		}
		/// <summary>Fraction of clear sky global radiation at ground level </summary> 
		public double ClearSkyTransmissivity
		{
			get {return _ClearSkyTransmissivity;}
			set {this._ClearSkyTransmissivity = value;}
		}
		/// <summary>Cloudiness factor </summary> 
		public double CloudinessFactor
		{
			get {return _CloudinessFactor;}
			set {this._CloudinessFactor = value;}
		}
        /// <summary>Daytime-averaged temperature </summary> 
        public double DaytimeTemperature
        {
            get { return _DaytimeTemperature; }
            set { this._DaytimeTemperature = value; }
        }
		/// <summary>Elevation </summary> 
		public double Elevation
		{
			get {return _Elevation;}
			set {this._Elevation = value;}
		}
		/// <summary>Daily global solar radiation ouside earth atmosphere  </summary> 
		public double ExtraterrestrialRadiation
		{
			get {return _ExtraterrestrialRadiation;}
			set {this._ExtraterrestrialRadiation = value;}
		}
		/// <summary>Daily global solar radiation at ground level </summary> 
		public double GlobalSolarRadiation
		{
			get {return _GlobalSolarRadiation;}
			set {this._GlobalSolarRadiation = value;}
		}
		/// <summary>Latent heat of vaporization </summary> 
		public double LatentHeatOfVaporization
		{
			get {return _LatentHeatOfVaporization;}
			set {this._LatentHeatOfVaporization = value;}
		}
		/// <summary>Net isothermal long wave radiation </summary> 
		public double LongWaveNetRadiation
		{
			get {return _LongWaveNetRadiation;}
			set {this._LongWaveNetRadiation = value;}
		}
		/// <summary>Maximum vapour pressure deficit </summary> 
		public double MaximumVapourPressureDeficit
		{
			get {return _MaximumVapourPressureDeficit;}
			set {this._MaximumVapourPressureDeficit = value;}
		}
		/// <summary>Psychrometric constant</summary> 
		public double PsychrometricConstant
		{
			get {return _PsychrometricConstant;}
			set {this._PsychrometricConstant = value;}
		}

		/// <summary>Net radiation</summary> 
		public double NetRadiation
		{
			get {return _NetRadiation;}
			set {this._NetRadiation = value;}
		}
        /// <summary> Pan coefficient</summary>
        public double PanCoefficient
        {
            get { return _PanCoefficient; }
            set { this._PanCoefficient = value; }
        }
        /// <summary> Class A pan evaporation</summary>
        public double PanEvaporationClassA
        {
            get { return _PanEvaporationClassA; }
            set { this._PanEvaporationClassA = value; }
        }
        /// <summary> Fetch distance</summary>
        public double FetchDistance
        {
            get { return _FetchDistance; }
            set { this._FetchDistance = value; }
        }

		/// <summary> Priestley taylor coefficient</summary>
		public double PriestleyTaylorCoefficient
		{
			get {return _PriestleyTaylorCoefficient;}
			set {this._PriestleyTaylorCoefficient = value;}
		}
		
		/// <summary>Reference evapotranspiration </summary> 
		public double ReferenceEvapotranspiration
		{
			get {return _ReferenceEvapotranspiration;}
			set {this._ReferenceEvapotranspiration = value;}
		}
        /// <summary>Global evapotranspiration </summary> 
		public double GlobalEvapotranspiration
		{
			get {return _GlobalEvapotranspiration;}
			set {this._GlobalEvapotranspiration = value;}
		}
		/// <summary>Maximum relative air humidity  </summary> 
		public double RelativeAirHumidityMax
		{
			get {return _RelativeAirHumidityMax;}
			set {this._RelativeAirHumidityMax = value;}
		}
		/// <summary>Minimum relative air humidity </summary> 
		public double RelativeAirHumidityMin
		{
			get {return _RelativeAirHumidityMin;}
			set {this._RelativeAirHumidityMin = value;}
		}
        /// <summary>Relative air humidity  </summary> 
        public double RelativeAirHumidity
        {
            get { return _RelativeAirHumidity; }
            set { this._RelativeAirHumidity = value; }
        }
        /// <summary>Rick Allen Constant </summary> 
        public double RickAllenConstant
        {
            get { return _RickAllenConstant; }
            set { this._RickAllenConstant = value; }
        }
		/// <summary>Saturation vapour pressure </summary> 
		public double SaturationVapourPressure
		{
			get {return _SaturationVapourPressure;}
			set {this._SaturationVapourPressure = value;}
		}
		/// <summary>Net short wave radiation </summary> 
		public double ShortWaveNetRadiation
		{
			get {return _ShortWaveNetRadiation;}
			set {this._ShortWaveNetRadiation = value;}
		}
		/// <summary>Slope saturated vapour pressure curve </summary> 
		public double SlopeVapourPressure
		{
			get {return _SlopeVapourPressure;}
			set {this._SlopeVapourPressure = value;}
		}
		/// <summary>Soil heat flux </summary> 
		public double SoilHeatFlux
		{
			get {return _SoilHeatFlux;}
			set {this._SoilHeatFlux = value;}
		}
		/// <summary>Vapour PressureDeficit </summary> 
		public double VapourPressureDeficit
		{
			get {return _VapourPressureDeficit;}
			set {this._VapourPressureDeficit = value;}
		}
		/// <summary>Wind speed </summary> 
		public double WindSpeed
		{
			get {return _WindSpeed;}
			set {this._WindSpeed = value;}
		}
		/// <summary>Wind measurement height </summary> 
		public double WindMeasurementHeight
		{
			get {return _WindMeasurementHeight;}
			set {this._WindMeasurementHeight = value;}
		}

        public virtual IDictionary<string, PropertyInfo> PropertiesDescription
        {
            get
            {
                return _parametersIO.GetCachedProperties(typeof(IDomainClass));
            }
        }

        public bool ClearValues()
        {
            _ActualVapourPressureHourly = new double[24];
            _AerodynamicResistanceHourly = new double[24];
            _DewPointTemperatureHourly = new double[24];
            _AirTemperatureHourly = new double[24];
            _AmbientTemperatureHourly = new double[24];
            _AtmosphericDensityHourly = new double[24];
            _ExtraterrestrialRadiationHourly = new double[24];
            _GlobalSolarRadiationHourly = new double[24];
            _LatentHeatOfVaporizationHourly = new double[24];
            _LeafTemperatureHourly = new double[24];
            _LongWaveNetRadiationHourly = new double[24];
            _NetRadiationHourly = new double[24];
            _PsychrometricConstantHourly = new double[24];
            _RadiativeResistanceHourly = new double[24];
            _ReferenceEvapotranspirationHourly = new double[24];
            _RelativeAirHumidityHourly = new double[24];
            _SaturationVapourPressureHourly = new double[24];
            _ShortWaveNetRadiationHourly = new double[24];
            _SlopeVapourPressureHourly = new double[24];
            _SoilHeatFluxHourly = new double[24];
            _VapourPressureDeficitHourly = new double[24];
            _WindSpeedHourly = new double[24];
            _LeafAreaIndexHourly = new double[24];
            _PotentialEvaporationHourly = new double[24];
            _ActualVapourPressure = default(double);
            _AerodynamicResistance = default(double);
            _DewPointTemperature = default(double);
            _DiurnalAirTemperatureRange = default(double);
            _AirHumidityFactor = default(double);
            _AirTemperatureMax = default(double);
            _AirTemperatureMin = default(double);
            _Albedo = default(double);
            _AtmosphericDensity = default(double);
            _ClearSkyTransmissivity = default(double);
            _CloudinessFactor = default(double);
            _DaytimeTemperature = default(double);
            _Elevation = default(double);
            _ExtraterrestrialRadiation = default(double);
            _GlobalSolarRadiation = default(double);
            _LatentHeatOfVaporization = default(double);
            _LongWaveNetRadiation = default(double);
            _MaximumVapourPressureDeficit = default(double);
            _NetRadiation = default(double);
            _NormalizedDifferenceVegetationIndex = default(double);
            _PriestleyTaylorCoefficient = default(double);
            _PsychrometricConstant = default(double);
            _ReferenceEvapotranspiration = default(double);
            _GlobalEvapotranspiration = default(double);
            _PanCoefficient = default(double);
            _PanEvaporationClassA = default(double);
            _FetchDistance = default(double);
            _RelativeAirHumidityMax = default(double);
            _RelativeAirHumidityMin = default(double);
            _RelativeAirHumidity = default(double);
            _RickAllenConstant = default(double);
            _SaturationVapourPressure = default(double);
            _ShortWaveNetRadiation = default(double);
            _SlopeVapourPressure = default(double);
            _SoilHeatFlux = default(double);
            _VapourPressureDeficit = default(double);
            _WindSpeed = default(double);
            _WindMeasurementHeight = default(double);
            // Returns true if everything is ok
            return true;

        }


        #endregion
    }
}
