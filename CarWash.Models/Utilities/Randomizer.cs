using System;
using System.Security.Cryptography;

namespace CarWash.Models.Utilities
{
    public static class Randomizer
    {
		/// <summary>
		/// Generates a random number.
		/// </summary>
		/// <returns>The random number.</returns>
		/// <param name="length">Length of the random number.</param>
		public static byte[] GenerateRandomNumber(int length)
		{
			using (var randomNumberGenerator = new RNGCryptoServiceProvider())
			{
				var randomNumber = new byte[length];
				randomNumberGenerator.GetBytes(randomNumber);
				return randomNumber;
			}
		}
    }
}
