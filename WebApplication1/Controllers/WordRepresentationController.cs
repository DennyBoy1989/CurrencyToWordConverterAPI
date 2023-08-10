using Domain.Workflows;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers {
    [ApiController]
    [Route("/wordrepresentation")]
    public class WordRepresentationController : ControllerBase {

        private readonly ILogger<WordRepresentationController> logger;
        private readonly CurrencyWorkflows currencyWorkflows;

        public WordRepresentationController(ILogger<WordRepresentationController> logger, CurrencyWorkflows currencyWorkflows) {
            this.logger = logger;
            this.currencyWorkflows = currencyWorkflows;
        }

        [HttpGet("{number}", Name = "GetWordRepresentation")]
        public IActionResult Get([FromRoute] string number) {
            try {
                var result = currencyWorkflows.GetCurrencyWordRepresentation(number);
                return Ok(result);
            }
            catch (Exception ex) {
                return ex switch {
                    //RequestedResourceNotFoundError => NotFound(ex.Message),
                    _ => Call(() => {
                        logger.LogError(ex, $"Unknown Error has occured");
                        return StatusCode(StatusCodes.Status500InternalServerError, $"Unknown Error has occured");
                    })
                };
            }
        }

        TRes Call<TRes>(Func<TRes> f) => f();
    }
}