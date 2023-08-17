using Domain.DomainErrors;
using Domain.DomainTypes;
using Domain.Workflows;
using Microsoft.AspNetCore.Mvc;
using System.Net;
using static Domain.Methods.Primitives.FuncMethods;
namespace WebApplication1.Controllers;

/// <summary>
/// Controller clas for "/wordrepresentation" API endpoints
/// </summary>
[ApiController]
[Produces("application/json")]
[Route("/wordrepresentation")]
public class WordRepresentationController : ControllerBase {

    private readonly ILogger<WordRepresentationController> logger;
    private readonly CurrencyWorkflows currencyWorkflows;

    public WordRepresentationController(ILogger<WordRepresentationController> logger, CurrencyWorkflows currencyWorkflows) {
        this.logger = logger;
        this.currencyWorkflows = currencyWorkflows;
    }

    /// <summary>
    /// Enpoint method. Takes the currency string from the url and returns its word representation. If the string is not a valid currency, a badrequest is returned.
    /// </summary>
    [ProducesResponseType(typeof(CurrencyWordRepresentation), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(string), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
    [HttpGet("{number}", Name = "GetWordRepresentation")]
    public IActionResult GetWordRepresentation([FromRoute] string number) {
        try {
            var result = currencyWorkflows.GetCurrencyWordRepresentation(number);
            return Ok(result);
        }
        catch (Exception ex) {
            return ex switch {
                InvalidNumberNotationError => BadRequest(ex.Message),
                InvalidRangeError => BadRequest(ex.Message),
                _ => Call(() => {
                    logger.LogError(ex, $"Unknown Error has occured");
                    return StatusCode(StatusCodes.Status500InternalServerError, $"Unknown Error has occured");
                })
            };
        }
    }
}