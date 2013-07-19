namespace Zxm.Core.Services
{
    public interface IEncryptionService
    {
        string Encrypt(string plainText, byte[] key);
        string Decrypt(string encryptedText, byte[] key);
    }
}
