using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StripeAPI.Contracts;
using StripeAPI.Models.Stripe;

namespace StripeAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StripeController : ControllerBase
    {
        private readonly IStripeAppService _stripeService;
        public StripeController(IStripeAppService stripeService)
        {
            _stripeService = stripeService;
        }

        [HttpPost("customer/add")]
        public async Task<ActionResult<StripeCustomer>> AddStripeCustomer([FromBody] AddStripeCustomer customer, CancellationToken ct)
        {
            StripeCustomer createdCustomer = await _stripeService.AddStripeCustomerAsync(customer, ct);
            return StatusCode(StatusCodes.Status200OK, createdCustomer);
        }
    }
}
