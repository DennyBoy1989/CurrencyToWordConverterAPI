using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DomainTypes {
    public class UnsignedIntDec2 {

        public int IntValue { get;}
        public string StringValue { get;}

        private UnsignedIntDec2(int intValue, string stringValue) {
            IntValue = intValue;
            StringValue = stringValue;
        }

        public static UnsignedIntDec2 Of(IntString value) {

            if(value.IntValue < 0) {
                throw new ArgumentException();
            }

            if (value.IntValue > 99) {
                throw new ArgumentException();
            }

            return new UnsignedIntDec2(value.IntValue, value.StringValue);
        }
    }
}
