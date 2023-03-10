using System.Text;

namespace Symmetrisk_Kryptering.Helper
{
    public static class ASCIIHelper
    {
        public static string ConvertBytesToASCII(byte[] encryptedPassword)
        {
            string decryptedText = "";
            var encryptedPasswordBytes = Convert.ToBase64String(encryptedPassword);

            var aSCIIBytes = Encoding.ASCII.GetBytes(encryptedPasswordBytes);
            foreach (byte aSCIIByte in aSCIIBytes)
            {
                int aCSIINumberValue = aSCIIByte;
                decryptedText += aCSIINumberValue.ToString();
            }
            return decryptedText;
        }
    }
}
