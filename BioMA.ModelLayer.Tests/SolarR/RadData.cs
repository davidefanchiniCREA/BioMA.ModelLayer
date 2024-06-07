using CRA.ModelLayer.Core;
using CRA.ModelLayer.ParametersManagement;
using System;
using System.Collections.Generic;
using System.Reflection;

namespace CRA.Clima.SolarR.Interfaces
{
    /// <summary>
    /// RadData is  the domain class used to estimate global solar radiation at a site.
    /// Each attribute is described using the VarInfo data-type in the
    /// RadDataVarInfo class.
    /// </summary>
    /// <remarks>June 2005</remarks>
    [Serializable()]
    public class RadData : IDomainClass, ICloneable
    {
        #region Private field for properties
        private ParametersIO _parametersIO;
        #endregion

        #region Constructor
        /// <summary>No parameters constructor</summary>
        public RadData()
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

        //variables to hold property values
        private double _AirTemperatureDailyAverage;
        private double _AirTemperatureDailyRange;
        private double _AirTemperatureMax; 
        private double _AirTemperatureMin;
        private double _AirTemperatureMin2;
        private double _AirTemperatureMonthlyRange;
        private double _AirTemperatureWeeklyRange;
        private double _AirTemperatureYearlyAverage;
        private double _AirTemperatureYearlyRange; 
        private double _Albedo;
        private double _AngleAspect;
        private double _AngleSlope;
        private double _CellSize;
        private int _CurrentDay;
        private double _ClearSkyTransmissivity;
        private double _DayLength; 
        //private double[,] _ElevationMatrix = new double[3,3];
        private double[] _ElevationMatrix = new double[9];
        private double _ExtraterrestrialRadiation; 
        private double[] _ExtraterrestrialRadiationHourly = new double[24]; 
        private double _GlobalSolarRadiation; 
        private double[] _GlobalSolarRadiationHourly = new double[24];  
        private double _GlobalSolarRadiationResidual; 
        private double[] _HourAngleHourly = new double[24]; 
        private double _HourSunrise; 
        private double _HourSunset; 
        private double _Latitude;  
        private double _PhotosynteticallyActiveRadiation;
        private double _ParBeam;
        private double _ParDiffuse;
        private double[] _PhotosynteticallyActiveRadiationHourly = new double[24]; 
        private double[] _ParBeamHourly = new double[24]; 
        private double[] _ParDiffuseHourly = new double[24];
        private double _RadiationBeam; 
        private double[] _RadiationBeamHourly = new double[24]; 
        private double _RadiationDiffuseSky; 
        private double[] _RadiationDiffuseSkyHourly = new double[24]; 
        private double _RadiationReflectedSoil; 
        private double[] _RadiationReflectedSoilHourly = new double[24]; 
        private double _SlopeAspectFactor; 
        private double[] _SlopeAspectFactorHourly = new double[24]; 
        private double _SolarDeclination; 
        private double[] _SolarElevationHourly = new double[24]; 
        private double _SunshineDuration;
        private List<string> _StrategyUsed = new List<string>();


        #region IDomainClass members
        /// <summary>Domain Class Description</summary>
        public virtual string Description
        {
            get
            {
                return "Variables to model Solar Radiation";
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

        #region IRadData Members
        //newly added property
        public List<string> StrategyUsed
        {
            get { return _StrategyUsed; }
            set { _StrategyUsed = value; }
        }
        /// <summary>Average of maximum and minimum air temperature</summary>
        public double AirTemperatureDailyAverage
        {
            get	{ return _AirTemperatureDailyAverage; }
            set	{ this._AirTemperatureDailyAverage = value; }
        }
        /// <summary>Difference between maximum and minimum air temperature</summary>
        public double AirTemperatureDailyRange
        {
            get	{ return _AirTemperatureDailyRange;}
            set	{ this._AirTemperatureDailyRange = value; }
        }
        /// <summary>Monthly average of difference between maximum and minimum air temperature</summary>
        public double AirTemperatureMonthlyRange
        {
            get	{ return _AirTemperatureMonthlyRange; }
            set	{ this._AirTemperatureMonthlyRange = value; }
        }
        /// <summary>Mobile mean of 7-day difference between maximum and minimum air temperature</summary>
        public double AirTemperatureWeeklyRange
        {
            get	{ return _AirTemperatureWeeklyRange; }
            set	{ this._AirTemperatureWeeklyRange = value; }
        }
        /// <summary>Yearly average of air temperature</summary>
        public double AirTemperatureYearlyAverage
        {
            get	{return _AirTemperatureYearlyAverage; }
            set	{ this._AirTemperatureYearlyAverage = value; }
        }
        /// <summary>Yearly average of difference between maximum and minimum air temperature</summary>
        public double AirTemperatureYearlyRange
        {
            get	{ return _AirTemperatureYearlyRange; }
            set	{ this._AirTemperatureYearlyRange = value; }
        }
        /// <summary>Ratio between reflected and incoming radiation</summary>
        public double Albedo
        {
            get	{ return _Albedo; }
            set	{ this._Albedo = value;	}
        }
        /// <summary>Surface inclination angle respect to an horizontal surface</summary>
        public double AngleSlope
        {
            get	{ return _AngleSlope; }
            set	{ this._AngleSlope = value; }
        }
        /// <summary>Clock-wise orientation angle to South</summary>
        public double AngleAspect
        {
            get	{ return _AngleAspect; }
            set	{ this._AngleAspect = value; }
        }
        /// <summary>Dimension of a square cell</summary>
        public double CellSize
        {
            get	{ return _CellSize;	}
            set	{this._CellSize = value; }
        }
        /// <summary>Fraction of clear sky global solar radiation at ground level over extra-terrestrial global solar radiation</summary>
        public double ClearSkyTransmissivity
        {
            get	{ return _ClearSkyTransmissivity; }
            set	{ this._ClearSkyTransmissivity = value;	}
        }
        /// <summary>Day of the year (1-366)</summary>
        public int CurrentDay
        {
            get	{ return _CurrentDay; }
            set	{ this._CurrentDay = value;	}
        }
        /// <summary>Time between sunrise and sunset at a given day of the year</summary>
        public double DayLength
        {
            get	{ return _DayLength; }
            set	{ this._DayLength = value; }
        }
        ///// <summary>Elevation above sea level</summary>
        //public double[,] ElevationMatrix
        //{
        //    get { return _ElevationMatrix; }
        //    set	{ this._ElevationMatrix = value; }
        //}
        /// <summary>Elevation above sea level</summary>
        public double[] ElevationMatrix
        {
            get { return _ElevationMatrix; }
            set { this._ElevationMatrix = value; }
        }
        /// <summary>Daily global solar radiation outside earth atmosphere</summary>
        public double ExtraterrestrialRadiation
        {
            get	{ return _ExtraterrestrialRadiation; }
            set	{ this._ExtraterrestrialRadiation = value; }
        }
        /// <summary>Hourly global solar radiation outside earth atmosphere</summary>
        public double[] ExtraterrestrialRadiationHourly
        {
            get	{ return _ExtraterrestrialRadiationHourly; }
            set	{ this._ExtraterrestrialRadiationHourly = value; }
        }
        /// <summary>Daily global solar radiation at ground level</summary>
        public double GlobalSolarRadiation
        {
            get	{ return _GlobalSolarRadiation;	}
            set	{ this._GlobalSolarRadiation = value; }
        }
        /// <summary>Hourly global solar radiation at ground level</summary>
        public double[] GlobalSolarRadiationHourly
        {
            get	{ return _GlobalSolarRadiationHourly; }
            set	{ this._GlobalSolarRadiationHourly = value;	}
        }
        /// <summary>Standardized normal deviate of generated global solar radiation for the day</summary>
        public double GlobalSolarRadiationResidual
        {
            get	{ return _GlobalSolarRadiationResidual;	}
            set	{ this._GlobalSolarRadiationResidual = value; }
        }
        /// <summary>Displacement of the sun east or west of the meridian due to the rotation of earth on its axis at 15° per hour</summary>
        public double[] HourAngleHourly
        {
            get	{ return _HourAngleHourly; }
            set	{ this._HourAngleHourly = value; }
        }
        /// <summary>Hour of sunrise</summary>
        public double HourSunrise
        {
            get	{ return _HourSunrise; }
            set	{ this._HourSunrise = value; }
        }
        /// <summary>Hour of sunset</summary>
        public double HourSunset
        {
            get	{ return _HourSunset; }
            set	{ this._HourSunset = value;	}
        }
        /// <summary>Site Latitude</summary>
        public double Latitude
        {
            get	{ return _Latitude;	}
            set	{ this._Latitude = value; }
        }
        /// <summary>Daily maximum air temperature</summary>
        public double AirTemperatureMax
        {
            get	{ return _AirTemperatureMax; }
            set { this._AirTemperatureMax = value; }
        }
        /// <summary>Daily minimum air temperature</summary>
        public double AirTemperatureMin
        {
            get	{ return _AirTemperatureMin; }
            set	{ this._AirTemperatureMin = value; }
        }
        /// <summary>Two-day average of minimum air temperature</summary>
        public double AirTemperatureMin2
        {
            get { return _AirTemperatureMin2; }
            set { this._AirTemperatureMin2 = value; }
        }
        /// <summary>Visible band energy: 380 to 710 nm wavelength</summary>
        public double PhotosynteticallyActiveRadiation
        {
            get	{ return _PhotosynteticallyActiveRadiation;	}
            set	{ this._PhotosynteticallyActiveRadiation = value; }
        }
        /// <summary>Daily beam visible band energy: 380 to 710 nm wavelength</summary>
        public double ParBeam
        {
            get	{ return _ParBeam;	}
            set	{ this._ParBeam = value; }
        }
        /// <summary>Daily diffuse visible band energy: 380 to 710 nm wavelength</summary>
        public double ParDiffuse
        {
            get	{ return _ParDiffuse;	}
            set	{ this._ParDiffuse = value; }
        }
        /// <summary>Hourly visible band energy: 380 to 710 nm wavelength</summary>
        public double[] PhotosynteticallyActiveRadiationHourly
        {
            get	{ return _PhotosynteticallyActiveRadiationHourly;	}
            set	{ this._PhotosynteticallyActiveRadiationHourly = value; }
        }
        /// <summary>Hourly beam visible band energy: 380 to 710 nm wavelength</summary>
        public double[] ParBeamHourly
        {
            get	{ return _ParBeamHourly;	}
            set	{ this._ParBeamHourly = value; }
        }
        /// <summary>Hourly diffuse visible band energy: 380 to 710 nm wavelength</summary>
        public double[] ParDiffuseHourly
        {
            get	{ return _ParDiffuseHourly;	}
            set	{ this._ParDiffuseHourly = value; }
        }
        /// <summary>Solar radiation that arrives in a straight line from the sun</summary>
        public double RadiationBeam
        {
            get	{ return _RadiationBeam; }
            set	{ this._RadiationBeam = value; }
        }
        /// <summary>Hourly solar radiation that arrives in a straight line from the sun</summary>
        public double[] RadiationBeamHourly
        {
            get	{ return _RadiationBeamHourly; }
            set	{ this._RadiationBeamHourly = value; }
        }
        /// <summary>Daily solar radiation scattered by atmospheric particles and gases</summary>
        public double RadiationDiffuseSky
        {
            get	{ return _RadiationDiffuseSky; }
            set	{ this._RadiationDiffuseSky = value; }
        }
        /// <summary>Hourly solar radiation scattered by atmospheric particles and gases</summary>
        public double[] RadiationDiffuseSkyHourly
        {
            get	{ return _RadiationDiffuseSkyHourly; }
            set	{ this._RadiationDiffuseSkyHourly = value; }
        }
        /// <summary>Daily solar radiation reflected from ground</summary>
        public double RadiationReflectedSoil
        {
            get	{ return _RadiationReflectedSoil; }
            set	{ this._RadiationReflectedSoil = value;	}
        }
        /// <summary>Hourly solar radiation reflected from ground</summary>
        public double[] RadiationReflectedSoilHourly
        {
            get	{ return _RadiationReflectedSoilHourly; }
            set	{ this._RadiationReflectedSoilHourly = value; }
        }
        /// <summary>Daily factor accounting for slope and aspect on irradiance</summary>
        public double SlopeAspectFactor
        {
            get	{ return _SlopeAspectFactor; }
            set	{ this._SlopeAspectFactor = value; }
        }
        /// <summary>Hourly factor accounting for slope and aspect on irradiance</summary>
        public double[] SlopeAspectFactorHourly
        {
            get	{ return _SlopeAspectFactorHourly; }
            set	{ this._SlopeAspectFactorHourly = value; }
        }
        /// <summary>Angle between the equatorial plane and the straight line joining the centers of the earth and the sun</summary>
        public double SolarDeclination
        {
            get	{ return _SolarDeclination;	}
            set	{ this._SolarDeclination = value; }
        }
        /// <summary>Sun Elevation angle above the horizon</summary>
        public double[] SolarElevationHourly
        {
            get	{ return _SolarElevationHourly; }
            set	{ this._SolarElevationHourly = value;	}
        }
        /// <summary>Time during the day of direct light intensity above 0.432 MJ m-2 h-1</summary>
        public double SunshineDuration
        {
            get	{ return _SunshineDuration; }
            set	{ this._SunshineDuration = value; }
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
            _AirTemperatureDailyAverage = default(double);
            _AirTemperatureDailyRange = default(double);
            _AirTemperatureMax = default(double);
            _AirTemperatureMin = default(double);
            _AirTemperatureMin2 = default(double);
            _AirTemperatureMonthlyRange = default(double);
            _AirTemperatureWeeklyRange = default(double);
            _AirTemperatureYearlyAverage = default(double);
            _AirTemperatureYearlyRange = default(double);
            _Albedo = default(double);
            _AngleAspect = default(double);
            _AngleSlope = default(double);
            _CellSize = default(double);
            _CurrentDay = default(int);
            _ClearSkyTransmissivity = default(double);
            _DayLength = default(double);
            _ExtraterrestrialRadiation = default(double);
            _ExtraterrestrialRadiationHourly = new double[24];
            _GlobalSolarRadiation = default(double);
            _GlobalSolarRadiationHourly = new double[24];
            _GlobalSolarRadiationResidual = default(double);
            _HourAngleHourly = new double[24];
            _HourSunrise = default(double);
            _HourSunset = default(double);
            _Latitude = default(double);
            _PhotosynteticallyActiveRadiation = default(double);
            _ParBeam = default(double);
            _ParDiffuse = default(double);
            _PhotosynteticallyActiveRadiationHourly = new double[24];
            _ParBeamHourly = new double[24];
            _ParDiffuseHourly = new double[24];
            _RadiationBeam = default(double);
            _RadiationBeamHourly = new double[24];
            _RadiationDiffuseSky = default(double);
            _RadiationDiffuseSkyHourly = new double[24];
            _RadiationReflectedSoil = default(double);
            _RadiationReflectedSoilHourly = new double[24];
            _SlopeAspectFactor = default(double);
            _SlopeAspectFactorHourly = new double[24];
            _SolarDeclination = default(double);
            _SolarElevationHourly = new double[24];
            _SunshineDuration = default(double);
            //_ElevationMatrix = new double[3, 3];
            _ElevationMatrix = new double[9];
            // Returns true if everything is ok
            return true;
        }
        #endregion
    }
}