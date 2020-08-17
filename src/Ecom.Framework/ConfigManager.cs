using Microsoft.Extensions.Configuration;
using System.Collections.Generic;

namespace Ecom.Framework
{
    public class EcomConfigManager : IEcomConfigManager
    {
        private readonly IConfiguration configuration;

        public EcomConfigManager(IConfiguration configuration)
        {
            this.configuration = configuration;
        }       

        public IEnumerable<string> GetProductSearchableFields()
        {
            var fields = new List<string>();

            IConfigurationSection productSection = configuration.GetSection("SearchableFields:Product");

            IEnumerable<IConfigurationSection> valueSections = productSection.GetChildren();

            foreach (IConfigurationSection valueSection in valueSections)
            {
                fields.Add(valueSection.Value);
            }

            return fields;
        }

        public OAuthInfo GetOAthInfo()
        {
            var oAuthInfo = new OAuthInfo();

            IConfigurationSection googleOAuthSection = configuration.GetSection("OAuthInfo:Google");
            oAuthInfo.ClientId = googleOAuthSection["ClientId"];
            oAuthInfo.ClientId = googleOAuthSection["ClientSecret"];
            oAuthInfo.ClientId = googleOAuthSection["RedirectUrl"];
            oAuthInfo.ClientId = googleOAuthSection["GrantType"];

            return oAuthInfo;
        }
    }
}
