
using NUnit.Framework;
using System;
using Appium.Samples.Helpers;
using OpenQA.Selenium.Appium;
using OpenQA.Selenium.Remote;
using System.Collections.Generic;
using OpenQA.Selenium;
using System.Threading;
using System.Drawing;
using OpenQA.Selenium.Appium.Interfaces;
using OpenQA.Selenium.Appium.MultiTouch;
using System.Collections.ObjectModel;
using OpenQA.Selenium.Appium.iOS;
using OpenQA.Selenium.Appium.iOS.Enums;

namespace Appium.Samples
{
    [TestFixture()]
    public class AndreyIOSTests
    {
        public AppiumDriver driver;

        [TestFixtureSetUp]
        public void SetUp()
        {
            DesiredCapabilities capabilities = new DesiredCapabilities();
            capabilities.SetCapability("deviceName", "dooby");
            capabilities.SetCapability("platformName", "iOS");
            capabilities.SetCapability("app", "/Users/gigyaqa/Documents/3.4.0/DenisTester.app");

            driver = new IOSDriver(new Uri("http://192.168.11.5:4723/wd/hub"), capabilities, TimeSpan.FromSeconds(180));
        }

        [Test()]
        public void FacebookNativeLoginIOSApp()
        {
            string handleWeb = String.Empty, nativeHandle= String.Empty;
            driver.FindElementByName("LoginUI").Click();
            Thread.Sleep(1000);
            ReadOnlyCollection<string> contexts = driver.Contexts;
            foreach (var context in contexts)
            {
                if (context.Contains("WEBVIEW"))
                    handleWeb = context;
                if (context.Contains("NATIVE"))
                    nativeHandle = context;

            }
            driver.Context = handleWeb;
            Thread.Sleep(5000);
            driver.FindElementByXPath("//span[text()='Facebook']").Click();
            Thread.Sleep(5000);
            driver.Context = nativeHandle;
            driver.FindElementByName("Logout").Click();
            /*
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
            */


        }



        [Test()]
        public void LinkedinWebLoginIOSApp()
        {
            string handleWeb = String.Empty, nativeHandle = String.Empty,handleLinkedin=String.Empty;
            driver.FindElementByName("LoginUI").Click();
            Thread.Sleep(1000);
            ReadOnlyCollection<string> contexts = driver.Contexts;
            foreach (var context in contexts)
            {
                if (context.Contains("WEBVIEW"))
                    handleWeb = context;
                if (context.Contains("NATIVE"))
                    nativeHandle = context;

            }
            driver.Context = handleWeb;
            Thread.Sleep(5000);
            driver.FindElementByXPath("//span[text()='LinkedIn']").Click();
            Thread.Sleep(5000);
            ReadOnlyCollection<string> contextsWeb = driver.Contexts;
            foreach(string context in contextsWeb)
                if (!(contexts.Contains(context)))
                {
                    handleLinkedin = context;
                }

          

            driver.Context = handleLinkedin;
            driver.FindElementByXPath("//input[@placeholder='Email']").SendKeys("gigyaauto02@gmail.com");
            driver.FindElementByXPath("//input[@placeholder='Password']").SendKeys("P@ssw0rd100");
            driver.FindElementByXPath("//input[@class='allow']").Click();
            Thread.Sleep(15000);
            driver.Context = nativeHandle;
            driver.FindElementByName("Logout").Click();
            /*
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
            */


        }

        

        [TestFixtureTearDown]
        public void End()
        {
            driver.Dispose();
        }
    }
}
