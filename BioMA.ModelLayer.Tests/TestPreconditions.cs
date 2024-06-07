using CRA.Clima.ET.Interfaces;
using CRA.Clima.ET.Strategies;
using CRA.Clima.SolarR.Interfaces;
using CRA.Clima.SolarR.Strategies;
using CRA.ModelLayer.Core;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BioMA.ModelLayer.NetFramework.Tests
{
    [TestClass]
    public class TestPreconditions
    {
        [TestMethod]
        public void TestNullPointerException()
        {
            try
            {
                HGSRGlobalSolarRadiationHourly s = new HGSRGlobalSolarRadiationHourly();
                RadData d = null;
                s.TestPreConditions(d, "call");
            }catch (Exception)
            {

            }
        }

        [TestMethod]
        public void HGSRGlobalSolarRadiation_AtLeastOneDifferentFromZeroCondition()
        {
            HGSRGlobalSolarRadiationHourly s = new HGSRGlobalSolarRadiationHourly();
            RadData d = new RadData();
            d.GlobalSolarRadiation = 0.1;

            string preconditions;
            //All NaN
            PreconditionErrorException preconditionErrorException = null;
            try
            {
                d.ExtraterrestrialRadiationHourly = new double[] { double.NaN, double.NaN };
                preconditions = s.TestPreConditions(d, "callID");
            }
            catch (Exception pee)
            {
                preconditionErrorException = PreconditionErrorException.GetInnerPreconditionsErrorException(pee);
            }
            Assert.IsNotNull(preconditionErrorException);
            Assert.AreEqual("ExtraterrestrialRadiationHourly[0] cannot be double.NaN callID;\r\nExtraterrestrialRadiationHourly[1] cannot be double.NaN callID;\r\nExtraterrestrialRadiationHourly[0] cannot be double.NaN callID;\r\nExtraterrestrialRadiationHourly[1] cannot be double.NaN callID;\r\n", preconditionErrorException.Message);

            //first NaN
            preconditionErrorException = null;
            try
            {
                d.ExtraterrestrialRadiationHourly = new double[] { double.NaN, 0.1 };
                preconditions = s.TestPreConditions(d, "callID");
            }
            catch (Exception pee)
            {
                preconditionErrorException = PreconditionErrorException.GetInnerPreconditionsErrorException(pee);
            }
            Assert.IsNotNull(preconditionErrorException);
            Assert.AreEqual("ExtraterrestrialRadiationHourly[0] cannot be double.NaN callID;\r\nExtraterrestrialRadiationHourly[0] cannot be double.NaN callID;\r\n", preconditionErrorException.Message);

            //all 0            
            d.ExtraterrestrialRadiationHourly = new double[] { 0.0, 0.0 };
            preconditions = s.TestPreConditions(d, "callID");
            Assert.AreEqual("PRE-CONDITIONS: all ExtraterrestrialRadiationHourly[ ] = 0  (at least one should have been different from 0) callID;\r\n", preconditions);
        }

        [TestMethod]
        public void HADAsaeDoubleArrayNaN()
        {
            HADAsae s = new HADAsae();
            ETData d = new ETData();

            string preconditions;
            //All NaN
            PreconditionErrorException preconditionErrorException = null;
            try
            {
                d.AirTemperatureHourly = new double[] { double.NaN, double.NaN, double.NaN };
                preconditions = s.TestPreConditions(d, "callID");
            }
            catch (Exception pee)
            {
                preconditionErrorException = PreconditionErrorException.GetInnerPreconditionsErrorException(pee);
            }
            Assert.IsNotNull(preconditionErrorException);
            Assert.AreEqual("AirTemperatureHourly[0] cannot be double.NaN callID;\r\nAirTemperatureHourly[1] cannot be double.NaN callID;\r\nAirTemperatureHourly[2] cannot be double.NaN callID;\r\n", preconditionErrorException.Message);

            // First NaN
            preconditionErrorException = null;
            try
            {
                d.AirTemperatureHourly = new double[] { double.NaN, 0.0, 0.0 };
                preconditions = s.TestPreConditions(d, "callID");
            }
            catch (Exception pee)
            {
                preconditionErrorException = PreconditionErrorException.GetInnerPreconditionsErrorException(pee);
            }
            Assert.IsNotNull(preconditionErrorException);
            Assert.AreEqual("AirTemperatureHourly[0] cannot be double.NaN callID;\r\n", preconditionErrorException.Message);

            // First NaN, second outside range
            preconditionErrorException = null;
            try
            {
                d.AirTemperatureHourly = new double[] { double.NaN, 1000.0, 0.0 };
                preconditions = s.TestPreConditions(d, "callID");
            }
            catch (Exception pee)
            {
                preconditionErrorException = PreconditionErrorException.GetInnerPreconditionsErrorException(pee);
            }
            Assert.IsNotNull(preconditionErrorException);
            Assert.AreEqual("AirTemperatureHourly[0] cannot be double.NaN callID;\r\n", preconditionErrorException.Message);

            // Second NaN
            preconditionErrorException = null;
            try
            {
                d.AirTemperatureHourly = new double[] { 0.0, double.NaN, 0.0 };
                preconditions = s.TestPreConditions(d, "callID");
            }
            catch (Exception pee)
            {
                preconditionErrorException = PreconditionErrorException.GetInnerPreconditionsErrorException(pee);
            }
            Assert.IsNotNull(preconditionErrorException);
            Assert.AreEqual("AirTemperatureHourly[1] cannot be double.NaN callID;\r\n", preconditionErrorException.Message);

            // Second outside range
            d.AirTemperatureHourly = new double[] { 0.0, 1000.0, 0.0 };
            preconditions = s.TestPreConditions(d, "callID");

            Assert.AreEqual("PRE-CONDITIONS: AirTemperatureHourly[1] = 1000 (max=50 - min=-25) callID;\r\n", preconditions);

            // All OK
            d.AirTemperatureHourly = new double[] { 0.0, 0.0, 0.0 };
            preconditions = s.TestPreConditions(d, "callID");

            Assert.AreEqual("", preconditions);
        }

        [TestMethod]
        public void DADAsaeTestPreconditionsDoubleNaN()
        {
            DADAsae s = new DADAsae();
            ETData d = new ETData();

            string preconditions;
            //NaN
            PreconditionErrorException preconditionErrorException = null;
            try
            {
                d.AirTemperatureMax = double.NaN;
                preconditions = s.TestPreConditions(d, "callID");
            }
            catch (Exception pee)
            {
                preconditionErrorException = PreconditionErrorException.GetInnerPreconditionsErrorException(pee);
            }
            Assert.IsNotNull(preconditionErrorException);
            Assert.AreEqual("AirTemperatureMax cannot have a value of double.NaN callID;\r\n", preconditionErrorException.Message);

            //More than max
            d.AirTemperatureMax = 51;
            preconditions = s.TestPreConditions(d, "callID");
            Assert.AreEqual("PRE-CONDITIONS: AirTemperatureMax = 51 (max=50 - min=-10) callID;\r\n", preconditions);


            //Less than min
            d.AirTemperatureMax = -11;
            preconditions = s.TestPreConditions(d, "callID");
            Assert.AreEqual("PRE-CONDITIONS: AirTemperatureMax = -11 (max=50 - min=-10) callID;\r\n", preconditions);

            //OK
            d.AirTemperatureMax = 0;
            preconditions = s.TestPreConditions(d, "callID");
            Assert.AreEqual("", preconditions);
        }

        [TestMethod]
        public void GreaterThanCondition()
        {
            HPBDSupitVanDerGroot s = new HPBDSupitVanDerGroot();
            RadData d = new RadData();

            d.GlobalSolarRadiation = 28.1;
            d.RadiationDiffuseSky = 1;

            string preconditions = null;
            PreconditionErrorException preconditionErrorException = null;

            preconditions = s.TestPreConditions(d, "callID");

            // All OK
            Assert.AreEqual("", preconditions);

            //Preconditions not respected
            d.GlobalSolarRadiation = 28.1;
            d.RadiationDiffuseSky = 30;

            preconditions = s.TestPreConditions(d, "callID");
            Assert.AreEqual("PRE-CONDITIONS: GlobalSolarRadiation < RadiationDiffuseSky (28.1 < 30) callID;\r\n", preconditions);

            //First variable NaN
            d.GlobalSolarRadiation = double.NaN;
            preconditionErrorException = null;
            try
            {
                preconditions = s.TestPreConditions(d, "callID");
            }
            catch(Exception pee)
            {
                preconditionErrorException = PreconditionErrorException.GetInnerPreconditionsErrorException(pee);
            }

            Assert.IsNotNull(preconditionErrorException);
            Assert.AreEqual("GlobalSolarRadiation cannot have a value of double.NaN callID;\r\n", preconditionErrorException.Message);

            //Second variable NaN
            d.GlobalSolarRadiation = 28.1;
            d.RadiationDiffuseSky = double.NaN;
            preconditionErrorException = null;
            try
            {
                preconditions = s.TestPreConditions(d, "callID");
            }
            catch (Exception pee)
            {
                preconditionErrorException = PreconditionErrorException.GetInnerPreconditionsErrorException(pee);
            }

            Assert.IsNotNull(preconditionErrorException);
            Assert.AreEqual("RadiationDiffuseSky cannot have a value of double.NaN callID;\r\n", preconditionErrorException.Message);

            //Both variables NaN
            d.GlobalSolarRadiation = double.NaN;
            d.RadiationDiffuseSky = double.NaN;
            preconditionErrorException = null;
            try
            {
                preconditions = s.TestPreConditions(d, "callID");
            }
            catch (Exception pee)
            {
                preconditionErrorException = PreconditionErrorException.GetInnerPreconditionsErrorException(pee);
            }

            Assert.IsNotNull(preconditionErrorException);
            Assert.AreEqual("GlobalSolarRadiation cannot have a value of double.NaN callID;\r\nRadiationDiffuseSky cannot have a value of double.NaN callID;\r\n", preconditionErrorException.Message);
        }

        [TestMethod]
        public void NotZeroIfSecondNotZero()
        {
            HPBDNotZeroIfSecondNotZero s = new HPBDNotZeroIfSecondNotZero();
            RadData d = new RadData();

            d.GlobalSolarRadiation = 28.1;
            d.RadiationDiffuseSky = 1;

            string preconditions = null;
            PreconditionErrorException preconditionErrorException = null;

            preconditions = s.TestPreConditions(d, "callID");

            // All OK
            Assert.AreEqual("", preconditions);

            d.GlobalSolarRadiation = 0.0;
            d.RadiationDiffuseSky = 0.0;

            preconditions = s.TestPreConditions(d, "callID");

            // All OK
            Assert.AreEqual("", preconditions);

            //Preconditions not respected
            d.GlobalSolarRadiation = 0.0;
            d.RadiationDiffuseSky = 30;

            preconditions = s.TestPreConditions(d, "callID");
            Assert.AreEqual("PRE-CONDITIONS: GlobalSolarRadiation cannot be = 0 if RadiationDiffuseSky is <> 0 (RadiationDiffuseSky = 30 callID;\r\n", preconditions);

            //First variable NaN
            d.GlobalSolarRadiation = double.NaN;
            preconditionErrorException = null;
            try
            {
                preconditions = s.TestPreConditions(d, "callID");
            }
            catch (Exception pee)
            {
                preconditionErrorException = PreconditionErrorException.GetInnerPreconditionsErrorException(pee);
            }

            Assert.IsNotNull(preconditionErrorException);
            Assert.AreEqual("GlobalSolarRadiation cannot have a value of double.NaN callID;\r\n", preconditionErrorException.Message);

            //Second variable NaN
            d.GlobalSolarRadiation = 28.1;
            d.RadiationDiffuseSky = double.NaN;
            preconditionErrorException = null;
            try
            {
                preconditions = s.TestPreConditions(d, "callID");
            }
            catch (Exception pee)
            {
                preconditionErrorException = PreconditionErrorException.GetInnerPreconditionsErrorException(pee);
            }

            Assert.IsNotNull(preconditionErrorException);
            Assert.AreEqual("RadiationDiffuseSky cannot have a value of double.NaN callID;\r\n", preconditionErrorException.Message);

            //Both variables NaN
            d.GlobalSolarRadiation = double.NaN;
            d.RadiationDiffuseSky = double.NaN;
            preconditionErrorException = null;
            try
            {
                preconditions = s.TestPreConditions(d, "callID");
            }
            catch (Exception pee)
            {
                preconditionErrorException = PreconditionErrorException.GetInnerPreconditionsErrorException(pee);
            }

            Assert.IsNotNull(preconditionErrorException);
            Assert.AreEqual("GlobalSolarRadiation cannot have a value of double.NaN callID;\r\nRadiationDiffuseSky cannot have a value of double.NaN callID;\r\n", preconditionErrorException.Message);
        }

        [TestMethod]
        public void RangeOneRangeTwo()
        {
            HPBDRangeOneRangeTwo s = new HPBDRangeOneRangeTwo();
            RadData d = new RadData();

            d.GlobalSolarRadiation = 28.1;
            d.RadiationDiffuseSky = 1;

            string preconditions = null;
            PreconditionErrorException preconditionErrorException = null;

            preconditions = s.TestPreConditions(d, "callID");

            // All OK
            Assert.AreEqual("", preconditions);

            d.GlobalSolarRadiation = 38;
            d.RadiationDiffuseSky = 16;

            preconditions = s.TestPreConditions(d, "callID");

            // All OK
            Assert.AreEqual("", preconditions);

            // All OK
            d.GlobalSolarRadiation = 0.0;
            d.RadiationDiffuseSky = 30;

            preconditions = s.TestPreConditions(d, "callID");
            Assert.AreEqual("", preconditions);

            // Preconditions not respected
            d.GlobalSolarRadiation = 40;
            d.RadiationDiffuseSky = 14;

            preconditions = s.TestPreConditions(d, "callID");
            Assert.AreEqual("PRE-CONDITIONS: GlobalSolarRadiation = 40. It cannot outrange (0.01-38) if RadiationDiffuseSky is within (0.1-15) callID;\r\n", preconditions);

            //First variable NaN
            d.GlobalSolarRadiation = double.NaN;
            preconditionErrorException = null;
            try
            {
                preconditions = s.TestPreConditions(d, "callID");
            }
            catch (Exception pee)
            {   
                preconditionErrorException = PreconditionErrorException.GetInnerPreconditionsErrorException(pee);
            }

            Assert.IsNotNull(preconditionErrorException);
            Assert.AreEqual("GlobalSolarRadiation cannot have a value of double.NaN callID;\r\n", preconditionErrorException.Message);

            //Second variable NaN
            d.GlobalSolarRadiation = 28.1;
            d.RadiationDiffuseSky = double.NaN;
            preconditionErrorException = null;
            try
            {
                preconditions = s.TestPreConditions(d, "callID");
            }
            catch (Exception pee)
            {
                preconditionErrorException = PreconditionErrorException.GetInnerPreconditionsErrorException(pee);
            }

            Assert.IsNotNull(preconditionErrorException);
            Assert.AreEqual("RadiationDiffuseSky cannot have a value of double.NaN callID;\r\n", preconditionErrorException.Message);

            //Both variables NaN
            d.GlobalSolarRadiation = double.NaN;
            d.RadiationDiffuseSky = double.NaN;
            preconditionErrorException = null;
            try
            {
                preconditions = s.TestPreConditions(d, "callID");
            }
            catch (Exception pee)
            {
                preconditionErrorException = PreconditionErrorException.GetInnerPreconditionsErrorException(pee);
            }

            Assert.IsNotNull(preconditionErrorException);
            Assert.AreEqual("GlobalSolarRadiation cannot have a value of double.NaN callID;\r\nRadiationDiffuseSky cannot have a value of double.NaN callID;\r\n", preconditionErrorException.Message);
        }
    }
}
