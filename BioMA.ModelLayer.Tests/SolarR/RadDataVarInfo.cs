using CRA.ModelLayer.Core;
using System;


namespace CRA.Clima.SolarR.Interfaces
{
    /// <summary>
    /// RadDataVarInfo contains static properties with variables description
    /// There must a VarInfo variable for each variable in IRadData
    /// </summary>
    public class RadDataVarInfo : IVarInfoClass
    {
        static RadDataVarInfo()
        {
            DescribeVariables();
        }
        #region IVarInfoClass members
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

        /// <summary>Value domain class of reference</summary>
        public virtual string DomainClassOfReference
        {
            get
            {
                return "RadData";
            }
        }
        #endregion
        //_ variables to hold property values
        private static VarInfo _AirTemperatureDailyAverage = new VarInfo();
        private static VarInfo _AirTemperatureDailyRange = new VarInfo();
        private static VarInfo _AirTemperatureMax = new VarInfo(); 
        private static VarInfo _AirTemperatureMin = new VarInfo(); 
        private static VarInfo _AirTemperatureMin2 = new VarInfo();
        private static VarInfo _AirTemperatureMonthlyRange = new VarInfo();
        private static VarInfo _AirTemperatureWeeklyRange = new VarInfo();
        private static VarInfo _AirTemperatureYearlyAverage = new VarInfo();
        private static VarInfo _AirTemperatureYearlyRange = new VarInfo(); 
        private static VarInfo _Albedo = new VarInfo();
        private static VarInfo _AngleAspect = new VarInfo();
        private static VarInfo _AngleSlope = new VarInfo();
        private static VarInfo _CellSize = new VarInfo();
        private static VarInfo _CurrentDay = new VarInfo();
        private static VarInfo _ClearSkyTransmissivity = new VarInfo();
        private static VarInfo _DayLength = new VarInfo(); 
        private static VarInfo _ElevationMatrix = new VarInfo();   
        private static VarInfo _ExtraterrestrialRadiation = new VarInfo(); 
        private static VarInfo _ExtraterrestrialRadiationHourly = new VarInfo(); 
        private static VarInfo _GlobalSolarRadiation = new VarInfo(); 
        private static VarInfo _GlobalSolarRadiationHourly = new VarInfo();
        private static VarInfo _GlobalSolarRadiationResidual = new VarInfo();  
        private static VarInfo _HourAngleHourly = new VarInfo(); 
        private static VarInfo _HourSunrise = new VarInfo(); 
        private static VarInfo _HourSunset = new VarInfo(); 
        private static VarInfo _Latitude = new VarInfo();  
        private static VarInfo _PhotosynteticallyActiveRadiation = new VarInfo();
        private static VarInfo _ParBeam = new VarInfo();
        private static VarInfo _ParDiffuse = new VarInfo();
        private static VarInfo _PhotosynteticallyActiveRadiationHourly = new VarInfo();
        private static VarInfo _ParBeamHourly = new VarInfo();
        private static VarInfo _ParDiffuseHourly = new VarInfo();  
        private static VarInfo _RadiationBeam = new VarInfo(); 
        private static VarInfo _RadiationBeamHourly = new VarInfo(); 
        private static VarInfo _RadiationDiffuseSky = new VarInfo(); 
        private static VarInfo _RadiationDiffuseSkyHourly = new VarInfo(); 
        private static VarInfo _RadiationReflectedSoil = new VarInfo(); 
        private static VarInfo _RadiationReflectedSoilHourly = new VarInfo(); 
        private static VarInfo _SlopeAspectFactor = new VarInfo(); 
        private static VarInfo _SlopeAspectFactorHourly = new VarInfo(); 
        private static VarInfo _SolarDeclination = new VarInfo(); 
        private static VarInfo _SolarElevationHourly = new VarInfo(); 
        private static VarInfo _SunshineDuration = new VarInfo();
		
        #region static properties
        /// <summary>Average of maximum and minimum air temperature</summary>
        public static VarInfo AirTemperatureDailyAverage
        {
            get	{ return _AirTemperatureDailyAverage; }
        }
        /// <summary>Difference between maximum and minimum air temperature</summary>
        public static VarInfo AirTemperatureDailyRange
        {
            get	{ return _AirTemperatureDailyRange;}
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
        /// <summary>Two-day average of minimum air temperature</summary>
        public static VarInfo AirTemperatureMin2
        {
            get { return _AirTemperatureMin2; }
        }
        /// <summary>Monthly average of difference between maximum and minimum air temperature</summary>
        public static VarInfo AirTemperatureMonthlyRange
        {
            get	{ return _AirTemperatureMonthlyRange; }
        }
        /// <summary>Mobile mean of 7-day difference between maximum and minimum air temperature</summary>
        public static VarInfo AirTemperatureWeeklyRange
        {
            get	{ return _AirTemperatureWeeklyRange; }
        }
        /// <summary>Yearly average of air temperature</summary>
        public static VarInfo AirTemperatureYearlyAverage
        {
            get	{return _AirTemperatureYearlyAverage; }
        }
        /// <summary>Yearly average of difference between maximum and minimum air temperature</summary>
        public static VarInfo AirTemperatureYearlyRange
        {
            get	{ return _AirTemperatureYearlyRange; }
        }
        /// <summary>Ratio between reflected and incoming radiation</summary>
        public static VarInfo Albedo
        {
            get	{ return _Albedo; }
        }
        /// <summary>Surface inclination angle respect to an horizontal surface</summary>
        public static VarInfo AngleSlope
        {
            get	{ return _AngleSlope; }
        }
        /// <summary>Clock-wise orientation angle to South</summary>
        public static VarInfo AngleAspect
        {
            get	{ return _AngleAspect; }
        }
        /// <summary>Dimension of a square cell</summary>
        public static VarInfo CellSize
        {
            get	{ return _CellSize;	}
        }
        /// <summary>Fraction of clear sky global solar radiation at ground level over extra-terrestrial global solar radiation</summary>
        public static VarInfo ClearSkyTransmissivity
        {
            get	{ return _ClearSkyTransmissivity; }
        }
        /// <summary>Day of the year (1-365)</summary>
        public static VarInfo CurrentDay
        {
            get	{ return _CurrentDay; }
        }
        /// <summary>Time between sunrise and sunset at a given day of the year</summary>
        public static VarInfo DayLength
        {
            get	{ return _DayLength; }
        }
        /// <summary>ElevationMatrix above sea level</summary>
        public static VarInfo ElevationMatrix
        {
            get { return _ElevationMatrix; }
        }
        /// <summary>Daily global solar radiation outside earth atmosphere</summary>
        public static VarInfo ExtraterrestrialRadiation
        {
            get	{ return _ExtraterrestrialRadiation; }
        }
        /// <summary>Hourly global solar radiation outside earth atmosphere</summary>
        public static VarInfo ExtraterrestrialRadiationHourly
        {
            get	{ return _ExtraterrestrialRadiationHourly; }
        }
        /// <summary>Daily global solar radiation at ground level</summary>
        public static VarInfo GlobalSolarRadiation
        {
            get	{ return _GlobalSolarRadiation;	}
        }
        /// <summary>Hourly global solar radiation at ground level</summary>
        public static VarInfo GlobalSolarRadiationHourly
        {
            get	{ return _GlobalSolarRadiationHourly; }
        }
        /// <summary>Standardized normal deviate of generated global solar radiation for the day</summary>
        public static VarInfo GlobalSolarRadiationResidual
        {
            get	{ return _GlobalSolarRadiationResidual; }
        }
        /// <summary>Displacement of the sun east or west of the meridian due to the rotation of earth on its axis at 15° per hour</summary>
        public static VarInfo HourAngleHourly
        {
            get	{ return _HourAngleHourly; }
        }
        /// <summary>Sunrise hour</summary>
        public static VarInfo HourSunrise
        {
            get	{ return _HourSunrise; }
        }
        /// <summary>Sunset hour</summary>
        public static VarInfo HourSunset
        {
            get	{ return _HourSunset; }
        }
        /// <summary>Site Latitude</summary>
        public static VarInfo Latitude
        {
            get	{ return _Latitude;	}
        }
        /// <summary>Daily visible band energy: 380 to 710 nm wavelength</summary>
        public static VarInfo PhotosynteticallyActiveRadiation
        {
            get	{ return _PhotosynteticallyActiveRadiation;	}
        }
        /// <summary>Daily beam visible band energy: 380 to 710 nm wavelength</summary>
        public static VarInfo ParBeam
        {
            get	{ return _ParBeam; }
        }
        /// <summary>Daily diffuse visible band energy: 380 to 710 nm wavelength</summary>
        public static VarInfo ParDiffuse
        {
            get	{ return _ParDiffuse; }
        }
        /// <summary>Hourly visible band energy: 380 to 710 nm wavelength</summary>
        public static VarInfo PhotosynteticallyActiveRadiationHourly
        {
            get	{ return _PhotosynteticallyActiveRadiationHourly; }
        }
        /// <summary>Hourly beam visible band energy: 380 to 710 nm wavelength</summary>
        public static VarInfo ParBeamHourly
        {
            get	{ return _ParBeamHourly; }
        }
        /// <summary>Hourly diffuse visible band energy: 380 to 710 nm wavelength</summary>
        public static VarInfo ParDiffuseHourly
        {
            get	{ return _ParDiffuseHourly; }
        }	
        /// <summary>Daily solar radiation that arrives in a straight line from the sun</summary>
        public static VarInfo RadiationBeam
        {
            get	{ return _RadiationBeam; }
        }
        /// <summary>Hourly solar radiation that arrives in a straight line from the sun</summary>
        public static VarInfo RadiationBeamHourly
        {
            get	{ return _RadiationBeamHourly; }
        }
        /// <summary>Daily solar radiation scattered by atmospheric particles and gases</summary>
        public static VarInfo RadiationDiffuseSky
        {
            get	{ return _RadiationDiffuseSky; }
        }
        /// <summary>Hourly solar radiation scattered by atmospheric particles and gases</summary>
        public static VarInfo RadiationDiffuseSkyHourly
        {
            get	{ return _RadiationDiffuseSkyHourly; }
        }
        /// <summary>Daily solar radiation reflected from ground</summary>
        public static VarInfo RadiationReflectedSoil
        {
            get	{ return _RadiationReflectedSoil; }
        }
        /// <summary>Hourly solar radiation reflected from ground</summary>
        public static VarInfo RadiationReflectedSoilHourly
        {
            get	{ return _RadiationReflectedSoilHourly; }
        }
        /// <summary>Daily factor accounting for slope and aspect on irradiance</summary>
        public static VarInfo SlopeAspectFactor
        {
            get	{ return _SlopeAspectFactor; }
        }
        /// <summary>Hourly factor accounting for slope and aspect on irradiance</summary>
        public static VarInfo SlopeAspectFactorHourly
        {
            get	{ return _SlopeAspectFactorHourly; }
        }
        /// <summary>Angle between the equatorial plane and the straight line joining the centers of the earth and the sun</summary>
        public static VarInfo SolarDeclination
        {
            get	{ return _SolarDeclination;	}
        }
        /// <summary>Sun Elevation angle above the horizon</summary>
        public static VarInfo SolarElevationHourly
        {
            get	{ return _SolarElevationHourly; }
        }
        /// <summary>Time during the day of direct light intensity above 0.432 MJ m-2 h-1</summary>
        public static VarInfo SunshineDuration
        {
            get	{ return _SunshineDuration; }
        } 
        #endregion
		
        #region Constructor method
        private static void DescribeVariables()
        {
            //INPUTS AND OUTPUTS
            //current value is set within strategies / models using the data
         	
            _AirTemperatureDailyAverage.Description = "Average of maximum and minimum air temperature";
            _AirTemperatureDailyAverage.Name = "AirTemperatureDailyAverage";
            _AirTemperatureDailyAverage.DefaultValue = 15;
            _AirTemperatureDailyAverage.MaxValue = 43;
            _AirTemperatureDailyAverage.MinValue = -17;
            _AirTemperatureDailyAverage.Units = "°C";

            _AirTemperatureDailyRange.Description = "Difference between maximum and minimum air temperature";
            _AirTemperatureDailyRange.Name = "AirTemperatureDailyRange";
            _AirTemperatureDailyRange.DefaultValue = 15;
            _AirTemperatureDailyRange.MaxValue = 25;
            _AirTemperatureDailyRange.MinValue = 1;
            _AirTemperatureDailyRange.Units = "°C";
			
            _AirTemperatureMonthlyRange.Description = "Monthly average of difference between maximum and minimum air temperature";
            _AirTemperatureMonthlyRange.Name = "AirTemperatureMonthlyRange";
            _AirTemperatureMonthlyRange.DefaultValue = 15;
            _AirTemperatureMonthlyRange.MaxValue = 25;
            _AirTemperatureMonthlyRange.MinValue = 1;
            _AirTemperatureMonthlyRange.Units = "°C";

            _AirTemperatureWeeklyRange.Description = "Mobile mean of 7-day difference between maximum and minimum air temperature";
            _AirTemperatureWeeklyRange.Name = "AirTemperatureWeeklyRange.DefaultValue";		
            _AirTemperatureWeeklyRange.DefaultValue = 15;
            _AirTemperatureWeeklyRange.MaxValue = 25;
            _AirTemperatureWeeklyRange.MinValue = 1;
            _AirTemperatureWeeklyRange.Units = "°C";

            _AirTemperatureYearlyAverage.Description = "Yearly average of air temperature";
            _AirTemperatureYearlyAverage.Name = "AirTemperatureYearlyAverage";
            _AirTemperatureYearlyAverage.DefaultValue = 15;
            _AirTemperatureYearlyAverage.MaxValue = 43;
            _AirTemperatureYearlyAverage.MinValue = -17;
            _AirTemperatureYearlyAverage.Units = "°C";

            _AirTemperatureYearlyRange.Description = "Yearly average of difference between maximum and minimum air temperature";
            _AirTemperatureYearlyRange.Name = "AirTemperatureYearlyRange";
            _AirTemperatureYearlyRange.DefaultValue = 15;
            _AirTemperatureYearlyRange.MaxValue = 25;
            _AirTemperatureYearlyRange.MinValue = 1;
            _AirTemperatureYearlyRange.Units = "°C";

            _Albedo.Description = "Ratio between reflected and incoming radiation";
            _Albedo.Name = "Albedo";
            _Albedo.DefaultValue = 0.2;
            _Albedo.MaxValue = 0.9;
            _Albedo.MinValue = 0.05;
            _Albedo.Units = "Unitless";
			
            _AngleAspect.Description = "Clock-wise orientation angle to South";
            _AngleAspect.Name = "AngleAspect";
            _AngleAspect.DefaultValue = 0;
            _AngleAspect.MaxValue= 359;
            _AngleAspect.MinValue= 0;
            _AngleAspect.Units = "Degree";
									
            _AngleSlope.Description = "surface inclination angle respect to an horizontal surface";
            _AngleSlope.Name = "AngleSlope";
            _AngleSlope.DefaultValue = 0;
            _AngleSlope.MaxValue = 90;
            _AngleSlope.MinValue = 0;
            _AngleSlope.Units = "degree";

            _CellSize.Description = "Dimension of a square cell";
            _CellSize.Name = "CellSize";
            _CellSize.DefaultValue = 100;
            _CellSize.MaxValue = 100000;
            _CellSize.MinValue = 1;
            _CellSize.Units = "m";

            _ClearSkyTransmissivity.Description = "Fraction of clear sky global solar radiation at ground level over extra-terrestrial global solar radiation";
            _ClearSkyTransmissivity.Name = "ClearSkyTransmissivity";
            _ClearSkyTransmissivity.DefaultValue = 0.75;
            _ClearSkyTransmissivity.MaxValue = 0.85;
            _ClearSkyTransmissivity.MinValue = 0.52;
            _ClearSkyTransmissivity.Units = "Unitless";

            _CurrentDay.Description = "Day number of the year";
            _CurrentDay.Name = "CurrentDay";
            _CurrentDay.DefaultValue = 180;
            _CurrentDay.MaxValue = 366;
            _CurrentDay.MinValue = 1;
            _CurrentDay.Units = "d";

            _DayLength.Description = "Time between sunrise and sunset";
            _DayLength.Name = "DayLength";
            _DayLength.DefaultValue = 8;
            _DayLength.MaxValue = 24;
            _DayLength.MinValue = 0;
            _DayLength.Units = "h";

            _ElevationMatrix.Description = "Altitude of the site above sea level";
            _ElevationMatrix.Name = "ElevationMatrix";
            _ElevationMatrix.DefaultValue = 0;
            _ElevationMatrix.MaxValue = 8000;
            _ElevationMatrix.MinValue = -100;
            _ElevationMatrix.Units = "m";

            _ExtraterrestrialRadiation.Description = "Daily global solar radiation outside earth atmosphere";
            _ExtraterrestrialRadiation.Name = "ExtraterrestrialRadiation";
            _ExtraterrestrialRadiation.DefaultValue = 25;
            _ExtraterrestrialRadiation.MaxValue = 42;
            _ExtraterrestrialRadiation.MinValue = 0.05;	
            _ExtraterrestrialRadiation.Units = "MJ m-2 d-1";

            _ExtraterrestrialRadiationHourly.Description = "Hourly global solar radiation outside earth atmosphere";
            _ExtraterrestrialRadiationHourly.Name = "ExtraterrestrialRadiationHourly";
            _ExtraterrestrialRadiationHourly.DefaultValue = 4.2; 
            _ExtraterrestrialRadiationHourly.MaxValue = 6;
            _ExtraterrestrialRadiationHourly.MinValue = 0;
            _ExtraterrestrialRadiationHourly.Units = "MJ m-2 h-1";

            _GlobalSolarRadiation.Description = "Daily global solar radiation at ground level";
            _GlobalSolarRadiation.Name = "GlobalSolarRadiation";
            _GlobalSolarRadiation.DefaultValue = 20; 
            _GlobalSolarRadiation.MaxValue = 38;
            _GlobalSolarRadiation.MinValue = 0.01;
            _GlobalSolarRadiation.Units = "MJ m-2 d-1";

            _GlobalSolarRadiationHourly.Description = "Hourly global solar radiation at ground level";
            _GlobalSolarRadiationHourly.Name = "GlobalSolarRadiationHourly";
            _GlobalSolarRadiationHourly.DefaultValue = 3;
            _GlobalSolarRadiationHourly.MaxValue = 6;
            _GlobalSolarRadiationHourly.MinValue = 0;
            _GlobalSolarRadiationHourly.Units = "MJ m-2 h-1";

            _GlobalSolarRadiationResidual.Description = "Standardized normal deviate of generated global solar radiation for the day";
            _GlobalSolarRadiationResidual.Name = "GlobalSolarRadiationResidual";
            _GlobalSolarRadiationResidual.DefaultValue = 0;
            _GlobalSolarRadiationResidual.MaxValue = 5;
            _GlobalSolarRadiationResidual.MinValue = -5;
            _GlobalSolarRadiationResidual.Units = "Unitless";

            _HourAngleHourly.Description = "Displacement of the sun east or west of the meridian due to the rotation of earth on its axis at 15° per hour";
            _HourAngleHourly.Name = "HourAngleHourly";
            _HourAngleHourly.DefaultValue = 0;
            _HourAngleHourly.MaxValue = 165;
            _HourAngleHourly.MinValue = -180;
            _HourAngleHourly.Units = "Degree";

            _HourSunrise.Description = "Hour of sunrise";
            _HourSunrise.Name = "HourSunrise";
            _HourSunrise.DefaultValue = 6; 
            _HourSunrise.MaxValue = 12;
            _HourSunrise.MinValue = 0;
            _HourSunrise.Units = "h";

            _HourSunset.Description = "Hour of sunset";
            _HourSunset.Name = "HourSunset";
            _HourSunset.DefaultValue = 18; 
            _HourSunset.MaxValue = 23;
            _HourSunset.MinValue = 12;
            _HourSunset.Units = "h";
					
            _Latitude.Description = "Latitude of the site";
            _Latitude.Name = "Latitude";
            _Latitude.DefaultValue = 45;
            _Latitude.MaxValue = 90;
            _Latitude.MinValue = -90;
            _Latitude.Units = "Degree";

            _AirTemperatureMax.Description = "Daily maximum air temperature";
            _AirTemperatureMax.Name = "MaxAirTemperature";
            _AirTemperatureMax.DefaultValue = 15;
            _AirTemperatureMax.MaxValue = 50;
            _AirTemperatureMax.MinValue = -10;
            _AirTemperatureMax.Units = "°C";

            _AirTemperatureMin.Description = "Daily minimum air temperature";
            _AirTemperatureMin.Name = "MinAirTemperature";
            _AirTemperatureMin.DefaultValue = 5;
            _AirTemperatureMin.MaxValue = 35;
            _AirTemperatureMin.MinValue = -25;
            _AirTemperatureMin.Units = "°C";

            _AirTemperatureMin2.Description = "2-day average of minimum air temperature";
            _AirTemperatureMin2.Name = "MinAirTemperature2";
            _AirTemperatureMin2.DefaultValue = 5;
            _AirTemperatureMin2.MaxValue = 35;
            _AirTemperatureMin2.MinValue = -25;
            _AirTemperatureMin2.Units = "°C";

            _PhotosynteticallyActiveRadiation.Description = "Visible band energy: 380 to 710 nm wavelength";
            _PhotosynteticallyActiveRadiation.Name = "PhotosynteticallyActiveRadiation";
            _PhotosynteticallyActiveRadiation.DefaultValue = 10; 
            _PhotosynteticallyActiveRadiation.MaxValue = 20;
            _PhotosynteticallyActiveRadiation.MinValue = 1;
            _PhotosynteticallyActiveRadiation.Units = "MJ m-2 d-1";

            _ParBeam.Description = "Beam visible band energy: 380 to 710 nm wavelength";
            _ParBeam.Name = "ParBeam";
            _ParBeam.DefaultValue = 10; 
            _ParBeam.MaxValue = 20;
            _ParBeam.MinValue = 0.1;
            _ParBeam.Units = "MJ m-2 d-1";

            _ParDiffuse.Description = "Diffuse visible band energy: 380 to 710 nm wavelength";
            _ParDiffuse.Name = "ParDiffuse";
            _ParDiffuse.DefaultValue = 5; 
            _ParDiffuse.MaxValue = 10;
            _ParDiffuse.MinValue = 0.1;
            _ParDiffuse.Units = "MJ m-2 d-1";

            _PhotosynteticallyActiveRadiationHourly.Description = "Hourly visible band energy: 380 to 710 nm wavelength";
            _PhotosynteticallyActiveRadiationHourly.Name = "PhotosynteticallyActiveRadiationHourly";
            _PhotosynteticallyActiveRadiationHourly.DefaultValue = 3; 
            _PhotosynteticallyActiveRadiationHourly.MaxValue = 20;
            _PhotosynteticallyActiveRadiationHourly.MinValue = 0;
            _PhotosynteticallyActiveRadiationHourly.Units = "MJ m-2 h-1";

            _ParBeamHourly.Description = "Hourly beam visible band energy: 380 to 710 nm wavelength";
            _ParBeamHourly.Name = "ParBeamHourly";
            _ParBeamHourly.DefaultValue = 3; 
            _ParBeamHourly.MaxValue = 20;
            _ParBeamHourly.MinValue = 0;
            _ParBeamHourly.Units = "MJ m-2 h-1";

            _ParDiffuseHourly.Description = "Hourly diffuse visible band energy: 380 to 710 nm wavelength";
            _ParDiffuseHourly.Name = "ParDiffuseHourly";
            _ParDiffuseHourly.DefaultValue = 1.5; 
            _ParDiffuseHourly.MaxValue = 20;
            _ParDiffuseHourly.MinValue = 0;
            _ParDiffuseHourly.Units = "MJ m-2 h-1";

            _RadiationBeam.Description = "Solar radiation that arrives in a straight line from the sun";
            _RadiationBeam.Name = "RadiationBeam";
            _RadiationBeam.DefaultValue = 20; 
            _RadiationBeam.MaxValue = 35;
            _RadiationBeam.MinValue = 0.1;
            _RadiationBeam.Units = " MJ m-2 d-1";

            _RadiationBeamHourly.Description = "Hourly solar radiation that arrives in a straight line from the sun";
            _RadiationBeamHourly.Name = "RadiationBeamHourly";
            _RadiationBeamHourly.DefaultValue = 3;  
            _RadiationBeamHourly.MaxValue = 4;
            _RadiationBeamHourly.MinValue = 0;
            _RadiationBeamHourly.Units = " MJ m-2 h-1";

            _RadiationDiffuseSky.Description = "Solar radiation scattered by atmospheric particles and gases";
            _RadiationDiffuseSky.Name = "RadiationDiffuseSky";
            _RadiationDiffuseSky.DefaultValue = 1;  
            _RadiationDiffuseSky.MaxValue = 15;
            _RadiationDiffuseSky.MinValue = 0.1;
            _RadiationDiffuseSky.Units = " MJ m-2 d-1";

            _RadiationDiffuseSkyHourly.Description = "Hourly solar radiation scattered by atmospheric particles and gases";
            _RadiationDiffuseSkyHourly.Name = "RadiationDiffuseSkyHourly";
            _RadiationDiffuseSkyHourly.DefaultValue = 0.5;  
            _RadiationDiffuseSkyHourly.MaxValue = 2;
            _RadiationDiffuseSkyHourly.MinValue = 0;
            _RadiationDiffuseSkyHourly.Units = " MJ m-2 h-1";

            _RadiationReflectedSoil.Description = "Solar radiation reflected from ground";
            _RadiationReflectedSoil.Name = "RadiationReflectedSoil";
            _RadiationReflectedSoil.DefaultValue = 1;  
            _RadiationReflectedSoil.MaxValue = 15;
            _RadiationReflectedSoil.MinValue = 0;
            _RadiationReflectedSoil.Units = " MJ m-2 d-1";

            _RadiationReflectedSoilHourly.Description = "Hourly solar radiation reflected from ground";
            _RadiationReflectedSoilHourly.Name = "RadiationReflectedSoilHourly";
            _RadiationReflectedSoilHourly.DefaultValue = 0; 
            _RadiationReflectedSoilHourly.MaxValue = 2;
            _RadiationReflectedSoilHourly.MinValue = 0;
            _RadiationReflectedSoilHourly.Units = " MJ m-2 h-1";

            _SlopeAspectFactor.Description = "Daily factor accounting for slope and aspect on irradiance";
            _SlopeAspectFactor.Name = "SlopeAspectFactor";
            _SlopeAspectFactor.DefaultValue = 1;
            _SlopeAspectFactor.MaxValue = 3;
            _SlopeAspectFactor.MinValue = 0;
            _SlopeAspectFactor.Units = "Unitless";

            _SlopeAspectFactorHourly.Description = "Hourly factor accounting for slope and aspect on irradiance";
            _SlopeAspectFactorHourly.Name = "SlopeAspectFactorHourly";
            _SlopeAspectFactorHourly.DefaultValue = 1;
            _SlopeAspectFactorHourly.MaxValue = 3;
            _SlopeAspectFactorHourly.MinValue = 0;
            _SlopeAspectFactorHourly.Units = "Unitless";

            _SolarDeclination.Description = "Angle between the equatorial plane and the straight line joining the centers of the earth and the sun";
            _SolarDeclination.Name = "SolarDeclination";
            _SolarDeclination.DefaultValue = 0;
            _SolarDeclination.MaxValue = 0.4093;
            _SolarDeclination.MinValue = -0.4093;
            _SolarDeclination.Units = "rad";

            _SolarElevationHourly.Description = "Sun Elevation angle above the horizon";
            _SolarElevationHourly.Name = "SolarElevationHourly";
            _SolarElevationHourly.DefaultValue = 0.5;
            _SolarElevationHourly.MaxValue = 1.571;
            _SolarElevationHourly.MinValue = 0;
            _SolarElevationHourly.Units = "rad";

            _SunshineDuration.Description = "Time during the day of direct light intensity above 0.432 MJ m-2 h-1";
            _SunshineDuration.Name = "SunshineDuration";
            _SunshineDuration.DefaultValue = 6;
            _SunshineDuration.MaxValue = 24;
            _SunshineDuration.MinValue = 0;
            _SunshineDuration.Units = "h";

            #region ValueTypes
            _AirTemperatureDailyAverage.ValueType = VarInfoValueTypes.GetInstanceForName("Double");
            _AirTemperatureDailyRange.ValueType = VarInfoValueTypes.GetInstanceForName("Double");
            _AirTemperatureMax.ValueType = VarInfoValueTypes.GetInstanceForName("Double");
            _AirTemperatureMin.ValueType = VarInfoValueTypes.GetInstanceForName("Double");
            _AirTemperatureMin2.ValueType = VarInfoValueTypes.GetInstanceForName("Double");
            _AirTemperatureMonthlyRange.ValueType = VarInfoValueTypes.GetInstanceForName("Double");
            _AirTemperatureWeeklyRange.ValueType = VarInfoValueTypes.GetInstanceForName("Double");
            _AirTemperatureYearlyAverage.ValueType = VarInfoValueTypes.GetInstanceForName("Double");
            _AirTemperatureYearlyRange.ValueType = VarInfoValueTypes.GetInstanceForName("Double");
            _Albedo.ValueType = VarInfoValueTypes.GetInstanceForName("Double");
            _AngleAspect.ValueType = VarInfoValueTypes.GetInstanceForName("Double");
            _AngleSlope.ValueType = VarInfoValueTypes.GetInstanceForName("Double");
            _CellSize.ValueType = VarInfoValueTypes.GetInstanceForName("Double");
            _CurrentDay.ValueType = VarInfoValueTypes.GetInstanceForName("Integer");
            _ClearSkyTransmissivity.ValueType = VarInfoValueTypes.GetInstanceForName("Double");
            _DayLength.ValueType = VarInfoValueTypes.GetInstanceForName("Double");
            _ElevationMatrix.ValueType = VarInfoValueTypes.GetInstanceForName("ArrayDouble");
            _ExtraterrestrialRadiation.ValueType = VarInfoValueTypes.GetInstanceForName("Double");
            _ExtraterrestrialRadiationHourly.ValueType = VarInfoValueTypes.GetInstanceForName("ArrayDouble");
            _GlobalSolarRadiation.ValueType = VarInfoValueTypes.GetInstanceForName("Double");
            _GlobalSolarRadiationHourly.ValueType = VarInfoValueTypes.GetInstanceForName("ArrayDouble");
            _GlobalSolarRadiationResidual.ValueType = VarInfoValueTypes.GetInstanceForName("Double");
            _HourAngleHourly.ValueType = VarInfoValueTypes.GetInstanceForName("ArrayDouble");
            _HourSunrise.ValueType = VarInfoValueTypes.GetInstanceForName("Double");
            _HourSunset.ValueType = VarInfoValueTypes.GetInstanceForName("Double");
            _Latitude.ValueType = VarInfoValueTypes.GetInstanceForName("Double");
            _PhotosynteticallyActiveRadiation.ValueType = VarInfoValueTypes.GetInstanceForName("Double");
            _ParBeam.ValueType = VarInfoValueTypes.GetInstanceForName("Double");
            _ParDiffuse.ValueType = VarInfoValueTypes.GetInstanceForName("Double");
            _PhotosynteticallyActiveRadiationHourly.ValueType = VarInfoValueTypes.GetInstanceForName("ArrayDouble");
            _ParBeamHourly.ValueType = VarInfoValueTypes.GetInstanceForName("ArrayDouble");
            _ParDiffuseHourly.ValueType = VarInfoValueTypes.GetInstanceForName("ArrayDouble");
            _RadiationBeam.ValueType = VarInfoValueTypes.GetInstanceForName("Double");
            _RadiationBeamHourly.ValueType = VarInfoValueTypes.GetInstanceForName("ArrayDouble");
            _RadiationDiffuseSky.ValueType = VarInfoValueTypes.GetInstanceForName("Double");
            _RadiationDiffuseSkyHourly.ValueType = VarInfoValueTypes.GetInstanceForName("ArrayDouble");
            _RadiationReflectedSoil.ValueType = VarInfoValueTypes.GetInstanceForName("Double");
            _RadiationReflectedSoilHourly.ValueType = VarInfoValueTypes.GetInstanceForName("ArrayDouble");
            _SlopeAspectFactor.ValueType = VarInfoValueTypes.GetInstanceForName("Double");
            _SlopeAspectFactorHourly.ValueType = VarInfoValueTypes.GetInstanceForName("ArrayDouble");
            _SolarDeclination.ValueType = VarInfoValueTypes.GetInstanceForName("Double");
            _SolarElevationHourly.ValueType = VarInfoValueTypes.GetInstanceForName("ArrayDouble");
            _SunshineDuration.ValueType = VarInfoValueTypes.GetInstanceForName("Double");
            #endregion ValueTypes
        }
        #endregion
    }
}