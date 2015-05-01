﻿using System.Collections.Generic;
using System.Linq;

using Magnum;

namespace Kata.Algorithms.Sorting
{
	public class IterativeBucketSorter
	{
		public IEnumerable<int> Sort(int[] list)
		{
			Guard.AgainstNull(list, "list");

			if (list.Count() <= 1)
			{
				foreach (var item in list)
				{
					yield return item;
				}
				yield break;
			}

			var max = 0;
			foreach (var item in list)
			{
				if (max < item)
					max = item;
			}

			var results = new List<int>[max];
			foreach (var item in list)
			{
				var index = item - 1;
				if (results[index] == null)
				{
					results[index] = new List<int>();
				}

				results[item - 1].Add(item);
			}

			foreach (var result in results)
			{
				if (result != null && result.Count != 0)
				{
					foreach (var item in result)
					{
						yield return item;
					}
				}
			}
		}
	}
}