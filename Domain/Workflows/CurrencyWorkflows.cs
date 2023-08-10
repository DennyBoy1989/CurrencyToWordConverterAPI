using Domain.DomainTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Workflows {
    public class CurrencyWorkflows {

        public CurrencyWordRepresentation GetCurrencyWordRepresentation(string currencyString) {
            var currency = new Currency(currencyString);
            return currency.GetWordRepresentation();
        }
    }
}
