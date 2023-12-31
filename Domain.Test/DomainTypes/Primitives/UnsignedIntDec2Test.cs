﻿using Domain.DomainErrors;
using Domain.DomainTypes.Primitives;

namespace Domain.Test.DomainTypes.Primitives;

[TestFixture]
public class UnsignedIntDec2Test {

    [TestCase("", 0u, "0")]
    [TestCase("1", 1u, "1")]
    [TestCase("43", 43u, "43")]
    [TestCase("99", 99u, "99")]
    public void Of_WhenValidIntegerString_ThenReturnNewUnsignedIntDec2(string input, uint expectedIntValue, IEnumerable<char> expectedChars) {

        var result = UnsignedIntDec2.Of(UnsignedIntString.Of(input));
        
        Assert.That(result.IntValue, Is.EqualTo(expectedIntValue));
        Assert.That(result.Digits, Is.EquivalentTo(expectedChars));
    }

    [TestCase("100")]
    [TestCase("2147483647")]
    public void Of_WhenIntegerStringSmallerThenZero_ThenThrowInvalidRangeError(string input) {

        Assert.That(() => UnsignedIntDec2.Of(UnsignedIntString.Of(input)), Throws.Exception.InstanceOf<InvalidRangeError>());
    }
}
