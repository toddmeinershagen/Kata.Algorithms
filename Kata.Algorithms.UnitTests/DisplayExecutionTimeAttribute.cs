using System;
using System.Diagnostics;

using NUnit.Framework;

namespace Kata.Algorithms.UnitTests
{
	[AttributeUsage(AttributeTargets.Method | AttributeTargets.Class, AllowMultiple = true)]
	public class DisplayExecutionTimeAttribute : Attribute, ITestAction
	{
		private readonly Stopwatch _watch;

		public DisplayExecutionTimeAttribute()
		{
			_watch = new Stopwatch();
		}

		public void BeforeTest(TestDetails testDetails)
		{
			_watch.Start();
		}

		public void AfterTest(TestDetails testDetails)
		{
			_watch.Stop();

			Console.WriteLine(testDetails.Fixture);
			Console.WriteLine("Execution Time:  {0}", _watch.Elapsed);
		}

		public ActionTargets Targets { get; private set; }
	}
}