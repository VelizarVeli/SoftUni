using System;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using SIS.Services.Common;
using SIS.Services.Contracts;

namespace SIS.Services
{
    public class EncryptionService : IEncryptionService
    {
	public string HashPassword(string password)
	{
	    using (var hashAlgorithm1 = MD5.Create())
	    {
		string stringToHash = password + Constants.PasswordSalt;
		byte[] bytesToHash = Encoding.UTF8.GetBytes(stringToHash);
		byte[] hashedBytes = hashAlgorithm1.ComputeHash(bytesToHash);
		using (var hashAlgorithm2 = SHA512.Create())
		{
		    byte[] saltBytes = Encoding.UTF8.GetBytes(Constants.PasswordSalt);
		    bytesToHash = hashedBytes.Concat(saltBytes).ToArray();
		    hashedBytes = hashAlgorithm2.ComputeHash(bytesToHash);
		    string hashedPassword = string.Concat(BitConverter.ToString(hashedBytes)
			.Replace("-", string.Empty).ToLowerInvariant().Reverse());
		    return hashedPassword;
		}
	    }
	}
    }
}
