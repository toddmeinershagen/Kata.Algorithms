using System.Collections.Generic;

namespace Kata.Algorithms.Sorting
{
	public interface ISorter
	{
		IEnumerable<int> Sort(IEnumerable<int> list);
	}
}