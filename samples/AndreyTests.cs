using NUnit.Framework;
using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Appium.Interfaces;
using OpenQA.Selenium.Appium.MultiTouch;
using OpenQA.Selenium.Interactions;
using OpenQA.Selenium.Remote;
using OpenQA.Selenium.Appium.Android;
using System.Collections.ObjectModel;
using System.Threading;
using System.Collections.Generic;

namespace Appium.Samples
{
    [TestFixture()]
    public class TestAppium
    {
        public AppiumDriver driver;

        [TestFixtureSetUp]
        public void SetUp()
        {
            DesiredCapabilities capabilities = new DesiredCapabilities();
            capabilities.SetCapability("device", "Android");
            capabilities.SetCapability("deviceName", "device");
            capabilities.SetCapability("platformName", "Android");
            capabilities.SetCapability("useKeystore", "true"); 
            capabilities.SetCapability("keystorePath", "C:/Users/andrey/.android/debug.keystore");
            

            driver = new AndroidDriver(new Uri("http://127.0.0.1:4723/wd/hub"), capabilities, TimeSpan.FromSeconds(180));
        }

        [Test()]
        public void FacebookNativeLoginAndroidApp()
        {
            string handleWeb = String.Empty, handleNative = String.Empty;
            handleNative = driver.Context;
            driver.FindElementById("com.example.denistester:id/LoginUI").Click();
            Thread.Sleep(3000);
            ReadOnlyCollection<string> contexts = driver.Contexts;
            foreach (var context in contexts)
            {
                if (context.Contains("WEBVIEW"))
                    handleWeb = context;

            }
            driver.Context = handleWeb;

           driver.FindElementByXPath("//span[text()='Facebook']").Click();
           Thread.Sleep(5000);
           driver.Context = handleNative;
           IWebElement elem =  driver.FindElementById("com.example.denistester:id/output");
           string info = elem.Text;
           if(!(info.Contains("Valdo")))
            Assert.Fail("No user");
          

           
        }

        [Test()]
        public void FacebookWebLoginAndroidApp()
        {
            string handleWeb = String.Empty, handleNative = String.Empty;
            handleNative = driver.Context;
            driver.FindElementById("com.example.denistester:id/LoginUI").Click();
            Thread.Sleep(3000);
            ReadOnlyCollection<string> contexts = driver.Contexts;
            foreach (var context in contexts)
            {
                if (context.Contains("WEBVIEW"))
                    handleWeb = context;

            }
            driver.Context = handleWeb;

            driver.FindElementByXPath("//span[text()='Facebook']").Click();
            Thread.Sleep(5000);
            driver.Context = handleNative;
            IWebElement elem = driver.FindElementById("com.example.denistester:id/output");
            string info = elem.Text;
            if (!(info.Contains("Valdo")))
                Assert.Fail("No user");
          
        }

        [TestFixtureTearDown]
        public void End()
        {
            driver.Dispose();
        }
    }

    }

