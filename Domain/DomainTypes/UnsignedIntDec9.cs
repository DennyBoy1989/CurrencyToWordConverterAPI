using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DomainTypes {
    public class UnsignedIntDec9 {

        public int IntValue { get;}
        public string StringValue { get;}

        private UnsignedIntDec9(int intValue, string stringValue) {
            IntValue = intValue;
            StringValue = stringValue;
        }

        public static UnsignedIntDec9 Of(IntString value) {

            if (value.IntValue < 0) {
                throw new ArgumentException();
            }

            if (value.IntValue > 999999999) {
                throw new ArgumentException();
            }

            return new UnsignedIntDec9(value.IntValue, value.StringValue);
        }
    }
}
