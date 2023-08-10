using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DomainTypes {
    public static class UnsignedIntDec3Methods {

        public static char GetUnitsDigit(this UnsignedIntDec3 number) {
            return number.StringValue.Reverse().ElementAtOrDefault(0);
        }
        public static char GetTensDigit(this UnsignedIntDec3 number) {
            return number.StringValue.Reverse().ElementAtOrDefault(1);
        }
        public static char GetHundredsDigit(this UnsignedIntDec3 number) {
            return number.StringValue.Reverse().ElementAtOrDefault(2);
        }
        public static bool HasUnitsDigit(this UnsignedIntDec3 number) {
            return number.StringValue.Count() >= 1;
        }
        public static bool HasTensDigit(this UnsignedIntDec3 number) {
            return number.StringValue.Count() >= 2;
        }
        public static bool HasHundredsDigit(this UnsignedIntDec3 number) {
            return number.StringValue.Count() >= 3;
        }


        public static string GetWordRepresentationOfMillionsNumber(this UnsignedIntDec3 number) {

            if (number.IntValue == 0) {
                return "";
            }

            var hundredsTensAndOnes = number.GetWordRepresentationOfHundredsNumber();
            return $"{hundredsTensAndOnes} million ";
        }

        public static string GetWordRepresentationOfThousandsNumber(this UnsignedIntDec3 number) {

            if (number.IntValue == 0) {
                return "";
            }

            var hundredsTensAndOnes = number.GetWordRepresentationOfHundredsNumber();
            return $"{hundredsTensAndOnes} thousand ";
        }

        public static string GetWordRepresentationOfHundredsNumber(this UnsignedIntDec3 number) {

            string hundreds = GetHundredsDigitWordRepresentation(number);
            string tensAndUnits = GetWordRepresentationOfDigitOfTensAndDigitOfOnes(number);

            return $"{hundreds}{tensAndUnits}".TrimEnd();
        }

        public static string GetWordRepresentationOfDigitOfTensAndDigitOfOnes(this UnsignedIntDec3 number) {
            if (!number.HasTensDigit()) {
                if (!number.HasUnitsDigit()) {
                    return "";
                }
                var unitsDigit = number.GetUnitsDigit();
                return GetUnitDigitsWordRepresentation(unitsDigit);
            }

            var tensDigit = number.GetTensDigit();
            if (tensDigit == '1') {
                var onesDigit = number.GetUnitsDigit();
                return GetWordRepresentationOfNumberBetweenTenAndNineTeen(onesDigit);
            }
            if (tensDigit == '0') {
                var unitsDigit = number.GetUnitsDigit();
                if (unitsDigit == '0') {
                    return "";
                }
                return GetUnitDigitsWordRepresentation(unitsDigit);
            }
            else {
                string tens = GetTensDigitWordRepresentation(tensDigit);

                var unitsDigit = number.GetUnitsDigit();
                if (unitsDigit == '0') {
                    return tens;
                }

                string ones = GetUnitDigitsWordRepresentation(unitsDigit);

                return $"{tens}-{ones}";
            }
        }

        public static string GetHundredsDigitWordRepresentation(this UnsignedIntDec3 number) {

            if (number.HasHundredsDigit()) {
                var hundredDigit = number.GetHundredsDigit();
                return GetHundredsDigitWordRepresentation(hundredDigit) + " ";
            }
            else {
                return "";
            }

        }

        public static string GetUnitDigitsWordRepresentation(char onesDigit) {
            return onesDigit switch {
                '0' => "zero",
                '1' => "one",
                '2' => "two",
                '3' => "three",
                '4' => "four",
                '5' => "five",
                '6' => "six",
                '7' => "seven",
                '8' => "eight",
                '9' => "nine",
                _ => ""
            };
        }

        public static string GetWordRepresentationOfNumberBetweenTenAndNineTeen(char onesDigit) {
            return onesDigit switch {
                '0' => "ten",
                '1' => "eleven",
                '2' => "twelve",
                '3' => "thirteen",
                '4' => "fourteen",
                '5' => "fifteen",
                '6' => "sixteen",
                '7' => "seventeen",
                '8' => "eighteen",
                '9' => "nineteen",
                _ => ""
            };
        }

        public static string GetTensDigitWordRepresentation(char tensDigit) {
            return tensDigit switch {
                '1' => "ten",
                '2' => "twenty",
                '3' => "thirty",
                '4' => "forty",
                '5' => "fifty",
                '6' => "sixty",
                '7' => "seventy",
                '8' => "eighty",
                '9' => "ninety",
                _ => ""
            };
        }

        public static string GetHundredsDigitWordRepresentation(char hundredDigit) {
            return hundredDigit switch {
                '1' => "one hundred",
                '2' => "two hundred",
                '3' => "three hundred",
                '4' => "four hundred",
                '5' => "five hundred",
                '6' => "six hundred",
                '7' => "seven hundred",
                '8' => "eight hundred",
                '9' => "nine hundred",
                _ => ""
            };
        }
    }
}
