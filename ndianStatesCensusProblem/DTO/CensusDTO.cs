﻿using ndianStatesCensusProblem.POCO;
using System;
using System.Collections.Generic;
using System.Text;

namespace ndianStatesCensusProblem.DTO
{
    public class CensusDTO
    {
        public int serialNumber;
        public string stateName;
        public string state;
        public int tin;
        public string stateCode;
        public long population;
        public long area;
        public long density;
        public CensusDTO(CensusDataDAO censusDataDao)
        {
            this.state = censusDataDao.state;
            this.population = censusDataDao.population;
            this.area = censusDataDao.area;
            this.density = censusDataDao.density;
        }
        public CensusDTO(StateCodeDAO stateCodeDAO)
        {
            this.serialNumber = stateCodeDAO.serialNumber;
            this.stateName = stateCodeDAO.stateName;
            this.tin = stateCodeDAO.tin;
            this.stateCode = stateCodeDAO.stateCode;
        }
    }
}