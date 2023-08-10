using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DomainTypes; 
public record Cents(UnsignedIntDec2 Value) {
    public static Cents Of(IntString value) {
        return new Cents(UnsignedIntDec2.Of(value));
    }
};
