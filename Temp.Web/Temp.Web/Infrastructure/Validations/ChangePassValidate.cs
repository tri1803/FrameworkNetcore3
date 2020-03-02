using FluentValidation;
using Temp.Common.Resources;
using Temp.Service.ViewModel;

namespace Temp.Web.Infrastructure.Validations
{
    /// <summary>
        /// validate form change password
        /// </summary>
    public class ChangePassValidate : AbstractValidator<ChangePassViewModel>
    {
        public ChangePassValidate() {
            RuleFor(s => s.UserName).NotNull()
                .WithMessage(MessageResource.NullPassword);

            RuleFor(reg => reg.Password).NotNull()
                  .WithMessage(MessageResource.NullPassword)
                   .MinimumLength(3)
                   .WithMessage(MessageResource.PasswordLength)
                   .MaximumLength(50);
            
            RuleFor(reg => reg.ConfirmPass).NotNull()
                    .WithMessage(MessageResource.NullPassword)                    
                    .Equal(reg => reg.Password).WithMessage(MessageResource.Compare);

            RuleFor(reg => reg.CurrentPass).NotNull()
                    .WithMessage(MessageResource.NullPassword);
        }
    }
}