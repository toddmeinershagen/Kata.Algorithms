using System;

namespace Kata.Algorithms.Palindrome
{
	public class RecursivePalindromeValidator : IPalindromeValidator
	{
		public bool IsPalindrome(string value)
		{
			if (value == null)
				return false;

			if (value.Length <= 1)
				return true;

			return Char.ToLower(value[0]) == Char.ToLower(value[value.Length - 1]) && IsPalindrome(value.Substring(1, value.Length - 2));
		}
	}
}