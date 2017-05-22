using System;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace CarWash.Cryptography
{
	public class RSAWithParameterKey
	{
		private RSAParameters _publicKey;
		private RSAParameters _privateKey;

		public void AssignNewKey()
		{
			using (var rsa = new RSACryptoServiceProvider(2048))
			{
				rsa.PersistKeyInCsp = false;
				_publicKey = rsa.ExportParameters(false);
				_privateKey = rsa.ExportParameters(true);
			}
		}

		public byte[] EncryptData(byte[] dataToEncrypt)
		{
			byte[] cipherbytes;

			using (var rsa = new RSACryptoServiceProvider(2048))
			{
				rsa.PersistKeyInCsp = false;
				rsa.ImportParameters(_publicKey);

				cipherbytes = rsa.Encrypt(dataToEncrypt, true);
			}

			return cipherbytes;
		}

        public Task EncryptDataAsync(byte[] dataToEncrypt)
        {
            return Task.Run(() => this.EncryptData(dataToEncrypt));
        }

		public byte[] DecryptData(byte[] dataToDecrypt)
		{
			byte[] plain;

			using (var rsa = new RSACryptoServiceProvider(2048))
			{
				rsa.PersistKeyInCsp = false;

				rsa.ImportParameters(_privateKey);
				plain = rsa.Decrypt(dataToDecrypt, true);
			}

			return plain;
		}

        public Task DecryptDataAsync(byte[] dataToDecrypt)
        {
            return Task.Run(() => this.DecryptData(dataToDecrypt));
        }
	}
}
