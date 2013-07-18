using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Zxm.Core.Services
{
    interface IEncryptionService
    {
        byte[] Encrypt(string plainText, byte[] key, byte[] iv);
        string Decrypt(byte[] encryptedText, byte[] key, byte[] iv);
    }
}
