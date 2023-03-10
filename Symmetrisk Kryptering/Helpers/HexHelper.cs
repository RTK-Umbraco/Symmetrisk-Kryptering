namespace Symmetrisk_Kryptering.Helper
{
    public static class HexHelper
    {
        public static string ConvertBytesToHex(byte[] encryptedPassword)
        {
            return BitConverter.ToString(encryptedPassword).Replace("-", " ");
        }
    }
}
