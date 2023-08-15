using Domain.DomainTypes;
using Domain.DomainTypes.Primitives;
using Domain.Methods;

namespace Domain.Test.Methods;

[TestFixture]
public class CurrencyMethodsTest {

    [Test]
    public void OnCurrency_GetWordRepresentation_WhenCentPartIsZero_ThenReturnWordRepresentationWithoutCents() {
        var dollars = Currency.Of(CurrencyString.Of("1,00"));

        var result = dollars.GetWordRepresentation();
        Assert.That(result.Value, Is.EqualTo("one dollar"));
    }

    [Test]
    public void OnCurrency_GetWordRepresentation_WhenCentPartIsNotZero_ThenReturnWordRepresentationWithCents() {
        var dollars = Currency.Of(CurrencyString.Of("1,77"));

        var result = dollars.GetWordRepresentation();
        Assert.That(result.Value, Is.EqualTo("one dollar and seventy-seven cents"));
    }
}
