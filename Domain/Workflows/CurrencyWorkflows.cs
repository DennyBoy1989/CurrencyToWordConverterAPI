using Domain.DomainTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Workflows {
    public class CurrencyWorkflows {

        public CurrencyWordRepresentation GetCurrencyWordRepresentation(string currencyString) {
            var currencyDecimalString = DecimalString.Of(currencyString, 2);
            var currency = Currency.Of(currencyDecimalString);
            return currency.GetWordRepresentation();
        }
    }
}
