using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Primitives;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ecom.Tests.Integration
{
    public class TestConfig : IConfiguration
    {
        public string this[string key] { get => GetConnectionString() ; set => throw new NotImplementedException(); }

        public IEnumerable<IConfigurationSection> GetChildren()
        {
            throw new NotImplementedException();
        }

        public IChangeToken GetReloadToken()
        {
            throw new NotImplementedException();
        }

        public IConfigurationSection GetSection(string key)
        {
            //var section = new ConfigSection
            //{
            //    Value = "mongodb://127.0.0.1:27017/testdb"
            //};

            //return section;

            return new TestConfigSection();
        }

        private string GetConnectionString()
        {
            return "mongodb://127.0.0.1:27017/testdb";
        }
    }
}
