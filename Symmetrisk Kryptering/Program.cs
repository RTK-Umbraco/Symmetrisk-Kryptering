using Symmetrisk_Kryptering.Dtos;
using Symmetrisk_Kryptering.Helper;
using Symmetrisk_Kryptering.Services;
using System.Security.Cryptography;

namespace Symmetrisk_Kryptering
{
    internal class Program
    {
        static EncryptService _encryptService = new EncryptService();

        static void Main(string[] args)
        {

            while (true)
            {
                SelectSymmetricEncryptionAlgorithm();

                Console.ReadKey();
                Console.Clear();
            }
        }

        private static void SelectSymmetricEncryptionAlgorithm()
        {
            Console.WriteLine("Select symmetric encryption algorithm");
            Console.WriteLine();
            Console.WriteLine("1. DES");
            Console.WriteLine("2. 3DES");
            Console.WriteLine("3. AES");

            var userInput = Convert.ToInt32(Console.ReadLine());

            var algorithm = _encryptService.SelectSymmetricEncryptionAlgorithm(userInput);
            var encrypted = Encrypt(algorithm);
            Decrypt(algorithm, encrypted);

            Console.ReadKey();
        }

        private static EncryptedMessageDto Encrypt(SymmetricAlgorithm algorithm)
        {
            try
            {
                Console.WriteLine();
                Console.WriteLine("Insert your password");

                var password = Console.ReadLine();

                var encryptedMessageDto = _encryptService.Encrypt(algorithm, password);
                Console.WriteLine();
                Console.WriteLine($"Encrypted Password: {Convert.ToBase64String(encryptedMessageDto.EncryptedPassword)}");
                Console.WriteLine($"Key: {Convert.ToBase64String(encryptedMessageDto.Key)}");
                Console.WriteLine($"Iv: {Convert.ToBase64String(encryptedMessageDto.Iv)}");

                var ACSII = ConvertEncryptedPasswordToASCII(encryptedMessageDto.EncryptedPassword);
                Console.WriteLine($"ACSII {ACSII}");
                Console.WriteLine();

                return encryptedMessageDto;
            }
            catch (Exception e)
            {
                Console.WriteLine();
                Console.WriteLine("An error occured while encrypting your password. Please make sure you have genereated 'Key' and 'IV'\n Error: " + e);
                return null;
            }
        }

        private static string ConvertEncryptedPasswordToASCII(byte[] encryptedPassword)
        {
            return ASCIIHelper.ConvertBytesToASCII(encryptedPassword);
        }

        //Doesnt work at the moment
        //private static void ConvertEncryptedPasswordToHex()
        //{
        //    _cipherHex = HexHelper.ConvertBytesToHex(_encryptedPassword);
        //}

        private static void Decrypt(SymmetricAlgorithm algorithm, EncryptedMessageDto encryptedMessageDto)
        {
            try
            {
                var desDecryptedPasword = _encryptService.Decrypt(algorithm, encryptedMessageDto.EncryptedPassword, encryptedMessageDto.Key, encryptedMessageDto.Iv);
                Console.WriteLine($"Decrypted password: {desDecryptedPasword.DecryptedPassword}");
            }
            catch (Exception e)
            {
                Console.WriteLine();
                Console.WriteLine("An error occured while decrypting your password. Please make sure you have encrypted your password\n Error: " + e);
            }
        }
    }
}