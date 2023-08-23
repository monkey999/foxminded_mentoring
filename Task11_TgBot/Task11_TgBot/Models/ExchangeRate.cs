using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task11_TgBot.Models
{
    public class ExchangeRate
    {
        public string BaseCurrency { get; set; }
        public string Currency { get; set; }
        public double SaleRateNB { get; set; }
        public double PurchaseRateNB { get; set; }
        public double SaleRate { get; set; }
        public double PurchaseRate { get; set; }
    }
}
