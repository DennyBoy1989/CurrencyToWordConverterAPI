using Domain.DomainTypes;
using Domain.Workflows;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Test.DomainTypes; 

[TestFixture]
public class CurrencyMethodsTest {

    [TestCase("100", "one hundred dollars")]
    [TestCase("200", "two hundred dollars")]
    [TestCase("327", "three hundred twenty-seven dollars")]
    [TestCase("611", "six hundred eleven dollars")]
    [TestCase("804", "eight hundred four dollars")]
    [TestCase("0", "zero dollars")]
    [TestCase("1", "one dollar")]
    [TestCase("25", "twenty-five dollars")]
    [TestCase("0", "zero dollars")]
    [TestCase("45100", "forty-five thousand one hundred dollars")]
    [TestCase("999999999", "nine hundred ninety-nine million nine hundred ninety-nine thousand nine hundred ninety-nine dollars")]
    [TestCase("123456789", "one hundred twenty-three million four hundred fifty-six thousand seven hundred eighty-nine dollars")]
    [TestCase("110111112", "one hundred ten million one hundred eleven thousand one hundred twelve dollars")]
    [TestCase("001", "one dollar")]
    public void GetCurrencyWordRepresentation_WhenGivenValidNumber_ThenReturnCurrencyWord(string input, string expectedOutput) {

        var result = CurrencyMethods.GetWordRepresentationOfDollars(Dollars.Of(IntString.Of(input)));

        Assert.That(result, Is.EqualTo(expectedOutput));
    }
}
