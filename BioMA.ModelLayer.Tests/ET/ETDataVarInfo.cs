using CRA.ModelLayer.Core;
using System;

namespace CRA.Clima.ET.Interfaces
{
	/// <summary>
	/// ETDataVarInfo contains the attributes for each variable in the domain class ETData.
	/// Attributes are valorized via the static constructor. The data-type VarInfo causes
	/// a dependency to the assembly CRA.Core.Preconditions.dll
	/// </summary>
    /// <remarks>June 2005</remarks>

    public class ETDataVarInfo : IVarInfoClass
	{
		static ETDataVarInfo()
		{
		DescribeVariables();
		}
        
        #region IVarInfoClass members
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

        /// <summary>Value domain class of reference</summary>
        public virtual string DomainClassOfReference
        {
            get
            {
                return "ETData";
            }
        }
        #endregion

		//variables to hold property values
		private static VarInfo _ActualVapourPressureHourly = new VarInfo();
		private static VarInfo _AerodynamicResistanceHourly = new VarInfo();
		private static VarInfo _DewPointTemperatureHourly = new VarInfo();
		private static VarInfo _AirTemperatureHourly = new VarInfo();
		private static VarInfo _AmbientTemperatureHourly = new VarInfo();
		private static VarInfo _AtmosphericDensityHourly = new VarInfo();
		private static VarInfo _ExtraterrestrialRadiationHourly = new VarInfo();
		private static VarInfo _GlobalSolarRadiationHourly = new VarInfo();
		private static VarInfo _LatentHeatOfVaporizationHourly = new VarInfo();
		private static VarInfo _LeafAreaIndexHourly = new VarInfo();
		private static VarInfo _LeafTemperatureHourly = new VarInfo();
		private static VarInfo _LongWaveNetRadiationHourly = new VarInfo();
		private static VarInfo _NetRadiationHourly = new VarInfo();
		private static VarInfo _PsychrometricConstantHourly = new VarInfo();
		private static VarInfo _RadiativeResistanceHourly = new VarInfo();
		private static VarInfo _ReferenceEvapotranspirationHourly = new VarInfo();
		private static VarInfo _RelativeAirHumidityHourly = new VarInfo();
		private static VarInfo _SaturationVapourPressureHourly = new VarInfo();
		private static VarInfo _ShortWaveNetRadiationHourly = new VarInfo();
		private static VarInfo _SlopeVapourPressureHourly = new VarInfo();
		private static VarInfo _SoilHeatFluxHourly = new VarInfo();
		private static VarInfo _VapourPressureDeficitHourly = new VarInfo();
		private static VarInfo _WindSpeedHourly = new VarInfo();
        private static VarInfo _PotentialEvaporationHourly = new VarInfo(); 
        private static VarInfo _ActualVapourPressure = new VarInfo();
		private static VarInfo _AerodynamicResistance = new VarInfo();
		private static VarInfo _DewPointTemperature = new VarInfo();
		private static VarInfo _AirHumidityFactor = new VarInfo();
		private static VarInfo _AirTemperatureMax = new VarInfo();
		private static VarInfo _AirTemperatureMin = new VarInfo();
		private static VarInfo _Albedo = new VarInfo();
		private static VarInfo _AtmosphericDensity = new VarInfo();
		private static VarInfo _ClearSkyTransmissivity = new VarInfo();
		private static VarInfo _CloudinessFactor = new VarInfo();
		private static VarInfo _Elevation = new VarInfo();
		private static VarInfo _ExtraterrestrialRadiation = new VarInfo();
		private static VarInfo _GlobalSolarRadiation = new VarInfo();
		private static VarInfo _LatentHeatOfVaporization = new VarInfo();
		private static VarInfo _LongWaveNetRadiation = new VarInfo();
		private static VarInfo _MaximumVapourPressureDeficit = new VarInfo();
		private static VarInfo _NetRadiation = new VarInfo();
        private static VarInfo _NormalizedDifferenceVegetationIndex = new VarInfo();
        private static VarInfo _DaytimeTemperature = new VarInfo();
        private static VarInfo _DiurnalAirTemperatureRange = new VarInfo();
		private static VarInfo _PriestleyTaylorCoefficient = new VarInfo();
		private static VarInfo _PsychrometricConstant = new VarInfo();
		private static VarInfo _ReferenceEvapotranspiration = new VarInfo();
        private static VarInfo _GlobalEvapotranspiration = new VarInfo();
        private static VarInfo _PanCoefficient = new VarInfo();
        private static VarInfo _PanEvaporationClassA = new VarInfo();
        private static VarInfo _FetchDistance = new VarInfo();
		private static VarInfo _RelativeAirHumidityMax = new VarInfo();
		private static VarInfo _RelativeAirHumidityMin = new VarInfo();
        private static VarInfo _RelativeAirHumidity = new VarInfo();
        private static VarInfo _RickAllenConstant = new VarInfo();
		private static VarInfo _SaturationVapourPressure = new VarInfo();
		private static VarInfo _ShortWaveNetRadiation = new VarInfo();
		private static VarInfo _SlopeVapourPressure = new VarInfo();
		private static VarInfo _SoilHeatFlux = new VarInfo();
		private static VarInfo _VapourPressureDeficit = new VarInfo();
		private static VarInfo _WindSpeed = new VarInfo();
		private static VarInfo _WindMeasurementHeight = new VarInfo();

	#region static property
		/// <summary>Hourly actual vapour pressure</summary>
		public static VarInfo ActualVapourPressureHourly
		{
		get	{ return _ActualVapourPressureHourly; }
		}
		/// <summary>Hourly aerodynamic resistance</summary>
		public static VarInfo AerodynamicResistanceHourly
		{
		get	{ return _AerodynamicResistanceHourly; }
		}
		/// <summary>Hourly dew point temperature</summary>
		public static VarInfo DewPointTemperatureHourly
		{
		get	{ return _DewPointTemperatureHourly; }
		}
		/// <summary>Hourly air temperature</summary>
		public static VarInfo AirTemperatureHourly
		{
		get	{ return _AirTemperatureHourly; }
		}
		/// <summary>Ambient hourly air temperature</summary>
		public static VarInfo AmbientTemperatureHourly
		{
		get	{ return _AmbientTemperatureHourly; }
		}
		/// <summary>Hourly atmospheric density</summary>
		public static VarInfo AtmosphericDensityHourly
		{
		get	{ return _AtmosphericDensityHourly; }
		}
		/// <summary>Hourly extraterrestrial radiation</summary>
		public static VarInfo ExtraterrestrialRadiationHourly
		{
		get	{ return _ExtraterrestrialRadiationHourly; }
		}
		/// <summary>Hourly global solar radiation outside earth atmosphere</summary>
		public static VarInfo GlobalSolarRadiationHourly
		{
		get	{ return _GlobalSolarRadiationHourly; }
		}
		/// <summary>Hourly latent heat of vaporization</summary>
		public static VarInfo LatentHeatOfVaporizationHourly
		{
		get	{ return _LatentHeatOfVaporizationHourly; }
		}
		/// <summary>Hourly leaf area index</summary>
		public static VarInfo LeafAreaIndexHourly
		{
			get	{ return _LeafAreaIndexHourly; }
		}
		/// <summary>Hourly leaf temperature</summary>
		public static VarInfo LeafTemperatureHourly
		{
		get	{ return _LeafTemperatureHourly; }
		}
		/// <summary>Hourly isothermal long wave net radiation</summary>
		public static VarInfo LongWaveNetRadiationHourly
		{
		get	{ return _LongWaveNetRadiationHourly; }
		}
		/// <summary>Hourly net radiation</summary>
		public static VarInfo NetRadiationHourly
		{
		get	{ return _NetRadiationHourly; }
		}
        /// <summary>Normalized difference vegetation index</summary>
        public static VarInfo NormalizedDifferenceVegetationIndex
        {
            get { return _NormalizedDifferenceVegetationIndex; }
        }
        /// <summary>Daytime-averaged air temperature</summary>
        public static VarInfo DaytimeTemperature
        {
            get { return _DaytimeTemperature; }
        }
        /// <summary>Diurnal air temperature range</summary>
        public static VarInfo DiurnalAirTemperatureRange
        {
            get { return _DiurnalAirTemperatureRange; }
        }
		/// <summary>Priestley taylor constant</summary>
		public static VarInfo PriestleyTaylorCoefficient
		{
			get	{ return _PriestleyTaylorCoefficient; }
		}
		/// <summary>Psychrometric constant hourly</summary>
		public static VarInfo PsychrometricConstantHourly
		{
		get	{ return _PsychrometricConstantHourly; }
		}
		/// <summary>Hourly radiative resistance</summary>
		public static VarInfo RadiativeResistanceHourly
		{
		get	{ return _RadiativeResistanceHourly; }
		}
		/// <summary>Hourly reference evapotranspiration</summary>
		public static VarInfo ReferenceEvapotranspirationHourly
		{
		get	{ return _ReferenceEvapotranspirationHourly; }
		}
		/// <summary>Hourly relative air humidity</summary>
		public static VarInfo RelativeAirHumidityHourly
		{
		get	{ return _RelativeAirHumidityHourly; }
		}
		/// <summary>Hourly saturation vapour pressure</summary>
		public static VarInfo SaturationVapourPressureHourly
		{
		get	{ return _SaturationVapourPressureHourly; }
		}
		/// <summary>Hourly short wave net radiation</summary>
		public static VarInfo ShortWaveNetRadiationHourly
		{
		get	{ return _ShortWaveNetRadiationHourly; }
		}
		/// <summary>Hourly slope saturated vapour pressure deficit</summary>
		public static VarInfo SlopeVapourPressureHourly
		{
		get	{ return _SlopeVapourPressureHourly; }
		}
		/// <summary>Hourly slope vapour pressure deficit</summary>
		public static VarInfo SoilHeatFluxHourly
		{
		get	{ return _SoilHeatFluxHourly; }
		}
		/// <summary>Hourly vapour pressure deficit</summary>
		public static VarInfo VapourPressureDeficitHourly
		{
		get	{ return _VapourPressureDeficitHourly; }
		}
		/// <summary>Hourly wind speed</summary>
		public static VarInfo WindSpeedHourly
		{
		get	{ return _WindSpeedHourly; }
		}
        /// <summary>Hourly potential evaporation</summary>
        public static VarInfo PotentialEvaporationHourly
        {
            get { return _PotentialEvaporationHourly; }
        }

		/// <summary>Actual vapour pressure</summary>
		public static VarInfo ActualVapourPressure
		{
		get	{ return _ActualVapourPressure; }
		}
		/// <summary>Canopy aerodynamic resistance</summary>
		public static VarInfo AerodynamicResistance
		{
		get	{ return _AerodynamicResistance; }
		}
		/// <summary>Air dew point temperature</summary>
		public static VarInfo DewPointTemperature
		{
		get	{ return _DewPointTemperature; }
		}
		/// <summary>Air humidity factor</summary>
		public static VarInfo AirHumidityFactor
		{
		get	{ return _AirHumidityFactor; }
		}
		/// <summary>Daily maximum air temperature</summary>
		public static VarInfo AirTemperatureMax
		{
		get	{ return _AirTemperatureMax; }
		}
        /// <summary>Daily minimum air temperature</summary>
		public static VarInfo AirTemperatureMin
		{
		get	{ return _AirTemperatureMin; }
		}
		/// <summary>Albedo</summary>
		public static VarInfo Albedo
		{
		get	{ return _Albedo; }
		}
		/// <summary>Atmospheric density</summary>
		public static VarInfo AtmosphericDensity
		{
		get	{ return _AtmosphericDensity; }
		}
		/// <summary>Fraction of clear sky global radiation at ground level</summary>
		public static VarInfo ClearSkyTransmissivity
		{
		get	{ return _ClearSkyTransmissivity; }
		}
		/// <summary>Cloudiness factor</summary>
		public static VarInfo CloudinessFactor
		{
		get	{ return _CloudinessFactor; }
		}
		/// <summary>Elevation</summary>
		public static VarInfo Elevation
		{
		get	{ return _Elevation; }
		}
		/// <summary>Daily global solar radiation ouside earth atmosphere </summary>
		public static VarInfo ExtraterrestrialRadiation
		{
		get	{ return _ExtraterrestrialRadiation; }
		}
		/// <summary>Daily global solar radiation at ground level</summary>
		public static VarInfo GlobalSolarRadiation
		{
		get	{ return _GlobalSolarRadiation; }
		}
		/// <summary>Latent heat of vaporization</summary>
		public static VarInfo LatentHeatOfVaporization
		{
		get	{ return _LatentHeatOfVaporization; }
		}
		/// <summary>Net isothermal long wave radiation</summary>
		public static VarInfo LongWaveNetRadiation
		{
		get	{ return _LongWaveNetRadiation; }
		}
		/// <summary>Maximum vapour pressure deficit</summary>
		public static VarInfo MaximumVapourPressureDeficit
		{
		get	{ return _MaximumVapourPressureDeficit; }
		}
		/// <summary>Net radiation</summary>
		public static VarInfo NetRadiation
		{
		get	{ return _NetRadiation; }
		}
		/// <summary>Psychrometric constant</summary>
		public static VarInfo PsychrometricConstant
		{
			get	{ return _PsychrometricConstant; }
		}
		/// <summary>Reference evapotranspiration</summary>
		public static VarInfo ReferenceEvapotranspiration
		{
		get	{ return _ReferenceEvapotranspiration; }
		}
        /// <summary>Global evapotranspiration</summary>
		public static VarInfo GlobalEvapotranspiration
		{
		get	{ return _GlobalEvapotranspiration; }
		}
		/// <summary>Maximum relative air humidity </summary>
		public static VarInfo RelativeAirHumidityMax
		{
		get	{ return _RelativeAirHumidityMax; }
		}
        /// <summary>Pan coefficient</summary>
        public static VarInfo PanCoefficient
        {
            get { return _PanCoefficient; }
        }
        /// <summary>Class A pan evaporation</summary>
        public static VarInfo PanEvaporationClassA
        {
            get { return _PanEvaporationClassA; }
        }
        /// <summary>Fetch distance</summary>
        public static VarInfo FetchDistance
        {
            get { return _FetchDistance; }
        }
		/// <summary>Minimum relative air humidity</summary>
		public static VarInfo RelativeAirHumidityMin
		{
		get	{ return _RelativeAirHumidityMin; }
		}
        /// <summary>Relative air humidity </summary>
        public static VarInfo RelativeAirHumidity
        {
            get { return _RelativeAirHumidity; }
        }
	    /// <summary>Rick Allen Constant</summary>
	    public static VarInfo RickAllenConstant
        {
            get { return _RickAllenConstant; }
        }
		/// <summary>Saturation vapour pressure</summary>
		public static VarInfo SaturationVapourPressure
		{
		get	{ return _SaturationVapourPressure; }
		}
		/// <summary>Short wave net radiation</summary>
		public static VarInfo ShortWaveNetRadiation
		{
		get	{ return _ShortWaveNetRadiation; }
		}
		/// <summary>Slope saturated vapour pressure curve</summary>
		public static VarInfo SlopeVapourPressure
		{
		get	{ return _SlopeVapourPressure; }
		}
		/// <summary>Soil heat flux</summary>
		public static VarInfo SoilHeatFlux
		{
		get	{ return _SoilHeatFlux; }
		}
		/// <summary>Vapour PressureDeficit</summary>
		public static VarInfo VapourPressureDeficit
		{
		get	{ return _VapourPressureDeficit; }
		}
		/// <summary>Wind speed</summary>
		public static VarInfo WindSpeed
		{
		get	{ return _WindSpeed; }
		}
		/// <summary>Wind measurement height</summary>
		public static VarInfo WindMeasurementHeight
		{
		get	{ return _WindMeasurementHeight; }
		}
	#endregion

	#region static constructor: variables description

		private static void DescribeVariables()
		{
		//INPUTS AND OUTPUTS
		//current value is set within strategies / models using the data
		_ActualVapourPressureHourly.Description = "Hourly actual vapour pressure";
		_ActualVapourPressureHourly.Name = "ActualVapourPressureHourly";
		_ActualVapourPressureHourly.DefaultValue = 1;
		_ActualVapourPressureHourly.MaxValue = 7.18;
		_ActualVapourPressureHourly.MinValue = 0.03;
		_ActualVapourPressureHourly.Units = "kPa";

		_AerodynamicResistanceHourly.Description = "Hourly aerodynamic resistance";
		_AerodynamicResistanceHourly.Name = "AerodynamicResistanceHourly";
		_AerodynamicResistanceHourly.DefaultValue = 50;
		_AerodynamicResistanceHourly.MaxValue = 665;
		_AerodynamicResistanceHourly.MinValue = 21;
		_AerodynamicResistanceHourly.Units = "s m-1";

		_DewPointTemperatureHourly.Description = "Hourly dew point temperature";
		_DewPointTemperatureHourly.Name = "DewPointTemperatureHourly";
		_DewPointTemperatureHourly.DefaultValue = 5;
		_DewPointTemperatureHourly.MaxValue = 15;
		_DewPointTemperatureHourly.MinValue = -10;
		_DewPointTemperatureHourly.Units = "°C";

		_AirTemperatureHourly.Description = "Hourly air temperature";
		_AirTemperatureHourly.Name = "AirTemperatureHourly";
		_AirTemperatureHourly.DefaultValue = 10;
		_AirTemperatureHourly.MaxValue = 50;
		_AirTemperatureHourly.MinValue = -25;
		_AirTemperatureHourly.Units = "°C";

		_AmbientTemperatureHourly.Description = "Ambient hourly air temperature";
		_AmbientTemperatureHourly.Name = "AmbientTemperatureHourly";
		_AmbientTemperatureHourly.DefaultValue = 10;
		_AmbientTemperatureHourly.MaxValue = 50;
		_AmbientTemperatureHourly.MinValue = -25;
		_AmbientTemperatureHourly.Units = "°C";

		_AtmosphericDensityHourly.Description = "Hourly atmospheric density";
		_AtmosphericDensityHourly.Name = "AtmosphericDensityHourly";
		_AtmosphericDensityHourly.DefaultValue = 1.2183;
		_AtmosphericDensityHourly.MaxValue = 1.3902;
		_AtmosphericDensityHourly.MinValue = 1.0675;
		_AtmosphericDensityHourly.Units = "kg m-3";

		_ExtraterrestrialRadiationHourly.Description = "Hourly extraterrestrial radiation";
		_ExtraterrestrialRadiationHourly.Name = "ExtraterrestrialRadiationHourly";
		_ExtraterrestrialRadiationHourly.DefaultValue = 2;
		_ExtraterrestrialRadiationHourly.MaxValue = 3;
		_ExtraterrestrialRadiationHourly.MinValue = 0;
		_ExtraterrestrialRadiationHourly.Units = "MJ m-2 h-1";

		_GlobalSolarRadiationHourly.Description = "Hourly global solar radiation at ground level";
		_GlobalSolarRadiationHourly.Name = "GlobalSolarRadiationHourly";
		_GlobalSolarRadiationHourly.DefaultValue = 3;
		_GlobalSolarRadiationHourly.MaxValue = 4;
		_GlobalSolarRadiationHourly.MinValue = 0;
		_GlobalSolarRadiationHourly.Units = "MJ m-2 h-1";

		_LatentHeatOfVaporizationHourly.Description = "Hourly latent heat of vaporization";
		_LatentHeatOfVaporizationHourly.Name = "LatentHeatOfVaporizationHourly";
		_LatentHeatOfVaporizationHourly.DefaultValue = 2.54;
		_LatentHeatOfVaporizationHourly.MaxValue = 2.57;
		_LatentHeatOfVaporizationHourly.MinValue = 2.38;
		_LatentHeatOfVaporizationHourly.Units = "MJ kg-1";

		_LeafAreaIndexHourly.Description = "Hourly leaf area index";
		_LeafAreaIndexHourly.Name = "LeafAreaIndexHourly";
		_LeafAreaIndexHourly.DefaultValue = 1;
		_LeafAreaIndexHourly.MaxValue = 15;
		_LeafAreaIndexHourly.MinValue = 0;
		_LeafAreaIndexHourly.Units = "m2 m-2";

		_LeafTemperatureHourly.Description = "Hourly leaf temperature";
		_LeafTemperatureHourly.Name = "LeafTemperatureHourly";
		_LeafTemperatureHourly.DefaultValue = 20;
		_LeafTemperatureHourly.MaxValue = 55;
		_LeafTemperatureHourly.MinValue = -5;
		_LeafTemperatureHourly.Units = "°C";

		_LongWaveNetRadiationHourly.Description = "Hourly isothermal long wave net radiation";
		_LongWaveNetRadiationHourly.Name = "LongWaveNetRadiationHourly";
		_LongWaveNetRadiationHourly.DefaultValue = 1;
		_LongWaveNetRadiationHourly.MaxValue = 6.85;
		_LongWaveNetRadiationHourly.MinValue = -0.48;
		_LongWaveNetRadiationHourly.Units = "MJ m-2 d-1";

		_NetRadiationHourly.Description = "Hourly net radiation";
		_NetRadiationHourly.Name = "NetRadiationHourly";
		_NetRadiationHourly.DefaultValue = 22;
		_NetRadiationHourly.MaxValue = 27.4;
		_NetRadiationHourly.MinValue = -6.78;
		_NetRadiationHourly.Units = "MJ m-2 d-1";

        _NormalizedDifferenceVegetationIndex.Description = "Daily normalized difference vegetation index";
        _NormalizedDifferenceVegetationIndex.Name = "NormalizedDifferenceVegetationIndex";
        _NormalizedDifferenceVegetationIndex.DefaultValue = 0.2;
        _NormalizedDifferenceVegetationIndex.MaxValue = 1;
        _NormalizedDifferenceVegetationIndex.MinValue = -1;
        _NormalizedDifferenceVegetationIndex.Units = "Unitless";

        _DaytimeTemperature.Description = "Daytime-averaged air temperature";
        _DaytimeTemperature.Name = "DaytimeTemperature";
        _DaytimeTemperature.DefaultValue = 20;
        _DaytimeTemperature.MaxValue = 50;
        _DaytimeTemperature.MinValue = -25;
        _DaytimeTemperature.Units = "°C";

        _DiurnalAirTemperatureRange.Description = "Diurnal air temperature range";
        _DiurnalAirTemperatureRange.Name = "DiurnalAirTemperatureRange";
        _DiurnalAirTemperatureRange.DefaultValue = 35;
        _DiurnalAirTemperatureRange.MaxValue = 75;
        _DiurnalAirTemperatureRange.MinValue = 0;
        _DiurnalAirTemperatureRange.Units = "°C";

		_PsychrometricConstantHourly.Description = "Hourly psychrometric constant";
		_PsychrometricConstantHourly.Name = "PsychrometricConstantHourly";
		_PsychrometricConstantHourly.DefaultValue = 0.064119;
		_PsychrometricConstantHourly.MinValue = 0.06;
		_PsychrometricConstantHourly.MaxValue = 0.07;
		_PsychrometricConstantHourly.Units = "kPa °C-1";

		_RadiativeResistanceHourly.Description = "Hourly radiative resistance";
		_RadiativeResistanceHourly.Name = "RadiativeResistanceHourly";
		_RadiativeResistanceHourly.DefaultValue = 239.7497;
		_RadiativeResistanceHourly.MaxValue = 406.4107;
		_RadiativeResistanceHourly.MinValue = 141.322;
		_RadiativeResistanceHourly.Units = "s m-1";

		_ReferenceEvapotranspirationHourly.Description = "Hourly reference evapotranspiration";
		_ReferenceEvapotranspirationHourly.Name = "ReferenceEvapotranspirationHourly";
		_ReferenceEvapotranspirationHourly.DefaultValue = 0;
		_ReferenceEvapotranspirationHourly.MaxValue = 2;
		_ReferenceEvapotranspirationHourly.MinValue = 0;
		_ReferenceEvapotranspirationHourly.Units = "mm h-1";

        _PotentialEvaporationHourly.Description = "Hourly potential evaporation";
        _PotentialEvaporationHourly.Name = "PotentialEvaporationHourly";
        _PotentialEvaporationHourly.DefaultValue = 0;
        _PotentialEvaporationHourly.MaxValue = 2;
        _PotentialEvaporationHourly.MinValue = 0;
        _PotentialEvaporationHourly.Units = "mm h-1";

		_RelativeAirHumidityHourly.Description = "Hourly relative air humidity";
		_RelativeAirHumidityHourly.Name = "RelativeAirHumidityHourly";
		_RelativeAirHumidityHourly.DefaultValue = 65;
		_RelativeAirHumidityHourly.MaxValue = 100;
		_RelativeAirHumidityHourly.MinValue = 10;
		_RelativeAirHumidityHourly.Units = "%";

		_SaturationVapourPressureHourly.Description = "Hourly saturation vapour pressure";
		_SaturationVapourPressureHourly.Name = "SaturationVapourPressureHourly";
		_SaturationVapourPressureHourly.DefaultValue = 1;
		_SaturationVapourPressureHourly.MaxValue = 12.3;
		_SaturationVapourPressureHourly.MinValue = 0.05;
		_SaturationVapourPressureHourly.Units = "kPa";

		_ShortWaveNetRadiationHourly.Description = "Hourly short wave net radiation";
		_ShortWaveNetRadiationHourly.Name = "ShortWaveNetRadiationHourly";
		_ShortWaveNetRadiationHourly.DefaultValue = 22;
		_ShortWaveNetRadiationHourly.MaxValue = 27.4;
		_ShortWaveNetRadiationHourly.MinValue = -6.78;
		_ShortWaveNetRadiationHourly.Units = "MJ m-2 d-1";

		_SlopeVapourPressureHourly.Description = "Hourly slope saturated vapour pressure";
		_SlopeVapourPressureHourly.Name = "SlopeVapourPressureHourly";
		_SlopeVapourPressureHourly.DefaultValue = 0.3;
		_SlopeVapourPressureHourly.MaxValue = 0.869;
		_SlopeVapourPressureHourly.MinValue = 0.005;
		_SlopeVapourPressureHourly.Units = "kPa C°-1";

		_SoilHeatFluxHourly.Description = "Hourly soil heat flux";
		_SoilHeatFluxHourly.Name = "SoilHeatFluxHourly";
		_SoilHeatFluxHourly.DefaultValue = 2.2;
		_SoilHeatFluxHourly.MaxValue = 13.7;
		_SoilHeatFluxHourly.MinValue = -3.39;
		_SoilHeatFluxHourly.Units = "MJ m-2 h-1";

		_VapourPressureDeficitHourly.Description = "Hourly vapour pressure deficit";
		_VapourPressureDeficitHourly.Name = "VapourPressureDeficitHourly";
		_VapourPressureDeficitHourly.DefaultValue = 1;
		_VapourPressureDeficitHourly.MaxValue = 12.31;
		_VapourPressureDeficitHourly.MinValue = 0;
		_VapourPressureDeficitHourly.Units = "kPa";

		_WindSpeedHourly.Description = "Hourly wind speed";
		_WindSpeedHourly.Name = "WindSpeedHourly";
		_WindSpeedHourly.DefaultValue = 1;
		_WindSpeedHourly.MaxValue = 100;
		_WindSpeedHourly.MinValue = 0;
		_WindSpeedHourly.Units = "m s-1";

		_PotentialEvaporationHourly.Description = "Potential evaporation hourly";
		_PotentialEvaporationHourly.Name = "PotentialEvaporationHourly";
		_PotentialEvaporationHourly.DefaultValue = 0;
		_PotentialEvaporationHourly.MaxValue = 3;
		_PotentialEvaporationHourly.MinValue = 0;
		_PotentialEvaporationHourly.Units = "mm h-1";

		_ActualVapourPressure.Description = "Actual vapour pressure";
		_ActualVapourPressure.Name = "ActualVapourPressure";
		_ActualVapourPressure.DefaultValue = 1;
		_ActualVapourPressure.MaxValue = 7.18;
		_ActualVapourPressure.MinValue = 0.03;
		_ActualVapourPressure.Units = "kPa";

		_AerodynamicResistance.Description = "Aerodynamic resistance";
		_AerodynamicResistance.Name = "AerodynamicResistance";
		_AerodynamicResistance.DefaultValue = 50;
		_AerodynamicResistance.MaxValue = 665;
		_AerodynamicResistance.MinValue = 21;
		_AerodynamicResistance.Units = "s m-1";

		_DewPointTemperature.Description = "Air dew point temperature";
		_DewPointTemperature.Name = "DewPointTemperature";
		_DewPointTemperature.DefaultValue = 5;
		_DewPointTemperature.MaxValue = 15;
		_DewPointTemperature.MinValue = -10;
		_DewPointTemperature.Units = "°C";

		_AirHumidityFactor.Description = "Air humidity factor";
		_AirHumidityFactor.Name = "AirHumidityFactor";
		_AirHumidityFactor.DefaultValue = 0.2;
		_AirHumidityFactor.MaxValue = 0.31575;
		_AirHumidityFactor.MinValue = -0.035137;
		_AirHumidityFactor.Units = "Unitless";

		_AirTemperatureMax.Description = "Daily maximum air temperature";
		_AirTemperatureMax.Name = "AirTemperatureMax";
		_AirTemperatureMax.DefaultValue = 15;
		_AirTemperatureMax.MaxValue = 50;
		_AirTemperatureMax.MinValue = -10;
		_AirTemperatureMax.Units = "°C";

		_AirTemperatureMin.Description = "Daily minimum air temperature";
		_AirTemperatureMin.Name = "AirTemperatureMin";
		_AirTemperatureMin.DefaultValue = 5;
		_AirTemperatureMin.MaxValue = 35;
		_AirTemperatureMin.MinValue = -25;
		_AirTemperatureMin.Units = "°C";

		_Albedo.Description = "Albedo";
		_Albedo.Name = "Albedo";
		_Albedo.DefaultValue = 0.2;
		_Albedo.MaxValue = 0.9;
		_Albedo.MinValue = 0.05;
		_Albedo.Units = "Unitless";

		_AtmosphericDensity.Description = "Atmospheric density";
		_AtmosphericDensity.Name = "AtmosphericDensity";
		_AtmosphericDensity.DefaultValue = 1.1768;
		_AtmosphericDensity.MaxValue = 1.3902;
		_AtmosphericDensity.MinValue = 1.0675;
		_AtmosphericDensity.Units = "kg m-3";

		_ClearSkyTransmissivity.Description = "Fraction of clear sky global radiation at ground level";
		_ClearSkyTransmissivity.Name = "ClearSkyTransmissivity";
		_ClearSkyTransmissivity.DefaultValue = 0.75;
		_ClearSkyTransmissivity.MaxValue = 0.82;
		_ClearSkyTransmissivity.MinValue = 0.6;
		_ClearSkyTransmissivity.Units = "Unitless";

		_CloudinessFactor.Description = "Cloudiness factor";
		_CloudinessFactor.Name = "CloudinessFactor";
		_CloudinessFactor.DefaultValue = 0;
		_CloudinessFactor.MaxValue = 1;
		_CloudinessFactor.MinValue = -0.08;
		_CloudinessFactor.Units = "Unitless";

		_Elevation.Description = "Altitude";
		_Elevation.Name = "Elevation";
		_Elevation.DefaultValue = 0;
		_Elevation.MaxValue = 8000;
		_Elevation.MinValue = -100;
		_Elevation.Units = "m";

		_ExtraterrestrialRadiation.Description = "Daily global solar radiation outside earth atmosphere ";
		_ExtraterrestrialRadiation.Name = "ExtraterrestrialRadiation";
		_ExtraterrestrialRadiation.DefaultValue = 25;
		_ExtraterrestrialRadiation.MaxValue = 42;
		_ExtraterrestrialRadiation.MinValue = 5;
		_ExtraterrestrialRadiation.Units = "MJ m-2 d-1";

		_GlobalSolarRadiation.Description = "Daily global solar radiation at ground level";
		_GlobalSolarRadiation.Name = "GlobalSolarRadiation";
		_GlobalSolarRadiation.DefaultValue = 20;
		_GlobalSolarRadiation.MaxValue = 35;
		_GlobalSolarRadiation.MinValue = 0.1;
		_GlobalSolarRadiation.Units = "MJ m-2 d-1";

		_LatentHeatOfVaporization.Description = "Latent heat of vaporization";
		_LatentHeatOfVaporization.Name = "LatentHeatOfVaporization";
		_LatentHeatOfVaporization.DefaultValue = 2.54;
		_LatentHeatOfVaporization.MaxValue = 2.57;
		_LatentHeatOfVaporization.MinValue = 2.38;
		_LatentHeatOfVaporization.Units = "MJ kg-1";

		_LongWaveNetRadiation.Description = "Net isothermal long wave radiation";
		_LongWaveNetRadiation.Name = "LongWaveNetRadiation";
		_LongWaveNetRadiation.DefaultValue = 1;
		_LongWaveNetRadiation.MaxValue = 6.85;
		_LongWaveNetRadiation.MinValue = -0.48;
		_LongWaveNetRadiation.Units = "MJ m-2 d-1";

		_MaximumVapourPressureDeficit.Description = "Maximum vapour pressure deficit";
		_MaximumVapourPressureDeficit.Name = "MaximumVapourPressureDeficit";
		_MaximumVapourPressureDeficit.DefaultValue = 1;
		_MaximumVapourPressureDeficit.MaxValue = 12;
		_MaximumVapourPressureDeficit.MinValue = 0.02;
		_MaximumVapourPressureDeficit.Units = "kPa";

		_NetRadiation.Description = "Net radiation";
		_NetRadiation.Name = "NetRadiation";
		_NetRadiation.DefaultValue = 22;
		_NetRadiation.MaxValue = 27.4;
		_NetRadiation.MinValue = -6.78;
		_NetRadiation.Units = "MJ m-2 d-1";

		_PriestleyTaylorCoefficient.Description = "Priestley taylor coefficient";
		_PriestleyTaylorCoefficient.Name = "PriestleyTaylorCoefficient";
		_PriestleyTaylorCoefficient.DefaultValue = 1.26;
		_PriestleyTaylorCoefficient.MaxValue = 1.65;
		_PriestleyTaylorCoefficient.MinValue = 1.00;
		_PriestleyTaylorCoefficient.Units = "Unitless";

		_PsychrometricConstant.Description = "Psychrometric constant";
		_PsychrometricConstant.Name = "PsychrometricConstant";
		_PsychrometricConstant.DefaultValue = 0.064119;
		_PsychrometricConstant.MinValue = 0.06;
		_PsychrometricConstant.MaxValue = 0.07;
		_PsychrometricConstant.Units = "kPa °C-1";

		_ReferenceEvapotranspiration.Description = "Reference evapotranspiration";
		_ReferenceEvapotranspiration.Name = "ReferenceEvapotranspiration";
		_ReferenceEvapotranspiration.DefaultValue = 0;
		_ReferenceEvapotranspiration.MaxValue = 20;
		_ReferenceEvapotranspiration.MinValue = 0;
		_ReferenceEvapotranspiration.Units = "mm d-1";

        _FetchDistance.Description = "Fetch distance";
        _FetchDistance.Name = "FetchDistance";
        _FetchDistance.DefaultValue = 10;
        _FetchDistance.MaxValue = 1000;
        _FetchDistance.MinValue = 1;
        _FetchDistance.Units = "m";

        _PanCoefficient.Description = "Pan coefficient";
        _PanCoefficient.Name = "PanCoefficient";
        _PanCoefficient.DefaultValue = 0.50;
        _PanCoefficient.MaxValue = 0.85;
        _PanCoefficient.MinValue = 0.10;
        //_PanCoefficient.MinValue = 0.40;
        _PanCoefficient.Units = "Unitless";

        /*Rayner, D.P. Australian synthetic daily Class A pan 
          evaporation. © The State of Queensland, Department of 
          Natural Resources and Mines 2005.*/

        _PanEvaporationClassA.Description = "Class A pan evaporation";
        _PanEvaporationClassA.Name = "PanEvaporationClassA";
        _PanEvaporationClassA.DefaultValue = 0;
        _PanEvaporationClassA.MaxValue = 25;
        _PanEvaporationClassA.MinValue = 0;
        _PanEvaporationClassA.Units = "mm d-1";

        _GlobalEvapotranspiration.Description = "Global evapotranspiration";
        _GlobalEvapotranspiration.Name = "GlobalEvapotranspiration";
        _GlobalEvapotranspiration.DefaultValue = 0;
        _GlobalEvapotranspiration.MaxValue = 20;
        _GlobalEvapotranspiration.MinValue = 0;
        _GlobalEvapotranspiration.Units = "mm d-1";

		_RelativeAirHumidityMax.Description = "Maximum relative air humidity ";
		_RelativeAirHumidityMax.Name = "RelativeAirHumidityMax";
		_RelativeAirHumidityMax.DefaultValue = 85;
		_RelativeAirHumidityMax.MaxValue = 100;
		_RelativeAirHumidityMax.MinValue = 40;
		_RelativeAirHumidityMax.Units = "%";

		_RelativeAirHumidityMin.Description = "Minimum relative air humidity";
		_RelativeAirHumidityMin.Name = "RelativeAirHumidityMin";
		_RelativeAirHumidityMin.DefaultValue = 55;
		_RelativeAirHumidityMin.MaxValue = 100;
		_RelativeAirHumidityMin.MinValue = 10;
		_RelativeAirHumidityMin.Units = "%";

        _RelativeAirHumidity.Description = "Relative air humidity";
        _RelativeAirHumidity.Name = "RelativeAirHumidity";
        _RelativeAirHumidity.DefaultValue = 65;
        _RelativeAirHumidity.MaxValue = 100;
        _RelativeAirHumidity.MinValue = 10;
        _RelativeAirHumidity.Units = "%";

        _RickAllenConstant.Description = "Rick Allen Constant";
        _RickAllenConstant.Name = "RickAllenConstant";
        _RickAllenConstant.DefaultValue = 2;
        _RickAllenConstant.MaxValue = 5;
        _RickAllenConstant.MinValue = 0;
        _RickAllenConstant.Units = "°C";

		_SaturationVapourPressure.Description = "Saturation vapour pressure";
		_SaturationVapourPressure.Name = "SaturationVapourPressure";
		_SaturationVapourPressure.DefaultValue = 1;
		_SaturationVapourPressure.MaxValue = 12.3;
		_SaturationVapourPressure.MinValue = 0.05;
		_SaturationVapourPressure.Units = "kPa";

		_ShortWaveNetRadiation.Description = "Short wave net radiation";
		_ShortWaveNetRadiation.Name = "ShortWaveNetRadiation";
		_ShortWaveNetRadiation.DefaultValue = 22;
		_ShortWaveNetRadiation.MaxValue = 27.4;
		_ShortWaveNetRadiation.MinValue = -6.78;
		_ShortWaveNetRadiation.Units = "MJ m-2 d-1";

		_SlopeVapourPressure.Description = "Slope saturated vapour pressure curve";
		_SlopeVapourPressure.Name = "SlopeVapourPressure";
		_SlopeVapourPressure.DefaultValue = 0.3;
		_SlopeVapourPressure.MaxValue = 0.869;
		_SlopeVapourPressure.MinValue = 0.005;
		_SlopeVapourPressure.Units = "kPa C°-1";

		_SoilHeatFlux.Description = "Soil heat flux";
		_SoilHeatFlux.Name = "SoilHeatFlux";
		_SoilHeatFlux.DefaultValue = 0;
		_SoilHeatFlux.MaxValue = 1;
		_SoilHeatFlux.MinValue = -1;
		_SoilHeatFlux.Units = "MJ m-2 d-1";

		_VapourPressureDeficit.Description = "Vapour pressure deficit";
		_VapourPressureDeficit.Name = "VapourPressureDeficit";
		_VapourPressureDeficit.DefaultValue = 1;
		_VapourPressureDeficit.MaxValue = 12.31;
		_VapourPressureDeficit.MinValue = 0;
		_VapourPressureDeficit.Units = "kPa";

		_WindSpeed.Description = "Wind speed";
		_WindSpeed.Name = "WindSpeed";
		_WindSpeed.DefaultValue = 1;
		_WindSpeed.MaxValue = 100;
		_WindSpeed.MinValue = 0;
		_WindSpeed.Units = "m s-1";

		_WindMeasurementHeight.Description = "Wind measurement height";
		_WindMeasurementHeight.Name = "WindMeasurementHeight";
		_WindMeasurementHeight.DefaultValue = 2;
		_WindMeasurementHeight.MaxValue = 30;
		_WindMeasurementHeight.MinValue = 1;
		_WindMeasurementHeight.Units = "m";

            #region ValueTypes
            _ActualVapourPressureHourly.ValueType = VarInfoValueTypes.GetInstanceForName("ArrayDouble");
            _AerodynamicResistanceHourly.ValueType = VarInfoValueTypes.GetInstanceForName("ArrayDouble");
            _DewPointTemperatureHourly.ValueType = VarInfoValueTypes.GetInstanceForName("ArrayDouble");
            _AirTemperatureHourly.ValueType = VarInfoValueTypes.GetInstanceForName("ArrayDouble");
            _AmbientTemperatureHourly.ValueType = VarInfoValueTypes.GetInstanceForName("ArrayDouble");
            _AtmosphericDensityHourly.ValueType = VarInfoValueTypes.GetInstanceForName("ArrayDouble");
            _ExtraterrestrialRadiationHourly.ValueType = VarInfoValueTypes.GetInstanceForName("ArrayDouble");
            _GlobalSolarRadiationHourly.ValueType = VarInfoValueTypes.GetInstanceForName("ArrayDouble");
            _LatentHeatOfVaporizationHourly.ValueType = VarInfoValueTypes.GetInstanceForName("ArrayDouble");
            _LeafTemperatureHourly.ValueType = VarInfoValueTypes.GetInstanceForName("ArrayDouble");
            _LongWaveNetRadiationHourly.ValueType = VarInfoValueTypes.GetInstanceForName("ArrayDouble");
            _NetRadiationHourly.ValueType = VarInfoValueTypes.GetInstanceForName("ArrayDouble");
            _PsychrometricConstantHourly.ValueType = VarInfoValueTypes.GetInstanceForName("ArrayDouble");
            _RadiativeResistanceHourly.ValueType = VarInfoValueTypes.GetInstanceForName("ArrayDouble");
            _ReferenceEvapotranspirationHourly.ValueType = VarInfoValueTypes.GetInstanceForName("ArrayDouble");
            _RelativeAirHumidityHourly.ValueType = VarInfoValueTypes.GetInstanceForName("ArrayDouble");
            _SaturationVapourPressureHourly.ValueType = VarInfoValueTypes.GetInstanceForName("ArrayDouble");
            _ShortWaveNetRadiationHourly.ValueType = VarInfoValueTypes.GetInstanceForName("ArrayDouble");
            _SlopeVapourPressureHourly.ValueType = VarInfoValueTypes.GetInstanceForName("ArrayDouble");
            _SoilHeatFluxHourly.ValueType = VarInfoValueTypes.GetInstanceForName("ArrayDouble");
            _VapourPressureDeficitHourly.ValueType = VarInfoValueTypes.GetInstanceForName("ArrayDouble");
            _WindSpeedHourly.ValueType = VarInfoValueTypes.GetInstanceForName("ArrayDouble");
            _LeafAreaIndexHourly.ValueType = VarInfoValueTypes.GetInstanceForName("ArrayDouble");
            _PotentialEvaporationHourly.ValueType = VarInfoValueTypes.GetInstanceForName("ArrayDouble");
            _ActualVapourPressure.ValueType = VarInfoValueTypes.GetInstanceForName("Double");
            _AerodynamicResistance.ValueType = VarInfoValueTypes.GetInstanceForName("Double");
            _DewPointTemperature.ValueType = VarInfoValueTypes.GetInstanceForName("Double");
            _DiurnalAirTemperatureRange.ValueType = VarInfoValueTypes.GetInstanceForName("Double");
            _AirHumidityFactor.ValueType = VarInfoValueTypes.GetInstanceForName("Double");
            _AirTemperatureMax.ValueType = VarInfoValueTypes.GetInstanceForName("Double");
            _AirTemperatureMin.ValueType = VarInfoValueTypes.GetInstanceForName("Double");
            _Albedo.ValueType = VarInfoValueTypes.GetInstanceForName("Double");
            _AtmosphericDensity.ValueType = VarInfoValueTypes.GetInstanceForName("Double");
            _ClearSkyTransmissivity.ValueType = VarInfoValueTypes.GetInstanceForName("Double");
            _CloudinessFactor.ValueType = VarInfoValueTypes.GetInstanceForName("Double");
            _DaytimeTemperature.ValueType = VarInfoValueTypes.GetInstanceForName("Double");
            _Elevation.ValueType = VarInfoValueTypes.GetInstanceForName("Double");
            _ExtraterrestrialRadiation.ValueType = VarInfoValueTypes.GetInstanceForName("Double");
            _GlobalSolarRadiation.ValueType = VarInfoValueTypes.GetInstanceForName("Double");
            _LatentHeatOfVaporization.ValueType = VarInfoValueTypes.GetInstanceForName("Double");
            _LongWaveNetRadiation.ValueType = VarInfoValueTypes.GetInstanceForName("Double");
            _MaximumVapourPressureDeficit.ValueType = VarInfoValueTypes.GetInstanceForName("Double");
            _NetRadiation.ValueType = VarInfoValueTypes.GetInstanceForName("Double");
            _NormalizedDifferenceVegetationIndex.ValueType = VarInfoValueTypes.GetInstanceForName("Double");
            _PriestleyTaylorCoefficient.ValueType = VarInfoValueTypes.GetInstanceForName("Double");
            _PsychrometricConstant.ValueType = VarInfoValueTypes.GetInstanceForName("Double");
            _ReferenceEvapotranspiration.ValueType = VarInfoValueTypes.GetInstanceForName("Double");
            _GlobalEvapotranspiration.ValueType = VarInfoValueTypes.GetInstanceForName("Double");
            _PanCoefficient.ValueType = VarInfoValueTypes.GetInstanceForName("Double");
            _PanEvaporationClassA.ValueType = VarInfoValueTypes.GetInstanceForName("Double");
            _FetchDistance.ValueType = VarInfoValueTypes.GetInstanceForName("Double");
            _RelativeAirHumidityMax.ValueType = VarInfoValueTypes.GetInstanceForName("Double");
            _RelativeAirHumidityMin.ValueType = VarInfoValueTypes.GetInstanceForName("Double");
            _RelativeAirHumidity.ValueType = VarInfoValueTypes.GetInstanceForName("Double");
            _RickAllenConstant.ValueType = VarInfoValueTypes.GetInstanceForName("Double");
            _SaturationVapourPressure.ValueType = VarInfoValueTypes.GetInstanceForName("Double");
            _ShortWaveNetRadiation.ValueType = VarInfoValueTypes.GetInstanceForName("Double");
            _SlopeVapourPressure.ValueType = VarInfoValueTypes.GetInstanceForName("Double");
            _SoilHeatFlux.ValueType = VarInfoValueTypes.GetInstanceForName("Double");
            _VapourPressureDeficit.ValueType = VarInfoValueTypes.GetInstanceForName("Double");
            _WindSpeed.ValueType = VarInfoValueTypes.GetInstanceForName("Double");
            _WindMeasurementHeight.ValueType = VarInfoValueTypes.GetInstanceForName("Double");
            #endregion ValueTypes

        }
        #endregion
    }
}
