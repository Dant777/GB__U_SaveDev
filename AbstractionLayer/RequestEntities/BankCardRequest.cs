using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractionLayer.RequestEntities
{
    public class BankCardRequest
    {
        public string UserName { get; set; }
        public int CardNumber { get; set; }
    }
}
