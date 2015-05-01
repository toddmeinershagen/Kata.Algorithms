using System;

namespace Kata.Algorithms.Palindrome
{
	public class IterativePalindromeValidator : IPalindromeValidator
	{
		public bool IsPalindrome(string value)
		{
			if (value == null)
				return false;

			if (value == String.Empty)
				return true;

			for (int i = 0; i < value.Length; i++)
			{
				if (IsOddLength(value) && (i == Math.Round((double) value.Length/2)))
					break;

				if (Char.ToLower(value[i]) != Char.ToLower(value[value.Length - 1 - i]))
					return false;
			}

			return true;
		}

		private static bool IsOddLength(string value)
		{
			return value.Length % 2 != 0;
		}
	}
}