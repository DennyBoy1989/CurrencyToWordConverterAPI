using Domain.Methods.Primitives;

namespace Domain.Test.Methods.Primitives;

[TestFixture]
public class StringMethodsTest {

    [Test]
    public void OnString_RemoveWhitespace_WhenStringContainsSpaces_ThenReturnStringWithAllSpacesRemoved() {
        
        var result = "  12 34  5678 ".RemoveWhitespace();
        Assert.That(result, Is.EqualTo("12345678"));
    }

    [Test]
    public void OnString_RemoveWhitespace_WhenStringContainsLineBreaks_ThenReturnStringWithAllLineBreaksRemoved() {

        var result = "1234\n5678 ".RemoveWhitespace();
        Assert.That(result, Is.EqualTo("12345678"));
    }

    [Test]
    public void OnString_RemoveWhitespace_WhenStringContainsTabs_ThenStringWithAllTabsRemoved() {

        var result = "1234\t5678 ".RemoveWhitespace();
        Assert.That(result, Is.EqualTo("12345678"));
    }

    [Test]
    public void OnString_ConcatWithSequenceWhenNotEmpty_WhenStringIsNotEmpty_ThenReturnConcatenatedStrings() {

        var result = "1234".ConcatWithSequenceWhenNotEmpty("5678");
        Assert.That(result, Is.EqualTo("12345678"));
    }

    [Test]
    public void OnString_ConcatWithSequenceWhenNotEmpty_WhenStringIsEmpty_ThenReturnEmptyString() {

        var result = "".ConcatWithSequenceWhenNotEmpty("5678");
        Assert.That(result, Is.EqualTo(""));
    }

    [Test]
    public void OnString_ConcatWithSequenceWhenNotEmpty_WhenStringOnlyContainsWhiteSpaces_ThenReturnTheOriginalString() {

        var result = "  ".ConcatWithSequenceWhenNotEmpty("5678");
        Assert.That(result, Is.EqualTo("  "));
    }
}

