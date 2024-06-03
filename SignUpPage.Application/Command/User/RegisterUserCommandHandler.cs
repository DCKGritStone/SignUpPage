using MediatR;
using Microsoft.AspNetCore.Identity;
using SignUpPage.Domain.Entities;

namespace SignUpPage.Application.Command.User
{
    public class RegisterUserCommandHandler : IRequestHandler<RegisterUserCommand, IdentityResult>
    {
        private readonly UserManager<ApplicationUser> userManager;

        public RegisterUserCommandHandler(UserManager<ApplicationUser> userManager)
        {
            this.userManager = userManager;
        }
        public async Task<IdentityResult> Handle(RegisterUserCommand request, CancellationToken cancellationToken)
        {
            var applicationUser = new ApplicationUser()
            {
                UserName = request.UserName,
                Email = request.Email,
                FullName = request.FullName
            };


            var result = await userManager.CreateAsync(applicationUser, request.Password);
            return result;

        }
    }
}
