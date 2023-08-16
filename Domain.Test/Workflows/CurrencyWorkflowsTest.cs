using Castle.Core.Logging;
using Domain.DomainErrors;
using Domain.Workflows;
using FakeItEasy;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Test.Workflows {

    [TestFixture]
    public class CurrencyWorkflowsTest {

        private CurrencyWorkflows currencyWorkflows;
        
        [SetUp]
        public void SetUp() {
            currencyWorkflows = new CurrencyWorkflows(A.Fake<ILogger<CurrencyWorkflows>>());
        }


        [TestCase("100", "one hundred dollars")]
        [TestCase("1000", "one thousand dollars")]
        [TestCase("1000000", "one million dollars")]
        [TestCase("200", "two hundred dollars")]
        [TestCase("327", "three hundred twenty-seven dollars")]
        [TestCase("611", "six hundred eleven dollars")]
        [TestCase("804", "eight hundred four dollars")]
        [TestCase("0","zero dollars")]
        [TestCase("1", "one dollar")]
        [TestCase("25,1", "twenty-five dollars and ten cents")]
        [TestCase("0,01", "zero dollars and one cent")]
        [TestCase("45100", "forty-five thousand one hundred dollars")]
        [TestCase("999 999 999,99", "nine hundred ninety-nine million nine hundred ninety-nine thousand nine hundred ninety-nine dollars and ninety-nine cents")]
        [TestCase("001,00", "one dollar")]
        [TestCase("101,00", "one hundred one dollars")]
        public void GetCurrencyWordRepresentation_WhenGivenValidNumber_ThenReturnCurrencyWord(string input, string expectedOutput) {
            
            var result = currencyWorkflows.GetCurrencyWordRepresentation(input);
            
            Assert.That(result.Value, Is.EqualTo(expectedOutput));
        }


        [TestCase("Foobar")]
        [TestCase("00/99")]
        public void GetCurrencyWordRepresentation_WhenGivenInvalidNumber_ThenThrowInvalidNumberNotationError(string input) {

            Assert.That(()=> currencyWorkflows.GetCurrencyWordRepresentation(input), Throws.Exception.InstanceOf<InvalidNumberNotationError>());
        }


        [TestCase("0,9999")]
        [TestCase("9 999 999 999,99")]
        public void GetCurrencyWordRepresentation_WhenGivenInvalidNumber_ThenThrowInvalidRangeError(string input) {

            Assert.That(() => currencyWorkflows.GetCurrencyWordRepresentation(input), Throws.Exception.InstanceOf<InvalidRangeError>());
        }
    }
}
