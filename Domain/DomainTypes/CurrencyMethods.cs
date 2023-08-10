using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Domain.DomainTypes; 
public static class CurrencyMethods {


    public static Dictionary<string, string> uniqueNumberWordsEnglish = new Dictionary<string, string>() {
            {"0", "zero"},
            {"1", "one"},
            {"2", "two"},
            {"3", "three"},
            {"4", "four"},
            {"5", "five"},
            {"6", "six"},
            {"7", "seven"},
            {"8", "eight"},
            {"9", "nine"},
            {"10", "ten"},
            {"11", "eleven"},
            {"12", "twelve"},
            {"13", "thirteen"},
            {"14", "fourteen"},
            {"15", "fifteen"},
            {"16", "sixteen"},
            {"17", "seventeen"},
            {"18", "thirteen"},
            {"19", "thirteen"},
            {"20", "twenty"},
            {"30", "thirty"},
            {"40", "thirty"},
            {"50", "thirty"},
            {"60", "thirty"},
            {"70", "thirty"},
            {"80", "thirty"},
            {"90", "thirty"},
            {"100", "hundred"},
            {"1000", "thousand"},
            {"1000000", "million"},
        };


    // 374 => 300 70 4
    // 612374 => 600 12 thousand 300 70 4
    // Number is composed of 1..* digits
    // digit is one specific number in the group of 0,1,2,3,4,5,6,7,8,9

    public static CurrencyWordRepresentation GetWordRepresentation(this Currency currency) {
        string hundredsTensAndOnes = GetWordRepresentationOfDollars(currency);
        return new CurrencyWordRepresentation(hundredsTensAndOnes);
    }

    public static string GetWordRepresentationOfDollars(this Currency currency) {

        string millionsNumber = GetWordRepresentationOfMillionsNumber(new Currency(currency.Value.Take(new Range(6, 9)).Reverse()));
        string thousandsNumber = GetWordRepresentationOfThousandsNumber(new Currency(currency.Value.Take(new Range(3, 6)).Reverse()));
        string hundredsNumber = GetWordRepresentationOfHundredsNumber(currency);
        if (int.Parse(new string(currency.Value.Reverse().ToArray())) == 1) {
            return $"{hundredsNumber} dollar";
        }
        return $"{millionsNumber}{thousandsNumber}{hundredsNumber} dollars";
    }

    private static string GetWordRepresentationOfMillionsNumber(Currency currency) {

        string hundreds = GetHundredsDigitWordRepresentation(currency);
        string tensAndOnes = getWordRepresentationOfDigitOfTensAndDigitOfOnes(currency);

        var hundredsTensAndOnes = $"{hundreds}{tensAndOnes}".TrimEnd();

        if (hundredsTensAndOnes.Length == 0) {
            return "";
        }
        return $"{hundredsTensAndOnes} million ";
    }

    private static string GetWordRepresentationOfThousandsNumber(Currency currency) {

        string hundreds = GetHundredsDigitWordRepresentation(currency);
        string tensAndOnes = getWordRepresentationOfDigitOfTensAndDigitOfOnes(currency);

        var hundredsTensAndOnes = $"{hundreds}{tensAndOnes}".TrimEnd();

        if(hundredsTensAndOnes.Length == 0) {
            return "";
        }
        return $"{hundredsTensAndOnes} thousand ";
    }

    private static string GetWordRepresentationOfHundredsNumber(Currency currency) {

        string hundreds = GetHundredsDigitWordRepresentation(currency);
        string tensAndOnes = getWordRepresentationOfDigitOfTensAndDigitOfOnes(currency);

        var hundredsTensAndOnes = $"{hundreds}{tensAndOnes}".TrimEnd();
        return hundredsTensAndOnes;
    }

    private static string getWordRepresentationOfDigitOfTensAndDigitOfOnes(Currency currency) {
        if(currency.Value.Count() < 2) {
            if(currency.Value.Count() < 1) {
                return "";
            }
            var onesDigit = currency.Value.ToList().ToList()[0];
            return GetUnitDigitsWordRepresentation(onesDigit);
        }
        
        var tensDigit = currency.Value.ToList().ToList()[1];
        if (tensDigit == '1') {
            var onesDigit = currency.Value.ToList().ToList()[0];
            return GetWordRepresentationOfNumberBetweenTenAndNineTeen(onesDigit);
        }
        if(tensDigit == '0') {
            var onesDigit = currency.Value.ToList().ToList()[0];
            if (onesDigit == '0') {
                return "";
            }
            return GetUnitDigitsWordRepresentation(onesDigit);
        }
        else {
            string tens = GetTensDigitWordRepresentation(tensDigit);

            var onesDigit = currency.Value.ToList().ToList()[0];
            if(onesDigit == '0') {
                return tens;
            }

            string ones = GetUnitDigitsWordRepresentation(onesDigit);

            return $"{tens}-{ones}";
        }
    }

    private static string GetHundredsDigitWordRepresentation(Currency currency) {
        if (currency.Value.Count() >= 3) {

            var hundredDigit = currency.Value.ToList().ToList()[2];
            return GetHundredsDigitWordRepresentation(hundredDigit) + " ";
        }
        else {
            return "";
        }

    }

    private static string GetUnitDigitsWordRepresentation(char onesDigit) {
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

    private static string GetWordRepresentationOfNumberBetweenTenAndNineTeen(char onesDigit) {
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

    private static string GetTensDigitWordRepresentation(char tensDigit) {
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

    private static string GetHundredsDigitWordRepresentation(char hundredDigit) {
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
