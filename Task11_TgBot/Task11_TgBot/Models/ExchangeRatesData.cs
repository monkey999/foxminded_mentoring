using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Task11_TgBot.Models
{
    public class ExchangeRatesData
    {
        public string Date { get; set; }
        public string Bank { get; set; }
        public int BaseCurrency { get; set; }
        public string BaseCurrencyLit { get; set; }
        public List<ExchangeRate> ExchangeRate { get; set; }
    }
}
