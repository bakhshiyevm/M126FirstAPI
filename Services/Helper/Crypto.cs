using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;


namespace Services.Helper
{


	public class Crypto
	{
		public static string GenerateSalt()
		{
			var saltBytes = new byte[10];

			var provider = new RNGCryptoServiceProvider();

			provider.GetNonZeroBytes(saltBytes);

			return Convert.ToBase64String(saltBytes);
		}

		public static string GenerateBase64Hash(string input, string salt)
		{
			var inputsalt = input + salt;

			var hash = Convert.ToBase64String((Encoding.UTF8.GetBytes(inputsalt)));

			return hash;

		}
		private static string GenerateSHA256Hash(string input, string salt)
		{

			HMACSHA256 alg = new HMACSHA256(Encoding.UTF8.GetBytes(salt));

			var hash = alg.ComputeHash(Encoding.UTF8.GetBytes(input + salt));

			return Encoding.UTF8.GetString(hash);
		}
	}
}
