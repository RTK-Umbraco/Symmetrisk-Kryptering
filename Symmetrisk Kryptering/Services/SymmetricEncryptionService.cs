using System.Security.Cryptography;
using System.Text;

namespace Symmetrisk_Kryptering.Services
{
    public class SymmetricEncryptionService
    {
        public byte[] Encrypt(string password, SymmetricAlgorithm algorithm)
        {
            try
            {
                var toBeEncrypt = Encoding.UTF8.GetBytes(password);

                using (var aesEncrypt = algorithm)
                {
                    aesEncrypt.Mode = CipherMode.CBC;
                    aesEncrypt.Padding = PaddingMode.PKCS7;

                    using (var memoryStream = new MemoryStream())
                    {
                        var cryptoStream = new CryptoStream(memoryStream, aesEncrypt.CreateEncryptor(), CryptoStreamMode.Write);

                        cryptoStream.Write(toBeEncrypt, 0, toBeEncrypt.Length);
                        cryptoStream.FlushFinalBlock();

                        var ecryptedBytes = memoryStream.ToArray();

                        return ecryptedBytes;
                    }
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        public string Decrypt(SymmetricAlgorithm algorithm, byte[] encryptedPassword, byte[] key, byte[] iv)
        {
            try
            {

                using (var decrypt = algorithm)
                {
                    decrypt.Mode = CipherMode.CBC;
                    decrypt.Padding = PaddingMode.PKCS7;

                    using (var memoryStream = new MemoryStream(encryptedPassword))
                    {
                        var cryptoStream = new CryptoStream(memoryStream, decrypt.CreateDecryptor(), CryptoStreamMode.Read);

                        using (var streamReader = new StreamReader(cryptoStream))
                        {
                            var decryptedPassword = streamReader.ReadToEnd();

                            return decryptedPassword;
                        }
                    }
                }
            }
            catch (Exception)
            {

                throw;
            }
        }
    }
}
