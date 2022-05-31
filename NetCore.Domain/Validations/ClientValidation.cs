using FluentValidation;
using NetCore.Domain.Models;

namespace NetCore.Domain.Validations;

public class ClientValidation : AbstractValidator<ClientModel>
{
    public ClientValidation()
    {
        RuleFor(x => x.Name)
            .NotNull()
            .NotEmpty()
            .Length(3, 100);

        RuleFor(x => x.Email)
            .NotNull()
            .NotEmpty()
            .EmailAddress(FluentValidation.Validators.EmailValidationMode.AspNetCoreCompatible)
            .Length(5, 150);

        RuleFor(x => x.PhoneNumber)
            .NotNull()
            .NotEmpty()
            .Length(11, 14);
    }
}