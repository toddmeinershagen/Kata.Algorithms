using FluentAssertions;

using Kata.Algorithms.Romanizer;

using NUnit.Framework;

namespace Kata.Algorithms.UnitTests.Romanizer
{
	/// <summary>
	/// (From http://en.wikipedia.org/wiki/Roman_numerals)
	/// 
	/// Roman numerals, as used today, are based on seven symbols:
	///	Symbol	Value
	///	I		1
	///	V		5
	///	X		10
	///	L		50
	///	C		100
	///	D		500
	///	M		1,000
	/// Numbers are formed by combining symbols and adding the values. So II is two ones, i.e. 2, and XIII is a ten and three ones, i.e. 13. There is no zero in this system, so 207, for example, is CCVII, using the symbols for two hundreds, a five and two ones. 1066 is MLXVI, one thousand, fifty and ten, a five and a one.
	///
	/// Symbols are placed from left to right in order of value, starting with the largest. However, in a few specific cases, to avoid four characters being repeated in succession (such as IIII or XXXX) these can be reduced using subtractive notation as follows:
	///
	/// * I can be placed before V and X to make 4 units (IV) and 9 units (IX) respectively
	/// * X can be placed before L and C to make 40 (XL) and 90 (XC) respectively
	/// * C can be placed before D and M to make 400 (CD) and 900 (CM) according to the same pattern
	/// </summary>
	[TestFixture(typeof(IterativeRomanizer))]
	[TestFixture(typeof(RecursiveRomanizer))]
	[DisplayExecutionTime]
	public class RomanNumeralConversionTests<TRomanizer>
		where TRomanizer : IRomanizer, new()
	{
		[SetUp]
		public void SetUp()
		{
			IntegerExtensions.Romanizer = new TRomanizer();
		}

		[TestCase(1, "I")]
		[TestCase(2, "II")]
		[TestCase(3, "III")]
		[TestCase(4, "IV")]
		[TestCase(5, "V")]
		[TestCase(9, "IX")]
		[TestCase(10, "X")]
		[TestCase(22, "XXII")]
		[TestCase(40, "XL")]
		[TestCase(50, "L")]
		[TestCase(90, "XC")]
		[TestCase(100, "C")]
		[TestCase(207, "CCVII")]
		[TestCase(400, "CD")]
		[TestCase(500, "D")]
		[TestCase(900, "CM")]
		[TestCase(1000, "M")]
		[TestCase(1066, "MLXVI")]
		[TestCase(1954, "MCMLIV")]
		[TestCase(1990, "MCMXC")]
		[TestCase(2014, "MMXIV")]
		public void given_number_when_converting_to_roman_numeral_should_return_expected(int number, string expected)
		{
			number.Romanize().Should().Be(expected);
		}
	}
}
