using Domain.DomainTypes;
using Domain.DomainTypes.Primitives;
using Domain.Methods;

namespace Domain.Test.Methods;

[TestFixture]
public class CentsMethodsTest {

    [TestCase("0", "zero cents")]
    [TestCase("20", "twenty cents")]
    [TestCase("99", "ninety-nine cents")]
    public void OnCents_GetWordRepresentation_WhenNotOne_ThenReturnValueWithSuffixCents(string input, string expectedWordRepresentation) {
        var cents = Cents.Of(UnsignedIntString.Of(input));

        var result = cents.GetWordRepresentation();
        Assert.That(result, Is.EqualTo(expectedWordRepresentation));
    }

    [Test]
    public void OnCents_GetWordRepresentation_WhenNotOne_ThenReturnValueWithSuffixCents() {
        var cents = Cents.Of(UnsignedIntString.Of("1"));

        var result = cents.GetWordRepresentation();
        Assert.That(result, Is.EqualTo("one cent"));
    }
}
