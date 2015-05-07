using System.Collections.Generic;
using System.Text;

namespace Kata.Algorithms.Romanizer
{
	public class IterativeRomanizer : IRomanizer
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
			var builder = new StringBuilder();

			foreach (var numeral in _numerals)
			{
				do
				{
					if (numeral.Key > value) continue;

					value -= numeral.Key;
					builder.Append(numeral.Value);
				} while (value >= numeral.Key);

				if (value == 0)
					break;
			}

			return builder.ToString();
		}
	}
}