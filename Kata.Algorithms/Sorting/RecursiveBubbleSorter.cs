using System.Collections.Generic;
using System.Linq;

using Magnum;

namespace Kata.Algorithms.Sorting
{
	public class RecursiveBubbleSorter : ISorter
	{
		public IEnumerable<int> Sort(IEnumerable<int> list)
		{
			Guard.AgainstNull(list, "list");

			var values = list.ToArray();
			var anyChanges = false;

			if (values.Count() == 0)
				return values;

			for (var index = 0; index < values.Count() - 1; index++)
			{
				var nextIndex = index + 1;
				var current = values[index];
				var next = values[nextIndex];

				if (next < current)
				{
					values.SetValue(current, nextIndex);
					values.SetValue(next, index);
					anyChanges = true;
				}
			}

			return anyChanges ? Sort(values) : values;
		}
	}
}
