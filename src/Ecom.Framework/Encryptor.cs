using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.Security.Cryptography;
using System.Threading.Tasks;

namespace Ecom.Framework
{
    public class Encryptor : IEncrptor
    {
        private readonly static byte[] salt = Encoding.UTF8.GetBytes("Rupa1!nagudi2#hash3?function5");

        public Task<string> HashAsync(string value)
        {
            byte[] values = Encoding.UTF8.GetBytes(value);
            byte[] salts = values.Concat(salt).ToArray();

            using var sha256 = new SHA256Managed();
            byte[] hashs = sha256.ComputeHash(salts);

            return Task.FromResult(Encoding.UTF8.GetString(hashs, 0, hashs.Length));
        }
    }
}
