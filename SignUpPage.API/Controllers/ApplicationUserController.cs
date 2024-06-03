using MediatR;
using Microsoft.AspNetCore.Mvc;
using SignUpPage.Application.Command.User;

namespace SignUpPage.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApplicationUserController : ControllerBase
    {
        private readonly IMediator mediator;

        public ApplicationUserController(IMediator mediator)
        {
            this.mediator = mediator;
        }

        [HttpPost("Register")]

        public async Task<IActionResult> PostApplicationUser(RegisterUserCommand command)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = await mediator.Send(command);

            if
            (result.Succeeded)
            {
                return
                Ok(result);
            }

            return
            BadRequest(result.Errors);
        }
    }
}
