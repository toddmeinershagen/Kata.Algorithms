using FluentAssertions;

using Kata.Algorithms.Palindrome;

using NUnit.Framework;

namespace Kata.Algorithms.UnitTests.Palindrome
{
	[TestFixture(typeof(IterativePalindromeValidator))]
	[TestFixture(typeof(RecursivePalindromeValidator))]
	[DisplayExecutionTime]
    public class PalindromeValidatorTests<TValidator> 
		where TValidator : IPalindromeValidator, new()
	{
		private IPalindromeValidator _validator;

		[SetUp]
		public void SetUp()
		{
			_validator = new TValidator();
		}

		[TestCase("", true)]
		[TestCase(null, false)]
		[TestCase("a", true)]
		[TestCase("b", true)]
		[TestCase("ba", false)]
		[TestCase("bob", true)]
		[TestCase("Bob", true)]
		[TestCase("Jumbo", false)]
		[TestCase("racecar", true)]
		public void given_string_value_when_validating_should_return_expected(string value, bool expected)
		{
			_validator.IsPalindrome(value).Should().Be(expected);
		}
    }
}
