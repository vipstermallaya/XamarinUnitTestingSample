﻿using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Utilities.Interfaces
{
    public interface IWebserviceHandler
    {
        Task<object> GetWeatherDetails(double latitude, double longitude)  ;
    }
}
