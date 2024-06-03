using MediatR;
using Microsoft.AspNetCore.Identity;

namespace SignUpPage.Application.Command.User
{
    public class RegisterUserCommand : IRequest<IdentityResult>
    {
        public string? UserName { get; set; }
        public string? Email { get; set; }
        public string? Password { get; set; }
        public string? FullName { get; set; }
    }
}
