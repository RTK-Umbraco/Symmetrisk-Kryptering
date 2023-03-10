using System.Security.Cryptography;

namespace Symmetrisk_Kryptering.Helper
{
    public static class RandomGeneratorHelper
    {
        public static byte[] GenerateRandomNumber(int length)
        {
            using (var randomNumberGenerator = RandomNumberGenerator.Create())
            {
                var randomNumber = new byte[length];
                randomNumberGenerator.GetBytes(randomNumber);

                return randomNumber;
            }
        }
    }
}
