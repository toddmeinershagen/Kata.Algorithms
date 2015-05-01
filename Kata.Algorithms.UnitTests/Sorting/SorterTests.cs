using System;
using System.Diagnostics;
using System.Linq;

using FluentAssertions;

using Kata.Algorithms.Sorting;

using NUnit.Framework;

namespace Kata.Algorithms.UnitTests.Sorting
{
	[TestFixture(typeof(IterativeBucketSorter))]
	[TestFixture(typeof(IterativeYieldingBucketSorter))]
	public class SorterTests<TSorter> 
		where TSorter : ISorter, new()
	{
		private TSorter _sorter;

		[SetUp]
		public void SetUp()
		{
			_sorter = new TSorter();
		}

		[TestCase(new int[] { }, new int[] { })]
		[TestCase(new[] { 1 }, new[] { 1 })]
		[TestCase(new[] { 1, 3, 5 }, new[] { 1, 3, 5 })]
		[TestCase(new[] { 4, 1, 8, 10, 2, 14, 5 }, new [] { 1, 2, 4, 5, 8, 10, 14 })]
		[TestCase(new[] { 4, 1, 4, 7, 2, 10, 1, 7 }, new [] { 1, 1, 2, 4, 4, 7, 7, 10 })]
		public void given_list_of_integers_when_sorting_should_match_sorted_list(int[] list, int[] expected)
		{
			var results = _sorter.Sort(list);
			results.Should().BeEquivalentTo(expected);
		}

		[Test]
		public void given_null_list_when_sorting_should_throw()
		{
			Action action = () => _sorter.Sort(null).ToList();

			action
				.ShouldThrow<ArgumentNullException>()
				.WithMessage("Value cannot be null.\r\nParameter name: list");
		}

		[Test]
		public void given_sorter_and_list_when_sorting_a_million_times_should_display_total_run_time()
		{
			var list = new[] { 4, 1, 4, 7, 2, 10, 1, 7, 4, 1, 4, 7, 2, 10, 1, 7, 4, 1, 4, 7, 2, 10, 1, 7, 4, 1, 4, 7, 2, 10, 1, 7 };

			var timer = new Stopwatch();
			timer.Start();

			Enumerable.Range(0, 1000000).ToList().ForEach(index => _sorter.Sort(list));

			timer.Stop();

			Debug.WriteLine("{0} - {1} second(s)", typeof(TSorter).Name, timer.Elapsed.TotalSeconds);
		}
	}
}
