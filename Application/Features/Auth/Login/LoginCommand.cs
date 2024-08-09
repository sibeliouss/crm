using Domain.Entities;
using FluentValidation;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;

namespace Application.Features.Auth.Login;

public class LoginCommand : IRequest<AppUser>
{
   public LoginCommand(string userNameOrEmail, string password)
   {
      UserNameOrEmail = userNameOrEmail;
      Password = password;
   }

   public string UserNameOrEmail { get; set; }
   public string Password { get; set; } 
   
   public class LoginCommandHandler : IRequestHandler<LoginCommand, AppUser>
   {
      private readonly IValidator<LoginCommand> _validator;
      private readonly UserManager<AppUser> _userManager;

      public LoginCommandHandler(
         IValidator<LoginCommand> validator,
         UserManager<AppUser> userManager)
      {
         _validator = validator;
         _userManager = userManager;
      }

      public async Task<AppUser> Handle(LoginCommand command, CancellationToken cancellationToken)
      {
         await _validator.ValidateAndThrowAsync(command, cancellationToken);

         var appUser = await _userManager.Users
            .FirstOrDefaultAsync(p => p.UserName == command.UserNameOrEmail || p.Email == command.UserNameOrEmail, cancellationToken);

         if (appUser == null)
         {
            throw new Exception("Kullanıcı bulunamadı.");
         }

         var checkPassword = await _userManager.CheckPasswordAsync(appUser, command.Password);

         if (!checkPassword)
         {
            throw new Exception("Yanlış şifre.");
         }

         return appUser;
      }
   }
}