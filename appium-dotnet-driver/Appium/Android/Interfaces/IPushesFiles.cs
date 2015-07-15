﻿using System;
using System.Collections.Generic;
using System.Linq;
using OpenQA.Selenium.Appium.Interfaces;
using System.Text;

namespace OpenQA.Selenium.Appium.Android.Interfaces
{
    public interface IPushesFiles : IInteractsWithFiles
    {
        /// <summary>
        /// Pushes a File.
        /// </summary>
        /// <param name="pathOnDevice">path on device to store file to</param>
        /// <param name="base64Data">base 64 data to store as the file</param>
        void PushFile(string pathOnDevice, string base64Data);
    }
}
