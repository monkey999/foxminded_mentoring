using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Logic.DTO_Contracts.Requests.Create
{
    public class CreateDebitAccountReqDTO
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public double Balance { get; set; }
        public string CurrencyType { get; set; }
    }
}
