namespace Symmetrisk_Kryptering.Dtos
{
    public class EncryptedMessageDto
    {

        public byte[] EncryptedPassword { get; set; }
        public string DecryptedPassword { get; set; }


        public byte[] Key { get; set; }
        public byte[] Iv { get; set; }
        
        public EncryptedMessageDto(byte[] encryptedPassword, byte[] key, byte[] iv)
        {
            EncryptedPassword = encryptedPassword;
            Key = key;
            Iv = iv;
        }
        
        public EncryptedMessageDto(string decryptedPassword)
        {
            DecryptedPassword = decryptedPassword;
        }
    }
}
