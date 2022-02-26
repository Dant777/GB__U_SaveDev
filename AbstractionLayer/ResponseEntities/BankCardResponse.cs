using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AbstractionLayer.ResponseEntities
{
    public class BankCardResponse
    {
        public int Id { get; set; }
        public string UserName { get; set; }
        public int CardNumber { get; set; }
    }
}
