using Symmetrisk_Kryptering.Dtos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;

namespace Symmetrisk_Kryptering.Services
{
    public class EncryptService
    {
        public SymmetricAlgorithm SelectSymmetricEncryptionAlgorithm(int userInput)
        {
            //switch (userInput)
            //{
            //    case 1:
            //        return DESEncrypt(password);
            //    case 2:
            //        return TripleDESEncrypt(password);
            //    case 3:
            //        return AESEncrypt(password);
            //    default:
            //        break;
            //}

            switch (userInput)
            {
                case 1:
                    return DES.Create();
                case 2:
                    return TripleDES.Create();
                case 3:
                    return Aes.Create();
                default:
                    break;
            }
            return null;
        }

        public EncryptedMessageDto Encrypt(SymmetricAlgorithm algorithm, string password)
        {
            algorithm.GenerateKey();
            algorithm.GenerateIV();

            SymmetricEncryptionService SymmetricEncryptionService = new SymmetricEncryptionService();
            var encryptedPassword = SymmetricEncryptionService.Encrypt(password, algorithm);

            return new EncryptedMessageDto(encryptedPassword, algorithm.Key, algorithm.IV);
        }

        public EncryptedMessageDto Decrypt(SymmetricAlgorithm algorithm, byte[] encryptedPassword, byte[] key, byte[] iv)
        {
            SymmetricEncryptionService symmetricEncryptionServiceEncryptionService = new SymmetricEncryptionService();

            var decryptedPassword = symmetricEncryptionServiceEncryptionService.Decrypt(algorithm,encryptedPassword, key, iv);

            return new EncryptedMessageDto(decryptedPassword);
        }
    }
}
