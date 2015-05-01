using System.Collections.Generic;
using System.Linq;

using Magnum;

namespace Kata.Algorithms.Sorting
{
	/// <summary>
	/// Bucket sort is O(n) complexity
	/// </summary>
	/// <remarks>
	/// Technique works well with positive integers.  However, it does require handling duplicates and discovering what the max number is in order 
	/// to create a bucket with enough slots to sort.
	/// </remarks>
	public class IterativeBucketSorter : ISorter
	{
		public IEnumerable<int> Sort(IEnumerable<int> list)
		{
			Guard.AgainstNull(list, "list");

			if (list.Count() <= 1)
			{
				return list;
			}

			var max = 0;
			foreach (var item in list)
			{
				if (max < item)
					max = item;
			}

			var bucket = new List<int>[max];
			foreach (var item in list)
			{
				var index = item - 1;
				if (bucket[index] == null)
				{
					bucket[index] = new List<int>();
				}

				bucket[item - 1].Add(item);
			}

			var results = new List<int>();
			foreach (var result in bucket)
			{
				if (result != null && result.Count != 0)
				{
					foreach (var item in result)
					{
						results.Add(item);
					}
				}
			}

			return results;
		}
	}
}