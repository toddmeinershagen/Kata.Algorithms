namespace Kata.Algorithms.Romanizer
{
	public static class IntegerExtensions
	{
		static IntegerExtensions()
		{
			Romanizer = new IterativeRomanizer();
		}

		public static string Romanize(this int value)
		{
			return Romanizer.Romanize(value);
		}

		internal static IRomanizer Romanizer { get; set; }
	}
}