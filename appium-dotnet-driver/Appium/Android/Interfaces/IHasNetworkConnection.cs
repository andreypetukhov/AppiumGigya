﻿using OpenQA.Selenium.Appium.Android.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OpenQA.Selenium.Appium.Android.Interfaces
{
    public interface IHasNetworkConnection
    {
        /// <summary>
        /// Get/set the Connection Type
        /// </summary>
        /// <returns>Connection Type of device</returns>
        /// <exception cref="System.InvalidCastException">Thrown when object return was not able to be converted to a ConnectionType Enum</exception>
        ConnectionType ConnectionType { get; set; }
    }
}
