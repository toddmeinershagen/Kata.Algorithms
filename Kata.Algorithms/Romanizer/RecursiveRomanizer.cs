using System.Collections.Generic;
using System.Linq;

namespace Kata.Algorithms.Romanizer
{
	public class RecursiveRomanizer : IRomanizer
	{
		private readonly IDictionary<int, string> _numerals = new Dictionary<int, string>()
		{
			{1000, "M"},
			{900, "CM"},
			{500, "D"},
			{400, "CD"},
			{100, "C"},
			{90, "XC"},
			{50, "L"},
			{40, "XL"},
			{10, "X"},
			{9, "IX"},
			{5, "V"},
			{4, "IV"},
			{1, "I"}
		};

		public string Romanize(int value)
		{
			return Romanize(value, _numerals);
		}

		private string Romanize(int value, IDictionary<int, string> numerals, string result = "")
		{
			var numeral = numerals.First();
			
			do
			{
				if (numeral.Key > value) continue;

				value -= numeral.Key;
				result += numeral.Value;
			} while (value >= numeral.Key);

			if (value == 0)
				return result;

			numerals.Remove(numeral.Key);
			return Romanize(value, numerals, result);
		}
	}
}