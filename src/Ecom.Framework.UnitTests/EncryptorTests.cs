using System;
using System.Threading.Tasks;
using Xunit;

namespace Ecom.Framework.UnitTests
{
    public class EncryptorTests
    {
        private readonly IEncrptor encryptor = new Encryptor();

        [Fact]
        public async Task Should_Hash()
        {
            string value = "IamGood123!?";
            string hashValue1 = await encryptor.HashAsync(value);
            string hashValue2 = await encryptor.HashAsync(value);

            Assert.Equal(hashValue1, hashValue2);
        }
    }
}
