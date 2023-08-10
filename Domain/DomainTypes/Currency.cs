using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DomainTypes;

public class Currency {
    public IEnumerable<char> Value { get; }

    public Currency(IEnumerable<char> value) {
        Value = value.Reverse();
    }
}