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
                if (i >= value.Length/2)
					break;

				if (char.ToUpperInvariant(value[i]).Equals(char.ToUpperInvariant(value[value.Length - 1 - i])) == false)
					return false;
			}

			return true;
		}
	}
}