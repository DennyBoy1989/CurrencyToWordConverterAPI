namespace Domain.Methods.Primitives;

/// <summary>
/// Extensions methods for characters. The methods are focused on characters that represent digits.
/// </summary>
public static class DigitCharMethods {


    /// <summary>
    /// Returns the word representation of a units digit. If the entered char is no digit, an empty char is returned.
    /// </summary>
    public static string GetWordRepresentationOfUnitsDigit(this char unitsDigit) {
        return unitsDigit switch {
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

    /// <summary>
    /// Interpretes the given digit character as the units digit of a numbe between 10 and 19 and returns the respective word representation as string. If the entered char is no digit, an empty char is returned.
    /// </summary>
    public static string GetWordRepresentationOfNumberBetweenTenAndNineTeen(this char unitsDigit) {
        return unitsDigit switch {
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

    /// <summary>
    /// Returns the word representation of a tens digit. If the entered char is no digit, an empty char is returned.
    /// </summary>
    public static string GetWordRepresentationOfTensDigit(this char tensDigit) {
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

    /// <summary>
    /// Returns the word representation of a hundreds digit. If the entered char is no digit, an empty char is returned.
    /// </summary>
    public static string GetWordRepresentationOfHundredsDigit(this char hundredsDigit) {
        if(hundredsDigit == '0') {
            return "";
        }
        return GetWordRepresentationOfUnitsDigit(hundredsDigit).ConcatWithSequenceWhenNotEmpty(" hundred");
    }
}
