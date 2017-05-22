using System;
using System.Security.Cryptography;
using System.Text;

namespace CarWash.Models.Utilities
{
    public static class Hashing
    {
		/// <summary>
		/// Hashess the provided byte array.
		/// </summary>
		/// <returns>The hashed string as a byte array.</returns>
		/// <param name="toBeHashed">Byte array to be hashed.</param>
		/// <param name="salt">Salt to use for scrambling the hash.</param>
		/// <param name="numberOfRounds">Number of times to hash the byte array.</param>
		public static byte[] HashPassword(byte[] toBeHashed, byte[] salt, int numberOfRounds)
		{
			using (var rfc2898 = new Rfc2898DeriveBytes(toBeHashed, salt, numberOfRounds))
			{
				return rfc2898.GetBytes(32);
			}
		}

		/// <summary>
		/// Hashess the provided string.
		/// </summary>
		/// <returns>The hashed string as a byte array.</returns>
		/// <param name="toBeHashed">The string to be hashed.</param>
		/// <param name="salt">Salt to use for scrambling the hash.</param>
		/// <param name="numberOfRounds">Number of times to hash the byte array.</param>
		public static byte[] HashPassword(string toBeHashed, byte[] salt, int numberOfRounds)
		{
            return Hashing.HashPassword(Encoding.Unicode.GetBytes(toBeHashed), salt, numberOfRounds);
		}

		/// <summary>
		/// Hashess the provided string.
		/// </summary>
		/// <returns>The hashed string as a byte array.</returns>
		/// <param name="toBeHashed">The string to be hashed.</param>
		/// <param name="salt">Salt to use for scrambling the hash.</param>
		/// <param name="numberOfRounds">Number of times to hash the byte array.</param>
		public static byte[] HashPassword(string toBeHashed, string salt, int numberOfRounds)
		{
            return Hashing.HashPassword(Encoding.Unicode.GetBytes(toBeHashed), Encoding.Unicode.GetBytes(salt), numberOfRounds);
		}
    }
}
