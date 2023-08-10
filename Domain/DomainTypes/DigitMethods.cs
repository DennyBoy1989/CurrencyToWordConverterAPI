namespace Domain.DomainTypes;

public static class DigitMethods {

    public static string GetUnitDigitsWordRepresentation(this char onesDigit) {
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

    public static string GetWordRepresentationOfNumberBetweenTenAndNineTeen(this char onesDigit) {
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

    public static string GetTensDigitWordRepresentation(this char tensDigit) {
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

    public static string GetHundredsDigitWordRepresentation(this char hundredDigit) {
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
