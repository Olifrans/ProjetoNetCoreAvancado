using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NetCore.Domain.Common
{
    public class Generetors : IGeneretors
    {
        public string Generate() => Guid.NewGuid().ToString("N");  
        
    }
}
