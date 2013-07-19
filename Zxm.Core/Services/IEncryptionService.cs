namespace Zxm.Core.Services
{
    interface IEncryptionService
    {
        string Encrypt(string plainText, byte[] key);
        string Decrypt(string encryptedText, byte[] key);
    }
}
