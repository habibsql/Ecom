using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Primitives;
using System;
using System.Collections.Generic;
using System.Text;

namespace Ecom.Tests.Integration
{
    public class TestConfigSection : IConfigurationSection
    {
        private Dictionary<string, string> Values = new Dictionary<string, string>(2);

        public TestConfigSection()
        {
            Values.Add("DefaultConnection", "mongodb://127.0.0.1:27017");
            Values.Add("DefaultDatabase", "TestDb");
        }
        public string this[string key]
        {
            get =>  Values[key];           

            set => throw new NotImplementedException();
        }

        public string Key => throw new NotImplementedException();

        public string Path => throw new NotImplementedException();

        public string Value { get => throw new NotImplementedException(); set => throw new NotImplementedException(); }

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
            throw new NotImplementedException();
        }
    }
}
