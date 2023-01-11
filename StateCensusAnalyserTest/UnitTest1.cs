using ndianStatesCensusProblem;
using ndianStatesCensusProblem.DTO;
using NUnit.Framework;
using System.Collections.Generic;
using static ndianStatesCensusProblem.CensusAnalyser;

namespace StateCensusAnalyserTest
{
    public class Tests
    {
        static string indianStateCensusHeaders = "State,Population,AreaInSqKm,DensityPerSqKm";
        static string indianStateCensusfilePath = @"D:\OneDrive\Documents\BridgeLabz\IndianStatesCensusAnalyserProblem\StateCensusAnalyserTest\CSVFiles\IndianStateCensusData.csv";
        static string wrongHeaderIndianCensusfilePath = @"D:\OneDrive\Documents\BridgeLabz\IndianStatesCensusAnalyserProblem\StateCensusAnalyserTest\CSVFiles\WrongHeaderIndianStateCensusData.csv";
        static string delimiterIndianCensusfilePath = @"D:\OneDrive\Documents\BridgeLabz\IndianStatesCensusAnalyserProblem\StateCensusAnalyserTest\CSVFiles\DelimiterIndianCensusData.csv";
        static string wrongIndianStateCensusfilePath = @"D:\OneDrive\Documents\BridgeLabz\IndianStatesCensusAnalyserProblem\StateCensusAnalyserTest\CSVFiles\WrongIndianStateIndiaData.csv";
        static string wrongIndianStateCensusfileType = @"D:\OneDrive\Documents\BridgeLabz\IndianStatesCensusAnalyserProblem\StateCensusAnalyserTest\CSVFiles\IndianStateCensusData.txt";


        ndianStatesCensusProblem.CensusAnalyser censusAnalyser;
        Dictionary<string, CensusDTO> totalRecord;
        Dictionary<string, CensusDTO> stateRecord;

        [SetUp]
        public void Setup()
        {
            censusAnalyser = new ndianStatesCensusProblem.CensusAnalyser();
            totalRecord = new Dictionary<string, CensusDTO>();
            stateRecord = new Dictionary<string, CensusDTO>();
        }

        [Test]//tc1.1
        public void GivenIndianCensusDataFile_WhenReaded_ShouldReturnCensusDataCount()
        {
            totalRecord = censusAnalyser.LoadCensusData(Country.INDIA, indianStateCensusfilePath, indianStateCensusHeaders);
            Assert.AreEqual(0, totalRecord.Count);
        }
        [Test]//tc1.2
        public void GivenWrongIndianCensusDataFile_WhenReaded_ShouldReturnCustomException()
        {
            var censusException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(Country.INDIA, wrongIndianStateCensusfilePath, indianStateCensusHeaders));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.FILE_NOT_FOUND, censusException.eType);
        }
        [Test]//tc1.3
        public void GivenWrongIndianCensusDataFileType_WhenReaded_ShouldReturnCustomException()
        {
            var censusException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(Country.INDIA, wrongIndianStateCensusfileType, indianStateCensusHeaders));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INVALID_FILE_TYPE, censusException.eType);
        }
        [Test]//tc1.4
        public void GivenIndianCensusDataFile_WhenDelimiterNotProper_ShouldReturnException()
        {
            var censusException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(Country.INDIA, delimiterIndianCensusfilePath, indianStateCensusHeaders));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INCORRECT_DELIMITER, censusException.eType);
        }
        [Test]//tc1.5
        public void GivenWrongIndianCensusDataFileType_WhenHeaderNotProper_ShouldReturnException()
        {
            var censusException = Assert.Throws<CensusAnalyserException>(() => censusAnalyser.LoadCensusData(Country.INDIA, wrongHeaderIndianCensusfilePath, indianStateCensusHeaders));
            Assert.AreEqual(CensusAnalyserException.ExceptionType.INCORRECT_HEADER, censusException.eType);
        }


    }
}