using Domain.DomainErrors;
using Domain.DomainTypes.Primitives;

namespace Domain.Test.DomainTypes.Primitives;

[TestFixture]
public class UnsignedIntDec3Test {

    [TestCase("", 0, "0")]
    [TestCase("1", 1, "1")]
    [TestCase("432", 432, "432")]
    [TestCase("999", 999, "999")]
    public void Of_WhenValidIntegerString_ThenReturnNewUnsignedIntDec3(string input, int expectedIntValue, IEnumerable<char> expectedChars) {

        var result = UnsignedIntDec3.Of(UnsignedIntString.Of(input));
        
        Assert.That(result.IntValue, Is.EqualTo(expectedIntValue));
        Assert.That(result.Digits, Is.EquivalentTo(expectedChars));
    }

    [TestCase("1000")]
    [TestCase("2147483647")]
    public void Of_WhenIntegerStringSmallerThenZero_ThenThrowInvalidRangeError(string input) {

        Assert.That(() => UnsignedIntDec3.Of(UnsignedIntString.Of(input)), Throws.Exception.InstanceOf<InvalidRangeError>());
    }
}
