using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DomainTypes;

public record Currency(Dollars Dollars, Cents Cents) {

    public static Currency Of(string value) {

        if (value.Contains(',')) {
            var stringParts = value.Split(",");
            return new Currency(Dollars.Of(IntString.Of(stringParts[0])), Cents.Of(IntString.Of(stringParts[1])));
        }
        else {
            return new Currency(Dollars.Of(IntString.Of(value)), Cents.Of(IntString.Of("0")));
        }
    }
}