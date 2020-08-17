using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Ecom.Framework
{
    /// <summary>
    /// Manage All Ecom configuration values
    /// </summary>
    public interface IEcomConfigManager
    {
        IEnumerable<string> GetProductSearchableFields();

        OAuthInfo GetOAthInfo();
    }
}
