﻿using System;
using OpenQA.Selenium.Appium.Interfaces;
using System.Collections.Generic;
using System.Reflection;

namespace OpenQA.Selenium.Appium.MultiTouch
{

	public class TouchAction : ITouchAction
	{
		internal class Step {
			private Dictionary<string, object> parameters = new Dictionary<string, object>();

			private string getIdForElement(IWebElement el) {
				return (string) typeof(OpenQA.Selenium.Remote.RemoteWebElement).GetField("elementId", 
					BindingFlags.NonPublic | BindingFlags.Instance).GetValue(el);
			}

			public Step(string action) {
				parameters.Add("action", action);
			}

			public Step AddOpt (string name, object value) {
				if (value != null) {
					if(!parameters.ContainsKey("options")) parameters.Add("options", new Dictionary<string, object> ());
					if (value is IWebElement) {
						string id = getIdForElement ((IWebElement)value);
						((Dictionary<string, object>)this.parameters ["options"]).Add (name, id);
					} else if (value is double) {
						double doubleValue = (double) value;
						if (doubleValue == (int) doubleValue) {
							((Dictionary<string, object>)this.parameters ["options"])
								.Add (name, (int) doubleValue);
						} else {
							((Dictionary<string, object>)this.parameters ["options"])
								.Add (name, doubleValue);
						}
					} else {
						((Dictionary<string, object>)this.parameters ["options"]).Add (name, value);
					}
				}
				return this;
			}

			public Dictionary<string, object> GetParameters() {
				return parameters;
			}
		}

		private AppiumDriver driver;
		private List<Step> steps = new List<Step>();

		public TouchAction ()
		{
		}

		public TouchAction (AppiumDriver driver)
		{
			this.driver = driver;
		}

		/// <summary>
		/// Press at the specified location in the element until the  context menu appears.
		/// </summary>
		/// <param name="element">The target element.</param>
		/// <param name=x>The x coordinate relative to the element.</param>
		/// <param name=y>The y coordinate relative to the element.</param>
		/// <returns>A self-reference to this <see cref="ITouchAction"/>.</returns>
		public ITouchAction LongPress(IWebElement element, double? x = null, double? y = null)
		{
			Step longPressStep = new Step("longpress");
			longPressStep
				.AddOpt ("element", element)
				.AddOpt("x", x)
				.AddOpt("y", y);
			this.steps.Add (longPressStep);
			return this;
		}

		/// <summary>
		/// Press at the specified location in the element until the  context menu appears.
		/// </summary>
		/// <param name="element">The target element.</param>
		/// <param name=x>The x coordinate relative to the element.</param>
		/// <param name=y>The y coordinate relative to the element.</param>
		/// <returns>A self-reference to this <see cref="ITouchAction"/>.</returns>
		public ITouchAction LongPress(double x, double y)
		{
			Step longPressStep = new Step("longpress");
			longPressStep
				.AddOpt("x", x)
				.AddOpt("y", y);
			this.steps.Add (longPressStep);
			return this;
		}

		/// <summary>
		/// Move to the specified location in the element.
		/// </summary>
		/// <param name="element">The target element.</param>
		/// <param name=x>The x coordinate relative to the element.</param>
		/// <param name=y>The y coordinate relative to the element.</param>
		/// <returns>A self-reference to this <see cref="ITouchAction"/>.</returns>
		public ITouchAction MoveTo(IWebElement element, double? x = null, double? y = null)
		{
			Step moveToStep = new Step("moveTo");
			moveToStep
				.AddOpt ("element", element)
				.AddOpt("x", x)
				.AddOpt("y", y);
			this.steps.Add (moveToStep);
			return this;
		}

		/// <summary>
		/// Move to the specified location.
		/// </summary>
		/// <param name=x>The x coordinate.</param>
		/// <param name=y>The y coordinate.</param>
		/// <returns>A self-reference to this <see cref="ITouchAction"/>.</returns>
		public ITouchAction MoveTo(double x, double y)
		{
			Step moveToStep = new Step("moveTo");
			moveToStep
				.AddOpt("x", x)
				.AddOpt("y", y);
			this.steps.Add (moveToStep);
			return this;
		}
				
		/// <summary>
		/// Press at the specified location in the element.
		/// </summary>
		/// <param name="element">The target element.</param>
		/// <param name=x>The x coordinate relative to the element.</param>
		/// <param name=y>The y coordinate relative to the element.</param>
		/// <returns>A self-reference to this <see cref="ITouchAction"/>.</returns>
		public ITouchAction Press(IWebElement element, double? x = null, double? y = null)
		{
			Step pressStep = new Step("press");
			pressStep
				.AddOpt ("element", element)
				.AddOpt("x", x)
				.AddOpt("y", y);
			this.steps.Add (pressStep);
			return this;
		}

		/// <summary>
		/// Press at the specified location.
		/// </summary>
		/// <param name=x>The x coordinate.</param>
		/// <param name=y>The y coordinate.</param>
		/// <returns>A self-reference to this <see cref="ITouchAction"/>.</returns>
		public ITouchAction Press(double x, double y)
		{
			Step pressStep = new Step("press");
			pressStep
				.AddOpt("x", x)
				.AddOpt("y", y);
			this.steps.Add (pressStep);
			return this;
		}

		/// <summary>
		/// Release the pressure.
		/// </summary>
		/// <returns>A self-reference to this <see cref="ITouchAction"/>.</returns>
		public ITouchAction Release()
		{
			Step releaseStep = new Step("release");
			this.steps.Add (releaseStep);
			return this;
		}

		/// <summary>
		/// Tap at the specified location in the element.
		/// </summary>
		/// <param name="element">The target element.</param>
		/// <param name="x">The x coordinate relative to the element.</param>
		/// <param name="y">The y coordinate relative to the element.</param>
		/// <param name="count">The number of times to tap.</param>
		/// <returns>A self-reference to this <see cref="ITouchAction"/>.</returns>
		public ITouchAction Tap(IWebElement element, double? x = null, double? y = null, long? count = null)
		{
			Step tapStep = new Step("tap");
			tapStep
				.AddOpt ("element", element)
				.AddOpt("x", x)
				.AddOpt("y", y)
				.AddOpt("count", count);
			this.steps.Add (tapStep);
			return this;
		}

		/// <summary>
		/// Tap at the specified location.
		/// </summary>
		/// <param name="x">The x coordinate relative to the element.</param>
		/// <param name="y">The y coordinate relative to the element.</param>
		/// <param name="count">The number of times to tap.</param>
		/// <returns>A self-reference to this <see cref="ITouchAction"/>.</returns>
		public ITouchAction Tap(double x, double y, long? count = null)
		{
			Step tapStep = new Step("tap");
			tapStep
				.AddOpt("x", x)
				.AddOpt("y", y)
				.AddOpt("count", count);
			this.steps.Add (tapStep);
			return this;
		}

		/// <summary>
		/// Wait for the given duration.
		/// </summary>
		/// <param name="ms">The amount of time to wait in milliseconds.</param>
		/// <returns>A self-reference to this <see cref="ITouchAction"/>.</returns>
		public ITouchAction Wait(long? ms = null)
		{
			Step waitStep = new Step("wait");
			waitStep
				.AddOpt ("ms", ms);
			this.steps.Add (waitStep);
			return this;
		}

		public List<Dictionary<string, object>> GetParameters() {
			List<Dictionary<string, object>> parameters = new List<Dictionary<string, object>> ();
			for(int i=0; i<this.steps.Count; i++) {
				parameters.Add(steps[i].GetParameters());
			}
			return parameters;
		}

		/// <summary>
		/// Cancels the Touch Action
		/// </summary>
		public void Cancel()
		{
			this.driver = null;
			steps.Clear ();
		}

		/// <summary>
		/// Executes the Touch Action
		/// </summary>
		public void Perform()
		{
			this.driver.PerformTouchAction (this);
		}

	}
}

