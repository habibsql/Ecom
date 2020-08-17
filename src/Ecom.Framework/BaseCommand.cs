using System;
using System.Collections.Generic;
using System.Text;

namespace Ecom.Framework
{
    public abstract class BaseCommand
    {
        public DateTime ExecutionDateTime { get; set; } = DateTime.UtcNow;
    }
}
