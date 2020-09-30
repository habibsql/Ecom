using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Ecom.Framework
{
    public interface IEncrptor
    {
        Task<string> HashAsync(string text);
    }
}
