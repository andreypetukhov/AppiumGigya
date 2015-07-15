using System;

namespace Appium.Samples.Helpers
{
	public class AppiumServers
	{
        public static Uri localURI = new Uri("http://192.168.11.5:4723/wd/hub");
		public static Uri sauceURI = new Uri("http://ondemand.saucelabs.com:80/wd/hub");
	}
}

