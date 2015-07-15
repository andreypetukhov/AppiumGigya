﻿using OpenQA.Selenium.Appium.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OpenQA.Selenium.Appium.Android.Interfaces
{
    public interface IAndroidDeviceActionShortcuts : IDeviceActionShortcuts
    {
        /// <summary>
        /// Triggers device key event with metastate for the keypress
        /// </summary>
        /// <param name="connectionType"></param>
        void KeyEvent(int keyCode, int metastate);
    }
}
