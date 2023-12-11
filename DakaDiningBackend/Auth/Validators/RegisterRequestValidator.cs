using DakaDiningBackend.Auth.Contracts.Requests;
using FastEndpoints;
using FluentValidation;

namespace DakaDiningBackend.Auth.Validators;

public class RegisterRequestValidator : Validator<RegisterRequest>
{
    public RegisterRequestValidator()
    {
        RuleFor(r => r.Password)
            .NotEmpty()
            .WithMessage("Password cannot be empty")
            .MinimumLength(6)
            .WithMessage("Password must be at least 6 characters long");

        RuleFor(r => r.Email)
            .NotEmpty()
            .WithMessage("Email address cannot be empty")
            .EmailAddress()
            .WithMessage("Invalid Email Address");

        RuleFor(r => r.FirstName)
            .NotEmpty()
            .WithMessage("First name cannot be empty");

        RuleFor(r => r.LastName)
            .NotEmpty()
            .WithMessage("Last name cannot be empty");

        RuleFor(r => r.MealSwipes)
            .LessThan(20)
            .WithMessage("Cannot create an account with more than 20 meal swipes");
    }
}
