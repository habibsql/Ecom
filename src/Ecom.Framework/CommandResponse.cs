using System.Collections.Generic;
using System.Linq;

namespace Ecom.Framework
{
    public class CommandResponse
    {
        public bool Succeed
        {
            get
            {
                return !Errors.Any();
            }
        }

        public IEnumerable<string> Errors { get; set; } = new List<string>();
    }
}
