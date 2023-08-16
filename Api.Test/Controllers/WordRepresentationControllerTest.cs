using Castle.Core.Logging;
using Domain.DomainErrors;
using Domain.DomainTypes;
using Domain.Workflows;
using FakeItEasy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using WebApplication1.Controllers;

namespace Api.Test.Controllers;

[TestFixture]
public class WordRepresentationControllerTest {

    private WordRepresentationController wordRepresentationController;

    [SetUp]
    public void SetUp() {
        var currenyWorkflows = new CurrencyWorkflows(A.Fake<ILogger<CurrencyWorkflows>>());
        wordRepresentationController = new WordRepresentationController(A.Fake<ILogger<WordRepresentationController>>(), currenyWorkflows);
    }

    [Test]
    public void GetWordRepresentation_WhenGivenValidString_ThenReturnWordRepresentation() {

        var result = wordRepresentationController.GetWordRepresentation("1234,56") as OkObjectResult;
        var resultValue = result!.Value as CurrencyWordRepresentation;

        Assert.That(resultValue, Is.Not.Null);
        Assert.That(resultValue.Value, Is.EqualTo("one thousand two hundred thirty-four dollars and fifty-six cents"));
    }

    [Test]
    public void GetWordRepresentation_WhenGivenInvalidNumberString_ThenThrowInvalidNumberNotationError() {

        var result = wordRepresentationController.GetWordRepresentation("1234-56") as BadRequestObjectResult;
        Assert.That(result, Is.Not.Null);
    }


    [Test]
    public void GetWordRepresentation_WhenGivenTooBigNumberString_ThenThrowInvalidRangeError() {

        var result = wordRepresentationController.GetWordRepresentation("1234,56789") as BadRequestObjectResult;
        Assert.That(result, Is.Not.Null);
    }
}
